using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit.Import.OpenXml;
using HxCore.Win;

namespace FarmDiaryAI.Win
{
    public partial class frmLogin : UbBaseForm
    {
        public frmLogin()
        {
            InitializeComponent();

            Load += OnForm_Load;
            Shown += OnForm_Shown;
            FormClosing += OnForm_FormClosing;
            FormClosed += OnForm_FormClosed;
        }

        

        public frmLogin(Form parentForm)
            : this()
        {
            this.Owner = parentForm;
        }

        public frmLogin(string username, string password)
            : this()
        {

        }

        public frmLogin(Form parentForm, string username, string password)
            : this(username, password)
        {
            this.Owner = parentForm;
        }

        private void OnForm_Load(object? sender, EventArgs evt)
        {
            btnLogin.Click += (s, e) => { MessageBox.Show("·Î±×ÀÎ"); };
            btnCancel.Click += (s, e) => { Close(); };

            if (this.IsStartUp != true)
            {

            }
        }

        private void OnForm_Shown(object? sender, EventArgs evt)
        {
            if (this.IsStartUp != true)
            {
                string strUserIP = $"{SysEnv._IP_GLOBAL_ADDR_} / {SysEnv._IP_HOST_ADDR_}";
                lblUserIP.Text = strUserIP;
                //lblUserIP.Text += " / " + SysEnv._IP_MAC_ADDR_;


                SysUtils.DoSplashScreenManager_CloseForm();

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
            DialogResult flag = MessageBox.Show("Application Exit(Close)?", "Exit?", buttons: MessageBoxButtons.YesNo, defaultButton: MessageBoxDefaultButton.Button2, icon: MessageBoxIcon.Question);
            if (flag != DialogResult.Yes) 
            { 
                e.Cancel = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(UbSplashScreenStarup), )
            //DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(null, typeof(UbSplashScreenStartup), false, true, false, 0);
            SysUtils.DoSplashScreenManager_ShowForm_Startup(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SysUtils.DoSplashScreenManager_CloseForm();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
