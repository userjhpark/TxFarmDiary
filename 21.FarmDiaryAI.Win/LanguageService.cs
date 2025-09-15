using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmDiaryAI.Win
{
    // Static 클래스 또는 싱글톤 서비스로 정의
    public static class LanguageService
    {
        public static event EventHandler? LanguageChanged;

        public static void SetLanguage(string cultureName)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureName);
            LanguageChanged?.Invoke(null, EventArgs.Empty); // 이벤트 발생
        }
    }
}
