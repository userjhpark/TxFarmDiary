using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HxCore;

namespace TxFarmDiaryAI
{
    public class TConfigAppSettings
    {
        public const string _CONFIG_FILE_NAME_ = "Config.json";

        public string CryptoKey { get; set; } = string.Empty;
        public string CultureName { get; set; } = "en-US";//"ko-KR";

        public TDatabaseConnection Database { get; set; } = new TDatabaseConnection();
        public TOcrApiConnection OcrApi { get; set; } = new TOcrApiConnection();
        public TWeatherKmaApiConnection WeatherKmaApi { get; set; } = new TWeatherKmaApiConnection();

        public TConfigAppSettings()
        {

        }

        public void InitLoad()
        {
            if (HxFile.IsFileExists(_CONFIG_FILE_NAME_) != true)
            {
                var defaultConfig = new TConfigAppSettings();
                defaultConfig.DefaultValue();
                defaultConfig.Save();
            }
            if (HxFile.IsFileExists(_CONFIG_FILE_NAME_) == true)
            {
                Load(_CONFIG_FILE_NAME_);
            }
        }

        private void DefaultValue()
        {
            this.CryptoKey = string.Empty;
            this.CultureName = "en-US";
            this.Database = new TDatabaseConnection();
            this.OcrApi = new TOcrApiConnection();
            this.WeatherKmaApi = new TWeatherKmaApiConnection();
            this.Database.DbHost = "localhost";
            this.Database.DbPort = "1521";
            this.Database.DbUser = "your_db_user";
            this.Database.DbPassword = "your_db_password";
            this.OcrApi.Url = "https://api.example.com/ocr";
            this.OcrApi.ContentType = "application/json";
            this.OcrApi.SecretKey = "your_ocr_api_secret_key";
            this.WeatherKmaApi.Url = "https://api.kma.go.kr/weather";
            this.WeatherKmaApi.AuthKey = "your_weather_kma_api_auth_key";
        }

        public static void DefaultSave(string? fileName = null)
        {
            if(fileName.IsNullOrWhiteSpaceEx() == true)
            {
                fileName = _CONFIG_FILE_NAME_;
            }
            TConfigAppSettings config = new TConfigAppSettings();
            config.DefaultValue();

            config.Save(fileName);
        }

        public void Load(string fileName)
        {
            if (System.IO.File.Exists(fileName) == true)
            {
                string jsonText = System.IO.File.ReadAllText(fileName, Encoding.UTF8);
                TConfigAppSettings? config = System.Text.Json.JsonSerializer.Deserialize<TConfigAppSettings>(jsonText);
                if (config != null)
                {
                    this.CryptoKey = config.CryptoKey;
                    this.Database = config.Database;
                    this.OcrApi = config.OcrApi;
                    this.WeatherKmaApi = config.WeatherKmaApi;
                }
            }
        }
        public void Save(string? fileName = null)
        {
            if (fileName.IsNullOrWhiteSpaceEx() == true)
            {
                fileName = _CONFIG_FILE_NAME_;
            }
            string jsonText = System.Text.Json.JsonSerializer.Serialize<TConfigAppSettings>(this, new System.Text.Json.JsonSerializerOptions() { WriteIndented = true });
            try
            {
                System.IO.File.WriteAllText(fileName!, jsonText, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Config Save Error: {ex.Message}");
                //throw ex;
            }
            
        }
        public static TConfigAppSettings LoadConfig(string fileName)
        {
            TConfigAppSettings config = new TConfigAppSettings();
            config.Load(fileName);
            return config;
        }
        public static void SaveConfig(string fileName, TConfigAppSettings config)
        {
            config.Save(fileName);
        }
        
    }

    public class TDatabaseConnection
    {
        public string DbHost { get; set; } = "localhost";
        public string DbPort { get; set; } = "1521";
        public string DbName { get; set; } = "ORCL";
        public string DbUser { get; set; } = string.Empty;
        public string DbPassword { get; set; } = string.Empty;
    }
    public class TOcrApiConnection
    {
        public string Url { get; set; } = string.Empty;
        public string ContentType { get; set; } = "application/json";
        public string SecretKey { get; set; } = string.Empty;
    }
    public class TWeatherKmaApiConnection
    {
        public string Url { get; set; } = string.Empty;
        public string AuthKey { get; set; } = string.Empty;
    }
}
