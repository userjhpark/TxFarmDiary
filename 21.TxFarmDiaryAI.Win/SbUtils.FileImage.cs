using DevExpress.Pdf;
using DevExpress.XtraRichEdit.API.Native;
using HxCore;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxFarmDiaryAI.Win
{
    partial class SbUtils
    {
        /*
        internal static string GetFileSizeReadable(long fileSize)
        {
            if (fileSize < 0)
                return "Invalid size";
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            double len = fileSize;
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len /= 1024;
            }
            return $"{len:0.##} {sizes[order]}";
        }
        */

        internal static string GetImageFormatString(Image image)
        {
            
            if (image == null)
                return "Unknown";
            return GetImageFormatString(image.RawFormat);
        }

        internal static string GetImageFormatString(System.Drawing.Imaging.ImageFormat format)
        {
            if (format.Equals(System.Drawing.Imaging.ImageFormat.Jpeg))
                return "JPEG";
            if (format.Equals(System.Drawing.Imaging.ImageFormat.Png))
                return "PNG";
            if (format.Equals(System.Drawing.Imaging.ImageFormat.Bmp))
                return "BMP";
            if (format.Equals(System.Drawing.Imaging.ImageFormat.Gif))
                return "GIF";
            if (format.Equals(System.Drawing.Imaging.ImageFormat.Tiff))
                return "TIFF";
            if (format.Equals(System.Drawing.Imaging.ImageFormat.Icon))
                return "ICON";
            return "Unknown";
        }

        internal static string GetCurrentTimestampString()
        {
            return DateTime.Now.ToString("yyyyMMdd_HHmmssfff");
        }
        internal static string GetTimestampString()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }

        internal static string GetDateString()
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }
        internal static string GetTimeString()
        {
            return DateTime.Now.ToString("HH:mm:ss.fff");
        }
        //이미지를 다른 포멧으로 변환
        internal static Image ConvertImageFormat(Image image, System.Drawing.Imaging.ImageFormat targetFormat)
        {
            if (image == null)
                return null!;

            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, targetFormat);
                ms.Position = 0;
                return Image.FromStream(ms);
            }
        }
        internal static Image ResizeImage(Image image, int width, int height)
        {
            if (image == null)
                return null!;
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);
            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                using (var wrapMode = new System.Drawing.Imaging.ImageAttributes())
                {
                    wrapMode.SetWrapMode(System.Drawing.Drawing2D.WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            return destImage;
        }
        internal static Image CropImage(Image image, Rectangle cropArea)
        {
            if (image == null)
                return null!;
            Bitmap bmpImage = new Bitmap(image);
            Bitmap bmpCrop = bmpImage.Clone(cropArea, bmpImage.PixelFormat);
            return (Image)(bmpCrop);
        }
        internal static Image RotateImage(Image image, float angle)
        {
            if (image == null)
                return null!;
            Bitmap bmp = new Bitmap(image.Width, image.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.TranslateTransform((float)image.Width / 2, (float)image.Height / 2);
                g.RotateTransform(angle);
                g.TranslateTransform(-(float)image.Width / 2, -(float)image.Height / 2);
                g.DrawImage(image, new Point(0, 0));
            }
            return bmp;
        }
        internal static Image FlipImage(Image image, bool horizontal, bool vertical)
        {
            if (image == null)
                return null!;
            if (horizontal && vertical)
                image.RotateFlip(RotateFlipType.RotateNoneFlipXY);
            else if (horizontal)
                image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            else if (vertical)
                image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            return image;
        }
        internal static Image CloneImage(Image image)
        {
            if (image == null)
                return null!;
            return (Image)image.Clone();
        }
        internal static void DisposeImage(ref Image image)
        {
            if (image != null)
            {
                image.Dispose();
                image = null!;
            }
        }

        public static bool SetPdfAccroTextFormValue(DevExpress.XtraPdfViewer.PdfViewer pdfCtl, string feildName, string textValue)
        {
            bool Result = false;
            if (pdfCtl == null || pdfCtl.IsDocumentOpened != true || feildName.IsNullOrWhiteSpaceEx() == true) { return Result;  }
            if (pdfCtl.IsDocumentOpened)
            {
                PdfDocumentFacade documentFacade = pdfCtl.GetDocumentFacade();
                if (documentFacade == null) { return Result; }

                PdfAcroFormFacade acroForm = documentFacade.AcroForm;
                if(acroForm == null) { return Result; }

                PdfTextFormFieldFacade formText = acroForm.GetTextFormField(feildName);
                if (formText == null || formText.FullName.IsNullOrWhiteSpaceEx() == true) { return Result; }

                formText.Value = textValue;
                if(formText.Value == textValue) { Result = true; }

                /*
                IEnumerable<PdfFormFieldFacade> collisions = acroForm.GetFields();
                if (collisions == null || collisions.Any() != true) { return Result; }

                IEnumerable<PdfFormFieldFacade> formFields = collisions.Where(r => r.FullName.Equals(feildName, StringComparison.OrdinalIgnoreCase));
                if (formFields != null && formFields.Any() == true) 
                {
                    foreach (PdfFormFieldFacade formField in formFields)
                    {
                        
                    }
                }
                */
            }
            return Result;

        }
    }
}
