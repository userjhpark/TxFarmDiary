using HxCore;
using HxCore.Win;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WIA;

using Utils = TxFarmDiaryAI.Win.SbUtils;

namespace TxFarmDiaryAI.Win
{
    
    /// <summary>
    /// 스캐너 정보를 담기 위한 도우미 클래스
    /// </summary>
    public class ScannerDevice
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
            string typeStr = DeviceType == WiaDeviceType.ScannerDeviceType ? " (Scanner)" : " (Camera)";
            return DeviceName + typeStr;
        }
    }

    public class TXFD_IMAGE_ITEM
    {
        public int Index { get; set; }
        
        public Image ImageData { get; set; }
        public byte[] ImageBytes => Utils.ImageToByteArray(ImageData); //public byte[] ImageBytes { get; set; }
        public long FileSize => ImageBytes.LongLength; //public long FileSize { get; set; }
        public string FileChecksum => Utils.GetMD5Checksum(ImageData); //public string FileChecksum { get; set; } => 
        //public string FilePath { get; set; }
        //public string FileName { get; set; }
        public string FileExt => Utils.GetImageFormatString(ImageData); //public string FileExt { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        //public DateTime ModifiedTime { get; set; }
        
        
        public TXFD_IMAGE_ITEM()
        {
            
            Index = -1;
            ImageData = null!;
            //ImageBytes = Array.Empty<byte>();
            //FileSize = 0;
            //FileChecksum = string.Empty;
            //FilePath = string.Empty;
            //FileName = string.Empty;
            //FileExt = string.Empty;
            CreatedTime = DateTime.Now;
            //ModifiedTime = DateTime.MinValue;
        }
    }
}
