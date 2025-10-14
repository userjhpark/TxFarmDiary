using HxCore;
using System;
using System.Globalization;
using TxFarmDiaryAI.Common;

namespace TxFarmDiaryAI
{
    public partial class TResourceLanguageStrings // : HxCore.HxUtils
    {
        #region Static
        public static TResourceLanguageStrings Instance { get; protected set; } = new();
        public static TResourceLanguageStrings CreateInstance() { return new(); }
        public static TResourceLanguageStrings GetInstance(bool condition = false) { return (condition == true ? Instance : CreateInstance()) ?? (Instance = CreateInstance()); }
        #endregion

        private string fCultureName = "en-US"; //CultureInfo.InstalledUICulture.Name; //= CultureInfo.InstalledUICulture.Name; //string.Empty; //= "ko-KR"; //"en-US";
        public CultureInfo Culture { get; protected set; } = CultureInfo.GetCultureInfo("en-US"); // CultureInfo.InstalledUICulture;
        
        public string CultureName 
        {
            get 
            { 
                return this.GetCultureName(); 
            }
            protected set
            {
                this.SetCultureName(value);
            }
        }

        public System.Resources.ResourceManager? ResourceManager { get; internal set; } = null;

        public TResourceLanguageStrings(string? cultureName = null)
        {
            LoadCultureResourceManager(cultureName.ToStringEx());
        }
        public void LoadCultureResourceManager(string cultureName = "en-US")
        {
            string namespaceName = "TxFarmDiaryAI";
            string resourceBaseName = $"{namespaceName}.Common.Strings";
            this.ResourceManager = new System.Resources.ResourceManager(resourceBaseName, typeof(TResourceLanguageStrings).Assembly) ?? Strings.ResourceManager;
            //this.ResourceManager = Strings.ResourceManager;
            //ResourceManager = new System.Resources.ResourceManager(resourceBaseName);

            //Thread.CurrentThread.CurrentCulture = new CultureInfo("ko-KR");
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            //Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            //string cultureName = "ko-KR"; // "en-US";
            //string cultureName = "en-US";

            SetCultureName(cultureName);

            this.CultureName = cultureName;
        }
        public string GetCultureName()
        {
            return this.fCultureName;
        }

        public void SetCultureName(string? cultureName = null)
        {
            //"en-US"; // "ko-KR";
            string strCultureName = cultureName.ToStringEx();
            if (strCultureName.IsNullOrWhiteSpaceEx())
            {
                strCultureName = this.CultureName;
            }
            if (strCultureName.IsNullOrWhiteSpaceEx() == true)
            {
                strCultureName = CultureInfo.InstalledUICulture.Name;
            }
            if (this.CultureName.IsNullOrWhiteSpaceEx() == true) 
            { 
                this.CultureName = strCultureName;
            }

            if (strCultureName.IsNullOrWhiteSpaceEx() != true)
            {
                this.fCultureName = strCultureName;
                this.Culture = new(name: cultureName!);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(this.fCultureName);

                Thread.CurrentThread.CurrentCulture = new CultureInfo(this.fCultureName);
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
                if (this.fCultureName == "ko-KR")
                {
                    Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol = "₩";
                }
                else if (this.fCultureName == "en-US")
                {
                    Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol = "$";
                }
                else
                {
                    Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol = "$";
                }
            }
            
        }

        public string? GetResourceLanguageString(string resourceKey, string? cultureName = null)
        {
            string? Result = null;
            if (resourceKey.IsNullOrWhiteSpaceEx() == true) return null;
            if (cultureName.IsNullOrWhiteSpaceEx() != true)
            {
                // cultureName이 null이 아님을 컴파일러에 명확히 알리기 위해 null-forgiving 연산자(!) 사용
                System.Globalization.CultureInfo culture = new(name: cultureName!);
                Result = Strings.ResourceManager.GetString(resourceKey, culture);
            }
            if (Result.IsNullOrWhiteSpaceEx() == true)
            {
                Result = Strings.ResourceManager.GetString(resourceKey, Thread.CurrentThread.CurrentCulture);
            }
            if (Result.IsNullOrWhiteSpaceEx() == true)
            {
                //Result = resourceKey; // 리소스 키 자체를 반환
            }
            if (Result.IsNullOrWhiteSpaceEx() == true)
            {
                Result = null;
            }
            return Result;
            //return Properties.Strings.ResourceManager.GetString(resourceKey, Thread.CurrentThread.CurrentUICulture);
        }
    }
}
