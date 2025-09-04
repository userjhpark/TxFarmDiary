using HxCore;
using HxCore.Win;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmDiaryAI.Win
{
    internal class SysUtils : HxWin
    {
        public static void DoSplashScreenManager_ShowForm(Form parentForm, Type splashFormType, bool useFadeIn = false, bool useFadeOut = true, bool throwExceptionIfAlreadyOpened = false, int pendingTime = 0)
        {
            try
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(parentForm, splashFormType, useFadeIn, useFadeOut, throwExceptionIfAlreadyOpened, pendingTime);
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
    }
}
