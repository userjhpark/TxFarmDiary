using HxCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxFarmDiaryAI
{
    public enum ResponseResultValueCaseType
    {
        None = 0,
        Json,
        Text,
        Serialize,
        Array,
        Base64,
        Default = Json,
        String = Text,
        DataTable = Serialize,
        Object = Serialize,
        Class = Serialize,
        List = Array
    }

    public class TImageCartItem
    {
        public int Index { get; set; }
        public string? Name { get; set; }

        public Image ImageData { get; set; }
        public byte[] ImageBytes => HxUtils.ImageToByteArray(ImageData); //public byte[] ImageBytes { get; set; }
        public long FileSize => ImageBytes.LongLength; //public long FileSize { get; set; }
        public string FileChecksum => HxUtils.GetMD5Checksum(ImageData); //public string FileChecksum { get; set; } => 
        //public string FilePath { get; set; }
        //public string FileName { get; set; }
        public string FileExt => HxUtils.GetImageFormatString(ImageData); //public string FileExt { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        //public DateTime ModifiedTime { get; set; }


        public TImageCartItem()
        {

            Index = -1;
            Name = null;
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

        public TImageCartItem(string fileFullName)
            : this()
        {
            if (fileFullName.IsNullOrWhiteSpaceEx() != true && HxFile.IsFileExists(fileFullName))
            {
                try
                {
                    Image? img = null;
                    string strFileExt = HxFile.GetFileExt(fileFullName).ToLower();
                    switch (strFileExt)
                    {
                        case "jpeg":
                        case "jpg":
                        case "png":
                        case "gif":
                        case "bmp":
                            img = Image.FromFile(fileFullName);
                            break;
                        default:
                            break;
                    }
                    if (img == null || img.Width <= 0 || img.Height <= 0) { return; }

                    if (img.RawFormat.Equals(ImageFormat.Png)
                        || img.RawFormat.Equals(ImageFormat.Jpeg)
                        || img.RawFormat.Equals(ImageFormat.Bmp)
                        || img.RawFormat.Equals(ImageFormat.Gif)
                    //|| img.RawFormat.Equals(ImageFormat.MemoryBmp)
                    )
                    {
                        this.Name = fileFullName;
                        this.ImageData = img;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    //throw;
                }
            }
        }
    }

    public class TTemplateItem
    {
        [JsonProperty("TemplateCode"), Description("Code")]
        public string TemplateCode;
        [JsonProperty("TemplateName"), Description("Name"), DisplayName("Tempate Name")]
        public string TemplateName { get; set; }
        [JsonProperty("TemplateFullPath"), Description("Path")]
        public string TemplateFullPath;
        public TTemplateItem(string templateCode, string templateName, string templateFullPath)
        {
            TemplateCode = templateCode;
            TemplateName = templateName;
            TemplateFullPath = templateFullPath;
        }
        public void Claer()
        {
            TemplateCode = string.Empty;
            TemplateName = string.Empty;
            TemplateFullPath = string.Empty;
        }
        public bool IsEmpty()
        {
            return TemplateCode.IsNullOrWhiteSpaceEx()
                && TemplateName.IsNullOrWhiteSpaceEx()
                && TemplateFullPath.IsNullOrWhiteSpaceEx();
        }
        public bool IsValid()
        {
            return TemplateCode.IsNullOrWhiteSpaceEx() != true
                && TemplateName.IsNullOrWhiteSpaceEx() != true
                && TemplateFullPath.IsNullOrWhiteSpaceEx() != true;
        }
    }
    public class TSmartDiaryPaperItem : IDisposable
    {
        public decimal? SNO { get; set; }
        public DateTime? DiaryDate { get; set; }
        public decimal? UNO { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        public string? DocTemplateCode { get; set; }
        public string? DocTemplateName { get; set; }
        public string? DocFileBase64Data { get; set; }
        public string? DocFileBase64Checksum => HxUtils.GetMD5String(DocFileBase64Data);
        public string? DocFileName { get; set;  }
        public string? DocFileChecksum { get; set; }
        public Dictionary<string, string>? DocFieldsData { get; set; }

        public string? OcrTemplateCode { get; set; }
        public string? OcrTemplateName { get; set; }
        public string? OcrImageName { get; set; }
        public string? OcrImageChecksum { get; set; }
        public string? OcrImageBase64Data { get; set; }
        public string? OcrImageBase64Checksum => HxUtils.GetMD5String(OcrImageBase64Data);
        public Dictionary<string, string>? OcrFieldsData { get; set; }
        public OCR_NAVER_API_Response_Body? OcrJsonData { get; set; }

        public TSmartDiaryPaperItem()
        {
            Clear();
        }

        public void Clear(bool isDispose = false)
        {
            SNO = null;
            DiaryDate = null;
            UNO = null;
            Title = string.Empty;
            Description = string.Empty;

            DocTemplateCode = string.Empty;
            DocTemplateName = string.Empty;
            DocFileName = string.Empty;
            DocFileChecksum = string.Empty;
            DocFileBase64Data = string.Empty;
            if (isDispose != true)
            {
                DocFieldsData = new Dictionary<string, string>();
            }
            OcrTemplateCode = string.Empty;
            OcrTemplateName = string.Empty;
            OcrImageBase64Data = string.Empty;
            OcrImageChecksum = string.Empty;
            if (isDispose != true)
            {
                OcrFieldsData = new Dictionary<string, string>();
                OcrJsonData = new OCR_NAVER_API_Response_Body();
            }

            if(isDispose == true)
            {
                DocFileBase64Data = null;
                OcrImageBase64Data = null;
                DocFieldsData = null;
                OcrFieldsData = null;
                OcrJsonData = null;
            }
        }

        public void Dispose()
        {
            Clear(true);
        }
    }
}
