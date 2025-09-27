using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxFarmDiaryAI.Win
{
    internal class SbDefs : Core.TDefs
    {
        internal const string _TAG_RESOURCE_TPL_PATTERN_ = @"(\{{\#)(\w+)(\}})";

        internal const string _RESOURCEKEY_SCANNER_FIND_NOTFOUND_ = @"SCANNER_FIND_NOTFOUND";
        internal const string _RESOURCEKEY_SCANNER_FIND_SUCCESS_ = @"SCANNER_FIND_SUCCESS";
        internal const string _RESOURCEKEY_SCANNER_FIND_ERROR_ = @"SCANNER_FIND_ERROR";
        internal const string _RESOURCEKEY_SCANNER_FIND_FINDING_ = @"SCANNER_FIND_FINDING";
        internal const string _RESOURCEKEY_SCANNER_SELECT_PLEASE_ = @"SCANNER_SELECT_PLEASE";
        internal const string _RESOURCEKEY_SCANNER_SELECT_CONN_ = @"SCANNER_SELECT_CONN";
        internal const string _RESOURCEKEY_SCANNER_SELECT_ERROR_ = @"SCANNER_SELECT_ERROR";
        internal const string _RESOURCEKEY_SCANNER_SCAN_START_ = @"SCANNER_SCAN_START";
        internal const string _RESOURCEKEY_SCANNER_SCAN_NOTFOUND_ = @"SCANNER_SCAN_NOTFOUND";
        internal const string _RESOURCEKEY_SCANNER_SCAN_SUCCESS_ = @"SCANNER_SCAN_SUCCESS";
        internal const string _RESOURCEKEY_IMAGE_EDIT_QUESTION_ = @"IMAGE_EDIT_QUESTION";
        internal const string _RESOURCEKEY_IMAGE_EDIT_NOIMAGE_ = @"IMAGE_EDIT_NOIMAGE";
        internal const string _RESOURCEKEY_IMAGE_DELETE_NOIMAGE_ = @"IMAGE_DELETE_NOIMAGE";
        internal const string _RESOURCEKEY_IMAGE_COPY_NOIMAGE_ = @"IMAGE_COPY_NOIMAGE";
        internal const string _RESOURCEKEY_IMAGE_PASTE_NOIMAGE_ = @"IMAGE_PASTE_NOIMAGE";
        internal const string _RESOURCEKEY_IMAGE_CUT_QUESTION_ = @"IMAGE_CUT_QUESTION";
        internal const string _RESOURCEKEY_IMAGE_CUT_NOIMAGE_ = @"IMAGE_CUT_NOIMAGE";
        internal const string _RESOURCEKEY_IMAGE_SAVE_NOIMAGE_ = @"IMAGE_SAVE_NOIMAGE";
        internal const string _RESOURCEKEY_IMAGE_SAVE_NOFILEEXT_ = @"IMAGE_SAVE_NOFILEEXT";
        internal const string _RESOURCEKEY_SAVE_FILEEXT_NOTSUPPORT_ = @"SAVE_FILEEXT_NOTSUPPORT";
        internal const string _RESOURCEKEY_FILE_NOTEXIST_ = @"FILE_NOTEXIST";
    }
}
