using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FarmDiaryAI.Win
{
    public partial class frmRibbonMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        internal bool IsStartup { get; private set; } = false;

        private frmLogin LoginForm { get => SysEnv.LoginForm; }
        private bool IsLogined => SysEnv.IsLogined;

        public frmRibbonMain()
        {
            InitializeComponent();

            Load += OnForm_Load;
            Activated += OnForm_Activated;
            Shown += OnForm_Shown;
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
            barbtnFarmManagement.ItemClick += (s, e) =>
            {
                this.DoShowFarmManagementForm();
            }
            ;
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
                SysEnv.LoginForm = new frmLogin(this);
            }
            if (this.LoginForm == null) { return; }

            if (this.IsLogined != true)
            {
                this.LoginForm.ShowDialog();

                if (this.IsLogined != true)
                {
                    Application.Exit();
                }
            }
        }
        private void DoShowFarmManagementForm()
        {
            if (this.IsStartup != true) { return; }

        }
    }
}