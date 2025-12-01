using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.CodeParser;
using DevExpress.Office.Crypto;
using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraPdfViewer;
using DevExpress.XtraTab;
using DevExpress.XtraVerticalGrid;
using HxCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

using Utils = TxFarmDiaryAI.Win.SbUtils;

namespace TxFarmDiaryAI.Win
{
    public partial class UbFarmDiaryListForm : UbBaseChildRibbonForm
    {
        internal DataTable GridDiaryData { get; private set; }
        //internal IEnumerable<SQL_TXFD_DIARY_SET_Table> GridDiaryRecordSet => GridDiaryData.ToRecordSetEx<SQL_TXFD_DIARY_SET_Table>();
        //internal BindingList<SQL_TXFD_DIARY_SET_Table> GridDiaryList { get; private set; } // = new BindingList<TImageCartItem>();

        public UbFarmDiaryListForm()
        {
            InitializeComponent();

            this.Load += OnForm_Load;
            this.Shown += OnForm_Shown;

            barbtnChildRefresh.ItemClick += (s, e) => DoRefreshAll(false);

            grdvFarmDiaryList.FocusedRowChanged += (s, e) => LoadTabPageDetail(false);
            grdvFarmDiaryList.DoubleClick += (s, e) =>
            {
                if (e == null) { return; }

                DXMouseEventArgs? ea = e as DXMouseEventArgs;
                if (ea != null) { return; }

                if (s is not GridView view) { return; }

                GridHitInfo info = view!.CalcHitInfo(ea!.Location);
                if (info.HitTest == GridHitTest.RowIndicator)
                {
                    int rowHandle = info.RowHandle;
                    if (rowHandle >= 0)
                    {
                        LoadTabPageDetail(false);
                    }
                }
                else if (info.InRow || info.InRowCell)
                {
                    int rowHandle = info.RowHandle;
                    if (rowHandle >= 0)
                    {
                        //LoadTabPageDetail(false);
                    }
                }
            };

            tabpageDetailCtl.SelectedPageChanged += (s, e) => LoadTabPageDetail(false);
        }

        private void OnForm_Shown(object? sender, EventArgs e)
        {
            if (this.IsStartUp != true)
            {
                InitGridFarmDiary(true);
                InitGridProperties(true);
                DoRefreshAll(false);
                SysEnv.ShowSelectRibbonMenuPageByText(rpChildFarmDiaryList.Text, true);
                this.IsStartUp = true;
            }
        }

        private void OnForm_Load(object? sender, EventArgs e)
        {
            spcBody.Dock = DockStyle.Fill;
            spcBody.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            spcBody.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel2;

            #region grdcFarmDiaryList / grdvFarmDiaryList Options
            grdcFarmDiaryList.UseEmbeddedNavigator = true;
            grdcFarmDiaryList.EmbeddedNavigator.Buttons.Append.Enabled = false;
            grdcFarmDiaryList.EmbeddedNavigator.Buttons.Append.Visible = false;
            grdcFarmDiaryList.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            grdcFarmDiaryList.EmbeddedNavigator.Buttons.Edit.Visible = false;
            grdcFarmDiaryList.EmbeddedNavigator.Buttons.Remove.Enabled = false;
            grdcFarmDiaryList.EmbeddedNavigator.Buttons.Remove.Visible = false;

            grdvFarmDiaryList.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            grdvFarmDiaryList.OptionsBehavior.Editable = false;
            grdvFarmDiaryList.OptionsBehavior.ReadOnly = true;
            //grdvFarmDiaryList.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowForFocusedRow;
            grdvFarmDiaryList.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            grdvFarmDiaryList.OptionsSelection.MultiSelect = true;

            #endregion

            #region grdcProperties / grdvProperties Options
            grdcProperties.UseEmbeddedNavigator = true;
            grdcProperties.EmbeddedNavigator.Buttons.Append.Enabled = false;
            grdcProperties.EmbeddedNavigator.Buttons.Append.Visible = false;
            grdcProperties.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            grdcProperties.EmbeddedNavigator.Buttons.Edit.Visible = false;
            grdcProperties.EmbeddedNavigator.Buttons.Remove.Enabled = false;
            grdcProperties.EmbeddedNavigator.Buttons.Remove.Visible = false;

            grdvProperties.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            grdvProperties.OptionsBehavior.Editable = false;
            grdvProperties.OptionsBehavior.ReadOnly = true;
            //grdvFarmDiaryList.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowForFocusedRow;
            grdvProperties.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
            grdvProperties.OptionsSelection.MultiSelect = true;
            grdvProperties.OptionsView.ShowGroupPanel = false;
            #endregion

            tabpImageViewer.PageVisible = false;

            picViewer.Properties.AllowZoom = DefaultBoolean.True;
            picViewer.Properties.ShowZoomSubMenu = DefaultBoolean.Default;
            picViewer.Properties.ShowScrollBars = true;
            picViewer.Properties.ShowMenu = true;

            pdfViewer.NavigationPaneInitialVisibility = DevExpress.XtraPdfViewer.PdfNavigationPaneVisibility.Hidden;
            pdfViewer.ReadOnly = true;
        }

        private void DoRefreshAll(bool isInit = false)
        {
            //Utils.ShowWaitLoadingForm(this);
            try
            {
                if (isInit == true)
                {
                    SysEnv.ReloadCodeAll();
                }
                LoadFarmDiaryData();
                
            }
            catch (Exception ex)
            {
                Utils.ShowMessageBox(ex);
                Debug.WriteLine(ex);
                //throw;
            }
            finally
            {
                //Utils.CloseWaitLoadingForm();
            }

        }

        private void InitGridFarmDiary(bool isInit = false)
        {
            GridControl grid = grdcFarmDiaryList;
            GridView view = grdvFarmDiaryList;

            if (grid == null || view == null) { return; }

            if (isInit == true || view.Columns.Count == 0)
            {
                view.BeginInit();
                view.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                view.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                view.Columns.Clear();

                GridColumn gcDNo = new GridColumn
                {
                    FieldName = SQL_TXFD_DIARY_INFO_View._CDF_DNO_,
                    Caption = "Diary No#",
                    Width = 50,
                    Visible = false
                }; gcDNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                GridColumn gcSNo = new()
                {
                    FieldName = SQL_TXFD_DIARY_INFO_View._CDF_SNO_,
                    Caption = "Farm No#",
                    Width = 50,
                    Visible = false
                }; gcSNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                GridColumn gcFileNo = new GridColumn
                {
                    FieldName = SQL_TXFD_DIARY_INFO_View._CDF_FILE_NO_,
                    Caption = "File No#",
                    Width = 50,
                    Visible = false
                }; gcFileNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                GridColumn gcOcrNo = new GridColumn
                {
                    FieldName = SQL_TXFD_DIARY_INFO_View._CDF_OCR_NO_,
                    Caption = "File No#",
                    Width = 50,
                    Visible = false
                }; gcOcrNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                GridColumn gcDiaryDate = new GridColumn
                {
                    FieldName = SQL_TXFD_DIARY_INFO_View._CDF_DIARY_DATE_,
                    Caption = "Diary Date",
                    Width = 70,
                    Visible = true
                }; gcDiaryDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                GridColumn gcTplCode = new GridColumn
                {
                    FieldName = SQL_TXFD_DIARY_INFO_View._CDF_TPL_CODE_,
                    Caption = "Tpl. Code",
                    Width = 50,
                    Visible = true
                }; gcTplCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                GridColumn gcTplName = new GridColumn
                {
                    FieldName = SQL_TXFD_DIARY_INFO_View._CDF_TPL_NAME_,
                    Caption = "Tpl. Name",
                    Width = 50,
                    Visible = true
                }; gcTplName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                GridColumn gcFieldCnt = new GridColumn
                {
                    FieldName = SQL_TXFD_DIARY_INFO_View._CDF_FIELD_CNT_,
                    Caption = "Field Count",
                    Width = 70,
                    Visible = false,
                }; gcFieldCnt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                GridColumn gcOcrFieldCnt = new GridColumn
                {
                    FieldName = SQL_TXFD_DIARY_INFO_View._CDF_OCR_FIELD_CNT_,
                    Caption = "Ocr Field Count",
                    Width = 70,
                    Visible = false,
                }; gcOcrFieldCnt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                GridColumn gcInputDate = new GridColumn
                {
                    FieldName = SQL_TXFD_DIARY_INFO_View._CDF_INPUT_DATE_,
                    Caption = "Work Date",
                    Width = 70,
                    Visible = true,
                }; gcInputDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                GridColumn gcInputWriter = new GridColumn
                {
                    FieldName = SQL_TXFD_DIARY_INFO_View._CDF_INPUT_DATE_,
                    Caption = "Writer",
                    Width = 70,
                    Visible = true,
                }; gcInputWriter.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                GridColumn gcINPUT_WEATHER = new GridColumn
                {
                    FieldName = SQL_TXFD_DIARY_INFO_View._CDF_INPUT_WEATHER_,
                    Caption = "Weather",
                    Width = 70,
                    Visible = true,
                }; gcINPUT_WEATHER.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                GridColumn gcINPUT_ADDR = new GridColumn
                {
                    FieldName = SQL_TXFD_DIARY_INFO_View._CDF_INPUT_ADDR_,
                    Caption = "Address",
                    Width = 120,
                    Visible = true,
                }; gcINPUT_ADDR.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                GridColumn gcINPUT_CROPS = new GridColumn
                {
                    FieldName = SQL_TXFD_DIARY_INFO_View._CDF_INPUT_CROPS_,
                    Caption = "Crops",
                    //Width = 70,
                    Visible = true,
                }; gcINPUT_CROPS.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;

                view.Columns.AddRange(new GridColumn[]
                {
                    gcDNo,
                    gcSNo,
                    gcFileNo,
                    gcOcrNo,
                    gcDiaryDate,
                    gcTplCode,
                    gcTplName,
                    gcFieldCnt,
                    gcOcrFieldCnt,
                    gcInputDate,
                    gcInputWriter,
                    gcINPUT_WEATHER,
                    gcINPUT_ADDR,
                    gcINPUT_CROPS,
                });

                view.EndInit();
            }
        }
        private void InitGridProperties(bool isInit = false)
        {
            GridControl grid = grdcProperties;
            GridView view = grdvProperties;
            if (grid == null || view == null) { return; }
            if (isInit == true || view.Columns.Count == 0)
            {
                view.BeginInit();
                view.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                view.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                view.Columns.Clear();
                GridColumn gcFieldID = new GridColumn
                {
                    FieldName = SQL_TXFD_DIARY_FIELD_Table._CDF_FIELD_ID_,
                    Caption = "Field ID",
                    Width = 100,
                    Visible = true
                }; gcFieldID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                GridColumn gcFieldName = new GridColumn
                {
                    FieldName = SQL_TXFD_DIARY_FIELD_Table._CDF_FIELD_NAME_,
                    Caption = "Field Name",
                    Width = 150,
                    Visible = false
                }; gcFieldName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                GridColumn gcFieldData = new GridColumn
                {
                    FieldName = SQL_TXFD_DIARY_FIELD_Table._CDF_FIELD_DATA_,
                    Caption = "Field Data",
                    Width = 300,
                    Visible = true
                }; gcFieldData.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                view.Columns.AddRange(new GridColumn[]
                {
                    gcFieldID,
                    gcFieldName,
                    gcFieldData,
                });
                view.EndInit();
            }
        }
        public void LoadFarmDiaryData()
        {
            grdcFarmDiaryList.DataSource = null;
            Dictionary<string, object> dictHeader = new Dictionary<string, object>
            {
                { "Content-Type", "application/json; charset=utf-8" }
            };
            HxResultValue res = HxUtils.GetRestClientContentResultValue(Defs._API_URL_FarmDiary_List_, RestSharp.Method.Get, dictHeader);
            if (res.Success == true && res.Value.IsNullOrWhiteSpaceEx() != true)
            {
                var val = res.Value;
                if (val != null)
                {
                    var obj = HxUtils.JsonDeserializeObject<DataTable>(val);
                    if (obj != null)
                    {
                        //Debug.WriteLine(obj?.GetType()?.Name);
                        this.GridDiaryData = obj as DataTable;
                        grdcFarmDiaryList.DataSource = this.GridDiaryData;
                    }
                }
            }
            
            
        }

        public void LoadTabPageDetail(bool isLoadPageAll = false)
        {
            if(IsStartUp != true) { return; }

            Utils.ShowWaitLoadingForm(this);
            try
            {
                XtraTabControl cmp = tabpageDetailCtl;
                XtraTabPage selTabPage = cmp.SelectedTabPage;
                if (selTabPage == null) { return; }

                if (isLoadPageAll == true || selTabPage == tabpProperty)
                {
                    LoadTabPageDetail_Property();
                }
                else if (isLoadPageAll == true || selTabPage == tabpPDFViewer)
                {
                    LoadTabPageDetail_PDFViewer();
                }
                else if (isLoadPageAll == true || selTabPage == tabpImageViewer)
                {
                    LoadTabPageDetail_ImageViewer();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowMessageBox(ex);
                //throw;
            }
            finally
            {
                Utils.CloseWaitLoadingForm();
            }

        }
        public void LoadTabPageDetail_Property()
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = grdvFarmDiaryList;
            int rowIndex = view.FocusedRowHandle;
            if (rowIndex < 0 || this.GridDiaryData == null || this.GridDiaryData.Rows.Count <= 0) { return; }
            DataRow row = view.GetDataRow(rowIndex);
            string strKeyColumnName = SQL_TXFD_DIARY_INFO_View._CDF_DNO_;
            if (row.Table.Columns.Contains(strKeyColumnName))
            {
                string strDiaryNo = row[strKeyColumnName].ToStringEx();
                //DataTable strJson = HxUtils.(strValue);
                //Debug.Write(strJson.ToString());

                Dictionary<string, object> dictHeader = new Dictionary<string, object>
                {
                    { "Content-Type", "application/json; charset=utf-8" }
                };
                string strCallUri = string.Format(Defs._API_URL_FarmDiary_Fields_, strDiaryNo);
                HxResultValue res = HxUtils.GetRestClientContentResultValue(strCallUri, RestSharp.Method.Get, dictHeader);
                if (res.Success == true && res.Value.IsNullOrWhiteSpaceEx() != true)
                {
                    var val = res.Value;
                    if (val != null)
                    {
                        var obj = HxUtils.JsonDeserializeObject<DataTable>(val);
                        if (obj != null)
                        {
                            //Debug.WriteLine(obj?.GetType()?.Name);
                            DataTable? dtValue = obj as DataTable;
                            if (dtValue != null)
                            {
                                grdcProperties.DataSource = dtValue;
                                /*
                                //DevExpress.XtraVerticalGrid.PropertyGridControl grid = grdpDiaryProperty;
                                //grid.Rows.Clear();
                                IOrderedEnumerable<SQL_TXFD_DIARY_FIELD_Table> recordSet = dtValue.ToRecordSetEx<SQL_TXFD_DIARY_FIELD_Table>().OrderBy(r => r.FIELD_NO);
                                if (recordSet != null && recordSet.Any())
                                {
                                    foreach (var record in recordSet)
                                    {
                                        
                                        
                                        DevExpress.XtraVerticalGrid.Rows.EditorRow rowProperty = new DevExpress.XtraVerticalGrid.Rows.EditorRow
                                        {
                                            Name = record.FIELD_ID ?? string.Empty,
                                            Visible = true,
                                            Properties =
                                            {
                                                FieldName = SQL_TXFD_DIARY_FIELD_Table._CDF_FIELD_DATA_,
                                                Caption = record.FIELD_NAME ?? string.Empty,
                                                ReadOnly = true,
                                                //Value = record.FIELD_DATA ?? string.Empty,
                                            },
                                        };
                                        grid.Rows.Add(rowProperty);
                                        grid.SetCellValue(rowProperty, 0, record.FIELD_DATA);
                                        
                                    }
                                
                                }*/
                            }
                        }
                    }
                }
            }
        }

        public void LoadTabPageDetail_PDFViewer()
        {
            pdfViewer.ClearSelection();

            DevExpress.XtraGrid.Views.Grid.GridView view = grdvFarmDiaryList;
            int rowIndex = view.FocusedRowHandle;
            if (rowIndex < 0 || this.GridDiaryData == null || this.GridDiaryData.Rows.Count <= 0) { return; }
            DataRow row = view.GetDataRow(rowIndex);
            string strColumnName_DiaryNo = SQL_TXFD_DIARY_INFO_View._CDF_DNO_;
            string strColumnName_FileNo = SQL_TXFD_DIARY_INFO_View._CDF_FILE_NO_;


            if (row.Table.Columns.Contains(strColumnName_DiaryNo) != true || row.Table.Columns.Contains(strColumnName_FileNo) != true) { return; }

            string strDiaryNo = row[strColumnName_DiaryNo].ToStringEx();
            string strFileNo = row[strColumnName_FileNo].ToStringEx();
            string? strLocalSaveFullPath = null;
            bool flowControl = GetRemoteFile(strFileNo, ref strLocalSaveFullPath);
            if (!flowControl)
            {
                return;
            }

            if (strLocalSaveFullPath.IsNullOrWhiteSpaceEx() != true && HxFile.IsFileExists(strLocalSaveFullPath) == true)
            {
                pdfViewer.LoadDocument(strLocalSaveFullPath);
                pdfViewer.ZoomMode = DevExpress.XtraPdfViewer.PdfZoomMode.PageLevel;
            }
        }

        private static bool GetRemoteFile(string strFileNo, ref string? strLocalSaveFullPath)
        {
            Dictionary<string, object> dictHeader = new Dictionary<string, object>
            {
                { "Content-Type", "application/json; charset=utf-8" }
            };
            string strCallUri = string.Format(Defs._API_URL_FarmDiary_File_, strFileNo);
            HxResultValue res = HxUtils.GetRestClientContentResultValue(strCallUri, RestSharp.Method.Get, dictHeader);
            if (res.Success == true && res.Value.IsNullOrWhiteSpaceEx() != true)
            {
                var val = res.Value;
                if (val != null)
                {
                    //DataTable dtValue = HxUtils.JsonDeserializeObject<DataTable>(val);
                    //DataTable dtValue = HxUtils.ConvertJsonDeserialize<DataTable>(val.ToStringEx());
                    DataTable dtValue = HxConvert.JsonDeserializeObject<DataTable>(val.ToStringEx());
                    if (dtValue != null && dtValue.Rows.Count > 0)
                    {
                        SQL_TXFD_FILE_ENV_Table[] rs = dtValue.ToRecordSetEx<SQL_TXFD_FILE_ENV_Table>();
                        if (rs == null || rs.Any() != true) { return false; }

                        SQL_TXFD_FILE_ENV_Table? rec = rs.FirstOrDefault();
                        if (rec == null || rec.FILE_DATA.IsNullOrWhiteSpaceEx() == true) { return false; }

                        //if (dtValue.Columns.Contains(SQL_TXFD_FILE_ENV_Table._CDF_FILE_DATA_) != true) { return; }
                        //string fileStrBase64 = dtValue.Rows[0][SQL_TXFD_FILE_ENV_Table._CDF_FILE_DATA_].ToStringEx();
                        string? fileStrBase64 = rec.FILE_DATA;
                        if (fileStrBase64.IsNullOrWhiteSpaceEx() == true) { return false; }

                        byte[]? fileBytes = HxUtils.ToByteFromBase64Decode(fileStrBase64);
                        if (fileBytes == null || fileBytes.Length <= 0) { return false; }

                        strLocalSaveFullPath = Path.Combine(SysEnv.GetAppTempDir(), $"{rec.FILE_CHECK}_{rec.FILE_CHECK_SUB}.{rec.FILE_EXT}");
                        if (HxFile.IsFileExists(strLocalSaveFullPath) != true)
                        {
                            strLocalSaveFullPath = HxFile.GetFileUniquePath(strLocalSaveFullPath, HxFileOverwriteType.RenameSequence);
                            HxFile.WriteAllBytes(strLocalSaveFullPath, fileBytes);
                        }
                    }
                }
            }

            return true;
        }

        public void LoadTabPageDetail_ImageViewer()
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = grdvFarmDiaryList;
            int rowIndex = view.FocusedRowHandle;
            if (rowIndex < 0 || this.GridDiaryData == null || this.GridDiaryData.Rows.Count <= 0) { return; }

            DataRow row = view.GetDataRow(rowIndex);
            string strColumnName_DiaryNo = SQL_TXFD_DIARY_INFO_View._CDF_DNO_;
            string strColumnName_FileNo = SQL_TXFD_DIARY_INFO_View._CDF_OCR_NO_;

            if (row.Table.Columns.Contains(strColumnName_DiaryNo) != true || row.Table.Columns.Contains(strColumnName_FileNo) != true) { return; }

            string strDiaryNo = row[strColumnName_DiaryNo].ToStringEx();
            string strFileNo = row[strColumnName_FileNo].ToStringEx();
            string? strLocalSaveFullPath = null;
            bool flowControl = GetRemoteFile(strFileNo, ref strLocalSaveFullPath);
            if (!flowControl)
            {
                return;
            }
            if (strLocalSaveFullPath.IsNullOrWhiteSpaceEx() != true && HxFile.IsFileExists(strLocalSaveFullPath) == true)
            {
                Image img = Image.FromFile(strLocalSaveFullPath!);
                picViewer.Image = img;
                picViewer.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            }
        }
    }
}
