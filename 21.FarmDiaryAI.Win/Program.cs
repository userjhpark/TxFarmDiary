using HxCore;
using System.Diagnostics;
using System.Globalization;

namespace FarmDiaryAI.Win
{
    internal static class Program
    {
        
        static bool IsApplicationStartUp = false;
        static string mutexName = SysEnv._APP_PROCESS_NAME_;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[]? args = null)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            Mutex mutex = new System.Threading.Mutex(true, mutexName, out bool bNew);
            mutex.WaitOne(TimeSpan.Zero, true);

            if (bNew == false) { Application.Exit(); }

            

            Application_StartUpProgram();

            ApplicationConfiguration.Initialize();

            

            SysEnv.MainForm = new UbRibbonMainForm();
            Application.Run(SysEnv.MainForm);
        }

        static void Application_StartUpProgram()
        {
            if (HxFile.IsFileExists(SysEnv._APP_CONFIG_FILENAME_) != true)
            {
                var configMgr = new SbConfigManager();

                Debug.WriteLine($"SMTP Server: {configMgr?.Config?.SmtpSettings?.Host}");

                configMgr?.UpdateManualUrl("http://farmdiaryai.typesw.com/manual/");

                configMgr?.AddServer(new ServerInfo
                {
                    Name = "DefaultServer",
                    WebApiUrl = "http://farmdiaryai.typesw.com/api/",
                    FileServerUrl = "http://farmdiaryai.typesw.com/files/shared/"
                });

            }

            if (IsApplicationStartUp != true)
            {
                string cultureName = "Ko-KR";
                // 시스템 기본값으로 되돌릴 경우 (일반적으로 사용하지 않음)
                if (cultureName != CultureInfo.InstalledUICulture.Name)
                {
                    cultureName = "en-US";
                }
                SysEnv.LoadResourceManager(cultureName);
                
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
                Application.ThreadException += Application_ThreadException;

                IsApplicationStartUp = true;
            }
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception ex)
            {
                MessageBox.Show(
                    ex.ToString(),
                    "예기치 않은 오류",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            else
            {
                MessageBox.Show(
                    "알 수 없는 예외가 발생했습니다.",
                    "예기치 않은 오류",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Exception ex = e.Exception;
            MessageBox.Show(
                ex != null ? ex.ToString() : "알 수 없는 예외가 발생했습니다.",
                "예기치 않은 오류",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }
    }
}