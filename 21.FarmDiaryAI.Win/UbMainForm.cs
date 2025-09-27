using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
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

            barbtnFarmManagement.ItemClick += (s, e) =>
            {
                this.DoShowFarmManagementForm();
            };
            barbtnScanner.ItemClick += (s, e) =>
            {
                var form = new UbSacnToImageForm
                {
                    Owner = this,
                    MdiParent = this,
                    //WindowState = FormWindowState.Maximized
                };

                form.Show();
            };
        }

        private void OnForm_Shown(object? sender, EventArgs evt)
        {
            if (this.IsStartup != true)
            {

                this.IsStartup = true;

                DoShowLoginForm();
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
                    if(rcMainMenu.SelectedPage != page)
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

        private void barbtnScanner_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void rcMainMenu_Click(object sender, EventArgs e)
        {

        }
    }
}