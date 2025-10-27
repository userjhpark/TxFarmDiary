using DevExpress.Map.Native;
using DevExpress.Utils;
using HxCore;
using HxCore.Win;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WIA;

using Utils = TxFarmDiaryAI.Win.SbUtils;

namespace TxFarmDiaryAI.Win
{
    
    /// <summary>
    /// 스캐너 정보를 담기 위한 도우미 클래스
    /// </summary>
    public class SbScannerDevice
    {
        [JsonProperty("deviceID"), JsonPropertyName("deviceID")]
        public string DeviceID { get; set; }
        [JsonProperty("deviceName"), JsonPropertyName("deviceName")]
        public string DeviceName { get; set; }

        public override string ToString()
        {
            return DeviceName;
        }
    }

    /// <summary>
    /// 스캐너 또는 카메라 장치 정보를 담기 위한 도우미 클래스
    /// </summary>
    public class SbImageDevice
    {
        [JsonPropertyName("deviceID"), JsonProperty("deviceID")]
        public string DeviceID { get; set; }
        [JsonPropertyName("deviceName"), JsonProperty("deviceName")]
        public string DeviceName { get; set; }
        [JsonPropertyName("deviceType"), JsonProperty("deviceType")]
        public WiaDeviceType DeviceType { get; set; }

        public override string ToString()
        {
            // 장치 타입에 따라 이름 뒤에 부가 정보 표시
            string typeStr = DeviceType == WiaDeviceType.ScannerDeviceType ? " (Scanner)" : " (Camera)";
            return DeviceName + typeStr;
        }
    }

    
}
