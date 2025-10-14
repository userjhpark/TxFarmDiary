using DevExpress.CodeParser;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using HxCore;
using HxCore.Win;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TxFarmDiaryAI.Win
{
    internal static class SysEnv
    {
        internal static bool IsLoadEnvironment { get; private set; } = false;
        /// <summary>
        /// 로그인 여부?
        /// </summary>
        public static bool IsLogined { get; internal set; } = false;

        public static CloseReason ApplicationCloseType { get; internal set; } = CloseReason.None;

        //internal static SbUtils Utils => SbUtils.Instance;

        private static TResourceLanguageStrings ResourceLanguageStrings => SbUtils.ResourceLanguageStrings;
        private static System.Resources.ResourceManager? ResourceManager => ResourceLanguageStrings.ResourceManager;
        internal static string CultureName { get; set; } = ResourceLanguageStrings?.CultureName ?? "en-US";//CultureInfo.InstalledUICulture.Name;

        #region 응용프로그램 / 실행 정보
        public static char _DIR_PATH_CHAR_ { get => HxUtils.DirSeparatorChar; }
        internal static string _HWD_VOLUME_ID_ { get => HxWin.GetUserVolumeId(); }
        internal static string _HWD_CPU_ID_ { get => HxWin.GetUserCPUId(); }
        internal static string _HWD_CUSTOM_UID_ { get => HxWin.GetUserUniqueID(); }

        internal static Assembly _APP_PROCESS_ASSEMBLY_ { get; private set; } = Assembly.GetExecutingAssembly();
        internal static string _APP_PROCESS_FILE_FULL_ { get; private set; } = GetAppFullName();
        internal static string _APP_PROCESS_FILE_DIR_ { get; private set; } = GetAppBaseDir();
        internal static System.IO.FileInfo _APP_PROCESS_FILE_INFO_ { get; private set; } = new System.IO.FileInfo(_APP_PROCESS_FILE_FULL_);
        internal static string _APP_PROCESS_FILE_NAME_ { get; private set; } = GetAppFileName();
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

            Result = Application.ExecutablePath;

            if (Result.IsNullOrWhiteSpaceEx() == true || HxFile.IsFileExists(Result) != true)
            {
                Result = _APP_PROCESS_ASSEMBLY_?.Location ?? string.Empty;
            }
            if (Result.IsNullOrWhiteSpaceEx() == true || HxFile.IsFileExists(Result) != true)
            {
                // .NET 5+에서는 CodeBase 사용을 피하고 Location을 사용해야 합니다.
                // CodeBase는 더 이상 사용되지 않으므로, Location을 사용하여 경로를 얻습니다.
                Result = Assembly.GetExecutingAssembly().Location ?? string.Empty;
                if (Result.IsNullOrWhiteSpaceEx() != true)
                {
                    // 필요하다면 경로 정규화
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
                    Result += _DIR_PATH_CHAR_;
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
        private const string _TAG_RESOURCE_TPL_PATTERN_ = SbDefs._TAG_RESOURCE_TPL_PATTERN_;
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



        public static UbMainForm? MainForm { get; internal set; }

        //public static Form MainForm { get; internal set; }
        public static UbLoginForm? LoginForm { get; internal set; }
        // 1. CS8618: null을 허용하지 않는 속성 '_APP_PROCESS_FILE_NAME_' 초기화
        // 2. IDE1006: 명명 규칙 위반 - '_' 접두사 제거

        // 기존 선언 교체
        internal static string AppProcessFileName { get; private set; } = GetAppFileName();

        #region Splash Screen / Wait
        public static void DoSplashScreenManager_ShowForm_Startup(Form parentForm, bool useFadeIn = false, bool useFadeOut = true, bool throwExceptionIfAlreadyOpened = false, int pendingTime = 0)
        {
            SbUtils.DoSplashScreenManager_ShowForm_Startup(parentForm, useFadeIn, useFadeOut, throwExceptionIfAlreadyOpened, pendingTime);
        }
        public static void DoSplashScreenManager_CloseForm(bool throwExceptionIfAlreadyClosed = false)
        {
            SbUtils.DoSplashScreenManager_CloseForm(throwExceptionIfAlreadyClosed);
        }

        // 새 메서드 추가 (명명 규칙에 맞게)
        private static string GetAppFileName()
        {
            var fileInfo = GetAppFileInfo();
            return fileInfo != null ? fileInfo.Name : string.Empty;
        }
        #endregion

        

        internal static void ShowSelectRibbonMenuPage(RibbonPage? page) => SysEnv.MainForm?.SetSelectRibbonMenuPage(page);
        internal static void ShowSelectRibbonMenuPageByName(string pageName, bool IsExactMatch = true) => SysEnv.MainForm?.SetSelectRibbonMenuPageByName(pageName, IsExactMatch);
        internal static void ShowSelectRibbonMenuPageByText(string pageText, bool IsExactMatch = true) => SysEnv.MainForm?.SetSelectRibbonMenuPageByText(pageText, IsExactMatch);

        /*
        internal static void ShowWaitLoadingForm(System.Windows.Forms.Form? sender = null, bool useFadeIn = false, bool useFadeOut = false, bool throwExceptionIfAlreadyOpened = false)
        {
            if(sender == null)
            {
                sender = SysEnv.MainForm;
            }
            SbUtils.ShowWaitLoadingForm(sender, useFadeIn, useFadeOut, throwExceptionIfAlreadyOpened);
        }
        internal static void CloseWaitLoadingForm(bool throwExceptionIfAlreadyClosed = false) => SbUtils.CloseWaitLoadingForm(throwExceptionIfAlreadyClosed);
        internal static DialogResult ShowMessageBox(string? text, string? caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton? messageBoxDefaultButton = null) => SbUtils.ShowMessageBox(text, caption, buttons, icon, messageBoxDefaultButton);
        */
        internal static void ReloadCodeAll()
        {
            LoadWorkspace();
        }
        #region Workspace
#if DEBUG
        internal static readonly string _API_URL_FarmSite_Workspace_ = @"http://localhost:5000/api/FarmSite/all/DataTable";
#else
        internal static readonly string _API_URL_FarmSite_Workspace_ = @"http://jhpark0406:5000/api/FarmSite/all";
#endif

        public static DataTable? WorkspaceDataTable { get; private set; } = null;

        public static SQL_TXFD_SITE_SET_Table[]? WorkspaceRecordSet => WorkspaceDataTable?.ToRecordSetEx<SQL_TXFD_SITE_SET_Table>();

        public static decimal? CurrWorkspaceSNO => MainForm?.GetSelectedWorkspaceSNO();
        public static SQL_TXFD_SITE_SET_Table? CurrWorksapceRecord 
        {
            get
            {
                if(WorkspaceRecordSet != null && WorkspaceRecordSet.Length > 0 && CurrWorkspaceSNO != null )
                {
                    SQL_TXFD_SITE_SET_Table? rec = WorkspaceRecordSet.Where(r => r.SNO == CurrWorkspaceSNO.Value).LastOrDefault();
                    if (rec != null && rec.SNO.IsNullOrWhiteSpaceEx() != true)
                    {
                        return rec;
                    }
                }
                return null;
            }
        }

        public static void LoadWorkspace(bool bInit = false)
        {
            if(WorkspaceDataTable == null || WorkspaceDataTable.Rows.Count < 1 || bInit == true)
            {
                Dictionary<string, object> dictHeader = new Dictionary<string, object>
                {
                    { "Content-Type", "application/json; charset=utf-8" }
                };
                HxResultValue res = HxUtils.GetRestClientContentResultValue(_API_URL_FarmSite_Workspace_, RestSharp.Method.Get, dictHeader);
                if (res.Success == true && res.Value.IsNullOrWhiteSpaceEx() != true)
                {
                    var val = res.Value;
                    if (val != null)
                    {
                        var obj = HxUtils.JsonDeserializeObject<DataTable>(val);
                        if (obj != null)
                        {
                            Debug.WriteLine(obj?.GetType()?.Name);
                            var dt = obj as DataTable;
                            if (dt != null)
                            {
                                WorkspaceDataTable = dt.Copy();
                                dt.Clear();
                            }
                        }
                    }
                }
            }
        }
        #endregion
    }
}
