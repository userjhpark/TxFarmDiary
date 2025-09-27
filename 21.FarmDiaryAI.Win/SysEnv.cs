using DevExpress.CodeParser;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using HxCore;
using HxCore.Win;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        internal static string CultureName { get; private set; } = string.Empty; //= "ko-KR"; //"en-US";
        public static System.Resources.ResourceManager? ResourceManager { get; internal set; } = null;
        //public static SysConfig? AppConfig { get; internal set; } = null;
        internal static void LoadCultureResourceManager(string cultureName = "ko-KR")
        {
            string namespaceName = typeof(Program)?.Namespace!;
            string resourceBaseName = $"{namespaceName}.Properties.Strings";
            ResourceManager = new System.Resources.ResourceManager(resourceBaseName, typeof(Program).Assembly);

            //Thread.CurrentThread.CurrentCulture = new CultureInfo("ko-KR");
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            //Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            //string cultureName = "ko-KR"; // "en-US";
            //string cultureName = "en-US";

            SetCultureCurrentThread(cultureName);


        }
        internal static string GetCultureName()
        {
            return CultureName;
        }
        internal static void SetCultureName(string cultureName)
        {
            if(ResourceManager == null)
            {
                LoadCultureResourceManager(cultureName);
            }

            if (CultureName != cultureName)
            {
                SetCultureCurrentThread(cultureName);

                CultureName = cultureName;
            }
        }

        private static void SetCultureCurrentThread(string cultureName)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureName);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureName);
            Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";
            Thread.CurrentThread.CurrentCulture.DateTimeFormat.LongTimePattern = "HH:mm:ss";
            Thread.CurrentThread.CurrentCulture.DateTimeFormat.FullDateTimePattern = "yyyy-MM-dd HH:mm:ss";
            /*
            Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ".";
            Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ",";
            Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = ".";
            Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ",";
            Thread.CurrentThread.CurrentCulture.NumberFormat.PercentDecimalSeparator = ".";
            Thread.CurrentThread.CurrentCulture.NumberFormat.PercentGroupSeparator = ",";
            */
            Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol = "₩";
        }

        // 각 컨트롤과 그 컨트롤이 사용할 리소스 키를 매핑하는 사전
        private static readonly Dictionary<Control, string?> _localizedControls = new Dictionary<Control, string?>();
        public static void LocalizedResourceSetEx(this Control control, string? resourceKey = null)
        {
            SetLocalizedResourceKeySet(control, resourceKey);
        }
        /// <summary>
        /// 컨트롤에 리소스 키를 할당하고, 언어 변경 시 자동으로 텍스트를 업데이트합니다.
        /// </summary>
        /// <param name="control">확장할 컨트롤</param>
        /// <param name="resourceKey">CoreLibrary.Properties.Strings에 정의된 리소스 키</param>
        internal static void SetLocalizedResourceKeySet(Control control, string? resourceKey = null)
        {
            if (control == null || control.Name.IsNullOrWhiteSpaceEx() == true)
            {
                return;
            }
            if(resourceKey.IsNullOrWhiteSpaceEx() == true)
            {
                resourceKey = control.Name;
            }

            // 기존에 등록된 것이 있다면 제거 후 재등록 (키 변경 가능성 대비)
            if (_localizedControls.ContainsKey(control))
            {
                _localizedControls.Remove(control);
            }
            _localizedControls.Add(control, resourceKey);

            // 즉시 텍스트 업데이트
            SetLocalizedUpdateControl(control, resourceKey.ToStringEx());
        }
        private static void SetLocalizedUpdateControl(Control control, string resourceKey)
        {
            if (control == null || control.IsDisposed) return;

            // 리소스 매니저를 통해 현재 Culture에 맞는 문자열 가져오기
            string? strLocalizedValue = SbUtils.GetLanguageResourceString(resourceKey, SysEnv.CultureName);

            if (strLocalizedValue.IsNullOrWhiteSpaceEx() != true)
            {
                // 컨트롤 타입에 따라 적절한 속성에 텍스트 할당
                if (control is Button button)
                {
                    button.Text = strLocalizedValue;
                }
                else if (control is System.Windows.Forms.Label label)
                {
                    label.Text = strLocalizedValue;
                }
                else if (control is TextBox textBox)
                {
                    // TextBox의 Text는 사용자 입력이므로, Placeholder/Watermark 텍스트에만 적용하는 것이 일반적
                    // textBox.Text = localizedString; // 일반적으로는 사용자 입력이므로 주석 처리
                }
                else if (control is Form form)
                {
                    form.Text = strLocalizedValue;
                }
                // 다른 컨트롤 타입도 필요에 따라 추가

            }
        }

        internal static void DoLocalizedUpdateControlAllToTextEx(this Control control)
        {
            SetLocalizedUpdateControlAllToText(control);
        }
        internal static void SetLocalizedUpdateControlAllToText(Control control)
        {
            IEnumerable<Control> q = HxWin.GetFindAllControl<Control>(control);
            SysEnv.SetLocalizedUpdateResourceKeyListToText(q);
        }

        // 모든 자식 컨트롤의 텍스트를 업데이트하는 재귀 함수 (선택 사항)
        internal static void SetLocalizedUpdateResourceKeyListToText(IEnumerable<Control> controls)
        {
            var q = from c in controls.Cast<Control>()
                    where c != null && !c.IsDisposed && !c.Name.IsNullOrWhiteSpaceEx()
                    select c;
            if (q == null || q.Any() != true) return;


            foreach (Control control in q)
            {
                if (control == null || control.IsDisposed) continue;
                if (control.Name.IsNullOrWhiteSpaceEx() == true) continue;

                if (_localizedControls == null || _localizedControls.Count <= 0 || _localizedControls.ContainsKey(control) != true) continue;

                string strResourceKey = _localizedControls[control].ToStringEx();
                if (strResourceKey.IsNullOrWhiteSpaceEx() == true) continue;

                bool flowControl = SetLocalizedUpdateControlToText(control, strResourceKey);
                if (!flowControl)
                {
                    continue;
                }

                // ... 다른 컨트롤 타입에 대한 처리

                if (control.HasChildren)
                {
                    //SetLocalizedUpdateControlListToText((IEnumerable<Control>)control);
                }

            }
        }

        private static bool SetLocalizedUpdateControlToText(Control control, string strResourceKey)
        {
            //string? strLocalizedValue = Properties.Strings.ResourceManager.GetString(strResourceKey);
            string? strLocalizedValue = GetLocalizedControlResourceValue(control, strResourceKey);

            if (strLocalizedValue.IsNullOrWhiteSpaceEx() == true) return false;

            if (control is Button button)
            {
                button.Text = strLocalizedValue;
            }
            else if (control is System.Windows.Forms.Label label)
            {
                label.Text = strLocalizedValue;
            }
            else if (control is TextBox textBox)
            {
                // TextBox의 Text는 사용자 입력이므로, Placeholder/Watermark 텍스트에만 적용하는 것이 일반적
                // textBox.Text = localizedString; // 일반적으로는 사용자 입력이므로 주석 처리
            }
            else if (control is SimpleButton xbtn)
            {
                xbtn.Text = strLocalizedValue;
            }
            else if (control is XtraControl xctl)
            {
                xctl.Text = strLocalizedValue;
            }
            else if (control is Control ctl)
            {
                ctl.Text = strLocalizedValue;
            }
            else if (control is Form form)
            {
                form.Text = strLocalizedValue;
            }

            return true;
        }

        private static string? GetLocalizedControlResourceValue(Control control, string strResourceKey)
        {
            string? strLocalizedValue = ResourceManager?.GetString(strResourceKey);
            System.Resources.ResourceManager resourceManager = Properties.Strings.ResourceManager;
            if (strLocalizedValue.IsNullOrWhiteSpaceEx() == true)
            {
                // 리소스 키가 없으면 컨트롤 이름으로 다시 시도
                strLocalizedValue = ResourceManager?.GetString(control.Name);
            }

            if (strLocalizedValue.IsNullOrWhiteSpaceEx() == true && resourceManager != null)
            {
                if (strLocalizedValue.IsNullOrWhiteSpaceEx() == true)
                {
                    // 리소스 키가 없으면 컨트롤 이름으로 다시 시도
                    strLocalizedValue = resourceManager.GetString(strResourceKey);
                }
                if (strLocalizedValue.IsNullOrWhiteSpaceEx() == true)
                {
                    // 리소스 키가 없으면 컨트롤 이름으로 다시 시도
                    strLocalizedValue = resourceManager.GetString(control.Name);
                }
            }

            return strLocalizedValue;
        }
        private static string? GetLocalizedResourceKeyValue(string strResourceKey)
        {
            string? strLocalizedValue = ResourceManager?.GetString(strResourceKey);
            return strLocalizedValue;
        }
        internal static void DoLocalizedUpdateFormChildAllConrolTagMatchToText(Form form)
        {
            IEnumerable<Control> q = HxWin.GetFindAllControl<Control>(form);
            SysEnv.DoLocalizedUpdateConrolTagMatchToText(q);
        }
        internal static void DoLocalizedUpdateConrolTagMatchToText(IEnumerable<Control> controls)
        {
            var q = from c in controls.Cast<Control>()
                    where c != null && !c.IsDisposed && !c.Name.IsNullOrWhiteSpaceEx()
                    select c;
            if (q == null || q.Any() != true) return;

            foreach (Control control in q)
            {
                if (control == null || control.IsDisposed) continue;
                if (control.Tag.IsNullOrWhiteSpaceEx() == true) continue;

                string strControlTag = control.Tag.ToStringEx();
                if (strControlTag.IsNullOrWhiteSpaceEx() == true) continue;

                System.Text.RegularExpressions.MatchCollection match = strControlTag.RegexMatchesEx(_TAG_RESOURCE_TPL_PATTERN_, System.Text.RegularExpressions.RegexOptions.Multiline);
                if (match == null || match.Count <= 0) continue;

                string strNewText = strControlTag;

                foreach (System.Text.RegularExpressions.Match m in match)
                {
                    if (m == null || m.Groups.Count < 3) continue;

                    string strTplName = m.Groups[2].Value;
                    if (strTplName.IsNullOrWhiteSpaceEx() == true) continue;

                    string strResourceKey = strTplName;
                    //string? strResourceValue = GetLocalizedResourceKeyValue(strResourceKey);
                    string? strResourceValue = SbUtils.GetLanguageResourceString(strResourceKey);
                    if (strResourceValue.IsNullOrWhiteSpaceEx() == true) continue;

                    strNewText = strNewText.Replace(m.Value, strResourceValue);
                }

                if (strNewText != strControlTag)
                {
                    control.Text = strNewText;
                }
            }
        }

        internal static void ShowSelectRibbonMenuPage(RibbonPage? page) => SysEnv.MainForm?.SetSelectRibbonMenuPage(page);
        internal static void ShowSelectRibbonMenuPageByName(string pageName, bool IsExactMatch = true) => SysEnv.MainForm?.SetSelectRibbonMenuPageByName(pageName, IsExactMatch);
        internal static void ShowSelectRibbonMenuPageByText(string pageText, bool IsExactMatch = true) => SysEnv.MainForm?.SetSelectRibbonMenuPageByText(pageText, IsExactMatch);


        internal static void ShowWaitLoadingForm(System.Windows.Forms.Form? sender = null, bool useFadeIn = false, bool useFadeOut = false, bool throwExceptionIfAlreadyOpened = false)
        {
            if(sender == null)
            {
                sender = SysEnv.MainForm;
            }
            SbUtils.ShowWaitLoadingForm(sender, useFadeIn, useFadeOut, throwExceptionIfAlreadyOpened);
        }
        internal static void CloseWaitLoadingForm(bool throwExceptionIfAlreadyClosed = false) => SbUtils.CloseWaitLoadingForm(throwExceptionIfAlreadyClosed);
    }
}
