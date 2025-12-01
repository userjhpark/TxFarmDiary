using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Utils = TxFarmDiaryAI.Win.SbUtils;

namespace TxFarmDiaryAI.Win
{
    internal static class SbUtilsExtensions
    {
        //private static SbUtils Utils => SbUtils.Instance;
        internal static void LocalizedResourceSetEx(this Control control, string? resourceKey = null)
        {
            Utils.SetLocalizedResourceKeySet(control, resourceKey);
        }
        internal static void DoLocalizedUpdateControlAllToTextEx(this Control control)
        {
            Utils.SetLocalizedUpdateControlAllToText(control);
        }

        internal static EScannerType ToEnumScannerType(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return EScannerType.Unknown;
            return value.Trim().ToUpper() switch
            {
                "WIA" => EScannerType.WIA,
                "TWAIN" => EScannerType.TWAIN,
                _ => EScannerType.Unknown,
            };
        }
    }
}
