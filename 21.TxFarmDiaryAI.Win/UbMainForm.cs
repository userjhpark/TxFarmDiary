using DevExpress.DocumentView;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using HxCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TxFarmDiaryAI.Win
{
    public partial class UbMainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        internal bool IsStartup { get; private set; } = false;

        private UbLoginForm? LoginForm { get => SysEnv.LoginForm; }
        private bool IsLogined => SysEnv.IsLogined;

        public UbMainForm()
        {
            InitializeComponent();

            Load += OnForm_Load;
            Activated += OnForm_Activated;
            Shown += OnForm_Shown;
            FormClosing += OnForm_FormClosing;
        }

        private void OnForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (SysEnv.IsLogined == true)
            {
                DialogResult flag = MessageBox.Show("Application Exit(Close)?", "Exit?", buttons: MessageBoxButtons.YesNo, defaultButton: MessageBoxDefaultButton.Button2, icon: MessageBoxIcon.Question);
                if (flag != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }

        private void OnForm_Activated(object? sender, EventArgs evt)
        {
            /*
            if (this.IsStartup == true && this.IsLogined != true)
            {
                DoLoginFormShow();
            }
            */
        }

        private void OnForm_Load(object? sender, EventArgs evt)
        {
            #region MDI Container
            this.IsMdiContainer = true;
            //this.AllowMdiBar = true;
            //this.ShowInTaskbar = true;

            this.mdimngMain.AppearancePage.HeaderActive.BackColor = Color.FromArgb(255, 128, 0);
            this.mdimngMain.AppearancePage.HeaderActive.BorderColor = Color.Red;
            this.mdimngMain.AppearancePage.HeaderActive.Font = new Font(this.mdimngMain.AppearancePage.HeaderActive.Font.Name, this.mdimngMain.AppearancePage.HeaderActive.Font.Size, FontStyle.Bold);
            this.mdimngMain.AppearancePage.HeaderActive.Options.UseBackColor = true;
            this.mdimngMain.AppearancePage.HeaderActive.Options.UseBorderColor = true;
            this.mdimngMain.AppearancePage.HeaderActive.Options.UseFont = true;

            this.mdimngMain.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders;
            this.mdimngMain.FloatOnDoubleClick = DevExpress.Utils.DefaultBoolean.False;
            this.mdimngMain.PageImagePosition = DevExpress.XtraTab.TabPageImagePosition.Near;

            this.mdimngMain.UseFormIconAsPageImage = DevExpress.Utils.DefaultBoolean.True;
            this.mdimngMain.MdiParent = this;

            rcMainMenu.MdiMergeStyle = RibbonMdiMergeStyle.Always;
            rcMainMenu.Merge += (s, e) =>
            {
                RibbonControl? parentRibbon = s as RibbonControl;
                RibbonControl? childRibbon = e.MergedChild;
                if (parentRibbon != null && childRibbon != null)
                {
                    //parentRibbon.MergeRibbon(childRibbon);
                    parentRibbon.StatusBar.MergeStatusBar(childRibbon.StatusBar);
                    parentRibbon.StatusBar.Refresh();
                    /*
                    if (childRibbon.Pages.Count > 1)
                    {
                        parentRibbon.SelectedPage = childRibbon.Pages[1];
                    }
                    //parentRibbon.SelectedPage = rpMainView;
                    
                    */
                    //parentRibbon.SelectedPage = parentRibbon.MergedPages.GetPageByName(childRibbon.Pages.Last().Name) ?? parentRibbon.Pages[0];
                    Application.DoEvents();
                }
            };
            rcMainMenu.UnMerge += (s, e) =>
            {
                if (s is RibbonControl parentRibbon)
                {
                    parentRibbon.StatusBar.UnMergeStatusBar();
                }
            };
            #endregion

            #region WorkspaceSelect
            InitWorkspaceSelect();
            repslueWorkspaceSelect.ButtonClick += (s, e) =>
            {
                this.OnButtonClick_WorkspaceSelect(s, e);
            };
            replueWorkspaceSelect.ButtonClick += (s, e) =>
            {
                this.OnButtonClick_WorkspaceSelect(s, e);
            };
            #endregion
            barbtnFarmManagement.ItemClick += (s, e) =>
            {
                this.DoShowFarmManagementForm();
            };
            barbtnScanner.ItemClick += (s, e) =>
            {
                var frmChild = new UbChildSacnToImageCartForm
                {
                    Owner = this,
                    MdiParent = this,
                    //WindowState = FormWindowState.Maximized
                };

                frmChild.Show();
            };
        }

        private void OnButtonClick_WorkspaceSelect(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs evt)
        {
            if (evt.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
            {
                SysEnv.LoadWorkspace(true);
                //repgrdvWorkspaceSelect.GridControl.DataSource = SysEnv.WorkspaceData;
                if (sender is DevExpress.XtraEditors.Repository.RepositoryItemLookUpEditBase ctr)
                {
                    ctr.DataSource = SysEnv.WorkspaceDataTable;
                }
            }
        }

        private void InitWorkspaceSelect()
        {
            /*
            replueWorkspaceSelect.BeginInit();
            replueWorkspaceSelect.Columns.Clear();
            replueWorkspaceSelect.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo{ FieldName = SQL_TXFD_SITE_SET_Table._CDF_SNO_, Caption = "NO", Visible = true, Width = 30, Alignment = DevExpress.Utils.HorzAlignment.Far, FormatType = DevExpress.Utils.FormatType.Numeric },
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo{ FieldName = SQL_TXFD_SITE_SET_Table._CDF_SITE_NAME_, Caption = "Farming Name", Visible = true, Width = 100, Alignment = DevExpress.Utils.HorzAlignment.Center },


                new DevExpress.XtraEditors.Controls.LookUpColumnInfo{ FieldName = SQL_TXFD_SITE_SET_Table._CDF_LOC_ADDR_, Caption = "Location / Adreess", Visible = true, Width = 150, Alignment = DevExpress.Utils.HorzAlignment.Near },
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo{ FieldName = SQL_TXFD_SITE_SET_Table._CDF_LOC_ROAD_, Caption = "Location / Road", Visible = false, Width = 100, Alignment = DevExpress.Utils.HorzAlignment.Near },
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo{ FieldName = SQL_TXFD_SITE_SET_Table._CDF_LOC_LATITUDE_, Caption = "Location / Latitude", Visible = true, Width = 50, Alignment = DevExpress.Utils.HorzAlignment.Far, FormatType = DevExpress.Utils.FormatType.Numeric, FormatString = "#,##0.00" },
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo{ FieldName = SQL_TXFD_SITE_SET_Table._CDF_LOC_LONGITUDE_, Caption = "Location / Longitude", Visible = true, Width = 50, Alignment = DevExpress.Utils.HorzAlignment.Far, FormatType = DevExpress.Utils.FormatType.Numeric, FormatString = "#,##0.00" },

                new DevExpress.XtraEditors.Controls.LookUpColumnInfo{ FieldName = SQL_TXFD_SITE_SET_Table._CDF_STN_CODE_, Caption = "STN Code", Visible = true, Width = 30, Alignment = DevExpress.Utils.HorzAlignment.Far },
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo{ FieldName = SQL_TXFD_SITE_SET_Table._CDF_STN_NAME_, Caption = "STN Name", Visible = true, Width = 80, Alignment = DevExpress.Utils.HorzAlignment.Default },

                new DevExpress.XtraEditors.Controls.LookUpColumnInfo{ FieldName = SQL_TXFD_SITE_SET_Table._CDF_SITE_MEMO_, Caption = "Remark", Visible = false, Width = 100, Alignment = DevExpress.Utils.HorzAlignment.Default },
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo{ FieldName = SQL_TXFD_SITE_SET_Table._CDF_IS_USE_, Caption = "STN Name", Visible = false, Width = 30, Alignment = DevExpress.Utils.HorzAlignment.Default },
            });
            replueWorkspaceSelect.DataSource = SysEnv.WorkspaceData;
            replueWorkspaceSelect.EndInit();
            replueWorkspaceSelect.PopupWidthMode = DevExpress.XtraEditors.PopupWidthMode.ContentWidth;
            */

            repgrdvWorkspaceSelect.BeginInit();
            repgrdvWorkspaceSelect.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            repgrdvWorkspaceSelect.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            repgrdvWorkspaceSelect.Columns.Clear();
            DevExpress.XtraGrid.Columns.GridColumn gcWorkspaceSelect_SNO = new()
            {
                FieldName = SQL_TXFD_SITE_SET_Table._CDF_SNO_,
                Caption = "SNO",
                Width = 30,
                Visible = true
            }; gcWorkspaceSelect_SNO.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            DevExpress.XtraGrid.Columns.GridColumn gcWorkspaceSelect_SITE_NAME = new()
            {
                FieldName = SQL_TXFD_SITE_SET_Table._CDF_SITE_NAME_,
                Caption = "Farming Name",
                Width = 100,
                Visible = true
            }; gcWorkspaceSelect_SITE_NAME.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            DevExpress.XtraGrid.Columns.GridColumn gcWorkspaceSelect_LOC_ADDR = new()
            {
                FieldName = SQL_TXFD_SITE_SET_Table._CDF_LOC_ADDR_,
                Caption = "Location / Adreess",
                Width = 100,
                Visible = true
            }; gcWorkspaceSelect_LOC_ADDR.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            DevExpress.XtraGrid.Columns.GridColumn gcWorkspaceSelect_LOC_ROAD = new()
            {
                FieldName = SQL_TXFD_SITE_SET_Table._CDF_LOC_ROAD_,
                Caption = "Location / Road",
                Width = 100,
                Visible = false
            }; gcWorkspaceSelect_LOC_ROAD.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            DevExpress.XtraGrid.Columns.GridColumn gcWorkspaceSelect_LOC_LATITUDE = new()
            {
                FieldName = SQL_TXFD_SITE_SET_Table._CDF_LOC_LATITUDE_,
                Caption = "Latitude",
                Width = 100,
                Visible = false
            }; gcWorkspaceSelect_LOC_LATITUDE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            DevExpress.XtraGrid.Columns.GridColumn gcWorkspaceSelect_LOC_LONGITUDE = new()
            {
                FieldName = SQL_TXFD_SITE_SET_Table._CDF_LOC_LONGITUDE_,
                Caption = "Longitude",
                Width = 100,
                Visible = false
            }; gcWorkspaceSelect_LOC_LONGITUDE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            DevExpress.XtraGrid.Columns.GridColumn gcWorkspaceSelect_STN_CODE = new()
            {
                FieldName = SQL_TXFD_SITE_SET_Table._CDF_STN_CODE_,
                Caption = "STN Code",
                Width = 30,
                Visible = true
            }; gcWorkspaceSelect_STN_CODE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            DevExpress.XtraGrid.Columns.GridColumn gcWorkspaceSelect_STN_NAME = new()
            {
                FieldName = SQL_TXFD_SITE_SET_Table._CDF_STN_NAME_,
                Caption = "STN Name",
                Width = 80,
                Visible = true
            }; gcWorkspaceSelect_STN_NAME.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            DevExpress.XtraGrid.Columns.GridColumn gcWorkspaceSelect_SITE_MEMO = new()
            {
                FieldName = SQL_TXFD_SITE_SET_Table._CDF_SITE_MEMO_,
                Caption = "STN Name",
                Width = 100,
                Visible = false
            }; gcWorkspaceSelect_SITE_MEMO.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            DevExpress.XtraGrid.Columns.GridColumn gcWorkspaceSelect_REG_DATE = new()
            {
                FieldName = SQL_TXFD_SITE_SET_Table._CDF_REG_DATE_,
                Caption = "Created Date",
                Width = 80,
                Visible = false
            }; gcWorkspaceSelect_REG_DATE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            DevExpress.XtraGrid.Columns.GridColumn gcWorkspaceSelect_MOD_DATE = new()
            {
                FieldName = SQL_TXFD_SITE_SET_Table._CDF_MOD_DATE_,
                Caption = "Modifed Date",
                Width = 80,
                Visible = false
            }; gcWorkspaceSelect_MOD_DATE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            DevExpress.XtraGrid.Columns.GridColumn gcWorkspaceSelect_IS_USE = new()
            {
                FieldName = SQL_TXFD_SITE_SET_Table._CDF_IS_USE_,
                Caption = "Use?",
                Width = 30,
                Visible = false
            }; gcWorkspaceSelect_IS_USE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            repgrdvWorkspaceSelect.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                gcWorkspaceSelect_SNO,
                gcWorkspaceSelect_SITE_NAME,
                gcWorkspaceSelect_LOC_ADDR,
                gcWorkspaceSelect_LOC_ROAD,
                gcWorkspaceSelect_LOC_LATITUDE,
                gcWorkspaceSelect_LOC_LONGITUDE,
                gcWorkspaceSelect_STN_CODE,
                gcWorkspaceSelect_STN_NAME,
                gcWorkspaceSelect_SITE_MEMO,
                gcWorkspaceSelect_REG_DATE,
                gcWorkspaceSelect_MOD_DATE,
                gcWorkspaceSelect_IS_USE
            });
            repgrdvWorkspaceSelect.EndInit();

            repslueWorkspaceSelect.BeginInit();
            repslueWorkspaceSelect.PopupWidthMode = DevExpress.XtraEditors.PopupWidthMode.ContentWidth;
            repslueWorkspaceSelect.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            repslueWorkspaceSelect.KeyMember = SQL_TXFD_SITE_SET_Table._CDF_SNO_;
            repslueWorkspaceSelect.ValueMember = SQL_TXFD_SITE_SET_Table._CDF_SNO_;
            repslueWorkspaceSelect.DisplayMember = SQL_TXFD_SITE_SET_Table._CDF_SITE_NAME_;
            repslueWorkspaceSelect.EndInit();
        }

        private void OnForm_Shown(object? sender, EventArgs evt)
        {
            if (this.IsStartup != true)
            {

                this.IsStartup = true;

                DoShowLoginForm();

                if (SysEnv.IsLogined == true)
                {
                    SysEnv.ReloadCodeAll();
                }
                repslueWorkspaceSelect.DataSource = SysEnv.WorkspaceDataTable;
            }
        }

        private void DoShowLoginForm()
        {
            if (this.IsStartup != true) { return; }

            if (this.LoginForm == null)
            {
                SysEnv.LoginForm = new UbLoginForm(this);
            }
            if (this.LoginForm == null) { return; }

            if (this.IsLogined != true)
            {
                this.LoginForm.ShowDialog();

                if (this.IsLogined != true)
                {
                    SysEnv.ApplicationCloseType = CloseReason.UserClosing;
                    Application.Exit();
                }
            }
        }
        private void DoShowFarmManagementForm()
        {
            if (this.IsStartup != true) { return; }

        }

        internal void SetSelectRibbonMenuPage(RibbonPage? page)
        {
            if (page != null)
            {
                try
                {
                    rcMainMenu.SelectedPage = page;
                    if (rcMainMenu.SelectedPage != page)
                    {
                        rcMainMenu.SelectedPage = rcMainMenu.MergedPages.GetPageByName(page.Name) ?? rcMainMenu.Pages[0];
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
            else
            {
                this.SetSelectRibbonMenuPageHome();
            }
        }
        internal void SetSelectRibbonMenuPageByName(string pageName, bool IsExactMatch = true)
        {
            if (pageName.IsNullOrWhiteSpaceEx() != true)
            {
                try
                {
                    var childPage = rcMainMenu.MergedPages.GetPageByName(pageName);
                    if (IsExactMatch != true && childPage == null)
                    {
                        childPage = rcMainMenu.MergedPages.GetPageByText(pageName);
                    }
                    rcMainMenu.SelectedPage = childPage ?? rcMainMenu.Pages[0];
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
            else
            {
                this.SetSelectRibbonMenuPageHome();
            }
        }
        internal void SetSelectRibbonMenuPageByText(string pageText, bool IsExactMatch = true)
        {
            if (pageText.IsNullOrWhiteSpaceEx() != true)
            {
                try
                {
                    var childPage = rcMainMenu.MergedPages.GetPageByText(pageText);
                    if (IsExactMatch != true && childPage == null)
                    {
                        childPage = rcMainMenu.Pages.GetPageByText(pageText);
                    }
                    if (IsExactMatch != true && childPage == null)
                    {
                        //childPage = rcMainMenu.Page.GetPageByText(pageText);
                    }

                    if (childPage != null && childPage.Visible != true)
                    {
                        childPage.Visible = true;
                    }
                    rcMainMenu.SelectedPage = childPage ?? rcMainMenu.Pages[0];
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
            else
            {
                this.SetSelectRibbonMenuPageHome();
            }
        }
        internal RibbonPage? GetSelectRebbonMenuPage()
        {
            return this.rcMainMenu?.SelectedPage;
        }
        internal void SetSelectRibbonMenuPageHome()
        {
            this.rcMainMenu.SelectedPage = rpMainHome;
        }
        internal void SetSelectRibbonMenuPageView()
        {
            this.rcMainMenu.SelectedPage = rpMainView;
        }

        private DataTable _formWorkspaceDataTable
        {
            get
            {
                if (repslueWorkspaceSelect.DataSource != null)
                {
                    if (repslueWorkspaceSelect.DataSource is DataTable dt && dt.Rows.Count > 0)
                    {
                        return dt;
                    }
                }
                return null;
            }
        }

        internal decimal? GetSelectedWorkspaceSNO()
        {
            if (_formWorkspaceDataTable != null && baredtWorkspaceSelect.EditValue.IsNullOrWhiteSpaceEx() != true)
            {
                return baredtWorkspaceSelect.EditValue.ToDecimalEx();
            }
            return null;
        }

        private void barbtnScanner_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void rcMainMenu_Click(object sender, EventArgs e)
        {

        }

        private void bbiTestForm_ItemClick(object sender, ItemClickEventArgs e)
        {
            UbTestForm frmTestForm = new UbTestForm
            {
                Owner = this,
                //MdiParent = this,
                //WindowState = FormWindowState.Maximized
            };
            frmTestForm.ShowDialog();
        }

        private void UbMainForm_Load(object sender, EventArgs e)
        {

        }

        private void bbiMainCart_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}