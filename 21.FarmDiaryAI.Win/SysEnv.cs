using HxCore.Win;
using HxCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FarmDiaryAI.Win
{
    internal static class SysEnv
    {
        /// <summary>
        /// 로그인 여부?
        /// </summary>
        public static bool IsLogined { get; private set; } = false;

        #region 응용프로그램 / 실행 정보
        public static char _DIR_PATH_CHAR_ { get => HxUtils.DirSeparatorChar; }
        internal static string _HWD_VOLUME_ID_ { get => HxWin.GetUserVolumeId(); }
        internal static string _HWD_CPU_ID_ { get => HxWin.GetUserCPUId(); }
        internal static string _HWD_CUSTOM_UID_ { get => HxWin.GetUserUniqueID(); }

        internal static Assembly _APP_PROCESS_ASSEMBLY_ { get; private set; } = Assembly.GetExecutingAssembly();
        internal static string _APP_PROCESS_FILE_FULL_ { get; private set; } = GetAppFullName();
        internal static string _APP_PROCESS_FILE_DIR_ { get; private set; } = GetAppBaseDir();
        internal static System.IO.FileInfo _APP_PROCESS_FILE_INFO_ { get; private set; } = new System.IO.FileInfo(_APP_PROCESS_FILE_FULL_);
        internal static string _APP_PROCESS_FILE_NAME_ { get; private set; }
        internal static string _APP_PROCESS_FILE_EXT_ { get; private set; } = _APP_PROCESS_FILE_INFO_.Extension;
        internal static string _APP_PROCESS_NAME_ { get; private set; } = GetAppNameOnly();
        internal static string _APP_PROCESS_GUID_ { get; private set; } = GetApplicationGuid();

        internal static string _IP_GLOBAL_ADDR_ { get; private set; } = HxWin.GetUserGlobalAddress();
        internal static string _IP_HOST_ADDR_ { get; private set; } = HxWin.GetUserHostAddress();
        internal static string _IP_LOCAL_ADDR_ { get; private set; } = HxWin.GetUserIPAddress();
        internal static string _IP_MAC_ADDR_ { get; private set; } = HxWin.GetUserMacAddress();


        internal static string GetAppFullName()
        {
            string Result;
            //Result = Assembly.GetExecutingAssembly().Location;
            //Result = Assembly.GetExecutingAssembly().GetName().CodeBase;
            //Result = HxUtils.AppBaseDir;

            Result = Application.ExecutablePath;

            if (Result.IsNullOrWhiteSpaceEx() == true || HxFile.IsFileExists(Result) != true)
            {
                //Result = Assembly.GetExecutingAssembly().Location;
                Result = _APP_PROCESS_ASSEMBLY_?.Location ?? string.Empty;
            }
            if (Result.IsNullOrWhiteSpaceEx() == true || HxFile.IsFileExists(Result) != true)
            {
                string pattern = @"^(file:\/\/\/|\/)";
                //Result = Assembly.GetExecutingAssembly().GetName().CodeBase;
                Result = Assembly.GetExecutingAssembly().CodeBase;
                if(Result.IsNullOrWhiteSpaceEx() != true)
                {
                    Result = Result.RegexReplaceEx(pattern, string.Empty);
                    Result = Result.Replace('/', _DIR_PATH_CHAR_);
                }
            }

            return Result;
        }
        internal static FileInfo? GetAppFileInfo()
        {
            string strFullName = GetAppFullName();
            if (strFullName.IsNullOrWhiteSpaceEx() != true)
            {
                return new FileInfo(strFullName);
            }
            return null;
        }
        internal static string GetAppBaseDir(bool bEndDirSeparatorChar = true)
        {
            string Result = GetAppFullName(); //HxUtils.AppBaseDir;
            if (bEndDirSeparatorChar == true)
            {
                if (Result.IsNullOrWhiteSpaceEx())
                {
                    Result = @"." + _DIR_PATH_CHAR_;
                    Result = Path.GetFullPath(Result);
                }
                else if (!Result.IsNullOrWhiteSpaceEx() && !Result.EndsWith(_DIR_PATH_CHAR_.ToString()))
                {
                    Result = Result + _DIR_PATH_CHAR_;
                }
            }
            return Result;
        }
        internal static string GetAppNameOnly()
        {
            string strFullName = GetAppFullName();
            FileInfo? fileInfo = GetAppFileInfo();
            if (fileInfo != null && fileInfo.FullName.IsNullOrWhiteSpaceEx() != true)
            {
                string strFileName = fileInfo.Name;
                return HxFile.GetFileNameWithOutExt(fileInfo.FullName);
                //return strFileName.Replace(fileInfo.Extension, string.Empty);
            }
            return string.Empty;
        }
        internal static string GetApplicationGuid()
        {
            Assembly assembly = _APP_PROCESS_ASSEMBLY_; //Assembly.GetExecutingAssembly();
            System.Runtime.InteropServices.GuidAttribute? attribute = assembly.GetCustomAttribute(typeof(System.Runtime.InteropServices.GuidAttribute)) as System.Runtime.InteropServices.GuidAttribute;
            return attribute?.Value ?? Guid.Empty.ToString();
        }
        #endregion //응용프로그램 / 실행 정보

        public const string _APP_CONFIG_FILENAME_ = "Confing.json";
        
        public static readonly int _APP_RUN_NOW_YEAR_ = DateTime.Now.Year;
        public static readonly int _APP_RUN_NOW_MONTH_ = DateTime.Now.Month;

        private static readonly string _APP_CREATOR_ = "Ju-hyun, Park";
        public const int _APP_COPYRIGHT_START_YEAR_ = 2025;
        
        public static string _APP_COPYRIGHT_CAPTION_ = AppCopyrightCaption;
        
        public static string AppCopyrightCaption
        {
            get
            {
                int iStartYear = _APP_COPYRIGHT_START_YEAR_;
                int iNowYear = _APP_RUN_NOW_YEAR_;
                string strCopyrightText = $"Copyright ⓒ {iStartYear} {_APP_CREATOR_} (South Korea)";

                if (false && iNowYear > 2025)
                {
                    strCopyrightText = string.Format("Copyright ⓒ 2025-{0} {1} (South Korea)", _APP_RUN_NOW_YEAR_, _APP_CREATOR_); //"Copyright © 2025-" + DateTime.Now.Year.ToString();
                }
                return strCopyrightText;
            }
        }

        public static  frmRibbonMain MainForm { get; internal set; }

        //public static Form MainForm { get; internal set; }
        public static frmLogin LoginForm { get; internal set; }

        #region Splash Screen / Wait
        public static void DoSplashScreenManager_ShowForm_Startup(Form parentForm, bool useFadeIn = false, bool useFadeOut = true, bool throwExceptionIfAlreadyOpened = false, int pendingTime = 0)
        {
            SysUtils.DoSplashScreenManager_ShowForm_Startup(parentForm, useFadeIn, useFadeOut, throwExceptionIfAlreadyOpened, pendingTime);
        }
        public static void DoSplashScreenManager_CloseForm(bool throwExceptionIfAlreadyClosed = false)
        {
            SysUtils.DoSplashScreenManager_CloseForm(throwExceptionIfAlreadyClosed);
        }
        #endregion

    }
}
