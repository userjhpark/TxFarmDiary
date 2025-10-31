using Amazon.Runtime.Internal.Transform;
using DevExpress.CodeParser.CodeStyle.Formatting;
using DevExpress.Drawing.Printing;
using DevExpress.Pdf;
using DevExpress.Utils;
using DevExpress.Utils.Extensions;
using DevExpress.XtraDiagram.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraPdfViewer.Bars;
using DevExpress.XtraPrinting;
using HxCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Exchange.WebServices.Data;
using NAPS2.Wia;
using Org.BouncyCastle.Utilities.Encoders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Interop;
using WIA;

using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

using Utils = TxFarmDiaryAI.Win.SbUtils;

namespace TxFarmDiaryAI.Win
{
    public partial class UbImageCartForm : UbBaseChildRibbonForm
    {
        private int fImageCartIndex = 0;
        internal BindingList<TImageCartItem> CartImageList { get; private set; } = new BindingList<TImageCartItem>();

        internal TImageCartItem? CartImageSingleSelectItem => GetSingleSelectedImageCartItem();
        internal TImageCartItem[]? CartImageMultiCheckedItem => GetMultiCheckedImageCartItem();

        public UbImageCartForm()
        {
            InitializeComponent();

            Load += OnForm_Load;
            Activated += (s, e) =>
            {
                if (this.IsStartUp == true)
                {
                    //SysEnv.ShowSelectRibbonMenuPage(rpChildScanToImage);
                    //SysEnv.ShowSelectRibbonMenuPageByText(rpChildScanToImage.Text);
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
                    //SysEnv.ShowSelectRibbonMenuPage(rpChildScanToImage);



                    SQL_TXFD_SITE_SET_Table? rec = SysEnv.CurrWorksapceRecord;
                    if (rec != null)
                    {
                        Debug.WriteLine(rec.SNO);
                    }
                    this.IsStartUp = true;
                }
                ShowSelectChildRibbonMenuPageByText(rpChildImageToOCR);
            };
            GotFocus += OnForm_GotFocus;

            repcbxScanners.ButtonClick += (s, e) =>
            {
                if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph && e.Button.Tag.ToStringEx().Equals("{{#REFRESH}}", StringComparison.CurrentCultureIgnoreCase))
                {
                    LoadScannerDevices();
                }
            };
            bbibtnCameraToPicture.ItemClick += (s, e) => { picViewer.ShowTakePictureDialog(); };
            bbibtnScanToPicture.ItemClick += (s, e) =>
            {   //Picture To File > Save To Image
                picViewer.Image = null;
                if (beicbxScanners.EditValue.IsNullOrWhiteSpaceEx() == true)
                {
                    this.ShowMessageBox(Utils.GetLanguageResourceString(Defs._RESOURCEKEY_SCANNER_SELECT_PLEASE_) ?? "Please select a scanner. (스캐너를 선택해주세요.)", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                SbUtils.ShowWaitLoadingForm(this);
                try
                {
                    this.StatusBarEventCaption = Utils.GetLanguageResourceString(Defs._RESOURCEKEY_SCANNER_SELECT_CONN_) ?? "Connecting to scanner... (스캐너와 연결 중입니다...)";
                    Application.DoEvents(); // UI 갱신

                    if (beicbxScanners.EditValue is not SbScannerDevice sel)
                    {
                        this.ShowMessageBox(Utils.GetLanguageResourceString(Defs._RESOURCEKEY_SCANNER_SELECT_PLEASE_) ?? "Please select a scanner. (스캐너를 선택해주세요.)", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (sel is not SbScannerDevice selectedScanner)
                    {
                        this.ShowMessageBox(Utils.GetLanguageResourceString(Defs._RESOURCEKEY_SCANNER_SELECT_PLEASE_) ?? "Please select a scanner. (스캐너를 선택해주세요.)", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    bool isConnected = Utils.ConnectToScannerComWIA(selectedScanner);
                    if (isConnected == false)
                    {
                        this.StatusBarEventCaption = Utils.GetLanguageResourceString(Defs._RESOURCEKEY_SCANNER_SELECT_ERROR_) ?? "Unable to connect to the selected scanner. (선택된 스캐너에 연결할 수 없습니다.)";
                        this.ShowMessageBox(this.StatusBarEventCaption, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    Device device = GetScannerDevice(selectedScanner);
                    if (device == null)
                    {
                        this.StatusBarEventCaption = Utils.GetLanguageResourceString(Defs._RESOURCEKEY_SCANNER_SELECT_ERROR_) ?? "Unable to connect to the selected scanner. (선택된 스캐너에 연결할 수 없습니다.)";
                        this.ShowMessageBox(this.StatusBarEventCaption, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    this.StatusBarEventCaption = Utils.GetLanguageResourceString(Defs._RESOURCEKEY_SCANNER_SCAN_START_) ?? "Starting the scan... (스캔을 시작합니다...)";
                    Application.DoEvents(); // UI 갱신

                    Image image = Utils.GetImageFromScanDevice(device);
                    if (image == null)
                    {
                        this.StatusBarEventCaption = Utils.GetLanguageResourceString(Defs._RESOURCEKEY_SCANNER_SCAN_NOTFOUND_) ?? "Unable to import scanned image. (스캔된 이미지를 가져올 수 없습니다.)";
                        this.ShowMessageBox(this.StatusBarEventCaption, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        picViewer.Image = image;
                        this.StatusBarEventCaption = Utils.GetLanguageResourceString(Defs._RESOURCEKEY_SCANNER_SCAN_SUCCESS_) ?? "Scan is complete. (스캔이 완료되었습니다.)";
                    }
                }
                catch (Exception ex)
                {
                    string strExMessage = $"[Scan Error] {ex.Message}";
                    Debug.WriteLine(strExMessage);

                    this.StatusBarEventCaption = strExMessage;
                    this.ShowMessageBox(strExMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    SbUtils.CloseWaitLoadingForm();
                }
            };
            bbibtnLoadToPicture.ItemClick += (s, e) =>
            {   //[Source] Scan / Camera / Picture > Load
                using OpenFileDialog openDlg = new OpenFileDialog();
                //openDlg.Filter = "Image Files (*.bmp;*.gif;*.jpg;*.jpeg;*.png)|*.bmp;*.gif;*.jpg;*.jpeg;*.png|All Files (*.*)|*.*";
                //openDlg.Filter = "Image Files (*.bmp;*.gif;*.jpg;*.jpeg;*.png)|*.bmp;*.gif;*.jpg;*.jpeg;*.png";
                openDlg.Filter = "Bitmap Files (*.bmp)|.bmp|Graphics Imterchange Format (*.gif)|*.gif|JPEG File Interchange Format (*.jpg)|*.jpg|Portable Network Graphics Format (*.png)|*.png|Image Files (*.bmp;*.gif;*.jpg;*.jpeg;*.png)|*.bmp;*.gif;*.jpg;*.jpeg;*.png";
                openDlg.FilterIndex = 5;
                openDlg.RestoreDirectory = true;
                openDlg.Multiselect = false;
                var dlgResult = openDlg.ShowDialog();
                string strFileName = openDlg.FileName;
                if (dlgResult != DialogResult.OK || strFileName.IsNullOrWhiteSpaceEx() == true) { return; }

                if (HxFile.IsFileExists(strFileName) == false)
                {
                    this.ShowMessageBox(Utils.GetLanguageResourceString(Defs._RESOURCEKEY_FILE_NOTEXIST_) ?? "The specified file does not exist. (지정된 파일이 존재하지 않습니다.)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SbUtils.ShowWaitLoadingForm(this);
                try
                {

                    Image img = Image.FromFile(strFileName);
                    picViewer.Image = img;
                }
                catch (Exception ex)
                {
                    string strExMessage = $"[Load Image Error] {ex.Message}";
                    Debug.WriteLine(strExMessage);
                    this.StatusBarEventCaption = strExMessage;
                    this.ShowMessageBox(strExMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    SbUtils.CloseWaitLoadingForm();
                }
            };
            bbibtnEditFromPicture.ItemClick += (s, e) =>
            {
                if (picViewer.Image != null)
                {
                    picViewer.ShowImageEditorDialog();
                }
                else
                {
                    this.ShowMessageBox(Utils.GetLanguageResourceString(Defs._RESOURCEKEY_IMAGE_EDIT_NOIMAGE_) ?? "There are no images to edit. (편집할 이미지가 없습니다.)", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };
            bbibtnClearFromPicture.ItemClick += (s, e) =>
            {
                if (picViewer.Image != null)
                {
                    if (this.ShowMessageBox(Utils.GetLanguageResourceString(Defs._RESOURCEKEY_IMAGE_EDIT_QUESTION_) ?? "Are you sure you want to delete the image? (이미지를 삭제하시겠습니까?)", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        picViewer.Image = null;
                    }
                }
                else
                {
                    this.ShowMessageBox(Utils.GetLanguageResourceString(Defs._RESOURCEKEY_IMAGE_DELETE_NOIMAGE_) ?? "There are no images to delete. (삭제할 이미지가 없습니다.)", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };
            bbibtnCopyFromPicture.ItemClick += (s, e) =>
            {
                if (picViewer.Image != null)
                {
                    //Clipboard.SetImage(pictureEdit1.Image);
                    picViewer.CopyImage();
                }
                else
                {
                    this.ShowMessageBox(Utils.GetLanguageResourceString(Defs._RESOURCEKEY_IMAGE_COPY_NOIMAGE_) ?? "There are no images to copy. (복사할 이미지가 없습니다.)", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };
            bbibtnCutFromPicture.ItemClick += (s, e) =>
            {
                if (picViewer.Image != null)
                {
                    if (this.ShowMessageBox(Utils.GetLanguageResourceString(Defs._RESOURCEKEY_IMAGE_CUT_QUESTION_) ?? "Are you sure you want to cut the image? (이미지를 잘라내시겠습니까?)", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        /*
                        Clipboard.SetImage(pictureEdit1.Image);
                        pictureEdit1.Image = null;
                        */
                        picViewer.CutImage();
                    }
                }
                else
                {
                    this.ShowMessageBox(Utils.GetLanguageResourceString(Defs._RESOURCEKEY_IMAGE_CUT_NOIMAGE_) ?? "There are no images to cut. (잘라낼 이미지가 없습니다.)", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };
            bbibtnPasteFromPicture.ItemClick += (s, e) =>
            {
                if (Clipboard.ContainsImage() == true)
                {
                    picViewer.Image = Clipboard.GetImage();
                }
                else
                {
                    this.ShowMessageBox(Utils.GetLanguageResourceString(Defs._RESOURCEKEY_IMAGE_PASTE_NOIMAGE_) ?? "There are no images to paste. (붙여넣을 이미지가 없습니다.)", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };
            bbibtnSavePictureToImage.ItemClick += (s, e) =>
            {
                if (picViewer.Image == null || picViewer.Visible != true || picViewer.Width <= 0 || picViewer.Height <= 0)
                {
                    this.ShowMessageBox(Utils.GetLanguageResourceString(Defs._RESOURCEKEY_IMAGE_SAVE_NOIMAGE_) ?? "There are no images to save. (저장할 이미지가 없습니다.)", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Image? img = picViewer.EditValue as Image;
                    if (img == null)
                    {
                        this.ShowMessageBox(Utils.GetLanguageResourceString(Defs._RESOURCEKEY_IMAGE_SAVE_NOIMAGE_) ?? "There are no images to save. (저장할 이미지가 없습니다.)", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        this.ShowMessageBox(Utils.GetLanguageResourceString(Defs._RESOURCEKEY_IMAGE_SAVE_NOFILEEXT_) ?? "There are no images to save. (저장할 이미지가 없습니다.)", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    /*
                    using Image copy = (Image)img.Clone();
                    using MemoryStream m = new MemoryStream();
                    copy.Save(stream: m, format: copy.RawFormat);
                    */

                    // Prompt the user to select a scanner
                    //using var device = deviceManager.PromptForDevice();


                    //Bitmap pic = new Bitmap((Image)img.Clone());
                    /*
                     * ImageCodecInfo encoder = new ImageCodecInfo {  };
                    //Imaging.EncoderParameters? encoderParams
                    img.Save(strFileName, encoder: encoder);
                    */
                    /*
                    PictureBox picbox = new()
                    {
                        Image = img as Bitmap
                    };
                    picViewer.Properties.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.Value;
                    picViewer.Properties.
                    Bitmap? pic = picbox.Image as Bitmap;
                    if (pic == null) { return; }

                    picViewer.Properties.
                    */

                    using Image pic = (Image)img.Clone();

                    if (strFileExt == "bmp")
                    {
                        pic.Save(strFileName, System.Drawing.Imaging.ImageFormat.Bmp);
                    }
                    else if (strFileExt == "gif")
                    {
                        pic.Save(strFileName, System.Drawing.Imaging.ImageFormat.Gif);
                    }
                    else if (strFileExt == "jpg")
                    {
                        pic.Save(strFileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        //img.Save(strFileName);
                    }
                    else if (strFileExt == "png")
                    {
                        pic.Save(strFileName, System.Drawing.Imaging.ImageFormat.Png);
                    }
                    else
                    {
                        this.ShowMessageBox(Utils.GetLanguageResourceString(Defs._RESOURCEKEY_SAVE_FILEEXT_NOTSUPPORT_) ?? "Unsupported file extension. (지원되지 않는 파일 확장자 입니다.)", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    SbUtils.ShowMeesageBox(SbUtils.GetLanguageResourceString(Defs._RESOURCEKEY_IMAGE_SAVE_NOIMAGE_) ?? "There are no images to save. (저장할 이미지가 없습니다.)", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                Image? img = picViewer.Image;
                if (img == null)
                {
                    this.ShowMessageBox(Utils.GetLanguageResourceString(Defs._RESOURCEKEY_IMAGE_SAVE_NOIMAGE_) ?? "There are no images to save. (저장할 이미지가 없습니다.)", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                        //scCtlBody.Panel2.Controls.Clear();
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
                            pdfViewer.CloseDocument();

                            // Export to PDF
                            report.ExportToPdf(strFileName);

                            if (HxFile.IsFileExists(strFileName))
                            {
                                ShowPDFViewer(strFileName);
                                this.StatusBarEventCaption = "PDF file created successfully. (PDF 파일이 성공적으로 생성되었습니다.)";
                            }
                            else
                            {
                                this.ShowMessageBox("PDF file creation failed. (PDF 파일 생성에 실패했습니다.)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            string strExMessage = $"[Export to PDF Error] {ex.Message}";
                            Debug.WriteLine(strExMessage);
                            this.StatusBarEventCaption = strExMessage;
                            this.ShowMessageBox(strExMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        this.ShowMessageBox(strExMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //throw;
                    }
                    finally
                    {
                        SbUtils.CloseWaitLoadingForm();
                    }
                }
            };

            bbibtnAppendPictureToCart.ItemClick += (s, e) =>
            {
                if (picViewer.Image == null)
                {
                    this.ShowMessageBox(Utils.GetLanguageResourceString(Defs._RESOURCEKEY_CART_APPEND_NOIMAGE_) ?? "There are no images to add to the cart. (장바구니에 추가할 이미지가 없습니다.)", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    //this.ShowMessageBox(strStatusMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SetAddImageToCart(picViewer.Image);
                    //SysEnv.ShowSelectRibbonMenuPage(SysEnv.ImageCartForm?.rpChildImageCart ?? SysEnv.MainForm?.rcMainMenu.Pages[0]);
                }
            };

            pdfFileCloseBarItem1.ItemClick += (s, e) =>
            {
                //pdfViewer1.CloseDocument();
                this.HidePDFViewer();
            };

            #region Image Cart Grid
            bbibtnPreview_FromCart.ItemClick += (s, e) =>
            {
                bool flowControl = LoadImageCartItemToViewer();
                if (!flowControl)
                {
                    return;
                }
            };
            bbibtnRemove_FromCart.ItemClick += (s, e) =>
            {
                bool flowControl = RemoveMultiCheckedByImageCart();
                if (!flowControl)
                {
                    return;
                }
            };
            bbibtnAppend_DiaryFromCart.ItemClick += (s, e) =>
            {
                if (this.CartImageSingleSelectItem == null || this.CartImageSingleSelectItem.ImageData == null || this.CartImageSingleSelectItem.ImageBytes == null || this.CartImageSingleSelectItem.ImageBytes.Length <= 0) { return; }

                UbFarmDiaryInputForm docForm = new(this.CartImageSingleSelectItem)
                {
                    Owner = this,
                    //MdiParent = SysEnv.MainForm,
                    StartPosition = FormStartPosition.CenterParent,
                };
                //pdfForm.BringToFront();
                //pdfForm.TopMost = true;
                //docForm.SetDisplayTitleFullName(false);
                docForm.Show();
                docForm.Focus();
            };

            #endregion
            grdcImageCart.DragDrop += (s, e) =>
            {
                object? dragData = e.Data?.GetData(DataFormats.FileDrop, false);
                if (s is GridControl cmp && dragData != null && dragData is string[] files && files.Length > 0)
                {
                    Utils.ShowWaitLoadingForm();
                    try
                    {
                        Dictionary<string, bool> okFiles = new();
                        Dictionary<string, string> badFiles = new();
                        foreach (string strFile in files)
                        {
                            if (strFile.IsNullOrWhiteSpaceEx() == true || HxFile.IsFileExists(strFile) != true)
                            {
                                badFiles.Add(strFile, Utils.GetLanguageResourceString(Defs._RESOURCEKEY_FILE_NOTEXIST_) ?? "The file does not exist. (파일이 존재하지 않습니다.)");
                                continue;
                            }
                            TImageCartItem item = new TImageCartItem(strFile);
                            if (item != null && item.ImageData != null && item.ImageBytes != null && item.ImageBytes.Length > 0)
                            {
                                bool bAddImage = SetAddImageToCart(item.ImageData, false, strFile);
                                okFiles.Add(strFile, bAddImage);
                                if (bAddImage == false)
                                {
                                    badFiles.Add(strFile, Utils.GetLanguageResourceString(Defs._RESOURCEKEY_CART_APPEND_WARRING_EXISTS_) ?? "The image is already in your cart. (이미 장바구니에 있는 이미지입니다.)");
                                }
                            }
                            else
                            {
                                Debug.WriteLine("ITEM을 생성하지 못함.");
                                badFiles.Add(strFile, Utils.GetLanguageResourceString(Defs._RESOURCEKEY_IMAGE_NOTSUPPORT_) ?? "Unsupported image file formats (미지원 이미지 파일 포멧)");
                            }
                        }
                        if (badFiles != null && badFiles.Count > 0)
                        {
                            string strBadMessage = Utils.GetLanguageResourceString(Defs._RESOURCEKEY_CART_APPEND_MISS_) ?? "This item could not be added to your cart. (File access and format errors)\n장바구니에 추가하지 못한 목록입니다.(파일 접근 및 형식 오류)";
                            strBadMessage += "\n";
                            foreach (var badFile in badFiles)
                            {
                                strBadMessage += $"\n - {badFile.Key}\n\t : {badFile.Value}";
                            }
                            this.ShowMessageBox(strBadMessage, icon: MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
                        //throw;
                    }
                    finally
                    {
                        Utils.CloseWaitLoadingForm();
                    }

                }
            };
            grdcImageCart.DragEnter += static (s, e) =>
            {
                if (e == null) { return; }

                if (e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            };
            grdvImageCart.DoubleClick += (s, e) =>
            {
                bool flowControl = LoadImageCartItemToViewer();
                if (!flowControl)
                {
                    return;
                }
            };
            grdvImageCart.KeyUp += (s, e) =>
            {
                if (s is DevExpress.XtraGrid.Views.Grid.GridView cmp && this.CartImageList != null && this.CartImageList.Count > 0 && e.KeyCode == Keys.Delete)
                {
                    bool flowControl = RemoveMultiCheckedByImageCart();
                    if (!flowControl)
                    {
                        return;
                    }
                }
                return;
            };

            tabCtlBody.SelectedPageChanged += (s, e) => DoTabPageSelected();
        }

        private void ShowSelectChildRibbonMenuPageByText(DevExpress.XtraBars.Ribbon.RibbonPage page)
        {
            SysEnv.ShowSelectRibbonMenuPageByText(page.Text, true);
        }

        private void DoTabPageSelected()
        {
            if (IsStartUp == true && tabCtlBody.TabPages.Count > 0 && tabCtlBody.SelectedTabPage != null)
            {
                if (tabCtlBody.SelectedTabPage == tpPdfViewer && tpPdfViewer.PageVisible == true)
                {
                    ShowSelectChildRibbonMenuPageByText(rpChildPdfViewer);
                }
                else if (tabCtlBody.SelectedTabPage == tpPicture && tpPicture.PageVisible == true)
                {
                    ShowSelectChildRibbonMenuPageByText(rpChildImageToOCR);
                }
            }
        }

        private void OnForm_GotFocus(object? sender, EventArgs e)
        {

        }



        private static Device GetScannerDevice(SbScannerDevice selectedScanner)
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

            #region Picture / PDF Viewer Settings
            picViewer.Properties.AllowZoom = DefaultBoolean.True;
            picViewer.Properties.ShowZoomSubMenu = DefaultBoolean.Default;
            picViewer.Properties.ShowScrollBars = true;
            picViewer.Properties.ShowMenu = true;
            bbibtnSavePictureToPDF.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            pdfFileOpenBarItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            #endregion //Picture / PDF Viewer Settings


            #region Grid Control/View/Column Settings


            grdvImageCart.OptionsBehavior.Editable = false;
            grdvImageCart.OptionsSelection.MultiSelect = false;
            grdvImageCart.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            grdvImageCart.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            grdvImageCart.OptionsView.ShowIndicator = true;
            grdvImageCart.OptionsView.ShowAutoFilterRow = false;
            //grdvFileList.OptionsView.ColumnAutoWidth = false;
            grdvImageCart.OptionsView.RowAutoHeight = true;
            grdvImageCart.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            grdvImageCart.OptionsView.ShowFooter = false;
            grdvImageCart.OptionsView.ShowGroupPanel = false;
            grdvImageCart.OptionsPrint.AutoWidth = false;
            grdvImageCart.OptionsPrint.PrintFooter = false;
            grdvImageCart.OptionsPrint.PrintGroupFooter = false;
            grdvImageCart.OptionsPrint.UsePrintStyles = true;
            grdvImageCart.Appearance.HeaderPanel.BackColor = Color.LightGray;
            grdvImageCart.Appearance.HeaderPanel.BackColor2 = Color.LightGray;
            grdvImageCart.Appearance.HeaderPanel.BorderColor = Color.Silver;
            grdvImageCart.Appearance.HeaderPanel.Options.UseBackColor = true;
            grdvImageCart.Appearance.HeaderPanel.Options.UseBorderColor = true;
            grdvImageCart.Appearance.HeaderPanel.ForeColor = Color.Black;
            grdvImageCart.Appearance.HeaderPanel.Options.UseForeColor = true;
            grdvImageCart.Appearance.HeaderPanel.Font = new Font(grdvImageCart.Appearance.HeaderPanel.Font, FontStyle.Bold);
            grdvImageCart.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdvImageCart.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            grdvImageCart.Appearance.HeaderPanel.Options.UseTextOptions = true;
            grdvImageCart.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            grdvImageCart.Appearance.Row.Options.UseTextOptions = true;

            gcImageGridNo.Width = 30;
            gcImageGridNo.MinWidth = 30;
            gcImageGridNo.MaxWidth = 30;
            gcImageGridNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcImageGridNo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            gcImageGridNo.AppearanceCell.Options.UseTextOptions = true;

            gcImageGridLoadDateTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcImageGridLoadDateTime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            gcImageGridLoadDateTime.AppearanceCell.Options.UseTextOptions = true;
            gcImageGridLoadDateTime.DisplayFormat.FormatType = FormatType.DateTime;
            gcImageGridLoadDateTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";

            gcImageGridFileSize.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            gcImageGridFileSize.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            gcImageGridFileSize.AppearanceCell.Options.UseTextOptions = true;
            gcImageGridFileSize.DisplayFormat.FormatType = FormatType.Numeric;
            gcImageGridFileSize.DisplayFormat.FormatString = "#,##0";

            gcImageGridFilePath.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            gcImageGridFilePath.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            gcImageGridFilePath.AppearanceCell.Options.UseTextOptions = true;
            #endregion //Grid Control/View/Column Settings

#if DEBUG
            bbibtnSavePictureToPDF.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
            pdfFileOpenBarItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
#endif
            grdcImageCart.AllowDrop = true; //Grid Drag & Drop 설정
            grdcImageCart.BindingContext = new System.Windows.Forms.BindingContext();
            grdcImageCart.DataSource = CartImageList;
        }

        private bool RemoveMultiCheckedByImageCart()
        {
            Cursor prevCursor = this.Cursor;
            Utils.ShowWaitLoadingForm(this);
            try
            {
                TImageCartItem[]? items = CartImageMultiCheckedItem;
                if (items == null || items.Length <= 0) { return false; }

                var dlg = this.ShowMessageBox(Utils.GetLanguageResourceString(Defs._RESOURCEKEY_CART_DELETE_QUESTION_) ?? "Do you want to delete the images in the selected cart? (선택된 장바구니의 이미지를 삭제하시겠습니까?)", icon: MessageBoxIcon.Question, buttons: MessageBoxButtons.YesNo, messageBoxDefaultButton: MessageBoxDefaultButton.Button2);
                if (dlg != DialogResult.Yes) { return false; }
                foreach (var item in items)
                {
                    CartImageList.Remove(item);
                }
                grdcImageCart.Refresh();
                Application.DoEvents();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                //throw;
            }
            finally
            {
                Utils.CloseWaitLoadingForm();
                this.Cursor = prevCursor;
            }
            return false;
        }

        private bool LoadImageCartItemToViewer()
        {
            Cursor prevCursor = this.Cursor;
            Utils.ShowWaitLoadingForm(this);
            try
            {
                TImageCartItem? item = CartImageSingleSelectItem;
                if (item == null || item.ImageData == null || item.ImageBytes == null || item.ImageBytes.Length < 0 || item.ImageData == picViewer.Image) { return false; }

                if (picViewer.Image != null)
                {
                    var dlg = this.ShowMessageBox(Utils.GetLanguageResourceString(Defs._RESOURCEKEY_PICTURE_LOADED_QUESTION_) ?? "There is an image loaded into the Picture object.\r\nWould you like to load  new one? \r\n(Picture 객체에 로드된 이미지가 있습니다. 새로 로드하시겠습니까?)", icon: MessageBoxIcon.Question, buttons: MessageBoxButtons.YesNo, messageBoxDefaultButton: MessageBoxDefaultButton.Button2);
                    if (dlg != DialogResult.Yes) { return false; }
                }
                picViewer.Image = item.ImageData;
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                //throw;
            }
            finally
            {
                Utils.CloseWaitLoadingForm();
                this.Cursor = prevCursor;
            }
            return false;
        }

        private TImageCartItem? GetSingleSelectedImageCartItem()
        {
            int rowHandle = grdvImageCart.FocusedRowHandle;
            if (rowHandle < 0) { return null; }

            if (grdvImageCart.GetFocusedRow() is not TImageCartItem Result || Result.Index < 0 || Result.ImageData == null || Result.FileSize <= 0) { return null; }

            return Result;
        }
        private TImageCartItem[]? GetMultiCheckedImageCartItem()
        {
            List<TImageCartItem> Result = new List<TImageCartItem>();
            DevExpress.XtraGrid.Views.Grid.GridView cmp = grdvImageCart;
            if (cmp != null && cmp.OptionsSelection.MultiSelect == true && cmp.SelectedRowsCount > 0)
            {
                int[] iSelectRows = cmp.GetSelectedRows();
                if (iSelectRows == null || iSelectRows.Length <= 0) return null;
                foreach (var iRowIndex in iSelectRows)
                {
                    if (cmp.GetRow(iRowIndex) is TImageCartItem item)
                    {
                        Result.Add(item);
                    }
                }
            }
            else if (this.CartImageSingleSelectItem != null)
            {
                Result.Add(CartImageSingleSelectItem);
            }
            return Result?.ToArray<TImageCartItem>();


            //cmp.OptionsBehavior

            //

        }

        override protected void ApplyResourcesStrings(string? cultureName = null)
        {
            base.ApplyResourcesStrings(cultureName);

            Utils.DoLocalizedUpdateFormChildAllConrolTagMatchToText(this);

        }

        /// <summary>
        /// 시스템에 연결된 스캐너 장치를 찾아 콤보박스에 추가
        /// </summary>
        private void LoadScannerDevices()
        {
            this.StatusBarEventCaption = Utils.GetLanguageResourceString(Defs._RESOURCEKEY_SCANNER_FIND_FINDING_) ?? "Searching for scanner device... (스캐너 장치를 검색 중입니다...)";
            Application.DoEvents(); // UI 갱신
            try
            {
                List<SbScannerDevice>? dictDevices = Utils.GetScannerComWIADevices();
                //List<ScannerDevice>? dictDevices = Utils.GetScannerNaps2WiaDevices();
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
                    string strFindText = repcbxScanners.Items.Count + " " + Utils.GetLanguageResourceString(Defs._RESOURCEKEY_SCANNER_FIND_SUCCESS_) ?? " Found Scanners.(개의 스캐너를 찾았습니다.)";
                    this.StatusBarEventCaption = strFindText;
                }
                else
                {
                    bbibtnScanToPicture.Enabled = false;
                    this.StatusBarEventCaption = Utils.GetLanguageResourceString(Defs._RESOURCEKEY_SCANNER_FIND_ERROR_) ?? "No connected scanner found. (연결된 스캐너를 찾을 수 없습니다.)";
                    this.ShowMessageBox(this.StatusBarEventCaption, MessageBoxIcon.Warning);
                }

                beicbxScanners.EditValue = null;
            }
            catch (Exception ex)
            {
                bbibtnScanToPicture.Enabled = false;
                this.StatusBarEventCaption = Utils.GetLanguageResourceString(Defs._RESOURCEKEY_SCANNER_FIND_ERROR_) ?? "An error occurred while searching for the scanner. (스캐너 검색 중 오류가 발생했습니다.)";
                this.ShowMessageBox($"{this.StatusBarEventCaption}\n{ex.Message}", MessageBoxIcon.Error);
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
                    pdfViewer.LoadDocument(fileName);
                    pdfViewer.ZoomMode = DevExpress.XtraPdfViewer.PdfZoomMode.FitToVisible;
                }
                ShowSelectChildRibbonMenuPageByText(rpChildPdfViewer);
            }
            else
            {
                UbPDFViewerRibbonForm pdfForm = new UbPDFViewerRibbonForm(fileName)
                {
                    StartPosition = FormStartPosition.CenterParent,
                    Owner = this,
                    //MdiParent = SysEnv.MainForm,
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
            //if (btsichkOptions_OpenPdfViewerInNewWindow.Checked != true)
            {
                ShowSelectChildRibbonMenuPageByText(rpChildImageToOCR);
                pdfViewer.CloseDocument();
                tpPicture.Show();
                tpPdfViewer.Hide();
                tpPdfViewer.PageVisible = false;
                rpChildPdfViewer.Visible = false;
            }

        }
        private bool SetAddImageToCart(Image image, bool isShowMeesageBox = true, string? name = null)
        {
            bool Result = false;

            if (image == null) return Result;

            string? strName = name.IsNullOrWhiteSpaceEx() != true ? "\n - " + name : null;

            if (image.Width == 0) return Result;
            if (image.Height == 0) return Result;
            if (image.Size == Size.Empty) return Result;
            if (image.Size.Width == 0) return Result;
            if (image.Size.Height == 0) return Result;
            if (image.Size.Width > 10000 || image.Size.Height > 10000)
            {
                if (isShowMeesageBox == true) this.ShowMessageBox(Utils.GetLanguageResourceString(Defs._RESOURCEKEY_IMAGE_SIZE_TOOLARGE_) ?? "The image size is too large. (이미지 크기가 너무 큽니다.)" + strName, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return Result;
            }
            if (image.Size.Width < 10 || image.Size.Height < 10)
            {
                if (isShowMeesageBox == true) this.ShowMessageBox(Utils.GetLanguageResourceString(Defs._RESOURCEKEY_IMAGE_SIZE_TOOSMALL_) ?? "The image size is too small. (이미지 크기가 너무 작습니다.)" + strName, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return Result;
            }
            if (image.RawFormat == null)
            {
                if (isShowMeesageBox == true) this.ShowMessageBox(Utils.GetLanguageResourceString(Defs._RESOURCEKEY_IMAGE_FORMAT_UNKNOWN_) ?? "The image format is unknown. (이미지 형식을 알 수 없습니다.)" + strName, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return Result;
            }
            if (image.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.MemoryBmp))
            {
                //this.ShowMessageBox(Utils.GetLanguageResourceString(Defs._RESOURCEKEY_IMAGE_FORMAT_MEMORYBMP_) ?? "The image format is not supported (MemoryBmp). (이미지 형식이 지원되지 않습니다 (MemoryBmp).)", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //return;
                image = Utils.ConvertImageFormat(image, System.Drawing.Imaging.ImageFormat.Png);
            }
            if (image.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Emf))
            {
                if (isShowMeesageBox == true) this.ShowMessageBox(Utils.GetLanguageResourceString(Defs._RESOURCEKEY_IMAGE_FORMAT_NOTSUPPORT_EMF_) ?? "The image format is not supported (Emf). (이미지 형식이 지원되지 않습니다 (Emf).)" + strName, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return Result;
            }
            if (image.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Wmf))
            {
                if (isShowMeesageBox == true) this.ShowMessageBox(Utils.GetLanguageResourceString(Defs._RESOURCEKEY_IMAGE_FORMAT_NOTSUPPORT_WMF_) ?? "The image format is not supported (Wmf). (이미지 형식이 지원되지 않습니다 (Wmf).)" + strName, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return Result;
            }
            if (image.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Icon))
            {
                if (isShowMeesageBox == true) this.ShowMessageBox(Utils.GetLanguageResourceString(Defs._RESOURCEKEY_IMAGE_FORMAT_NOTSUPPORT_ICON_) ?? "The image format is not supported (Icon). (이미지 형식이 지원되지 않습니다 (Icon).)" + strName, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return Result;
            }
            if (fImageCartIndex >= int.MaxValue)
            {
                fImageCartIndex = 0;
                if (isShowMeesageBox == true) this.ShowMessageBox("The image cart index has been reset. (이미지 장바구니 인덱스가 재설정되었습니다.)", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (fImageCartIndex < 0)
            {
                fImageCartIndex = 0;
                //this.ShowMessageBox("The image cart index has been reset. (이미지 장바구니 인덱스가 재설정되었습니다.)", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //this.ShowMessageBox("The image cart index was invalid and has been reset. (이미지 장바구니 인덱스가 잘못되어 재설정되었습니다.)", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //장바구니의 인덱스가 음수로 잘못 설정되어 더이상 진행하지 않음
                if (isShowMeesageBox == true) this.ShowMessageBox(Utils.GetLanguageResourceString(Defs._RESOURCEKEY_CART_APPEND_ERROR_INDEX_) ?? "Failed to add image to cart due to an invalid index. (잘못된 인덱스로 인해 이미지를 장바구니에 추가하지 못했습니다.)" + strName, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return Result;
            }



            TImageCartItem img = new TImageCartItem
            {
                Index = ++this.fImageCartIndex,
                Name = name,
                ImageData = image,
                //ImageBytes = imageBytes,
                CreatedTime = DateTime.Now,
            };
            int n = CartImageList.AsEnumerable<TImageCartItem>().Where(r => r.FileChecksum == img.FileChecksum && r.FileSize == img.FileSize).Count();
            if (n <= 0)
            {
                CartImageList.Add(img);
            }
            else
            {
                //이미 같은 이미지가 추가되어 있음
                string strAddImageMeesage = Utils.GetLanguageResourceString(Defs._RESOURCEKEY_CART_APPEND_WARRING_EXISTS_) ?? "The image is already in your cart. (이미 장바구니에 있는 이미지입니다.)" + strName;
                if (isShowMeesageBox == true) this.ShowMessageBox(strAddImageMeesage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //StatusBarEventCaption = Utils.GetLanguageResourceString(Defs._RESOURCEKEY_CART_APPEND_WARRING_EXISTS_) ?? "The image is already in your cart. (이미 장바구니에 있는 이미지입니다.)";
                return Result;
            }

            //grdcImageCart.DataSource = fImageCartList;
            // 기존 코드
            // Binding binding = grdcImageCart.DataBindings["DataSource"];

            // 수정된 코드 (null 허용 및 안전한 캐스팅 적용)
            Binding? binding = grdcImageCart.DataBindings["DataSource"];
            //binding.DataSource
            if (binding != null && binding.DataSource is BindingList<TImageCartItem> dataSource)
            {
                // 데이터 소스가 BindingList<TXFD_IMAGE_ITEM> 타입인 경우에만 작업 수행
                dataSource.Add(img);
            }
            else
            {
                // 데이터 소스가 예상한 타입이 아닌 경우에 대한 처리
                // 예: 로그 기록, 예외 처리 등
                Debug.WriteLine("Data source is not of type BindingList<TXFD_IMAGE_ITEM> or is null.");
            }

            grdcImageCart.Refresh();

            string strStatusMessage = Utils.GetLanguageResourceString(Defs._RESOURCEKEY_CART_APPEND_WARRING_EXISTS_) ?? "The image has been added to the cart. (이미지가 장바구니에 추가되었습니다.)" + strName;
            StatusBarEventCaption = strStatusMessage;

            Result = true;
            return Result;
        }



        private void rcChildMenu_Click(object sender, EventArgs e)
        {

        }

        private void bbibtnCameraToPicture_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}
