using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FarmDiaryAI.Win
{
    public partial class UbSplashScreenStartup : SplashScreen
    {
        public UbSplashScreenStartup()
        {
            InitializeComponent();

            Load += OnForm_Load;
            Shown += OnForm_Shown;
        }

        private void OnForm_Shown(object? sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void OnForm_Load(object? sender, EventArgs e)
        {
            /*
            int iStartYear = SysEnv._APP_COPYRIGHT_START_YEAR_;
            int iNowYear = DateTime.Now.Year;
            string strCopyrightText = $"Copyright ⓒ {iStartYear} Ju-hyun, Park (South Korea)";
            if (iNowYear > 2025)
            {
                strCopyrightText = string.Format("Copyright ⓒ 2025-{0} Ju-hyun, Park (South Korea)", DateTime.Now.Year.ToString()); //"Copyright © 2025-" + DateTime.Now.Year.ToString();
            }
            */
            labelCopyright.Text = SysEnv._APP_COPYRIGHT_CAPTION_;
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum SplashScreenCommand
        {
        }
    }
}