using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmDiaryAI.Win
{
    internal class SbConfigManager
    {
        private const string ConfigFilePath = "Config.json";
        public AppConfig Config { get; private set; }

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
                Config = new AppConfig
                {
                    Version = new Version(Application.ProductVersion),
                    SmtpSettings = new SmtpSettings(),
                    Servers = new List<ServerInfo>()
                };
                SaveConfig(); // 기본 파일 생성
            }
        }

        public void SaveConfig()
        {
            var json = JsonConvert.SerializeObject(Config, Formatting.Indented);
            File.WriteAllText(ConfigFilePath, json);
        }

        public void AddServer(ServerInfo server)
        {
            Config.Servers.Add(server);
            SaveConfig();
        }

        public void UpdateManualUrl(string url)
        {
            Config.ManualUrl = url;
            SaveConfig();
        }
    }
    public class SmtpSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }

    public class ServerInfo
    {
        public string Name { get; set; }
        public string WebApiUrl { get; set; }
        public string FileServerUrl { get; set; }
    }

    public class AppConfig
    {
        public Version Version { get; set; }
        public SmtpSettings SmtpSettings { get; set; }
        public string ManualUrl { get; set; }
        public List<ServerInfo> Servers { get; set; }
    }
}
