using HxCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TxFarmDiaryAI
{
    public class TDefs
    {
        public const string _APP_PROGRAM_FULL_TITLE_ = "Farming Diary Automation System Implementation with AI-OCR";
        public const string _APP_PROGRAM_SHORT_TITLE_ = "Farming Diary Automation System";
        public const string _APP_WEBAPI_DEPLOY_VERSION_ = "dev";

        public const string _WEBAPI_DEFAULT_CALL_DEPLOY_VERSION_ = "v1";
        public const HxNameingCaseType _WEBAPI_DEFAULT_JSON_NAMING_CASE_ = HxNameingCaseType.PascalCase;

        public const string _TPL_RESOURCE_TAG_PATTERN_ = @"(\{{\#)(\w+)(\}})";
        public const string _TPL_FILE_PATTERN_ = @"^(?<prefix>tpl)(?<delimiter01>-|_)(?<title>영농일지)(?<delimiter02>-|_)R(?<rev>[\d]+)(?<delimiter03>-|_)(?<page>[\d]+)Page(?<delimiter04>-|_)?(?<remark>.*)?(?<delimiter05>.)(?<ext>pdf)$";
        //public const string _URL_PATTERN_ = @"^(?<protocol>https?):\/\/(?<domain>[^\/]+)(?<path>\/[^?]*)(?<query>\?.*)?$";


        public const string _RESOURCEKEY_FILE_NOTEXIST_ = @"FILE_NOTEXIST";

        public const string _RESOURCEKEY_TEMPLATE_FILE_NOT_EXIST_ = @"TEMPLATE_FILE_NOT_EXIST";


        public const string _RESOURCEKEY_SAVE_FILEEXT_NOTSUPPORT_ = @"SAVE_FILEEXT_NOTSUPPORT";

        public const string _RESOURCEKEY_SCANNER_FIND_NOTFOUND_ = @"SCANNER_FIND_NOTFOUND";
        public const string _RESOURCEKEY_SCANNER_FIND_SUCCESS_ = @"SCANNER_FIND_SUCCESS";
        public const string _RESOURCEKEY_SCANNER_FIND_ERROR_ = @"SCANNER_FIND_ERROR";
        public const string _RESOURCEKEY_SCANNER_FIND_FINDING_ = @"SCANNER_FIND_FINDING";
        public const string _RESOURCEKEY_SCANNER_SELECT_PLEASE_ = @"SCANNER_SELECT_PLEASE";
        public const string _RESOURCEKEY_SCANNER_SELECT_CONN_ = @"SCANNER_SELECT_CONN";
        public const string _RESOURCEKEY_SCANNER_SELECT_ERROR_ = @"SCANNER_SELECT_ERROR";
        public const string _RESOURCEKEY_SCANNER_SCAN_START_ = @"SCANNER_SCAN_START";
        public const string _RESOURCEKEY_SCANNER_SCAN_NOTFOUND_ = @"SCANNER_SCAN_NOTFOUND";
        public const string _RESOURCEKEY_SCANNER_SCAN_SUCCESS_ = @"SCANNER_SCAN_SUCCESS";

        public const string _RESOURCEKEY_IMAGE_EDIT_QUESTION_ = @"IMAGE_EDIT_QUESTION";
        public const string _RESOURCEKEY_IMAGE_EDIT_NOIMAGE_ = @"IMAGE_EDIT_NOIMAGE";
        public const string _RESOURCEKEY_IMAGE_DELETE_NOIMAGE_ = @"IMAGE_DELETE_NOIMAGE";
        public const string _RESOURCEKEY_IMAGE_COPY_NOIMAGE_ = @"IMAGE_COPY_NOIMAGE";
        public const string _RESOURCEKEY_IMAGE_PASTE_NOIMAGE_ = @"IMAGE_PASTE_NOIMAGE";
        public const string _RESOURCEKEY_IMAGE_CUT_QUESTION_ = @"IMAGE_CUT_QUESTION";
        public const string _RESOURCEKEY_IMAGE_CUT_NOIMAGE_ = @"IMAGE_CUT_NOIMAGE";
        public const string _RESOURCEKEY_IMAGE_SAVE_NOIMAGE_ = @"IMAGE_SAVE_NOIMAGE";
        public const string _RESOURCEKEY_IMAGE_SAVE_NOFILEEXT_ = @"IMAGE_SAVE_NOFILEEXT";
        public const string _RESOURCEKEY_IMAGE_SIZE_TOOLARGE_ = @"IMAGE_SIZE_TOOLARGE";
        public const string _RESOURCEKEY_IMAGE_SIZE_TOOSMALL_ = @"IMAGE_SIZE_TOOSMALL";
        public const string _RESOURCEKEY_IMAGE_FORMAT_UNKNOWN_ = @"IMAGE_FORMAT_UNKNOWN";
        public const string _RESOURCEKEY_IMAGE_FORMAT_MEMORYBMP_ = @"IMAGE_FORMAT_MEMORYBMP";
        public const string _RESOURCEKEY_IMAGE_NOTSUPPORT_          = @"IMAGE_NOTSUPPORT";
        public const string _RESOURCEKEY_IMAGE_FORMAT_NOTSUPPORT_EMF_ = @"IMAGE_FORMAT_NOTSUPPORT_EMF";
        public const string _RESOURCEKEY_IMAGE_FORMAT_NOTSUPPORT_WMF_ = @"IMAGE_FORMAT_NOTSUPPORT_WMF";
        public const string _RESOURCEKEY_IMAGE_FORMAT_NOTSUPPORT_ICON_ = @"IMAGE_FORMAT_NOTSUPPORT_ICON";

        public const string _RESOURCEKEY_CART_APPEND_NOIMAGE_ = @"CART_APPEND_NOIMAGE";
        public const string _RESOURCEKEY_CART_APPEND_SUCCESS_ = @"CART_APPEND_SUCCESS";
        public const string _RESOURCEKEY_CART_APPEND_MISS_ = @"CART_APPEND_MISS";
        public const string _RESOURCEKEY_CART_APPEND_ERROR_INDEX_ = @"CART_APPEND_ERROR_INDEX";
        public const string _RESOURCEKEY_CART_APPEND_WARRING_EXISTS_ = @"CART_APPEND_WARRING_EXISTS";
        public const string _RESOURCEKEY_CART_DELETE_QUESTION_ = @"CART_DELETE_QUESTION";

        public const string _RESOURCEKEY_PICTURE_LOADED_QUESTION_ = @"PICTURE_LOADED_QUESTION";
    }
}
