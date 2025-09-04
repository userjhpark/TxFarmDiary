using HxCore;

namespace FarmDiaryAI.Win
{
    internal static class Program
    {
        static Mutex mutex;
        static string mutexName = SysEnv._APP_PROCESS_NAME_;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            mutex = new System.Threading.Mutex(true, mutexName, out bool bNew);
            mutex.WaitOne(TimeSpan.Zero, true);

            if (bNew == false) { Application.Exit(); }

            if (HxFile.IsFileExists(SysEnv._APP_CONFIG_FILENAME_) != true)
            {
                var configMgr = new SbConfigManager();
                
                Console.WriteLine($"SMTP Server: {configMgr.Config.SmtpSettings.Host}");

                configMgr.UpdateManualUrl("http://farmdiaryai.typesw.com/manual/");

                configMgr.AddServer(new ServerInfo
                {
                    Name = "DefaultServer",
                    WebApiUrl = "http://farmdiaryai.typesw.com/api/",
                    FileServerUrl = "http://farmdiaryai.typesw.com/files/shared/"
                });

            }


            ApplicationConfiguration.Initialize();
            SysEnv.MainForm = new frmRibbonMain();
            Application.Run(SysEnv.MainForm);
        }
    }
}