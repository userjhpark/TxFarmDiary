using DevExpress.Drawing.Printing;
using DevExpress.Pdf;
using DevExpress.XtraEditors;
using DevExpress.XtraPdfViewer.Bars;
using DevExpress.XtraPrinting;
using HxCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WIA;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace TxFarmDiaryAI.Win
{
    public partial class UbSacnToImageForm : UbBaseChildRibbonForm
    {
        public UbSacnToImageForm()
        {
            InitializeComponent();

            Load += OnForm_Load;
            Activated += (s, e) =>
            {
                if (this.IsStartUp == true)
                {
                    //SysEnv.ShowSelectRibbonMenuPage(rpChildImageToPDF);
                }
            };
            Shown += (s, e) =>
            {
                if (this.IsStartUp != true)
                {
                    //base.OnForm_Load(sender, evt);

                    this.SetRibbonSubMenuMergeStyle();
                    this.ApplyResourcesStrings();

                    this.LoadScannerDevices();

                    //SbUtils.ShowMeesageBoxMainForm?.rcMainMenu.SelectedPage = SbUtils.ShowMeesageBoxMainForm?.rcMainMenu.MergedPages.GetPageByName(rpChildImageToPDF.Name) ?? SbUtils.ShowMeesageBoxMainForm?.rcMainMenu.Pages[0];
                    this.HidePDFViewer();
                    SysEnv.ShowSelectRibbonMenuPage(rpChildImageToPDF);
                    this.IsStartUp = true;
                }
                
            };
            GotFocus += OnForm_GotFocus;

            repcbxScanners.ButtonClick += (s, e) =>
            {
                if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph && e.Button.Tag.ToStringEx().Equals("{{#REFRESH}}", StringComparison.CurrentCultureIgnoreCase))
                {
                    LoadScannerDevices();
                }
            };
            bbibtnCameraToPicture.ItemClick += (s, e) => { pictureEdit1.ShowTakePictureDialog(); };
            bbibtnScanToPicture.ItemClick += (s, e) =>
            {
                pictureEdit1.Image = null;
                if (beicbxScanners.EditValue.IsNullOrWhiteSpaceEx() == true)
                {
                    SbUtils.ShowMessageBox(SbUtils.GetLanguageResourceString(SbDefs._RESOURCEKEY_SCANNER_SELECT_PLEASE_) ?? "Please select a scanner. (스캐너를 선택해주세요.)", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                SbUtils.ShowWaitLoadingForm(this);
                try
                {
                    this.StatusBarEventCaption = SbUtils.GetLanguageResourceString(SbDefs._RESOURCEKEY_SCANNER_SELECT_CONN_) ?? "Connecting to scanner... (스캐너와 연결 중입니다...)";
                    Application.DoEvents(); // UI 갱신

                    if (beicbxScanners.EditValue is not TScannerDevice sel)
                    {
                        SbUtils.ShowMessageBox(SbUtils.GetLanguageResourceString(SbDefs._RESOURCEKEY_SCANNER_SELECT_PLEASE_) ?? "Please select a scanner. (스캐너를 선택해주세요.)", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (sel is not TScannerDevice selectedScanner)
                    {
                        SbUtils.ShowMessageBox(SbUtils.GetLanguageResourceString(SbDefs._RESOURCEKEY_SCANNER_SELECT_PLEASE_) ?? "Please select a scanner. (스캐너를 선택해주세요.)", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    bool isConnected = SbUtils.ConnectToScanner(selectedScanner);
                    if (isConnected == false)
                    {
                        this.StatusBarEventCaption = SbUtils.GetLanguageResourceString(SbDefs._RESOURCEKEY_SCANNER_SELECT_ERROR_) ?? "Unable to connect to the selected scanner. (선택된 스캐너에 연결할 수 없습니다.)";
                        SbUtils.ShowMessageBox(this.StatusBarEventCaption, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    Device device = GetScannerDevice(selectedScanner);
                    if (device == null)
                    {
                        this.StatusBarEventCaption = SbUtils.GetLanguageResourceString(SbDefs._RESOURCEKEY_SCANNER_SELECT_ERROR_) ?? "Unable to connect to the selected scanner. (선택된 스캐너에 연결할 수 없습니다.)";
                        SbUtils.ShowMessageBox(this.StatusBarEventCaption, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    this.StatusBarEventCaption = SbUtils.GetLanguageResourceString(SbDefs._RESOURCEKEY_SCANNER_SCAN_START_) ?? "Starting the scan... (스캔을 시작합니다...)";
                    Application.DoEvents(); // UI 갱신

                    Image image = SbUtils.GetImageFromScanDevice(device);
                    if (image == null)
                    {
                        this.StatusBarEventCaption = SbUtils.GetLanguageResourceString(SbDefs._RESOURCEKEY_SCANNER_SCAN_NOTFOUND_) ?? "Unable to import scanned image. (스캔된 이미지를 가져올 수 없습니다.)";
                        SbUtils.ShowMessageBox(this.StatusBarEventCaption, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        pictureEdit1.Image = image;
                        this.StatusBarEventCaption = SbUtils.GetLanguageResourceString(SbDefs._RESOURCEKEY_SCANNER_SCAN_SUCCESS_) ?? "Scan is complete. (스캔이 완료되었습니다.)";
                    }
                }
                catch (Exception ex)
                {
                    string strExMessage = $"[Scan Error] {ex.Message}";
                    Debug.WriteLine(strExMessage);

                    this.StatusBarEventCaption = strExMessage;
                    SbUtils.ShowMessageBox(strExMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    SbUtils.CloseWaitLoadingForm();
                }
            };
            bbibtnLoadToPicture.ItemClick += (s, e) =>
            {
                using OpenFileDialog openDlg = new OpenFileDialog();
                openDlg.Filter = "Image Files (*.bmp;*.gif;*.jpg;*.jpeg;*.png)|*.bmp;*.gif;*.jpg;*.jpeg;*.png|All Files (*.*)|*.*";
                openDlg.FilterIndex = 1;
                openDlg.RestoreDirectory = true;
                openDlg.Multiselect = false;
                var dlgResult = openDlg.ShowDialog();
                string strFileName = openDlg.FileName;
                if (dlgResult != DialogResult.OK || strFileName.IsNullOrWhiteSpaceEx() == true) { return; }

                if (HxFile.IsFileExists(strFileName) == false)
                {
                    SbUtils.ShowMessageBox(SbUtils.GetLanguageResourceString(SbDefs._RESOURCEKEY_FILE_NOTEXIST_) ?? "The specified file does not exist. (지정된 파일이 존재하지 않습니다.)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SbUtils.ShowWaitLoadingForm(this);
                try
                {

                    Image img = Image.FromFile(strFileName);
                    pictureEdit1.Image = img;
                }
                catch (Exception ex)
                {
                    string strExMessage = $"[Load Image Error] {ex.Message}";
                    Debug.WriteLine(strExMessage);
                    this.StatusBarEventCaption = strExMessage;
                    SbUtils.ShowMessageBox(strExMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    SbUtils.CloseWaitLoadingForm();
                }
            };
            bbibtnEditFromPicture.ItemClick += (s, e) =>
            {
                if (pictureEdit1.Image != null)
                {
                    pictureEdit1.ShowImageEditorDialog();
                }
                else
                {
                    SbUtils.ShowMessageBox(SbUtils.GetLanguageResourceString(SbDefs._RESOURCEKEY_IMAGE_EDIT_NOIMAGE_) ?? "There are no images to edit. (편집할 이미지가 없습니다.)", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };
            bbibtnClearFromPicture.ItemClick += (s, e) =>
            {
                if (pictureEdit1.Image != null)
                {
                    if (SbUtils.ShowMessageBox(SbUtils.GetLanguageResourceString(SbDefs._RESOURCEKEY_IMAGE_EDIT_QUESTION_) ?? "Are you sure you want to delete the image? (이미지를 삭제하시겠습니까?)", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        pictureEdit1.Image = null;
                    }
                }
                else
                {
                    SbUtils.ShowMessageBox(SbUtils.GetLanguageResourceString(SbDefs._RESOURCEKEY_IMAGE_DELETE_NOIMAGE_) ?? "There are no images to delete. (삭제할 이미지가 없습니다.)", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };
            bbibtnCopyFromPicture.ItemClick += (s, e) =>
            {
                if (pictureEdit1.Image != null)
                {
                    //Clipboard.SetImage(pictureEdit1.Image);
                    pictureEdit1.CopyImage();
                }
                else
                {
                    SbUtils.ShowMessageBox(SbUtils.GetLanguageResourceString(SbDefs._RESOURCEKEY_IMAGE_COPY_NOIMAGE_) ?? "There are no images to copy. (복사할 이미지가 없습니다.)", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };
            bbibtnCutFromPicture.ItemClick += (s, e) =>
            {
                if (pictureEdit1.Image != null)
                {
                    if (SbUtils.ShowMessageBox(SbUtils.GetLanguageResourceString(SbDefs._RESOURCEKEY_IMAGE_CUT_QUESTION_) ?? "Are you sure you want to cut the image? (이미지를 잘라내시겠습니까?)", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        /*
                        Clipboard.SetImage(pictureEdit1.Image);
                        pictureEdit1.Image = null;
                        */
                        pictureEdit1.CutImage();
                    }
                }
                else
                {
                    SbUtils.ShowMessageBox(SbUtils.GetLanguageResourceString(SbDefs._RESOURCEKEY_IMAGE_CUT_NOIMAGE_) ?? "There are no images to cut. (잘라낼 이미지가 없습니다.)", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };
            bbibtnPasteFromPicture.ItemClick += (s, e) =>
            {
                if (Clipboard.ContainsImage() == true)
                {
                    pictureEdit1.Image = Clipboard.GetImage();
                }
                else
                {
                    SbUtils.ShowMessageBox(SbUtils.GetLanguageResourceString(SbDefs._RESOURCEKEY_IMAGE_PASTE_NOIMAGE_) ?? "There are no images to paste. (붙여넣을 이미지가 없습니다.)", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };
            bbibtnSavePictureToImage.ItemClick += (s, e) =>
            {
                if (pictureEdit1.Image == null)
                {
                    SbUtils.ShowMessageBox(SbUtils.GetLanguageResourceString(SbDefs._RESOURCEKEY_IMAGE_SAVE_NOIMAGE_) ?? "There are no images to save. (저장할 이미지가 없습니다.)", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Image? img = pictureEdit1.Image;
                    if (img == null)
                    {
                        SbUtils.ShowMessageBox(SbUtils.GetLanguageResourceString(SbDefs._RESOURCEKEY_IMAGE_SAVE_NOIMAGE_) ?? "There are no images to save. (저장할 이미지가 없습니다.)", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    using SaveFileDialog saveDlg = new SaveFileDialog();
                    saveDlg.Filter = "Bitmap Files (*.bmp)|.bmp|Graphics Imterchange Format (*.gif)|*.gif|JPEG File Interchange Format (*.jpg)|*.jpg|Portable Network Graphics Format (*.png)|*.png";
                    saveDlg.FilterIndex = 3;
                    saveDlg.RestoreDirectory = true;
                    saveDlg.ShowDialog();

                    string strFileName = saveDlg.FileName;
                    if (strFileName.IsNullOrWhiteSpaceEx() == true) { return; }

                    string? strFileExt = HxFile.GetFileExt(strFileName)?.ToLower();
                    if (strFileExt.IsNullOrWhiteSpaceEx() == true)
                    {
                        SbUtils.ShowMessageBox(SbUtils.GetLanguageResourceString(SbDefs._RESOURCEKEY_IMAGE_SAVE_NOFILEEXT_) ?? "There are no images to save. (저장할 이미지가 없습니다.)", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else if (strFileExt == "bmp")
                    {
                        img.Save(strFileName, System.Drawing.Imaging.ImageFormat.Bmp);
                    }
                    else if (strFileExt == "gif")
                    {
                        img.Save(strFileName, System.Drawing.Imaging.ImageFormat.Gif);
                    }
                    else if (strFileExt == "jpg")
                    {
                        img.Save(strFileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    else if (strFileExt == "png")
                    {
                        img.Save(strFileName, System.Drawing.Imaging.ImageFormat.Png);
                    }
                    else
                    {
                        SbUtils.ShowMessageBox(SbUtils.GetLanguageResourceString(SbDefs._RESOURCEKEY_SAVE_FILEEXT_NOTSUPPORT_) ?? "Unsupported file extension. (지원되지 않는 파일 확장자 입니다.)", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            };

            /*
            bbibtnSaveAsImageToPDF.ItemClick += (s, e) => 
            {
                Image? img = pictureEdit1.Image;
                if (img == null)
                {
                    SbUtils.ShowMeesageBox(SbUtils.GetLanguageResourceString(SbDefs._RESOURCEKEY_IMAGE_SAVE_NOIMAGE_) ?? "There are no images to save. (저장할 이미지가 없습니다.)", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    byte[] imageData;
                    using (var ms = new MemoryStream())
                    {
                        img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        imageData = ms.ToArray();
                        ms.Position = 0;
                        pdfViewer1.LoadDocument(ms as Stream);
                    }
                    PrintingSystem ps = new PrintingSystem();
                    PrintableComponentLink link = new PrintableComponentLink(ps);
                    PictureBox pic = new PictureBox();// { Image = img, SizeMode = PictureBoxSizeMode.Zoom };
                    pic.Image = img;
                    pic.SizeMode = PictureBoxSizeMode.Zoom;
                    link.Component = (IBasePrintable)pic;
                    link.Landscape = img.Width > img.Height;
                    link.Margins = new System.Drawing.Printing.Margins(50, 50, 50, 50);
                    link.CreateDocument();

                    using SaveFileDialog saveDlg = new SaveFileDialog();
                    saveDlg.Filter = "PDF Files (*.pdf)|*.pdf";
                    saveDlg.FilterIndex = 1;
                    saveDlg.RestoreDirectory = true;
                    saveDlg.ShowDialog();
                    string strFileName = saveDlg.FileName;
                    if (strFileName.IsNullOrWhiteSpaceEx() == true) { return; }
                    link.PrintingSystem.ExportToPdf(strFileName);
                }
            };
            */

            bbibtnSavePictureToPDF.ItemClick += (s, e) =>
            {
                Image? img = pictureEdit1.Image;
                if (img == null)
                {
                    SbUtils.ShowMessageBox(SbUtils.GetLanguageResourceString(SbDefs._RESOURCEKEY_IMAGE_SAVE_NOIMAGE_) ?? "There are no images to save. (저장할 이미지가 없습니다.)", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    SbUtils.ShowWaitLoadingForm(this);
                    try
                    {
                    /*
                    byte[] imageData;
                    using (var ms = new MemoryStream())
                    {
                        img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        imageData = ms.ToArray();
                        ms.Position = 0;
                        pdfViewer1.LoadDocument(ms as Stream);
                    }
                    */

                    // Create a report

                    scCtlBody.Panel2.Controls.Clear();
                    //splitContainerControl1.Panel2.Controls.Add(report);

                    using DevExpress.XtraReports.UI.XtraReport report = new DevExpress.XtraReports.UI.XtraReport();
                    report.BeginInit();

                    report.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
                    report.Name = "ScanToImage";
                    report.TextAlignment = TextAlignment.TopLeft;
                    report.DataSource = null;
                    report.DataMember = null;
                    report.ShowPrintMarginsWarning = false;
                    report.ShowPrintStatusDialog = false;
                    report.HorizontalContentSplitting = HorizontalContentSplitting.Exact;
                    report.VerticalContentSplitting = VerticalContentSplitting.Exact;
                    report.Dpi = 600F;//report.Dpi = 100F;
                    report.Padding = new PaddingInfo(0, 0, 0, 0, report.Dpi); //report.Padding = new PaddingInfo(0, 0, 0, 0, 100F); 
                    //report.TextFormatString = "{0}";
                    report.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    report.ForeColor = Color.Black;
                    report.BorderColor = Color.Black;
                    //report.BorderWidth = 1F;
                    report.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
                    report.CanShrink = true;
                    report.CanGrow = true;
                    report.PaperKind = DXPaperKind.A4;
                    report.Landscape = img.Width > img.Height;
                    //report.Width = img.Width;
                    //report.Height = img.Height;

                    report.EndInit();

                    // Create picture box and set its properties
                    var pictureBox = new DevExpress.XtraReports.UI.XRPictureBox
                    {
                        Image = img,
                        Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage,
                        LocationF = new DevExpress.Utils.PointFloat(0, 0),
                        Width = (int)(report.PageWidth - report.Margins.Left - report.Margins.Right),
                        Height = (int)(report.PageHeight - report.Margins.Top - report.Margins.Bottom)
                        //Width = report.PageWidth,
                        //Height = report.PageHeight
                    };

                    // Clear existing bands
                    report.Bands.Clear();
                    /*
                    //report.Bands.Add(new DevExpress.XtraReports.UI.TopMarginBand { HeightF = report.Margins.Top });
                    report.Bands.Add(new DevExpress.XtraReports.UI.TopMarginBand { HeightF = report.Margins.Top });
                    //report.Bands.Add(new DevExpress.XtraReports.UI.BottomMarginBand { HeightF = report.Margins.Bottom });
                    report.Bands.Add(new DevExpress.XtraReports.UI.BottomMarginBand { HeightF = 0F });
                    report.Bands.Add(new DevExpress.XtraReports.UI.ReportHeaderBand { HeightF = 0F });
                    report.Bands.Add(new DevExpress.XtraReports.UI.ReportFooterBand { HeightF = 0F });
                    report.Bands.Add(new DevExpress.XtraReports.UI.PageHeaderBand { HeightF = 0F });
                    report.Bands.Add(new DevExpress.XtraReports.UI.PageFooterBand { HeightF = 0F });
                    //report.Bands.Add(new DevExpress.XtraReports.UI.DetailBand { HeightF = pictureBox.HeightF });
                    */

                    // Add the picture box to the report
                    report.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
                        new DevExpress.XtraReports.UI.DetailBand { Controls = { pictureBox } }
                    });


                    using SaveFileDialog saveDlg = new SaveFileDialog();
                    saveDlg.Filter = "PDF Files (*.pdf)|*.pdf";
                    saveDlg.FilterIndex = 1;
                    saveDlg.RestoreDirectory = true;
                    if (saveDlg.ShowDialog() != DialogResult.OK) return;

                    string strFileName = saveDlg.FileName;
                    if (strFileName.IsNullOrWhiteSpaceEx() == true) return;

                    try
                    {
                        pdfViewer1.CloseDocument();

                        // Export to PDF
                        report.ExportToPdf(strFileName);

                        if (HxFile.IsFileExists(strFileName))
                        {
                            ShowPDFViewer(strFileName);
                            this.StatusBarEventCaption = "PDF file created successfully. (PDF 파일이 성공적으로 생성되었습니다.)";
                        }
                        else
                            {
                                SbUtils.ShowMessageBox("PDF file creation failed. (PDF 파일 생성에 실패했습니다.)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    catch (Exception ex)
                    {
                        string strExMessage = $"[Export to PDF Error] {ex.Message}";
                        Debug.WriteLine(strExMessage);
                        this.StatusBarEventCaption = strExMessage;
                        SbUtils.ShowMessageBox(strExMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //throw;
                    }
                    finally
                    {
                        report.StopPageBuilding();
                    }

                        /*
                        var ps = new DevExpress.XtraPrinting.PrintingSystem();
                        var link = new DevExpress.XtraPrinting.PrintableComponentLink(ps);

                        // PictureEdit 컨트롤을 생성하여 이미지 할당
                        var printablePictureEdit = new DevExpress.XtraEditors.PictureEdit();
                        printablePictureEdit.Image = img;
                        printablePictureEdit.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;

                        link.Component = (DevExpress.XtraPrinting.IBasePrintable) printablePictureEdit;

                        link.Landscape = img.Width > img.Height;
                        link.Margins = new System.Drawing.Printing.Margins(50, 50, 50, 50);
                        link.CreateDocument();

                        using SaveFileDialog saveDlg = new SaveFileDialog();
                        saveDlg.Filter = "PDF Files (*.pdf)|*.pdf";
                        saveDlg.FilterIndex = 1;
                        saveDlg.RestoreDirectory = true;
                        saveDlg.ShowDialog();
                        string strFileName = saveDlg.FileName;
                        if (strFileName.IsNullOrWhiteSpaceEx() == true) { return; }
                        link.PrintingSystem.ExportToPdf(strFileName);
                        */
                    }
                    catch (Exception exExport)
                    {
                        string strExMessage = $"[Export to PDF Error] {exExport.Message}";
                        Debug.WriteLine(strExMessage);
                        this.StatusBarEventCaption = strExMessage;
                        SbUtils.ShowMessageBox(strExMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //throw;
                    }
                    finally
                    {
                        SbUtils.CloseWaitLoadingForm();
                    }
                }
            };

            pdfFileCloseBarItem1.ItemClick += (s, e) =>
            {
                //pdfViewer1.CloseDocument();
                this.HidePDFViewer();
            };
        }

        

        private void OnForm_GotFocus(object? sender, EventArgs e)
        {
            
        }



        private static Device GetScannerDevice(TScannerDevice selectedScanner)
        {
            var deviceManager = new DeviceManager();
            Device device = null;

            foreach (DeviceInfo info in deviceManager.DeviceInfos)
            {
                if (info.DeviceID == selectedScanner.DeviceID)
                {
                    device = info.Connect();
                    break;
                }
            }

            return device;
        }

        private void OnForm_Load(object? sender, EventArgs evt)
        {
            scCtlBody.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            scCtlBody.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel2;
            //scBody.SplitterPosition = this.Height / 2;
            scCtlBody.Panel2.Width = this.Height / 4;
            bbibtnScanToPicture.Enabled = false;
            //bbibtnScan.Appearance.BackColor = Color.Orange;
            //bbibtnScan.Appearance.Options.UseBackColor = true;
            //bbibtnScan.Appearance Hovered.BackColor = Color.OrangeRed;
            //bbibtnScan.AppearanceHovered.Options.UseBackColor = true;
            repcbxScanners.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            #region Grid Control/View/Column Settings
            grdvFileList.OptionsBehavior.Editable = false;
            grdvFileList.OptionsSelection.MultiSelect = true;
            grdvFileList.OptionsView.ShowIndicator = true;
            grdvFileList.OptionsView.ShowAutoFilterRow = false;
            //grdvFileList.OptionsView.ColumnAutoWidth = false;
            grdvFileList.OptionsView.RowAutoHeight = true;
            grdvFileList.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            grdvFileList.OptionsView.ShowFooter = false;
            grdvFileList.OptionsView.ShowGroupPanel = false;
            grdvFileList.OptionsPrint.AutoWidth = false;
            grdvFileList.OptionsPrint.PrintFooter = false;
            grdvFileList.OptionsPrint.PrintGroupFooter = false;
            grdvFileList.OptionsPrint.UsePrintStyles = true;
            grdvFileList.Appearance.HeaderPanel.BackColor = Color.LightGray;
            grdvFileList.Appearance.HeaderPanel.BackColor2 = Color.LightGray;
            grdvFileList.Appearance.HeaderPanel.BorderColor = Color.Silver;
            grdvFileList.Appearance.HeaderPanel.Options.UseBackColor = true;
            grdvFileList.Appearance.HeaderPanel.Options.UseBorderColor = true;
            grdvFileList.Appearance.HeaderPanel.ForeColor = Color.Black;
            grdvFileList.Appearance.HeaderPanel.Options.UseForeColor = true;
            grdvFileList.Appearance.HeaderPanel.Font = new Font(grdvFileList.Appearance.HeaderPanel.Font, FontStyle.Bold);
            grdvFileList.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdvFileList.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            grdvFileList.Appearance.HeaderPanel.Options.UseTextOptions = true;
            grdvFileList.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            grdvFileList.Appearance.Row.Options.UseTextOptions = true;

            gcImageGridNo.Width = 30;
            gcImageGridNo.MinWidth = 30;
            gcImageGridNo.MaxWidth = 30;
            gcImageGridNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcImageGridNo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            gcImageGridNo.AppearanceCell.Options.UseTextOptions = true;

            gcImageGridFileSize.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            gcImageGridFileSize.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            gcImageGridFileSize.AppearanceCell.Options.UseTextOptions = true;

            gcImageGridFilePath.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            gcImageGridFilePath.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            gcImageGridFilePath.AppearanceCell.Options.UseTextOptions = true;
            #endregion //Grid Control/View/Column Settings

            #region Picture / PDF Viewer Settings
            bbibtnSavePictureToPDF.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            pdfFileOpenBarItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            #endregion //Picture / PDF Viewer Settings
#if DEBUG
            bbibtnSavePictureToPDF.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
            pdfFileOpenBarItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
#endif


        }

        override protected void ApplyResourcesStrings(string? cultureName = null)
        {
            base.ApplyResourcesStrings(cultureName);

            SysEnv.DoLocalizedUpdateFormChildAllConrolTagMatchToText(this);

        }

        /// <summary>
        /// 시스템에 연결된 스캐너 장치를 찾아 콤보박스에 추가
        /// </summary>
        private void LoadScannerDevices()
        {
            this.StatusBarEventCaption = SbUtils.GetLanguageResourceString(SbDefs._RESOURCEKEY_SCANNER_FIND_FINDING_) ?? "Searching for scanner device... (스캐너 장치를 검색 중입니다...)";
            Application.DoEvents(); // UI 갱신
            try
            {
                List<TScannerDevice>? dictDevices = SbUtils.GetScannerDevices();
                if (dictDevices != null && dictDevices.Count > 0)
                {
                    repcbxScanners.Items.Clear();
                    foreach (var item in dictDevices)
                    {
                        repcbxScanners.Items.Add(item);
                        //cbxScanners.Properties.displaytext
                    }
                    //beicbxScanners..SelectedIndex = 0;
                }

                if (repcbxScanners.Items.Count > 0)
                {
                    bbibtnScanToPicture.Enabled = true;
                    string strFindText = repcbxScanners.Items.Count + " " + SbUtils.GetLanguageResourceString(SbDefs._RESOURCEKEY_SCANNER_FIND_SUCCESS_) ?? " Found Scanners.(개의 스캐너를 찾았습니다.)";
                    this.StatusBarEventCaption = strFindText;
                }
                else
                {
                    bbibtnScanToPicture.Enabled = false;
                    this.StatusBarEventCaption = SbUtils.GetLanguageResourceString(SbDefs._RESOURCEKEY_SCANNER_FIND_ERROR_) ?? "No connected scanner found. (연결된 스캐너를 찾을 수 없습니다.)";
                    SbUtils.ShowMessageBox(this.StatusBarEventCaption, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                beicbxScanners.EditValue = null;
            }
            catch (Exception ex)
            {
                bbibtnScanToPicture.Enabled = false;
                this.StatusBarEventCaption = SbUtils.GetLanguageResourceString(SbDefs._RESOURCEKEY_SCANNER_FIND_ERROR_) ?? "An error occurred while searching for the scanner. (스캐너 검색 중 오류가 발생했습니다.)";
                SbUtils.ShowMessageBox($"{this.StatusBarEventCaption}\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private string StatusBarEventCaption
        {
            get { return GetStatusBarEventCaption(); }
            set { SetStatusBarEventCaption(value); }
        }

        private void SetStatusBarEventCaption(string message)
        {
            barsiChildEventStatus.Caption = message;
            Application.DoEvents(); // UI 갱신
        }
        private string GetStatusBarEventCaption()
        {
            return barsiChildEventStatus.Caption;
        }

        private string StatusBarFileGridCaption
        {
            get { return GetStatusBarEventCaption(); }
            set { SetStatusBarEventCaption(value); }
        }

        private void SetStatusBarFileGridCaption(string message)
        {
            barsiChildImageListStatus.Caption = message;
            Application.DoEvents(); // UI 갱신
        }
        private string GetStatusBarFileGridCaption()
        {
            return barsiChildImageListStatus.Caption;
        }

        private void pdfViewer1_Load(object sender, EventArgs e)
        {

        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void ShowPDFViewer(string fileName)
        {
            if (btsichkOptions_OpenPdfViewerInNewWindow.Checked != true)
            {
                rpChildPdfViewer.Visible = true;
                tpPdfViewer.PageVisible = true;
                tpPdfViewer.Show();
                if (fileName.IsNullOrWhiteSpaceEx() == false && HxFile.IsFileExists(fileName) == true)
                {
                    pdfViewer1.LoadDocument(fileName);
                    pdfViewer1.ZoomMode = DevExpress.XtraPdfViewer.PdfZoomMode.FitToVisible;
                }
                SysEnv.ShowSelectRibbonMenuPage(rpChildPdfViewer);
            }
            else
            {
                UbPDFViewerRibbonForm pdfForm = new UbPDFViewerRibbonForm(fileName)
                {
                    StartPosition = FormStartPosition.CenterParent,
                    Owner = SysEnv.MainForm,
                    MdiParent = SysEnv.MainForm,
                };
                //pdfForm.BringToFront();
                //pdfForm.TopMost = true;
                pdfForm.SetDisplayTitleFullName(false);
                pdfForm.Show();
                pdfForm.Focus();
                //SysEnv.ShowSelectRibbonMenuPageByName("PDF Viewer", false);
            }
        }
        private void HidePDFViewer()
        {
            if(btsichkOptions_OpenPdfViewerInNewWindow.Checked != true)
            {
                SysEnv.ShowSelectRibbonMenuPage(rpChildImageToPDF);
                pdfViewer1.CloseDocument();
                tpPicture.Show();
                tpPdfViewer.Hide();
                tpPdfViewer.PageVisible = false;
                rpChildPdfViewer.Visible = false;
            }
            
        }
    }
}
