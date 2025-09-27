using DevExpress.Data.Mask.Internal;
using HxCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WIA;

namespace TxFarmDiaryAI.Win
{
    internal class SbUtils : HxCore.Win.HxWin
    {
        
        public static string? GetLanguageResourceString(string resourceKey, string? cultureName = null)
        {
            string? Result = null;
            if (resourceKey.IsNullOrWhiteSpaceEx() == true) return null;
            if (cultureName.IsNullOrWhiteSpaceEx() != true)
            {
                // cultureName이 null이 아님을 컴파일러에 명확히 알리기 위해 null-forgiving 연산자(!) 사용
                System.Globalization.CultureInfo culture = new(name: cultureName!);
                Result = Properties.Strings.ResourceManager.GetString(resourceKey, culture);
            }
            if (Result.IsNullOrWhiteSpaceEx() == true)
            {
                Result = Properties.Strings.ResourceManager.GetString(resourceKey, Thread.CurrentThread.CurrentCulture);
            }
            if (Result.IsNullOrWhiteSpaceEx() == true)
            {
                //Result = resourceKey; // 리소스 키 자체를 반환
            }
            if(Result.IsNullOrWhiteSpaceEx() == true)
            {
                Result = null;
            }
            return Result;
            //return Properties.Strings.ResourceManager.GetString(resourceKey, Thread.CurrentThread.CurrentUICulture);
        }
        public static List<TScannerDevice>? GetScannerDevices()
        {
            List<TScannerDevice>? Result = null;
            WIA.DeviceManager deviceManager = new();
            if(deviceManager == null || deviceManager.DeviceInfos == null || deviceManager.DeviceInfos.Count == 0)
            {
                return Result;
            }

            Result = [];
            foreach (WIA.DeviceInfo info in deviceManager.DeviceInfos)
            {
                if (info != null && info.DeviceID.IsNullOrWhiteSpaceEx() != true && info.Properties != null && info.Properties.Count > 0)
                {
                    //Console.WriteLine("Scanner: " + info.Properties["Name"].get_Value());
                    if(info.Type != WIA.WiaDeviceType.ScannerDeviceType)
                    {
                        Debug.WriteLine($"[WIA] Not Scanner Device: {info.Type} - {info.Properties["Name"].get_Value()}");
                        continue;
                    }
                    string strDeviceID = info.DeviceID;
                    string strDeviceName = "Unknown Device"; // 기본 장치 이름
                    foreach (dynamic prop in info.Properties)
                    {
                        if (prop is not WIA.Property p) continue;

                        if (p.Name == "Name") // WIA_DIP_DEV_NAME (Device Name)
                        {
                            strDeviceName = p.get_Value();
                            break;
                        }
                    }
                    Result.Add(new TScannerDevice { DeviceID = strDeviceID, DeviceName = strDeviceName });
                }
            }
            //return deviceManager.DeviceInfos.Cast<DeviceInfo>().Select(di => di.Properties["Name"].get_Value()).ToList();
            return Result;
        }

        internal static bool ConnectToScanner(TScannerDevice selectedScanner)
        {
            var deviceManager = new WIA.DeviceManager();
            WIA.Device device = null;

            foreach (WIA.DeviceInfo info in deviceManager.DeviceInfos)
            {
                if (info.DeviceID == selectedScanner.DeviceID)
                {
                    try
                    {
                        device = info.Connect();
                        if (device != null)
                        {
                            Debug.WriteLine($"[WIA] Connected to scanner: {selectedScanner.DeviceName}");
                            return true;
                        }
                        else
                        {
                            Debug.WriteLine($"[WIA] Failed to connect to scanner: {selectedScanner.DeviceName}");
                            return false;
                        }
                    }
                    catch (FileNotFoundException ex)
                    {
                        Debug.WriteLine($"[WIA] Scanner not found: {ex.Message}");
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"[WIA] ConnectToScanner Error: {ex.Message}");
                        return false;
                        //throw;
                    }
                    
                }
            }
            return device != null;
        }

        internal static System.Drawing.Image GetImageFromScanDevice(WIA.Device device)
        {
            System.Drawing.Image Result = null;
            try
            {
                if (device == null || device.Items == null || device.Items.Count < 1)
                {
                    Debug.WriteLine("[WIA] ScanImageFromDevice Error: Device or Items is null or empty.");
                    return Result;
                }

                WIA.Item item = device.Items[1]; // 1-based index
                string formatID = "{B96B3CAF-0728-11D3-9D7B-0000F81EF32E}"; // wiaFormatPNG
                //WIA.FormatID.wiaFormatPNG //  "{B96B3CAF-0728-11D3-9D7B-0000F81EF32E}"
                //WIA.FormatID.wiaFormatJPEG // "{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}"
                WIA.ImageFile image = (WIA.ImageFile)new WIA.CommonDialog().ShowTransfer(item, formatID, false);
                if (image != null)
                {
                    //image.SaveFile()
                    var imageBytes = (byte[])image.FileData.get_BinaryData();
                    using (var ms = new MemoryStream(imageBytes))
                    {
                        Result = System.Drawing.Image.FromStream(ms);
                        Debug.WriteLine(Result.RawFormat);
                    }
                }
            }

            catch (System.Runtime.InteropServices.COMException comEx)
            {
                if (comEx.ErrorCode == unchecked((int)0x80210067))
                {
                    Debug.WriteLine($"사용자가 스캔을 취소했습니다: {comEx.Message}");
                }

                // 사용자가 스캔을 취소한 경우 (0x80210067)는 일반적인 상황이므로 오류 메시지를 표시하지 않음
                if (comEx.ErrorCode != -2145320857)
                {
                    Debug.WriteLine($"스캔 중 오류가 발생했습니다: {comEx.Message}");
                }
                
                Result = null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[WIA] ScanImageFromDevice Error: {ex.Message}");
                //throw ex;
            }
            return Result;
        }
    }
}
