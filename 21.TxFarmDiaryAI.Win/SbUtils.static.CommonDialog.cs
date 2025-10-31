using HxCore;
using HxCore.Win;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxFarmDiaryAI.Win
{
    partial class SbUtils
    {
        public static void DoSplashScreenManager_ShowForm(Form parentForm, Type splashFormType, bool useFadeIn = false, bool useFadeOut = true, bool throwExceptionIfAlreadyOpened = false, int pendingTime = 0)
        {
            try
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(parentForm, splashFormType, useFadeIn, useFadeOut, throwExceptionIfAlreadyOpened, pendingTime);
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                Debug.Write(ex.ToString());
                //throw;
            }

        }
        public static void DoSplashScreenManager_ShowForm_Startup(Form parentForm, bool useFadeIn = false, bool useFadeOut = true, bool throwExceptionIfAlreadyOpened = false, int pendingTime = 0)
        {
            try
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(parentForm, typeof(UbSplashScreenStartup), useFadeIn, useFadeOut, throwExceptionIfAlreadyOpened, pendingTime);
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                Debug.Write(ex.ToString());
                //throw;
            }

        }
        public static void DoSplashScreenManager_CloseForm(bool throwExceptionIfAlreadyClosed, int closingDelay, Form parent)
        {
            try
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(throwExceptionIfAlreadyClosed, closingDelay, parent);
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                Debug.Write(ex.ToString());
                //throw;
            }

        }
        public static void DoSplashScreenManager_CloseForm(bool throwExceptionIfAlreadyClosed = false)
        {
            try
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(throwExceptionIfAlreadyClosed);
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                Debug.Write(ex.ToString());
                if (throwExceptionIfAlreadyClosed == true)
                {
                    throw;
                }
            }
            
        }

        internal static void ShowWaitLoadingForm(System.Windows.Forms.Form? sender = null, bool useFadeIn = false, bool useFadeOut = false, bool throwExceptionIfAlreadyOpened = false)
        {
            try
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(sender, typeof(WaitForm1), useFadeIn, useFadeOut, throwExceptionIfAlreadyOpened);
                //Application.DoEvents();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                //throw;
            }
        }
        internal static void CloseWaitLoadingForm(bool throwExceptionIfAlreadyClosed = false)
        {
            DoSplashScreenManager_CloseForm(throwExceptionIfAlreadyClosed);
            /*
            try
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(throwExceptionIfAlreadyClosed);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                //throw;
            }
            */

        }
        internal static DialogResult ShowMessageBox(string? text, string? caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton? messageBoxDefaultButton = null)
        {
            CloseWaitLoadingForm();
            if (messageBoxDefaultButton != null)
            {
                return MessageBox.Show(text, caption, buttons, icon, messageBoxDefaultButton.Value);
            }
            return MessageBox.Show(text, caption, buttons, icon);
        }
    }
}
