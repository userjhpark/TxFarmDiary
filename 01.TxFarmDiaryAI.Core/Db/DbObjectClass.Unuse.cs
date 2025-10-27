using HxCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxFarmDiaryAI.Db
{
    partial class DbObjectClass
    {
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

    public class SQL_TXFD_IMAGE_ENV_Table : SQL_TXFD_BASE
    {
        public const string _DB_TABLE_NAME_ = "TXFD_IMAGE_SET";
        public const string _DB_SEQ_NAME_ = $"SEQ_{_DB_TABLE_NAME_}";
        public const string _SELECT_DEFAULT_QUERY_STRING_ = @$"SELECT
    img_no, source_type, source_date, image_width, image_height, file_name, file_save, file_path, file_size, file_ext, file_type, file_check, file_remark, file_data, file_contents, etc, is_use, raw_guid, reg_date, reg_agent, reg_user, reg_uno, mod_date, mod_agent, mod_user, mod_uno
FROM {_DB_TABLE_NAME_}
WHERE 1 = 1
    AND {_CDF_IS_USE_} = 'Y' {{0}}";

        public const string _CDF_IMG_NO_ = "img_no";
        public const string _CDF_IMAGE_KIND_ = "image_kind";
        public const string _CDF_IMAGE_SUBJECT_ = "image_subject";
        public const string _CDF_IMAGE_CHECK_ = "image_check";
        public const string _CDF_IMAGE_MEMO_ = "image_memo";
        public const string _CDF_FILE_NAME_ = "file_name";
        public const string _CDF_FILE_SAVE_ = "file_save";
        public const string _CDF_FILE_PATH_ = "file_path";
        public const string _CDF_FILE_SIZE_ = "file_size";
        public const string _CDF_FILE_EXT_ = "file_ext";
        public const string _CDF_FILE_TYPE_ = "file_type";
        public const string _CDF_FILE_CHECK_ = "file_check";
        public const string _CDF_FILE_REMARK_ = "file_remark";
        public const string _CDF_FILE_DATA_ = "file_data";
        public const string _CDF_FILE_CONTENTS_ = "file_contents";
        public const string _CDF_ETC_ = "etc";

        [JsonProperty(_CDF_IMG_NO_)] public decimal IMG_NO { get; set; }
        [JsonProperty(_CDF_IMAGE_KIND_)] public string? IMAGE_KIND { get; set; }
        [JsonProperty(_CDF_IMAGE_SUBJECT_)] public string? IMAGE_SUBJECT { get; set; }
        [JsonProperty(_CDF_IMAGE_CHECK_)] public string? IMAGE_CHECK { get; set; }
        [JsonProperty(_CDF_IMAGE_MEMO_)] public string? IMAGE_MEMO { get; set; }
        [JsonProperty(_CDF_FILE_NAME_)] public string? FILE_NAME { get; set; }
        [JsonProperty(_CDF_FILE_SAVE_)] public string? FILE_SAVE { get; set; }
        [JsonProperty(_CDF_FILE_PATH_)] public string? FILE_PATH { get; set; }
        [JsonProperty(_CDF_FILE_SIZE_)] public long FILE_SIZE { get; set; }
        [JsonProperty(_CDF_FILE_EXT_)] public string? FILE_EXT { get; set; }
        [JsonProperty(_CDF_FILE_TYPE_)] public string? FILE_TYPE { get; set; }
        [JsonProperty(_CDF_FILE_CHECK_)] public string FILE_CHECK { get; set; }
        [JsonProperty(_CDF_FILE_REMARK_)] public string? FILE_REMARK { get; set; }
        [JsonProperty(_CDF_FILE_DATA_)] public string? FILE_DATA { get; set; }
        [JsonProperty(_CDF_FILE_CONTENTS_)] public string? FILE_CONTENTS { get; set; }
        [JsonProperty(_CDF_ETC_)] public string? ETC { get; set; }



        public SQL_TXFD_IMAGE_ENV_Table()
        {
            Clear();
        }
        public override void Clear()
        {
            this.IMG_NO = int.MinValue;
            this.IMAGE_KIND = null;
            this.IMAGE_SUBJECT = null;
            this.IMAGE_CHECK = null;
            this.IMAGE_MEMO = null;
            this.FILE_NAME = string.Empty;
            this.FILE_SAVE = string.Empty;
            this.FILE_PATH = string.Empty;
            this.FILE_SIZE = int.MinValue;
            this.FILE_EXT = null;
            this.FILE_TYPE = null;
            this.FILE_CHECK = string.Empty;
            this.FILE_REMARK = null;
            this.FILE_DATA = null;
            this.FILE_CONTENTS = null;
            this.ETC = null;
        }
        public override bool IsEmpty()
        {
            if (this.IMG_NO == int.MinValue &&
                this.IMAGE_KIND.IsNullOrWhiteSpaceEx() &&
                this.IMAGE_SUBJECT == null &&
                this.IMAGE_CHECK == null &&
                this.IMAGE_MEMO == null &&
                this.FILE_NAME.IsNullOrWhiteSpaceEx() &&
                this.FILE_SAVE.IsNullOrWhiteSpaceEx() &&
                this.FILE_PATH.IsNullOrWhiteSpaceEx() &&
                this.FILE_SIZE <= 0 &&
                this.FILE_EXT.IsNullOrWhiteSpaceEx() &&
                this.FILE_TYPE.IsNullOrWhiteSpaceEx() &&
                this.FILE_CHECK.IsNullOrWhiteSpaceEx() &&
                this.FILE_REMARK.IsNullOrWhiteSpaceEx() &&
                this.FILE_DATA.IsNullOrWhiteSpaceEx() &&
                this.FILE_CONTENTS.IsNullOrWhiteSpaceEx() &&
                this.ETC.IsNullOrWhiteSpaceEx())
            {
                return true;
            }
            return false;
        }

        public override bool IsValid()
        {
            if (this.FILE_NAME.IsNullOrWhiteSpaceEx() != true &&
                this.FILE_SIZE <= 0 &&
                this.FILE_CHECK.IsNullOrWhiteSpaceEx() != true)
            {
                return true;
            }
            return false;
        }

        public override bool SetDbInsert(IHxDb db, string? userText = null, decimal? uno = null)
        {
            bool Result = false;
            bool isValid = IsValid();
            if (isValid != true) { return Result; }

            if (db == null) throw new ArgumentNullException("Database Resource");

            if (db.Open() != true) { return Result; }

            string SQL = @"";

            return Result;
        }
        /**
        public static DataTable? ToDataTable(IHxDb db, string? addWhereQuery = null)
        {
            if (db == null) throw new ArgumentNullException("Database Resource");
            if (db.Open() != true) { return null; }
            string SQL = string.Format(_DEFAULT_QUERY_STRING_, string.Empty);
            if (addWhereQuery.IsNullOrWhiteSpaceEx() != true)
            {
                SQL = GetQueryString(SQL, addWhereQuery);
            }
            DataTable Result = db.QueryDataTable(SQL);
            if (Result != null) { Result.TableName = _TABLE_NAME_; }
            return Result;
        }
        public static SQL_TXFD_IMAGE_SET_Table[]? ToRecordSet(IHxDb db, string? addWhereQuery = null)
        {
            DataTable? dt = ToDataTable(db, addWhereQuery);
            if (dt == null || dt.Rows.Count <= 0) { return null; }
            return dt.ToRecordSetEx<SQL_TXFD_IMAGE_SET_Table>();
        }
        public static string? ToJsonSerializeDataTable(IHxDb db, string? addWhereQuery = null)
        {
            DataTable? dt = ToDataTable(db, addWhereQuery);
            if (dt == null || dt.Rows.Count <= 0) { return null; }
            string Result = dt.ToJsonStringEx();
            return Result;
        }
        public static string? ToJsonSerializeRecordSet(IHxDb db, string? addWhereQuery = null, HxNameingCaseType caseType = HxNameingCaseType.JsonCase)
        {
            SQL_TXFD_IMAGE_SET_Table[]? rs = ToRecordSet(db, addWhereQuery);
            if (rs == null || rs.Length <= 0) { return null; }
            return rs.ToJsonStringWithNameingCaseEx(caseType);
        }
        */


        public override string GetDbTableName()
        {
            return _DB_TABLE_NAME_;
        }
        public override string GetDbSeqName()
        {
            return _DB_SEQ_NAME_;
        }

        public override string GetDbSelectDefaultQueryString()
        {
            return _SELECT_DEFAULT_QUERY_STRING_;
        }

        public override bool SetDbInsert(IHxDb db, (string? userText, decimal? uno) woker)
        {
            bool Result = false;
            bool isValid = IsValid();
            if (isValid != true) { return Result; }

            if (db == null) throw new ArgumentNullException("Database Resource");

            if (db.Open() != true) { return Result; }

            string SQL = $@"INSERT INTO {GetDbTableName()} (
    img_no, source_type, source_date, image_width, image_height, file_name, file_save, file_path, file_size, file_ext, file_type, file_check, file_remark, file_data, file_contents, etc, is_use, raw_guid, reg_date, reg_agent, reg_user, reg_uno, mod_date, mod_agent, mod_user, mod_uno
) VALUES (
    :img_no, :source_type, :source_date, :image_width, :image_height, :file_name, :file_save, :file_path, :file_size, :file_ext, :file_type, :file_check, :file_remark, :file_data, :file_contents, :etc, 'Y', SYS_GUID(), SYSDATE, :reg_agent, :reg_user, :reg_uno, SYSDATE, :mod_agent, :mod_user, :mod_uno
)";
            int n = db.Query(SQL, new Dictionary<string, object>()
            {
                { "img_no", this.IMG_NO },
                { "source_type", this.IMAGE_KIND ?? (object)DBNull.Value },
                { "source_date", this.IMAGE_SUBJECT ?? (object)DBNull.Value },
                { "image_width", this.IMAGE_CHECK ?? (object)DBNull.Value },
                { "image_height", this.IMAGE_MEMO ?? (object)DBNull.Value },
                { "file_name", this.FILE_NAME ?? (object)DBNull.Value },
                { "file_save", this.FILE_SAVE ?? (object)DBNull.Value },
                { "file_path", this.FILE_PATH ?? (object)DBNull.Value },
                { "file_size", this.FILE_SIZE },
                { "file_ext", this.FILE_EXT ?? (object)DBNull.Value },
                { "file_type", this.FILE_TYPE ?? (object)DBNull.Value },
                { "file_check", this.FILE_CHECK ?? (object)DBNull.Value },
                { "file_remark", this.FILE_REMARK ?? (object)DBNull.Value },
                { "file_data", this.FILE_DATA ?? (object)DBNull.Value },
                { "file_contents", this.FILE_CONTENTS ?? (object)DBNull.Value },
                { "etc", this.ETC ?? (object)DBNull.Value },
                { "reg_agent", CUSTOM_USER_AGENT },
                { "reg_user", woker.userText ?? DbNullToObject },
                { "reg_uno", woker.uno ?? DbNullToObject },
                { "mod_agent", CUSTOM_USER_AGENT },
                { "mod_user", woker.userText ?? DbNullToObject },
                { "mod_uno", woker.uno ?? DbNullToObject },
            });
            if (n > 0)
            {
                Result = true;
            }
            return Result;
        }
    }
}
