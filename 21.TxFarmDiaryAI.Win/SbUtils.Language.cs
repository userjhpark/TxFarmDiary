using DevExpress.XtraEditors;
using HxCore;
using HxCore.Win;

namespace TxFarmDiaryAI.Win
{
    partial class SbUtils
    {
        public static TResourceLanguageStrings ResourceLanguageStrings => TResourceLanguageStrings.Instance;
        private static System.Resources.ResourceManager? ResourceManager => ResourceLanguageStrings.ResourceManager;
        //private const string _TAG_RESOURCE_TPL_PATTERN_ = @"(\{)(RESX|RES|LNG|LANG|LOC|LOCALIZE|LOCALIZATION)(:)([a-zA-Z0-9_\-\.]+)(\})";
        //private const string _TAG_RESOURCE_TPL_PATTERN_ = @"(\{{\#)(\w+)(\}})";
        // 각 컨트롤과 그 컨트롤이 사용할 리소스 키를 매핑하는 사전
        private static readonly Dictionary<Control, string?> _localizedControls = new Dictionary<Control, string?>();

        internal static void LoadCultureResourceManager(string cultureName)
        {
            //throw new NotImplementedException();
            ResourceLanguageStrings.LoadCultureResourceManager(cultureName);
        }

        public static string? GetLanguageResourceString(string resourceKey, string? cultureName = null, string? defaultText = null)
        {
            string? Result = null;
            if (resourceKey.IsNullOrWhiteSpaceEx() == true) return null;
            if (cultureName.IsNullOrWhiteSpaceEx() != true)
            {
                // cultureName이 null이 아님을 컴파일러에 명확히 알리기 위해 null-forgiving 연산자(!) 사용
                System.Globalization.CultureInfo culture = new(name: cultureName!);
                Result = ResourceManager?.GetString(resourceKey, culture);
            }
            if (Result.IsNullOrWhiteSpaceEx() == true)
            {
                Result = ResourceManager?.GetString(resourceKey, Thread.CurrentThread.CurrentCulture);
            }
            if (Result.IsNullOrWhiteSpaceEx() == true)
            {
                //Result = resourceKey; // 리소스 키 자체를 반환
            }
            if (Result.IsNullOrWhiteSpaceEx() == true)
            {
                Result = null;
            }
            if(Result.IsNullOrWhiteSpaceEx() == true && defaultText.IsNullOrWhiteSpaceEx() != true)
            {
                Result = defaultText;
            }
            return Result;
            //return Properties.Strings.ResourceManager.GetString(resourceKey, Thread.CurrentThread.CurrentUICulture);
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
            if (resourceKey.IsNullOrWhiteSpaceEx() == true)
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
            string? strLocalizedValue = GetLanguageResourceString(resourceKey, SysEnv.CultureName);

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

        
        internal static void SetLocalizedUpdateControlAllToText(Control control)
        {
            IEnumerable<Control> q = HxWin.GetFindAllControl<Control>(control);
            SetLocalizedUpdateResourceKeyListToText(q);
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
            System.Resources.ResourceManager resourceManager = ResourceManager!;
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
            DoLocalizedUpdateConrolTagMatchToText(q);
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

                System.Text.RegularExpressions.MatchCollection match = strControlTag.RegexMatchesEx(Defs._TPL_RESOURCE_TAG_PATTERN_, System.Text.RegularExpressions.RegexOptions.Multiline);
                if (match == null || match.Count <= 0) continue;

                string strNewText = strControlTag;

                foreach (System.Text.RegularExpressions.Match m in match)
                {
                    if (m == null || m.Groups.Count < 3) continue;

                    string strTplName = m.Groups[2].Value;
                    if (strTplName.IsNullOrWhiteSpaceEx() == true) continue;

                    string strResourceKey = strTplName;
                    //string? strResourceValue = GetLocalizedResourceKeyValue(strResourceKey);
                    string? strResourceValue = GetLanguageResourceString(strResourceKey);
                    if (strResourceValue.IsNullOrWhiteSpaceEx() == true) continue;

                    strNewText = strNewText.Replace(m.Value, strResourceValue);
                }

                if (strNewText != strControlTag)
                {
                    control.Text = strNewText;
                }
            }
            Application.DoEvents();
        }
    }
}
