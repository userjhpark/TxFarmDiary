using DevExpress.DocumentView;
using DevExpress.Pdf;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using HxCore;
using Org.BouncyCastle.Bcpg.OpenPgp;
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
            
            repsluMainWorkspaceSelect.ButtonClick += (s, e) =>
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
            barbtnMainImageToOCR.ItemClick += (s, e) =>
            {
                var frmChild = new UbImageCartForm
                {
                    Owner = this,
                    MdiParent = this,
                    //WindowState = FormWindowState.Maximized
                };

                frmChild.Show();
            };

            barbtnMainAppend_FarmingDiary.ItemClick += (s, e) =>
            {
                var frmChild = new UbFarmDiaryInputForm
                {
                    Owner = this,
                    //MdiParent = this,
                    WindowState = FormWindowState.Normal,
                    StartPosition = FormStartPosition.CenterParent
                };
                frmChild.BringToFront();
                frmChild.Show();
                frmChild.Focus();
            };

            barbtnMainList_FarmingDiary.ItemClick += (s, e) =>
            {
                var frmChild = new UbFarmDiaryListForm
                {
                    Owner = this,
                    MdiParent = this,
                    WindowState = FormWindowState.Normal,
                    StartPosition = FormStartPosition.CenterParent
                };
                frmChild.BringToFront();
                frmChild.Show();
                frmChild.Focus();
            };


#if DEBUG
            barbtnDiarySampleFolder.Visibility = BarItemVisibility.OnlyInRuntime;
#endif
            barbtnDiarySampleFolder.ItemClick += (s, e) =>
            {
                string strDirPath = Path.Combine(SysEnv.GetAppBaseDir(), "Sample");
                SbUtils.ExecuteProcessRun(strDirPath);
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
            SysEnv.InitWorkspaceSelectFromSearchLookupEdit(repsluMainWorkspaceSelect, SysEnv.WorkspaceDataTable);
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

                    InitWorkspaceSelect();
                }
                
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
        internal void SetSelectRibbonMenuPageByName(string pageName, bool IsExactMatch = true, DevExpress.XtraBars.Ribbon.RibbonControl? ribbonControl = null)
        {
            DevExpress.XtraBars.Ribbon.RibbonControl menu = ribbonControl ?? rcMainMenu;
            if (pageName.IsNullOrWhiteSpaceEx() != true)
            {
                try
                {
                    var findPage = menu.MergedPages.GetPageByName(pageName);
                    if (IsExactMatch == true && findPage == null)
                    {
                        findPage = menu.MergedPages.GetPageByText(pageName);
                    }
                    menu.SelectedPage = findPage ?? menu.MergedPages[0] ?? menu.Pages[0];
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
        internal void SetSelectRibbonMenuPageByText(string pageText, bool IsExactMatch = true, DevExpress.XtraBars.Ribbon.RibbonControl? ribbonControl = null)
        {
            DevExpress.XtraBars.Ribbon.RibbonControl menu = ribbonControl ?? rcMainMenu;
            if (pageText.IsNullOrWhiteSpaceEx() != true)
            {
                try
                {
                    var findPage = menu.Pages.GetPageByText(pageText);
                    if (findPage == null && IsExactMatch == true)
                    {
                        findPage = menu.Pages.GetPageByName(pageText);
                    }
                    if (findPage == null && IsExactMatch == true)
                    {
                        findPage = menu.MergedPages.GetPageByText(pageText);
                    }
                    if (findPage == null && IsExactMatch == true)
                    {
                        findPage = menu.MergedPages.GetPageByName(pageText);
                    }

                    if (findPage != null && findPage.Visible != true)
                    {
                        findPage.Visible = true;
                    }
                    menu.SelectedPage = findPage ?? menu.Pages[0] ?? menu.MergedPages[0];
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

        private DataTable workspaceDataTable
        {
            get
            {
                if (repsluMainWorkspaceSelect.DataSource != null)
                {
                    if (repsluMainWorkspaceSelect.DataSource is DataTable dt && dt.Rows.Count > 0)
                    {
                        return dt;
                    }
                }
                return null;
            }
        }

        internal decimal? GetSelectedWorkspaceSNO()
        {
            if (workspaceDataTable != null && baredtMainWorkspaceSelect.EditValue.IsNullOrWhiteSpaceEx() != true)
            {
                return baredtMainWorkspaceSelect.EditValue.ToDecimalEx();
            }
            return null;
        }
        internal string GetSelectedWorkspaceName()
        {
            if (workspaceDataTable != null && baredtMainWorkspaceSelect.EditValue.IsNullOrWhiteSpaceEx() != true)
            {
                DataRow[] findRows = workspaceDataTable.Select($"{SQL_TXFD_SITE_SET_Table._CDF_SNO_} = {baredtMainWorkspaceSelect.EditValue.ToDecimalEx()}");
                if (findRows.Length > 0)
                {
                    return findRows[0][SQL_TXFD_SITE_SET_Table._CDF_SITE_NAME_].ToStringEx();
                }
            }
            return string.Empty;
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