using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit.Import.OpenXml;
using HxCore;
using HxCore.Win;
using System.Globalization;

using Utils = TxFarmDiaryAI.Win.SbUtils;

namespace TxFarmDiaryAI.Win
{
    public partial class UbLoginForm : UbBaseChildForm
    {
        public UbLoginForm()
        {
            InitializeComponent();

            Load += OnForm_Load;
            Shown += OnForm_Shown;
            FormClosing += OnForm_FormClosing;
            FormClosed += OnForm_FormClosed;
        }

        public UbLoginForm(Form parentForm)
            : this()
        {
            this.Owner = parentForm;
        }

        public UbLoginForm(string username, string password)
            : this()
        {

        }

        public UbLoginForm(Form parentForm, string username, string password)
            : this(username, password)
        {
            this.Owner = parentForm;
        }

        private void OnForm_Load(object? sender, EventArgs evt)
        {
            this.btnTestShow.Visible = false;
            this.btnTestClose.Visible = false;
            this.btnTestLang_koKR.Visible = false;
            this.btnTestLang_enUS.Visible = false;


            btnLogin.Click += (s, e) => { SysEnv.IsLogined = true; this.Close(); };
            btnCancel.Click += (s, e) => 
            { 
                //SysEnv.IsLogined = false; 
                SysEnv.ApplicationCloseType = CloseReason.UserClosing; 
                Close(); 
            };

            this.btnTestLang_koKR.Click += (s, e) =>
            {
                //SysEnv.SetCultureInfo("ko-KR");
                ApplyResourcesStrings("ko-KR");
            };
            this.btnTestLang_enUS.Click += (s, e) =>
            {
                //SysEnv.SetCultureInfo("en-US");
                ApplyResourcesStrings("en-US");
            };

            if (this.IsStartUp != true)
            {
                //Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                //this.Text = HelloText;

                /*
                this.btnTestShow.LocalizedResourceSetEx();

                this.btnTestClose.LocalizedResourceSetEx();
                this.btnLogin.LocalizedResourceSetEx();
                */
#if DEBUG
                this.btnTestShow.Visible = true;
                this.btnTestClose.Visible = true;
                this.btnTestLang_koKR.Visible = true;
                this.btnTestLang_enUS.Visible = true;

                
#endif
            }
        }
        protected override void ApplyResourcesStrings(string? cultureName)
        {
            if (cultureName == "ko-KR")
            {
                btnTestLang_koKR.Enabled = false;
                btnTestLang_enUS.Enabled = true;
            }
            else if (cultureName == "en-US")
            {
                btnTestLang_koKR.Enabled = true;
                btnTestLang_enUS.Enabled = false;
            }
            else
            {
                btnTestLang_koKR.Enabled = true;
                btnTestLang_enUS.Enabled = true;
            }

            btnTestLang_koKR.Enabled = true;
            btnTestLang_enUS.Enabled = true;

            base.ApplyResourcesStrings(cultureName);

            //this.DoLocalizedUpdateControlAllToTextEx();
            IEnumerable<Control> q = SbUtils.GetFindAllControl<Control>(this);
            Utils.DoLocalizedUpdateConrolTagMatchToText(q);
        }

        private void OnForm_Shown(object? sender, EventArgs evt)
        {
            if (this.IsStartUp != true)
            {
                string strUserIP = $"{SysEnv._IP_GLOBAL_ADDR_} / {SysEnv._IP_HOST_ADDR_}";
                lblUserIP.Text = strUserIP;
                //lblUserIP.Text += " / " + SysEnv._IP_MAC_ADDR_;


                SbUtils.DoSplashScreenManager_CloseForm();

            }
            this.IsStartUp = true;
        }

        private void OnForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            //throw new NotImplementedException();
            
        }

        private void OnForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            //throw new NotImplementedException();
            if (SysEnv.ApplicationCloseType != CloseReason.UserClosing && SysEnv.IsLogined != true)
            {
                DialogResult flag = MessageBox.Show("Application Exit(Close)?", "Exit?", buttons: MessageBoxButtons.YesNo, defaultButton: MessageBoxDefaultButton.Button2, icon: MessageBoxIcon.Question);
                if (flag != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
                else
                {
                    SysEnv.ApplicationCloseType = CloseReason.UserClosing;
                    //SysEnv.MainForm?.Close();
                }
            }
        }

        private void btnTestShow_Click(object sender, EventArgs e)
        {
            //DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(UbSplashScreenStarup), )
            //DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(null, typeof(UbSplashScreenStartup), false, true, false, 0);
            SbUtils.DoSplashScreenManager_ShowForm_Startup(this);
        }

        private void btnTestClose_Click(object sender, EventArgs e)
        {
            SbUtils.DoSplashScreenManager_CloseForm();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
