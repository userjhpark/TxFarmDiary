using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxFarmDiaryAI.Win
{
    internal class SbDefs : TDefs
    {
        internal const string _TEMP_DIR_NAME_       = "Temp";
        internal const string _LOG_DIR_NAME_        = "Log";
        internal const string _DOWNLOAD_DIR_NAME_   = "Download";
        internal const string _TEMPLATE_DIR_NAME_   = "Template"    ;
        internal const string _SAMPLE_DIR_NAME_     = "Sample"      ;
        internal const string _OUTPUT_DIR_NAME_     = "Output"  ;
#if DEBUG
        internal const string _HOME_URL_FarmDiary_ = @"http://localhost:5000";
#else
        internal const string _HOME_URL_FarmDiary_ = @"http://fd.typesw.com";
#endif
        internal const string _API_URL_FarmDiary_ = _HOME_URL_FarmDiary_ + "/api";
        internal const string _API_URL_NaverOCR_Custom_ = @"https://cugmmfu019.apigw.ntruss.com/custom/v1/46311/28645cc31f95289c0bc759520d489043a6ab9ebe045360e6b66c84f1e0165503/infer";

        internal const string _API_URL_FarmSite_Workspace_ = @$"{_API_URL_FarmDiary_}/FarmSite/all/DataTable";
        internal const string _API_URL_FarmDiary_List_ = @$"{_API_URL_FarmDiary_}/FarmDiary/List?value_case=DataTable";
        internal const string _API_URL_FarmDiary_Fields_ = @$"{_API_URL_FarmDiary_}/FarmDiary/Feilds/{{0}}/?value_case=DataTable";
        internal const string _API_URL_FarmDiary_File_ = @$"{_API_URL_FarmDiary_}/FarmDiary/File/{{0}}/?value_case=DataTable";
    }
    internal class Defs : SbDefs
    {
    }
}
