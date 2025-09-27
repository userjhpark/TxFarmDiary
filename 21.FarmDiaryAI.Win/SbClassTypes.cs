using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIA;

namespace TxFarmDiaryAI.Win
{
    /// <summary>
    /// 스캐너 정보를 담기 위한 도우미 클래스
    /// </summary>
    public class TScannerDevice
    {
        public string DeviceID { get; set; }
        public string DeviceName { get; set; }

        public override string ToString()
        {
            return DeviceName;
        }
    }

    /// <summary>
    /// 스캐너 또는 카메라 장치 정보를 담기 위한 도우미 클래스
    /// </summary>
    public class ImageDevice
    {
        public string DeviceID { get; set; }
        public string DeviceName { get; set; }
        public WiaDeviceType DeviceType { get; set; }

        public override string ToString()
        {
            // 장치 타입에 따라 이름 뒤에 부가 정보 표시
            string typeStr = DeviceType == WiaDeviceType.ScannerDeviceType ? " (스캐너)" : " (카메라)";
            return DeviceName + typeStr;
        }
    }
}
