using Amazon.Runtime.Internal.Transform;
using DevExpress.CodeParser;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraSpellChecker;
using HxCore;
using HxCore.Win;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
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
        public static decimal? LoginUserSNO { get; internal set; } = null;

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
            string Result = HxUtils.GetAppBaseDir(); //HxUtils.AppBaseDir;
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
        internal static string GetAppWorkDir(bool isEndDirSeparatorChar = true, bool isNotExistToCreate = true)
        {
            string Result = Path.Combine("C:", "TypeSW", "Programs", "FarmDiary");
            if (isEndDirSeparatorChar == true)
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
            if(Result.IsNullOrWhiteSpaceEx() != true && isNotExistToCreate == true && HxFile.IsDirectoryExists(Result) != true)
            {
                HxFile.DirectoryCreate(Result);
            }
            return Result;
        }
        internal static string GetAppTempDir(bool isEndDirSeparatorChar = true, bool isNotExistToCreate = true)
        {
            string Result = Path.Combine(GetAppWorkDir(false), Defs._TEMP_DIR_NAME_);
            if (isEndDirSeparatorChar == true)
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
            if (Result.IsNullOrWhiteSpaceEx() != true && isNotExistToCreate == true && HxFile.IsDirectoryExists(Result) != true)
            {
                HxFile.DirectoryCreate(Result);
            }
            return Result;
        }
        internal static string GetAppOutputDir(bool isEndDirSeparatorChar = true, bool isNotExistToCreate = true)
        {
            string Result = Path.Combine(GetAppWorkDir(false), Defs._OUTPUT_DIR_NAME_);
            if (isEndDirSeparatorChar == true)
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
            if (Result.IsNullOrWhiteSpaceEx() != true && isNotExistToCreate == true && HxFile.IsDirectoryExists(Result) != true)
            {
                HxFile.DirectoryCreate(Result);
            }
            return Result;
        }
        internal static string GetAppDownloadDir(bool isEndDirSeparatorChar = true, bool isNotExistToCreate = true)
        {
            string Result = Path.Combine(GetAppWorkDir(false), Defs._DOWNLOAD_DIR_NAME_);
            if (isEndDirSeparatorChar == true)
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
            if (Result.IsNullOrWhiteSpaceEx() != true && isNotExistToCreate == true && HxFile.IsDirectoryExists(Result) != true)
            {
                HxFile.DirectoryCreate(Result);
            }
            return Result;
        }
        internal static string GetAppLogDir(bool isEndDirSeparatorChar = true, bool isNotExistToCreate = true)
        {
            string Result = Path.Combine(GetAppWorkDir(false), Defs._LOG_DIR_NAME_);
            if (isEndDirSeparatorChar == true)
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
            if (Result.IsNullOrWhiteSpaceEx() != true && isNotExistToCreate == true && HxFile.IsDirectoryExists(Result) != true)
            {
                HxFile.DirectoryCreate(Result);
            }
            return Result;
        }
        internal static string GetAppSampleDir(bool isEndDirSeparatorChar = true)
        {
            string Result = Path.Combine(GetAppBaseDir(false), Defs._SAMPLE_DIR_NAME_);
            if (isEndDirSeparatorChar == true)
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

        public const string _APP_CONFIG_FILENAME_ = TConfigAppSettings._CONFIG_FILE_NAME_;
        public static TConfigAppSettings AppConfigSettings { get; private set; } = new TConfigAppSettings();

        public static readonly int _APP_RUN_NOW_YEAR_ = DateTime.Now.Year;
        public static readonly int _APP_RUN_NOW_MONTH_ = DateTime.Now.Month;

        private static readonly string _APP_CREATOR_ = "Ju-hyun, Park";
        public const int _APP_COPYRIGHT_START_YEAR_ = 2025;
        private const string _TAG_RESOURCE_TPL_PATTERN_ = SbDefs._TPL_RESOURCE_TAG_PATTERN_;
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
        internal static void ShowSelectRibbonMenuPageByName(string pageName, bool IsExactMatch = true, DevExpress.XtraBars.Ribbon.RibbonControl? ribbonControl = null) => SysEnv.MainForm?.SetSelectRibbonMenuPageByName(pageName, IsExactMatch, ribbonControl);
        internal static void ShowSelectRibbonMenuPageByText(string pageText, bool IsExactMatch = true, DevExpress.XtraBars.Ribbon.RibbonControl? ribbonControl = null) => SysEnv.MainForm?.SetSelectRibbonMenuPageByText(pageText, IsExactMatch, ribbonControl);

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
            LoadFarmingDiaryTemplate();
        }

        #region Workspace
        public static DataTable? WorkspaceDataTable { get; private set; } = null;
        public static SQL_TXFD_SITE_SET_Table[]? WorkspaceRecordSet => WorkspaceDataTable?.ToRecordSetEx<SQL_TXFD_SITE_SET_Table>() ?? GetWorkspaceRecordSet();
        
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
        public static decimal? CurrWorkspaceSNO => MainForm?.GetSelectedWorkspaceSNO();
        public static string? CurrWorkspaceName => MainForm?.GetSelectedWorkspaceName();
        public static string? CurrWorkspaceStnCode => MainForm?.GetSelectedWorkspaceStnCode();
        public static void LoadWorkspace(bool bInit = false)
        {
            if(WorkspaceDataTable == null || WorkspaceDataTable.Rows.Count < 1 || bInit == true)
            {
                Dictionary<string, object> dictHeader = new Dictionary<string, object>
                {
                    { "Content-Type", "application/json; charset=utf-8" }
                };
                HxResultValue res = HxUtils.GetRestClientContentResultValue(Defs._API_URL_FarmSite_Workspace_, RestSharp.Method.Get, dictHeader);
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
        public static SQL_TXFD_SITE_SET_Table[]? GetWorkspaceRecordSet()
        {
            if (WorkspaceDataTable == null) return null;
            var list = new List<SQL_TXFD_SITE_SET_Table>();
            foreach (DataRow row in WorkspaceDataTable.Rows)
            {
                // 필수 멤버를 모두 채워서 객체 생성
                var record = new SQL_TXFD_SITE_SET_Table
                {
                    SNO = row.Field<decimal>(SQL_TXFD_SITE_SET_Table._CDF_SNO_),
                    SITE_NAME = row.Field<string>(SQL_TXFD_SITE_SET_Table._CDF_SITE_NAME_) ?? string.Empty,
                    STN_CODE = row.Field<string>(SQL_TXFD_SITE_SET_Table._CDF_STN_CODE_) ?? string.Empty,
                    // 선택적 필드
                    STN_NAME = row.Field<string>(SQL_TXFD_SITE_SET_Table._CDF_STN_NAME_),
                    LOC_ADDR = row.Field<string>(SQL_TXFD_SITE_SET_Table._CDF_LOC_ADDR_),
                    LOC_LATITUDE = row.Field<decimal?>(SQL_TXFD_SITE_SET_Table._CDF_LOC_LATITUDE_),
                    LOC_LONGITUDE = row.Field<decimal?>(SQL_TXFD_SITE_SET_Table._CDF_LOC_LONGITUDE_),
                    LOC_ROAD = row.Field<string>(SQL_TXFD_SITE_SET_Table._CDF_LOC_ROAD_)
                };
                list.Add(record);
            }
            return list.ToArray();
        }
        internal static BindingList<SQL_TXFD_SITE_SET_Table> WorkspaceBindingList
        {
            get
            {
                return WorkspaceRecordSet != null ? new BindingList<SQL_TXFD_SITE_SET_Table>(WorkspaceRecordSet.ToList()) : new BindingList<SQL_TXFD_SITE_SET_Table>();
                /*
                var list = new BindingList<SQL_TXFD_SITE_SET_Table>();
                var records = WorkspaceRecordSet;
                if (records != null && records.Length > 0)
                {
                    foreach (var rec in records)
                    {
                        list.Add(rec);
                    }
                }
                return list;
                */
            }
        }
        internal static void InitWorkspaceSelectFromSearchLookupEdit(DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit sender, DataTable? dataTable)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender.View;
            InitWorkspaceSelectFromGridView(view);

            sender.BeginInit();
            sender.PopupWidthMode = DevExpress.XtraEditors.PopupWidthMode.ContentWidth;
            sender.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            sender.KeyMember = SQL_TXFD_SITE_SET_Table._CDF_SNO_;
            sender.ValueMember = SQL_TXFD_SITE_SET_Table._CDF_SNO_;
            sender.DisplayMember = SQL_TXFD_SITE_SET_Table._CDF_SITE_NAME_;
            sender.EndInit();
            
            sender.DataSource = dataTable;
        }
        internal static void InitWorkspaceSelectFromGridView(DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            
            view.BeginUpdate();
            view.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            view.Columns.Clear();
            DevExpress.XtraGrid.Columns.GridColumn gcWorkspaceSelect_SNO = new()
            {
                FieldName = SQL_TXFD_SITE_SET_Table._CDF_SNO_,
                Caption = "Farm No#",
                Width = 30,
                Visible = true
            }; gcWorkspaceSelect_SNO.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            DevExpress.XtraGrid.Columns.GridColumn gcWorkspaceSelect_SITE_NAME = new()
            {
                FieldName = SQL_TXFD_SITE_SET_Table._CDF_SITE_NAME_,
                Caption = "Farm Name",
                Width = 100,
                Visible = true
            }; gcWorkspaceSelect_SITE_NAME.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            DevExpress.XtraGrid.Columns.GridColumn gcWorkspaceSelect_LOC_ADDR = new()
            {
                FieldName = SQL_TXFD_SITE_SET_Table._CDF_LOC_ADDR_,
                Caption = "Location / Adreess",
                Width = 100,
                Visible = true
            }; gcWorkspaceSelect_LOC_ADDR.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            DevExpress.XtraGrid.Columns.GridColumn gcWorkspaceSelect_LOC_ROAD = new()
            {
                FieldName = SQL_TXFD_SITE_SET_Table._CDF_LOC_ROAD_,
                Caption = "Location / Road",
                Width = 100,
                Visible = false
            }; gcWorkspaceSelect_LOC_ROAD.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            DevExpress.XtraGrid.Columns.GridColumn gcWorkspaceSelect_LOC_LATITUDE = new()
            {
                FieldName = SQL_TXFD_SITE_SET_Table._CDF_LOC_LATITUDE_,
                Caption = "Latitude",
                Width = 100,
                Visible = false
            }; gcWorkspaceSelect_LOC_LATITUDE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            DevExpress.XtraGrid.Columns.GridColumn gcWorkspaceSelect_LOC_LONGITUDE = new()
            {
                FieldName = SQL_TXFD_SITE_SET_Table._CDF_LOC_LONGITUDE_,
                Caption = "Longitude",
                Width = 100,
                Visible = false
            }; gcWorkspaceSelect_LOC_LONGITUDE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            DevExpress.XtraGrid.Columns.GridColumn gcWorkspaceSelect_STN_CODE = new()
            {
                FieldName = SQL_TXFD_SITE_SET_Table._CDF_STN_CODE_,
                Caption = "STN Code",
                Width = 30,
                Visible = true
            }; gcWorkspaceSelect_STN_CODE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            DevExpress.XtraGrid.Columns.GridColumn gcWorkspaceSelect_STN_NAME = new()
            {
                FieldName = SQL_TXFD_SITE_SET_Table._CDF_STN_NAME_,
                Caption = "STN Name",
                Width = 80,
                Visible = true
            }; gcWorkspaceSelect_STN_NAME.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            DevExpress.XtraGrid.Columns.GridColumn gcWorkspaceSelect_SITE_MEMO = new()
            {
                FieldName = SQL_TXFD_SITE_SET_Table._CDF_SITE_MEMO_,
                Caption = "STN Name",
                Width = 100,
                Visible = false
            }; gcWorkspaceSelect_SITE_MEMO.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            DevExpress.XtraGrid.Columns.GridColumn gcWorkspaceSelect_REG_DATE = new()
            {
                FieldName = SQL_TXFD_SITE_SET_Table._CDF_REG_DATE_,
                Caption = "Created Date",
                Width = 80,
                Visible = false
            }; gcWorkspaceSelect_REG_DATE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            DevExpress.XtraGrid.Columns.GridColumn gcWorkspaceSelect_MOD_DATE = new()
            {
                FieldName = SQL_TXFD_SITE_SET_Table._CDF_MOD_DATE_,
                Caption = "Modifed Date",
                Width = 80,
                Visible = false
            }; gcWorkspaceSelect_MOD_DATE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            DevExpress.XtraGrid.Columns.GridColumn gcWorkspaceSelect_IS_USE = new()
            {
                FieldName = SQL_TXFD_SITE_SET_Table._CDF_IS_USE_,
                Caption = "Use?",
                Width = 30,
                Visible = false
            }; gcWorkspaceSelect_IS_USE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                gcWorkspaceSelect_SNO,
                gcWorkspaceSelect_SITE_NAME,
                gcWorkspaceSelect_LOC_ADDR,
                gcWorkspaceSelect_LOC_ROAD,
                gcWorkspaceSelect_LOC_LATITUDE,
                gcWorkspaceSelect_LOC_LONGITUDE,
                gcWorkspaceSelect_STN_CODE,
                gcWorkspaceSelect_STN_NAME,
                gcWorkspaceSelect_SITE_MEMO,
                gcWorkspaceSelect_REG_DATE,
                gcWorkspaceSelect_MOD_DATE,
                gcWorkspaceSelect_IS_USE
            });
            view.EndUpdate();
        }
        #endregion

        #region AI-OCR
        internal static readonly string _API_URL_Naver_OCR_ = SysEnv.AppConfigSettings.OcrApi.Url; //?? Defs._CALL_URL_NaverOCR_Custom_;
        public static HxResultValue? CallOcrNaverApi_GetJson(Image image, bool isTesting = false)
        {
            HxResultValue Result = null!;
            if (image != null)
            {
                //string imageBase64 = HxImagePicture.GetBase64Encode(image);

                Dictionary<string, object> dictHeader = new Dictionary<string, object>
                {
                    { "Content-Type", $"{SysEnv.AppConfigSettings.OcrApi.ContentType ?? "application/json"}; charset=utf-8" },
                    { "X-OCR-SECRET", HxCrypt.Decrypt(SysEnv.AppConfigSettings.OcrApi.SecretKey, SysEnv.AppConfigSettings.CryptoKey) }
                };
                OCR_NAVER_API_Request_Body raw = new OCR_NAVER_API_Request_Body(image);
                if (raw.images == null || raw.requestId.IsNullOrWhiteSpaceEx() == true) { return null; }
                string strRaw = raw.ToJsonStringEx();
                bool bJsonProcessed = false;
                byte[] bytes = HxUtils.ImageToByteArray(image);
                string strFileChecksum = HxUtils.GetMD5Checksum(bytes);
                if (isTesting == true)
                {
                    string? strSampleFullName = null;
                    
                    if (bytes != null && bytes.Length > 1 && strFileChecksum.IsNullOrWhiteSpaceEx() != true)
                    {
                        if(strFileChecksum.Equals("080033efe6de5c648e1d79b02b178271", StringComparison.OrdinalIgnoreCase) == true) 
                        {
                            strSampleFullName = Path.Combine(GetAppSampleDir(), "Sample01.json"); //663ddf35f000fb03abd7c9a030d75fbb
                        }
                        /*
                        else if (strFileChecksum.Equals("14bd5fef733328805d834e752f3fa1fe", StringComparison.OrdinalIgnoreCase) == true)
                        {
                            strSampleFullName = Path.Combine(GetAppBaseDir(), "Sample", "Sample02.json"); //974552d58d95395cd2b698467f4a877b
                        }
                        */
                        if(strSampleFullName.IsNullOrWhiteSpaceEx() == true)
                        {
                            strSampleFullName = Path.Combine(GetAppSampleDir(false), $"Sample_{strFileChecksum}.json");
                        }
                        if (HxFile.IsFileExists(strSampleFullName) != true)
                        {
                            strSampleFullName = Path.Combine(GetAppOutputDir(false, true), $"OCR_NaverApi_Result_{strFileChecksum}.json"); //663ddf35f000fb03abd7c9a030d75fbb
                        }
                        if (HxFile.IsFileExists(strSampleFullName))
                        {
                            Result = new();
                            Result.Success = false;
                            string strSampleJsonText = HxFile.GetTextFileReadAllText(strSampleFullName);
                            Result.Value = strSampleJsonText;
                            bJsonProcessed = true;
                        }
                    }
                }
                if(bJsonProcessed != true)
                {
                    Result = HxUtils.GetRestClientContentResultValue(_API_URL_Naver_OCR_, RestSharp.Method.Post, dictHeader, strRaw);
                    if(isTesting == true)
                    {
                        string strTestOutputDir = GetAppOutputDir(false, true);
                        if (HxFile.IsDirectoryExists(strTestOutputDir) != true)
                        {
                            HxFile.DirectoryCreate(strTestOutputDir);
                        }
                        string strTestOutputFullName = Path.Combine(strTestOutputDir, $"OCR_NaverApi_Result_{strFileChecksum}.json"); //{DateTime.Now.ToString("yyyyMMdd_HHmmss")}
                        string strResultValue = (Result != null && Result.Value != null) ? Result.Value.ToStringEx() : string.Empty;
                        HxFile.SetTextFileWriteAllText(strTestOutputFullName, strResultValue);
                    }
                    bJsonProcessed = true;
                }
                if (Result != null && Result.Success == true && Result.Value.IsNullOrWhiteSpaceEx() != true)
                {
                    var val = Result.Value;
                    if (val != null)
                    {
                        OCR_NAVER_API_Response_Body obj = HxUtils.JsonDeserializeObject<OCR_NAVER_API_Response_Body>(val);
                        if (obj.images != null && obj.requestId.IsNullOrWhiteSpaceEx() != true)
                        {
                            Debug.WriteLine(obj.GetType()?.Name);
                        }
                    }
                }
            }
            return Result;
        }

        public static HxResultValue? CallSmartDiaryApi_SaveFarmingDiaryPaperItem(TSmartDiaryPaperItem item)
        {
            HxResultValue Result = null!;
            if (item != null && item.DocFileBase64Data.IsNullOrWhiteSpaceEx() != true)
            {
                string apiUrl = @$"{Defs._API_URL_FarmDiary_}/FarmDiary/Create";
                Dictionary<string, object> dictHeader = new Dictionary<string, object>
                {
                    { "Content-Type", "application/json; charset=utf-8" }
                };
                string strRaw = item.ToJsonStringEx();
                Result = HxUtils.GetRestClientContentResultValue(apiUrl, RestSharp.Method.Post, dictHeader, strRaw);
            }
            return Result;
        }

        /*
        public static HxResultValue? CallOcrNaverApi_SaveOcrResultToDb(SQL_TXFD_IMAGE_SET_Table iMAGE_SET_Table, SQL_TXFD_OCR_SET_Table ocrResult, Dictionary<string, string> inputData)
        {
            HxResultValue Result = null!;
            if (iMAGE_SET_Table != null && iMAGE_SET_Table.SNO.IsNullOrWhiteSpaceEx() != true && ocrResult != null && ocrResult.requestId.IsNullOrWhiteSpaceEx() != true)
            {
                string apiUrl = @$"{_API_URL_ROOT_FarmSite__}/api/FarmSite/FarmDiaryOcrResult/Save";
                Dictionary<string, object> dictHeader = new Dictionary<string, object>
                {
                    { "Content-Type", "application/json; charset=utf-8" }
                };
                var requestBody = new
                {
                    ImageSetSNO = iMAGE_SET_Table.SNO,
                    OcrRequestId = ocrResult.requestId,
                    OcrResultJson = ocrResult.ToJsonStringEx()
                };
                string strRaw = HxUtils.JsonSerializeObject(requestBody);
                Result = HxUtils.GetRestClientContentResultValue(apiUrl, RestSharp.Method.Post, dictHeader, strRaw);
            }
            return Result;
        }
        */
        #endregion

        public static HxResultValue CallWeahterAPIbyKMA_GetResultValue(string? stnCode, string? sourceDate = null)
        {
            Dictionary<string, object> dictHeader = new Dictionary<string, object>
            {
                { "Content-Type", "application/json; charset=utf-8" }
            };
            if(stnCode.IsNullOrWhiteSpaceEx() == true && WorkspaceRecordSet != null && WorkspaceRecordSet.Any() == true)
            {
                // Find workspace by stnCode
                var records = WorkspaceRecordSet;
                if (records != null && records.Length > 0)
                {
                    var rec = records.Where(r => r.STN_CODE.Equals(stnCode, StringComparison.OrdinalIgnoreCase)).LastOrDefault();
                    if (rec != null && rec.SNO.IsNullOrWhiteSpaceEx() != true)
                    {
                        stnCode = rec.STN_CODE;
                    }
                }
            }

            if(sourceDate != null && sourceDate.IsNullOrWhiteSpaceEx() != true)
            {
                // Validate sourceDate format (yyyyMMdd)
                if (DateTime.TryParseExact(sourceDate, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt))
                {
                    sourceDate = dt.ToString("yyyyMMdd");
                }
                else
                {
                    sourceDate = null;
                }
            }
            if (sourceDate.IsNullOrWhiteSpaceEx() == true)
            {
                sourceDate = DateTime.Now.ToString("yyyyMMdd");
            }
            string strKmaHomeUrl = $"{SysEnv.AppConfigSettings.WeatherKmaApi.Url}&authKey={HxCrypt.Decrypt(SysEnv.AppConfigSettings.WeatherKmaApi.AuthKey, SysEnv.AppConfigSettings.CryptoKey)}";
            string strKmaStnParam = stnCode.IsNullOrWhiteSpaceEx() != true ? $"&stn={stnCode}" : string.Empty;
            string strKmaTmParam = sourceDate.IsNullOrWhiteSpaceEx() != true ? $"&tm={sourceDate}" : string.Empty;
            string strApiUrl = @$"{strKmaHomeUrl}{strKmaStnParam}{strKmaTmParam}"; //&stn=174&help=1&tm=20251103

            HxResultValue Result = HxUtils.GetRestClientContentResultValue(strApiUrl, RestSharp.Method.Get, dictHeader);

            //HxResultValue Result = HxUtils.GetRestClientContentResultValue(strApiUrl, RestSharp.Method.Get, dictHeader);
            if (Result.Success == true && Result.Value.IsNullOrWhiteSpaceEx() != true)
            {
                var val = Result.Value;
                if (val != null)
                {
                    var obj = val;
                    if (obj != null)
                    {
                        /**
                        var waters = TWaterTypeClasses.Load(@"#START7777
#--------------------------------------------------------------------------------------------------
#  기상청 지상관측 일자료 [입력인수형태][예] ?tm=20100715&stn=0&help=1
#--------------------------------------------------------------------------------------------------
#  1. TM            : 관측일 (KST)
#  2. STN           : 국내 지점번호
#  3. WS_AVG        : 일 평균 풍속 (m/s)
#  4. WR_DAY        : 일 풍정 (m)
#  5. WD_MAX        : 최대풍향
#  6. WS_MAX        : 최대풍속 (m/s)
#  7. WS_MAX_TM     : 최대풍속 시각 (시분)
#  8. WD_INS        : 최대순간풍향
#  9. WS_INS        : 최대순간풍속 (m/s)
# 10. WS_INS_TM     : 최대순간풍속 시각 (시분)
# 11. TA_AVG        : 일 평균기온 (C)
# 12. TA_MAX        : 최고기온 (C)
# 13. TA_MAX_TM     : 최고기온 시가 (시분)
# 14. TA_MIN        : 최저기온 (C)
# 15. TA_MIN_TM     : 최저기온 시각 (시분)
# 16. TD_AVG        : 일 평균 이슬점온도 (C)
# 17. TS_AVG        : 일 평균 지면온도 (C)
# 18. TG_MIN        : 일 최저 초상온도 (C)
# 19. HM_AVG        : 일 평균 상대습도 (%)
# 20. HM_MIN        : 최저습도 (%)
# 21. HM_MIN_TM     : 최저습도 시각 (시분)
# 22. PV_AVG        : 일 평균 수증기압 (hPa)
# 23. EV_S          : 소형 증발량 (mm)
# 24. EV_L          : 대형 증발량 (mm)
# 25. FG_DUR        : 안개계속시간 (hr)
# 26. PA_AVG        : 일 평균 현지기압 (hPa)
# 27. PS_AVG        : 일 평균 해면기압 (hPa)
# 28. PS_MAX        : 최고 해면기압 (hPa)
# 29. PS_MAX_TM     : 최고 해면기압 시각 (시분)
# 30. PS_MIN        : 최저 해면기압 (hPa)
# 31. PS_MIN_TM     : 최저 해면기압 시각 (시분)
# 32. CA_TOT        : 일 평균 전운량 (1/10)
# 33. SS_DAY        : 일조합 (hr)
# 34. SS_DUR        : 가조시간 (hr)
# 35. SS_CMB        : 캄벨 일조 (hr)
# 36. SI_DAY        : 일사합 (MJ/m2)
# 37. SI_60M_MAX    : 최대 1시간일사 (MJ/m2)
# 38. SI_60M_MAX_TM : 최대 1시간일사 시각 (시분)
# 39. RN_DAY        : 일 강수량 (mm)
# 40. RN_D99        : 9-9 강수량 (mm)
# 41. RN_DUR        : 강수계속시간 (hr)
# 42. RN_60M_MAX    : 1시간 최다강수량 (mm)
# 43. RN_60M_MAX_TM : 1시간 최다강수량 시각 (시분)
# 44. RN_10M_MAX    : 10분간 최다강수량 (mm)
# 45. RN_10M_MAX_TM : 10분간 최다강수량 시각 (시분)
# 46. RN_POW_MAX    : 최대 강우강도 (mm/h)
# 47. RN_POW_MAX_TM : 최대 강우강도 시각 (시분)
# 48. SD_NEW        : 최심 신적설 (cm)
# 49. SD_NEW_TM     : 최심 신적설 시각 (시분)
# 50. SD_MAX        : 최심 적설 (cm)
# 51. SD_MAX_TM     : 최심 적설 시각 (시분)
# 52. TE_05         : 0.5m 지중온도 (C) 
# 53. TE_10         : 1.0m 지중온도 (C)
# 54. TE_15         : 1.5m 지중온도 (C)
# 55. TE_30         : 3.0m 지중온도 (C)
# 56. TE_50         : 5.0m 지중온도 (C)
#--------------------------------------------------------------------------------------------------
#2345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123
# YYMMDD STN   WS    WR  WD   WS   WS  WD   WS   WS    TA    TA   TA    TA   TA    TD    TS    TG    HM    HM   HM    PV  EV_S  EV_L    FG     PA     PS     PS   PS     PS   PS   CA   SS   SS   SS    SI    SI   SI     RN     RN    RN     RN   RN     RN   RN     RN   RN     SD   SD     SD   SD    TE    TE    TE    TE    TE
#    KST  ID  AVG   DAY MAX  MAX  MAX INS  INS  INS   AVG   MAX  MAX   MIN  MIN   AVG   AVG   MIN   AVG   MIN  MIN   AVG               DUR    AVG    AVG    MAX  MAX    MIN  MIN  TOT  DAY  DUR  CMB   DAY   60M  60M    DAY    D99   DUR    60M  60M    10M  10M    POW  POW    NEW  NEW    MAX  MAX     5    10    15    30    50
#             m/s     m  16  m/s   TM  16  m/s   TM     C     C   TM     C   TM     C     C     C     %     %   TM   hPa    mm    mm    hr    hPa    hPa    hPa   TM    hPa   TM    %   hr   hr   hr         MAX   TM     mm     mm    hr     mm   TM     mm   TM     mm   TM     cm   TM     cm   TM     C     C     C     C     C
20251105,174,0.6,545,20,2.8,1313,20,4.3,1313,10.0,20.7,1444,3.0,712,4.7,14.0,0.0,75.5,26.0,1446,8.6,-9.0,-9.0,-9.00,1002.1,1022.1,1024.4,52,1018.9,1539,1.1,9.3,10.6,-9.0,-9.00,-9.00,-9,-9.0,-9.0,-9.00,-9.0,-9,-9.0,-9,-9.0,-9,-9.0,-9,-9.0,-9,-99.0,-99.0,-99.0,-99.0,-99.0,
#7777END");
                        */
                        IEnumerable<TWeaterKMA_Response_Body> waters = TWeaterKMA_Response_Body.Load(obj.ToStringEx());
                        Debug.WriteLine(waters);
                        if (waters == null || waters.Any() != true || waters.Count() < 1)
                        {
                            return new HxResultValue() { Success = false, Value = "No weather data found for the specified parameters." };
                        }

                        TWeaterKMA_Response_Body water = waters.LastOrDefault();
                        if(water.TM.IsNullOrWhiteSpaceEx() == true || water.TM.StartsWith("#"))
                        {
                            return new HxResultValue() { Success = false, Value = "No valid weather data found for the specified parameters." };
                        }

                        //Result.Value = water;
                        /*
                        var arr = HxDefaultPropertyInfo.ToLoad(water);
                        var str = HxDefaultPropertyInfo.ToJson(water);

                        var YYMMDD = water.TM;
                        var STN = water.STN;
                        var WS_MAX = water.WS_MAX;          //최대풍속 (m/s)
                        var WS_INS = water.WS_INS;          //최대순간풍속 (m/s)
                        var TA_MAX = water.TA_MAX;          //최고기온 (C)
                        var TA_MAX_TM = water.TA_MAX_TM;    //최고기온 시각 (시분)
                        var TA_MIN = water.TA_MIN;          //최저기온 (C)
                        var TA_MIN_TM = water.TA_MIN_TM;    //최저기온 시각 (시분)
                        var HM_MIN = water.HM_MIN;          //최저습도 (%)
                        var HM_MIN_TM = water.HM_MIN_TM;    //최저습도 시각 (시분)
                        var RN_DAY = water.RN_DAY;          //일 강수량 (mm)
                        */
                            
                    }
                }
                return Result;
            }
            return new HxResultValue() { Success = false, Value = "Weather data was not processed properly during loading." };
        }

        #region Template Files

        internal static string GetTemplateDirFullPath()
        {
            string dirFullPath = Path.Combine(GetAppBaseDir(), Defs._TEMPLATE_DIR_NAME_);
            return dirFullPath;
        }

        //internal static DataTable? TemplateDataTable { get; private set; } = null;
        internal static IEnumerable<TTemplateItem>? FarmingDiaryTemplates { get; private set; }
        internal static BindingList<TTemplateItem> FarmingDiaryTemplateBindingList
        {
            get
            {
                return FarmingDiaryTemplates != null ? new BindingList<TTemplateItem>(FarmingDiaryTemplates.ToList()) : new BindingList<TTemplateItem>();
            }
        }

        internal static void LoadFarmingDiaryTemplate(bool bInit = false)
        {
            /**
            if (TemplateFarmingDiaryDataTable == null || TemplateFarmingDiaryDataTable.Rows.Count < 1 || bInit == true)
            {
                string apiUrl = @$"{_API_URL_ROOT_FarmSite__}/api/FarmSite/FarmDiaryTemplateList/DataTable";
                Dictionary<string, object> dictHeader = new Dictionary<string, object>
                {
                    { "Content-Type", "application/json; charset=utf-8" }
                };
                HxResultValue res = HxUtils.GetRestClientContentResultValue(apiUrl, RestSharp.Method.Get, dictHeader);
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
                                TemplateFarmingDiaryDataTable = dt.Copy();
                                dt.Clear();
                            }
                        }
                    }
                }
            }
            */

            string templateDir = GetTemplateDirFullPath();
            if (HxFile.IsDirectoryExists(templateDir))
            {
                
                var files = HxFile.GetFiles(templateDir, searchPattern: @"tpl-영농일지_R1-*Page*.pdf");
                if (files != null && files.Length > 0)
                {
                    //var match = SbUtils.RegexTagMatchVarNamePattern(_TAG_RESOURCE_TPL_PATTERN_, "tpl-영농일지_R1-(?<TemplateId>.+)-Page(?<PageNo>\\d+)\\.pdf");
                    var regex = new Regex(TDefs._TPL_FILE_PATTERN_, RegexOptions.IgnoreCase);
                    
                    var list = new List<TTemplateItem>();
                    foreach (var file in files)
                    {
                        string fileName = HxFile.GetFileName(file);
                        string fileOnlyName = HxFile.GetFileNameWithOutExt(fileName);
                        
                        Match match = regex.Match(fileName);
                        if (match.Success != true)
                        {
                            continue;
                        }
                        //@"^(?<prefix>tpl)(?:\-|\_)(?<title>영농일지)(?:\-|\_)(?<rev>R[\d]*)(?:\-|\_)(?<page>[\d]*)Page(?:\-|\_)?(?<remark>.*)?(?:\.)(?<ext>pdf)$";
                        //@"^(?<prefix>tpl)(?<delimiter01>-|_)(?<title>영농일지)(?<delimiter02>-|_)R(?<rev>[\d]+)(?<delimiter03>-|_)(?<page>[\d]+)Page(?<delimiter04>-|_)?(?<remark>.*)?(?<delimiter05>.)(?<ext>pdf)$";
                        string templatePage = match.Groups["page"].Value;
                        string templateCode = $"{match.Groups["prefix"].Value}{match.Groups["delimiter01"].Value}{match.Groups["title"].Value}{match.Groups["delimiter02"].Value}R{match.Groups["rev"].Value}{match.Groups["delimiter03"].Value}{match.Groups["page"]}Page";
                        string templateRemark = match.Groups["remark"].Value;
                        if(templateRemark.IsNullOrWhiteSpaceEx() == true)
                        {
                            switch (templatePage)
                            {
                                case "1":
                                case "01":
                                    templateRemark = "영농 일지";
                                    break;
                                case "2":
                                case "02":
                                    templateRemark = "자재 구매 내역";
                                    break;
                                default:
                                    templateRemark = "미분류";
                                    break;
                            }
                        }
                        if (templateRemark.IsNullOrWhiteSpaceEx() == true)
                        {
                            templateRemark = fileOnlyName;
                        }
                        string templateName = templateRemark.Replace('_', ' ');
                        list.Add(new TTemplateItem(templateCode, templateName, file));
                        //TemplateFarmingDiaryBindingList.Add(new TemplateItem(templateId, templateName, file));
                    }
                    FarmingDiaryTemplates = list;
                }
            }

        }
        internal static void InitFarmingDiaryTemplateFromBarItem(DevExpress.XtraBars.BarEditItem sender, BindingList<TTemplateItem>? items)
        {
            if (sender.Edit is not DevExpress.XtraEditors.Repository.RepositoryItemLookUpEditBase cmp) { return; }

            SysEnv.LoadFarmingDiaryTemplate();

            cmp.BeginInit();
            cmp.PopupWidthMode = DevExpress.XtraEditors.PopupWidthMode.ContentWidth;
            cmp.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            cmp.KeyMember = "TemplateCode";
            cmp.ValueMember = "TemplateCode";
            cmp.DisplayMember = "TemplateName";
            cmp.EndInit();

            //cmp.bind = new System.Windows.Forms.BindingContext();
            cmp.DataSource = items;
        }
        #endregion
    }
}
