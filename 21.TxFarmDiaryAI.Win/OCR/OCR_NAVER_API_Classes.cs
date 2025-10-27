using DevExpress.Map.Kml.Model;
using Google.Protobuf.WellKnownTypes;
using HxCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIA;
/*
namespace TxFarmDiaryAI.Win
{
    public struct OCR_NAVER_API_Request_image
    {
        public string format { get; set; }
        public string name { get; set; }
        public string? data { get; set; }
        public string? url { get; set; }
        public OCR_NAVER_API_Request_image()
        {
            format = string.Empty;
            name = string.Empty;
            data = null;
            url = null;
        }
        public OCR_NAVER_API_Request_image(TImageCartItem item, string? inputName = null)
            : this()
        {
            if (item == null || item.ImageBytes == null || item.ImageBytes.Length <= 0) { return; }

            format = HxImagePicture.GetImageFormatString(item.ImageData.RawFormat).ToLower();
            name = inputName ?? DateTime.Now.ToDateTimeStringDefaultFormatBEx();
            data = HxString.GetByteToBase64Encode(item.ImageBytes);
            url = null;
        }

        public OCR_NAVER_API_Request_image(string hostUrl = null)
            : this()
        {
            if (hostUrl.IsNullOrWhiteSpaceEx() == true) { return; }

            format = HxFile.GetFileNameExt(hostUrl).ToLower();
            name = HxFile.GetFileNameWithOutExt(hostUrl);
            data = null;
            url = hostUrl;
        }
        public OCR_NAVER_API_Request_image(Image image, string? inputName = null)
        {
            if (image == null || image.Size.Width <= 0 || image.Size.Height <= 0) { return; }

            format = HxImagePicture.GetImageFormatString(image.RawFormat).ToLower();
            name = inputName ?? DateTime.Now.ToDateTimeStringDefaultFormatBEx();
            data = HxString.GetImageToBase64Encode(image);
            url = null;
        }
    }
    public struct OCR_NAVER_API_Request_Body
    {
        public IEnumerable<OCR_NAVER_API_Request_image>? images { get; set; }
        public string lang { get; set; } = "ko";
        public string requestId { get; set; } = "string";
        public string resultType { get; set; } = "string";
        public long timestamp { get; set; } = DateTimeOffset.Now.ToUnixTimeSeconds();
        public string version { get; set; } = "v1";
        public OCR_NAVER_API_Request_Body()
        {
            images = null;
            lang = "ko";
            requestId = "string";
            resultType = "string";
            //timestamp = @"{{$timestamp}}";
            timestamp = HxUtils.GetNowToUnixTimestamp();
            version = "v1";
        }

        public OCR_NAVER_API_Request_Body(IEnumerable<TImageCartItem> items)
            : this()
        {
            if (items == null || items.Any() != true) { return; }

            List<OCR_NAVER_API_Request_image> list = [];
            foreach (var item in items)
            {
                OCR_NAVER_API_Request_image img = new(item);
                if (img.format.IsNullOrWhiteSpaceEx() != true && img.data.IsNullOrWhiteSpaceEx() != true)
                {
                    list.Add(img);
                }
            }
            images = list?.ToArray<OCR_NAVER_API_Request_image>();
        }
        public OCR_NAVER_API_Request_Body(Image image)
        {
            if (image == null || image.Size.Width <= 0 || image.Size.Height <=0 ) { return; }

            List<OCR_NAVER_API_Request_image> list = [];
            OCR_NAVER_API_Request_image img = new(image);
            list.Add(img);
            images = list?.ToArray<OCR_NAVER_API_Request_image>();
        }
    }

    public struct OCR_NAVER_API_Response_matchedTemplate
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    public struct OCR_NAVER_API_Response_validationResult
    {
        public string result { get; set; }
    }
    public struct OCR_NAVER_API_Response_bounding
    {
        public decimal top { get; set; }
        public decimal left { get; set; }
        public decimal width { get; set; }
        public decimal height { get; set; }
    }

    public struct OCR_NAVER_API_Response_field
    {
        public string name { get; set; }
        public OCR_NAVER_API_Response_bounding bounding { get; set; }
        public string valueType { get; set; }
        public string inferText { get; set; }
        public string inferConfidence { get; set; }
    }
    public struct OCR_NAVER_API_Response_title
    {
        public string name { get; set; }
        public OCR_NAVER_API_Response_bounding bounding { get; set; }
        public string inferText { get; set; }
        public decimal inferConfidence { get; set; }
    }
    public struct OCR_NAVER_API_Response_image
    {
        public string uid { get; set; }
        public string name { get; set; }
        public string inferResult { get; set; }
        public string message { get; set; }
        public OCR_NAVER_API_Response_matchedTemplate matchedTemplate { get; set; }
        public OCR_NAVER_API_Response_validationResult validationResult { get; set; }
        public IEnumerable<OCR_NAVER_API_Response_field> fields { get; set; }
        public OCR_NAVER_API_Response_title title { get; set; }
    }
    public struct OCR_NAVER_API_Response_Body
    {
        public string version { get; set; }
        public string requestId { get; set; }
        public long timestamp { get; set; }
        public IEnumerable<OCR_NAVER_API_Response_image>? images { get; set; }
    }
}
*/