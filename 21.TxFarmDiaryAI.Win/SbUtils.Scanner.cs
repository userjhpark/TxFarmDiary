using DevExpress.Pdf.Native;
using HxCore;
using iTextSharp.text.html.simpleparser;
using NAPS2.Wia;

//using NAPS2.Wia;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
//using WIA;

namespace TxFarmDiaryAI.Win
{
    partial class SbUtils
    {
        public static List<SbScannerDevice>? GetScannerComWIADevices()
        {
            List<SbScannerDevice>? Result = null;
            WIA.DeviceManager deviceManager = new();
            if (deviceManager == null || deviceManager.DeviceInfos == null || deviceManager.DeviceInfos.Count == 0)
            {
                return Result;
            }

            Result = [];
            foreach (WIA.DeviceInfo info in deviceManager.DeviceInfos)
            {
                if (info != null && info.DeviceID.IsNullOrWhiteSpaceEx() != true && info.Properties != null && info.Properties.Count > 0)
                {
                    //Console.WriteLine("Scanner: " + info.Properties["Name"].get_Value());
                    if (info.Type != WIA.WiaDeviceType.ScannerDeviceType)
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
                    Result.Add(new SbScannerDevice { DeviceID = strDeviceID, DeviceName = strDeviceName });
                }
            }
            //return deviceManager.DeviceInfos.Cast<DeviceInfo>().Select(di => di.Properties["Name"].get_Value()).ToList();
            return Result;
        }

        public static List<SbScannerDevice>? GetScannerNaps2WiaDevices()
        {
            using NAPS2.Wia.WiaDeviceManager deviceManager = new();
            if (deviceManager == null || deviceManager.GetDeviceInfos() == null || deviceManager.GetDeviceInfos().Any() != true) { return null; }

            List<SbScannerDevice>? Result = [];

            IEnumerable<WiaDeviceInfo> deviceInfos = deviceManager.GetDeviceInfos();
            foreach (NAPS2.Wia.WiaDeviceInfo deviceInfo in deviceInfos)
            {
                using (deviceInfo)
                {
                    string id = deviceInfo.Id();
                    string name = deviceInfo.Name();
                    //var device = deviceInfo.
                    if (name.Equals(@"No friendly name", StringComparison.InvariantCultureIgnoreCase))
                    {
                        // Some Windows/driver issues can result in the scanner name appearing as "No friendly name".
                        // Better to replace with a generic "Unknown Scanner" string.
                        name = "Unknown Scanner";
                    }
                    Result.Add(new SbScannerDevice { DeviceID = id, DeviceName = name });
                }
            }
            return Result;
        }

        internal static bool ConnectToScannerComWIA(SbScannerDevice selectedScanner)
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

        internal static bool ConnectToScannerMaps2Wia(SbScannerDevice selectedScanner)
        {
            return false;

            using NAPS2.Wia.WiaDeviceManager deviceManager = new();
            if (deviceManager == null || deviceManager.GetDeviceInfos() == null || deviceManager.GetDeviceInfos().Any() != true) { return false; }

            foreach (WiaDeviceInfo deviceInfo in deviceManager.GetDeviceInfos())
            {
                using (deviceInfo)
                {
                    string id = deviceInfo.Id();
                    string name = deviceInfo.Name();
                    WiaDevice device = deviceManager.FindDevice(id);
                    //device.
                    if (name.Equals(@"No friendly name", StringComparison.InvariantCultureIgnoreCase))
                    {
                        // Some Windows/driver issues can result in the scanner name appearing as "No friendly name".
                        // Better to replace with a generic "Unknown Scanner" string.
                        name = "Unknown Scanner";
                    }
                    //new ScannerDevice { DeviceID = id, DeviceName = name });

                    if (id == selectedScanner.DeviceID)
                    {
                        try
                        {
                            if (deviceInfo != null)
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
            }
        }

        internal static System.Drawing.Image? GetImageFromScanDevice(WIA.Device device)
        {
            System.Drawing.Image? Result = null;
            try
            {
                if (device == null || device.Items == null || device.Items.Count < 1)
                {
                    Debug.WriteLine("[WIA] ScanImageFromDevice Error: Device or Items is null or empty.");
                    return Result;
                }

                WIA.Item item = device.Items[1]; // 1-based index
                string formatID = "{B96B3CAF-0728-11D3-9D7B-0000F81EF32E}";
                //string formatID = "{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}";
                //WIA.FormatID.wiaFormatBMP //{B96B3CAB-0728-11D3-9D7B-0000F81EF32E}
                //WIA.FormatID.wiaFormatPNG //  "{B96B3CAF-0728-11D3-9D7B-0000F81EF32E}"
                //WIA.FormatID.wiaFormatJPEG // "{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}"

                WIA.ImageFile wiaImage = (WIA.ImageFile)new WIA.CommonDialog().ShowTransfer(item, formatID, false);
                //WIA.ImageFile image = (WIA.ImageFile)new WIA.CommonDialog().ShowTransfer(item);
                if (wiaImage != null)
                {
                    //image.SaveFile()
                    //var imageBytes = (byte[])image.FileData.get_BinaryData();
                    
                    var imageBytes = (byte[])wiaImage.FileData.get_BinaryData();
                    using MemoryStream ms = new(imageBytes);
                    //Result = System.Drawing.Image.FromStream(ms);
                    using Image img = Image.FromStream(ms);
                    using Bitmap pic = new(img);
                    Result = pic.Clone() as Image;
                    //Result = System.Drawing.Image.FromStream(ms)?.Clone() as Image;
                    /*
                    var bitmap = System.Drawing.Bitmap.FromStream(ms);
                    Result = (Bitmap)bitmap.Clone();
                    */
                    Debug.WriteLine(Result?.RawFormat);
                    return Result;
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
