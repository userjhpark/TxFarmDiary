using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmDiaryAI.Win
{
    internal class SbConfigManager
    {
        private const string ConfigFilePath = "Config.json";
        // 'Config' 속성을 nullable로 선언하여 CS8618 경고를 해결합니다.
        public AppConfig? Config { get; private set; }

        public SbConfigManager()
        {
            LoadConfig();
        }

        public void LoadConfig()
        {
            if (File.Exists(ConfigFilePath))
            {
                var json = File.ReadAllText(ConfigFilePath);
                Config = JsonConvert.DeserializeObject<AppConfig>(json);
            }
            else
            {
                try
                {
                    Config = new AppConfig
                    {
                        Version = new Version(Application.ProductVersion),
                        SmtpSettings = new SmtpSettings(),
                        Servers = new List<ServerInfo>()
                    };
                    
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Config 파일 생성에 실패했습니다.");
                    //throw;
                }
                finally
                {
                    SaveConfig(); // 기본 파일 생성
                }
            }
        }

        public void SaveConfig()
        {
            var json = JsonConvert.SerializeObject(Config, Formatting.Indented);
            File.WriteAllText(ConfigFilePath, json);
        }

        public void AddServer(ServerInfo server)
        {
            try
            {
                if (Config?.Servers == null)
                    throw new InvalidOperationException("Config 또는 Servers가 초기화되지 않았습니다.");
                Config.Servers.Add(server);
            }
            catch (Exception)
            {
                Debug.WriteLine("서버 추가에 실패했습니다.");
                //throw;
            }
            
            SaveConfig();
        }

        public void UpdateManualUrl(string url)
        {
            try
            {
                if (Config == null)
                    throw new InvalidOperationException("Config가 초기화되지 않았습니다.");
                Config.ManualUrl = url;
            }
            catch (Exception)
            {
                Debug.WriteLine("Manual URL 업데이트에 실패했습니다.");
                //throw;
            }
            SaveConfig();
        }
    }
    public class SmtpSettings
    {
        public string Host { get; set; } = string.Empty;
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
        public string User { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class ServerInfo
    {
        public string Name { get; set; } = string.Empty;
        public string WebApiUrl { get; set; } = string.Empty;
        public string FileServerUrl { get; set; } = string.Empty;
    }

    public class AppConfig
    {
        public Version Version { get; set; } = new Version();
        public SmtpSettings SmtpSettings { get; set; } = new SmtpSettings();
        public string ManualUrl { get; set; } = string.Empty;
        public List<ServerInfo> Servers { get; set; } = new List<ServerInfo>();
    }
}
