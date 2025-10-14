using HxCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxFarmDiaryAI
{
    internal class DbObjectClass
    {
    }
    public class SQL_TXFD_SITE_SET_Table : HxDbModelSetValue
    {
        public const string _TABLE_NAME_ = "TXFD_SITE_SET";

        public const string _CDF_SNO_              = "sno";
        public const string _CDF_SITE_NAME_        = "site_name";
        public const string _CDF_SITE_MEMO_        = "site_memo";
        public const string _CDF_STATUS_           = "status";
        public const string _CDF_STN_CODE_         = "stn_code";
        public const string _CDF_STN_NAME_         = "stn_name";
        public const string _CDF_LOC_ADDR_         = "loc_addr";
        public const string _CDF_LOC_LATITUDE_     = "loc_latitude";
        public const string _CDF_LOC_LONGITUDE_    = "loc_longitude";
        public const string _CDF_LOC_ROAD_         = "LocRoad";


        [JsonProperty(_CDF_SNO_)]
        public decimal SNO { get; set; }
        [JsonProperty(_CDF_SITE_NAME_)]
        public string? SITE_NAME { get; set; }
        [JsonProperty(_CDF_STN_CODE_)]
        public string? STN_CODE { get; set; }
        [JsonProperty(_CDF_STN_NAME_)]
        public string? STN_NAME { get; set; }
        [JsonProperty(_CDF_LOC_ADDR_)]
        public string? LOC_ADDR { get; set; }
        [JsonProperty(_CDF_LOC_LATITUDE_)]
        public decimal? LOC_LATITUDE { get; set; }
        [JsonProperty(_CDF_LOC_LONGITUDE_)]
        public decimal? LOC_LONGITUDE { get; set; }
        [JsonProperty(_CDF_LOC_ROAD_)]
        public string? LOC_ROAD { get; set; }
        /*
        public string? IS_USE { get; set; }
        public DateTime? REG_DATE { get; set; }
        public string? REG_USER { get; set; }
        public DateTime? MOD_DATE { get; set; }
        public string? MOD_USER { get; set; }
        */

        protected const string _DEFAULT_QUERY_STRING_ = $@"SELECT 
    sno, site_name, site_memo, status, stn_code, stn_name, loc_addr, loc_latitude, loc_longitude, loc_road, etc, is_use, raw_guid, reg_date, reg_agent, reg_user, reg_uno, mod_date, mod_agent, mod_user, mod_uno 
FROM {_TABLE_NAME_} 
WHERE 1 = 1 
    AND {_CDF_IS_USE_} = 'Y' {{0}}";

        public static DataTable? ToDataTable(IHxDb db, string? queryString = null)
        {
            if(db == null) throw new ArgumentNullException("Database Resource");

            if (db.Open() != true) { return null; }

            string SQL = string.Format(_DEFAULT_QUERY_STRING_, string.Empty);
            if (queryString.IsNullOrWhiteSpaceEx() != true)
            {
                SQL = GetQueryString(SQL, queryString);
            }

            DataTable Result = db.QueryDataTable(SQL);
            if (Result != null) { Result.TableName = _TABLE_NAME_; }

            return Result;
        }

        public static SQL_TXFD_SITE_SET_Table[]? ToRecordSet(IHxDb db, string? queryString = null)
        {
            DataTable? dt = ToDataTable(db, queryString);
            if(dt == null || dt.Rows.Count <= 0) { return null; }

            return dt.ToRecordSetEx<SQL_TXFD_SITE_SET_Table>();
        }

        public static string? ToJsonSerializeDataTable(IHxDb db, string? queryString = null)
        {
            DataTable? dt = ToDataTable(db, queryString);
            if (dt == null || dt.Rows.Count <= 0) { return null; }

            string Result = dt.ToJsonStringEx() ; 
            return Result ;
        }
        public static string? ToJsonSerializeRecordSet(IHxDb db, string? queryString = null, HxNameingCaseType caseType = HxNameingCaseType.JsonCase)
        {
            SQL_TXFD_SITE_SET_Table[]? rs = ToRecordSet(db, queryString);
            if (rs == null || rs.Length <= 0) { return null; }

            return rs.ToJsonStringWithNameingCaseEx(caseType);
        }
        public static DataTable ToJsonDeserializeDataTable(string json)
        {
            return HxUtils.JsonDeserializeObject<DataTable>(json);
        }
        public static SQL_TXFD_SITE_SET_Table[]? ToJsonDeserializeRecordSet(string json, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
        {
            return HxUtils.JsonDeserializeObjectWithNameingCase<SQL_TXFD_SITE_SET_Table[]>(json, caseType);
        }
    }
    public class SQL_TXFD_IMAGE_CART_Table : HxDbModelSetValue
    {
        public decimal CART_NO { get; set; }

        public string? SOURCE_TYPE { get; set; }
        public DateTime? SOURCE_DATE { get; set; }

        public int? IMAGE_WIDTH { get; set; }
        public int? IMAGE_HEIGHT { get; set; }

        public string? FILE_NAME { get; set; }
        public string? FILE_SAVE { get; set; }
        public string? FILE_PATH { get; set; }
        public long? FILE_SIZE { get; set; }
        public string? FILE_EXT { get; set; }
        public string? FILE_TYPE { get; set; }
        public string? FILE_CHECK { get; set; }
        public string? FILE_REMARK { get; set; }
        /*
        public DateTime? REG_DATE { get; set; }
        public string? REG_USER { get; set; }
        public DateTime? MOD_DATE { get; set; }
        public string? MOD_USER { get; set; }
        */
    }
}
