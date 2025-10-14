using HxCore;
using MongoDB.Bson.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Math.EC.ECCurve;
using Newtonsoft.Json;
using JsonConvert = Newtonsoft.Json.JsonConvert;

namespace TxFarmDiaryAI
{
    public class TSmtpSettings
    {
        public string Host { get; set; } = string.Empty;
        public int? Port { get; set; } = null;
        public bool IsUseSsl { get; set; } = false;
        public bool? IsUseTls { get; set; } = null;
        public string User { get; set; } = string.Empty;
        public string Password { get; protected set; } = string.Empty;

        public void SetPassword(string password, string key = "password")
        {
            Password = HxCrypt.Encrypt(password, key);
        }
    }
    public class TDatabaseSettings
    {
        //protected string ConnectionString { get; set; }
        //public int ConnectionTimeout { get; set; }
        public HxDbProviderType ProviderType { get; set; }
        public string UserID { get; set; } = string.Empty;
        public string Password { get; protected set; } = string.Empty;
        public string Host { get; set; } = string.Empty;
        public int Port { get; set; }
        public string DatabaseName { get; set; } = string.Empty;

        public void SetPassword(string password, string key = "password")
        {
            Password = HxCrypt.Encrypt(password, key);
        }
    }

    public class TServiceSettings
    {
        public Version? Version { get; set; } = null;
        public TSmtpSettings? SmtpSettings { get; set; } = null;
        public TDatabaseSettings? DatabaseSettings { get; set; } = null;
    }

    public class TServiceManager
    {
        private static readonly Version version = new Version(1, 0, 0, 0);
        private static readonly string DefaultServiceFileName = "Service.json";
        
        private TServiceSettings setting { get; set; }
        public TServiceManager() 
        {
        }

        public void LoadSettings(string? fileName = null, bool isNotFileExistToDefaultCreateFile = true)
        {
            string? strFileName = null;
            if(fileName.IsNullOrWhiteSpaceEx() == true)
            {
                strFileName = DefaultServiceFileName;
            }
            else
            {
                strFileName = fileName;
            }

            if (HxFile.IsFileExists(strFileName) == true)
            {
                var json = HxUtils.FileReadAllTextToString(strFileName);
                var obj = HxUtils.ConvertJsonDeserialize<TServiceSettings>(json);
            }

        }

        //기본 설정 Service.json파일 만들기
        public void CreateDefaultFile()
        {
            //JsonConvert.
        }
    }
}