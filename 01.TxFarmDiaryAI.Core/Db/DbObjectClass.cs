using Amazon.Runtime.Internal.Transform;
using HxCore;
using MySqlX.XDevAPI.Common;
using Newtonsoft.Json;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TxFarmDiaryAI
{
    internal partial class DbObjectClass
    {
    }
    public interface ISQL_TXFD_BASE_Table
    {
        void Clear();
        bool IsEmpty();
        bool IsValid();
        string GetDbTableName();
        string GetDbSeqName();
        string GetDbSelectDefaultQueryString();
        bool SetDbInsert(IHxDb db, string? userText = null, decimal? uno = null);
    }
    

    public abstract class SQL_TXFD_BASE : HxDbModelSetValue, IHxSetValue, ISQL_TXFD_BASE_Table, IDisposable
    {
        public virtual IHxDb? DB { get; protected set; }
        public void SetDbConn(IHxDb db)
        {
            DB = db;
        }
        /*
        protected static ASQL_BASE? Instance { get; set; }
        protected static ASQL_BASE Create<T>() 
            where T : ASQL_BASE, ISQL_TXFD_BASE_Table, new()
        {
            Instance = new T();
            return Instance;
        }
        public static string DbTableName => Instance!.GetDbTableName();
        public static string DbSelectDefaultQueryString => Instance!.GetDbSelectDefaultQueryString();
        */


        public SQL_TXFD_BASE()
        {
            //Clear();
        }
        public SQL_TXFD_BASE(IHxDb db)
            : this()
        {
            SetDbConn(db);
        }
        public void Dispose()
        {
            Clear();
        }
        public abstract void Clear();
        public abstract bool IsEmpty();
        public abstract bool IsValid();
        
        public abstract string GetDbTableName();
        public abstract string GetDbSeqName();
        public abstract string GetDbSelectDefaultQueryString();
        
        public abstract bool SetDbInsert(IHxDb db, (string? userText, decimal? uno) woker);

        public virtual bool SetDbInsert(IHxDb db, string? userText = null, decimal? uno = null)
        {
            return SetDbInsert(db, (userText, uno));
        }

        public virtual bool DbOpenCheck(IHxDb db)
        {
            bool Result = false;
            
            if (db == null) throw new ArgumentNullException("Database Resource");
            if (db.Open() != true) { return Result; }
            return Result;

        }

        

        

        /*
public static DataTable? ToDataTable(IHxDb db, string? addWhereQuery = null)
{
   if (db == null) throw new ArgumentNullException("Database Resource");

   if (db.Open() != true) { return null; }

   string SQL = string.Format(DbSelectDefaultQueryString, string.Empty);
   if (addWhereQuery.IsNullOrWhiteSpaceEx() != true)
   {
       SQL = GetQueryString(SQL, addWhereQuery);
   }
   DataTable Result = db.QueryDataTable(SQL);
   if (Result != null) { Result.TableName = DbTableName; }
   return Result;
}
public static T[] ToRecordSet(IHxDb db, string? addWhereQuery = null)

{
   DataTable? dt = ToDataTable(db, addWhereQuery);
   if (dt == null || dt.Rows.Count <= 0) { return null; }
   return dt.ToRecordSetEx<T>();
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
   SQL_TXFD_OCR_SET_Table[]? rs = ToRecordSet(db, addWhereQuery);
   if (rs == null || rs.Length <= 0) { return null; }
   return rs.ToJsonStringWithNameingCaseEx(caseType);
}
public static SQL_TXFD_OCR_SET_Table? ToJsonDeserializeRecord(string json, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
{
   return HxUtils.JsonDeserializeObjectWithNameingCase<SQL_TXFD_OCR_SET_Table>(json, caseType);
}
public static SQL_TXFD_OCR_SET_Table[]? ToJsonDeserializeRecordSet(string json, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
{
   return HxUtils.JsonDeserializeObjectWithNameingCase<SQL_TXFD_OCR_SET_Table[]>(json, caseType);
}
public static SQL_TXFD_OCR_SET_Table? ToJsonDeserializeRecordFromResponseData(string json, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
{
   return HxUtils.JsonDeserializeObjectWithNameingCase<SQL_TXFD_OCR_SET_Table>(json, caseType);
}
public static SQL_TXFD_OCR_SET_Table[]? ToJsonDeserializeRecordSetFromResponseData(string json, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
{
   return HxUtils.JsonDeserializeObjectWithNameingCase<SQL_TXFD_OCR_SET_Table[]>(json, caseType);
}
public static SQL_TXFD_OCR_SET_Table? ToJsonDeserializeRecordFromResponseDataObject(object responseDataObj, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
{
   string json = HxUtils.JsonSerializeObject(responseDataObj);
   return ToJsonDeserializeRecordFromResponseData(json, caseType);
}
*/
        /** Original
        public static SQL_TXFD_OCR_SET_Table[]? ToRecordSet(IHxDb db, string? addWhereQuery = null)
        {
            DataTable? dt = ToDataTable(db, addWhereQuery);
            if (dt == null || dt.Rows.Count <= 0) { return null; }
            return dt.ToRecordSetEx<SQL_TXFD_OCR_SET_Table>();
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
            SQL_TXFD_OCR_SET_Table[]? rs = ToRecordSet(db, addWhereQuery);
            if (rs == null || rs.Length <= 0) { return null; }
            return rs.ToJsonStringWithNameingCaseEx(caseType);
        }
        public static SQL_TXFD_OCR_SET_Table? ToJsonDeserializeRecord(string json, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
        {
            return HxUtils.JsonDeserializeObjectWithNameingCase<SQL_TXFD_OCR_SET_Table>(json, caseType);
        }
        public static SQL_TXFD_OCR_SET_Table[]? ToJsonDeserializeRecordSet(string json, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
        {
            return HxUtils.JsonDeserializeObjectWithNameingCase<SQL_TXFD_OCR_SET_Table[]>(json, caseType);
        }
        public static SQL_TXFD_OCR_SET_Table? ToJsonDeserializeRecordFromResponseData(string json, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
        {
            return HxUtils.JsonDeserializeObjectWithNameingCase<SQL_TXFD_OCR_SET_Table>(json, caseType);
        }
        public static SQL_TXFD_OCR_SET_Table[]? ToJsonDeserializeRecordSetFromResponseData(string json, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
        {
            return HxUtils.JsonDeserializeObjectWithNameingCase<SQL_TXFD_OCR_SET_Table[]>(json, caseType);
        }
        public static SQL_TXFD_OCR_SET_Table? ToJsonDeserializeRecordFromResponseDataObject(object responseDataObj, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
        {
            string json = HxUtils.JsonSerializeObject(responseDataObj);
            return ToJsonDeserializeRecordFromResponseData(json, caseType);
        }
        */
    }
    public class SQL_TXFD_FILE_ENV_Table : SQL_TXFD_BASE
    {
        public const string _DB_TABLE_NAME_ = "TXFD_FILE_ENV";
        public const string _DB_SEQ_NAME_ = $"SEQ_{_DB_TABLE_NAME_}";
        public const string _SELECT_DEFAULT_QUERY_STRING_ = @"select file_no, file_check, file_check_sub, file_name, file_save, file_path, file_ext, file_type, file_size, file_remark, file_data, file_contents from txfd_file_env";

        public const string _CDF_FILE_NO_ = "file_no";
        public const string _CDF_FILE_CHECK_ = "file_check";
        public const string _CDF_FILE_CHECK_SUB_ = "file_check_sub";
        public const string _CDF_FILE_NAME_ = "file_name";
        public const string _CDF_FILE_SAVE_ = "file_save";
        public const string _CDF_FILE_PATH_ = "file_path";
        public const string _CDF_FILE_EXT_ = "file_ext";
        public const string _CDF_FILE_TYPE_ = "file_type";
        public const string _CDF_FILE_SIZE_ = "file_size";
        public const string _CDF_FILE_REMARK_ = "file_remark";
        public const string _CDF_FILE_DATA_ = "file_data";
        [JsonProperty(_CDF_FILE_NO_)] public decimal? FILE_NO { get; set; }
        [JsonProperty(_CDF_FILE_CHECK_)] public string? FILE_CHECK { get; set; }

        [JsonProperty(_CDF_FILE_CHECK_SUB_)] public string? FILE_CHECK_SUB { get; set; }

        [JsonProperty(_CDF_FILE_NAME_)] public string? FILE_NAME { get; set; }
        [JsonProperty(_CDF_FILE_SAVE_)] public string? FILE_SAVE { get; set; }
        [JsonProperty(_CDF_FILE_PATH_)] public string? FILE_PATH { get; set; }
        [JsonProperty(_CDF_FILE_EXT_)] public string? FILE_EXT { get; set; }
        [JsonProperty(_CDF_FILE_TYPE_)] public string? FILE_TYPE { get; set; }
        [JsonProperty(_CDF_FILE_SIZE_)] public long? FILE_SIZE { get; set; }
        [JsonProperty(_CDF_FILE_REMARK_)] public string? FILE_REMARK { get; set; }
        [JsonProperty(_CDF_FILE_DATA_)] public string? FILE_DATA { get; set; }

        public SQL_TXFD_FILE_ENV_Table()
        {
            Clear();
        }

        public override void Clear()
        {
            FILE_NO = null;
            FILE_CHECK = null;
            FILE_CHECK_SUB = null;
            FILE_NAME = null;
            FILE_SAVE = null;
            FILE_PATH = null;
            FILE_EXT = null;
            FILE_TYPE = null;
            FILE_SIZE = null;
            FILE_REMARK = null;
        }

        public override string GetDbSelectDefaultQueryString()
        {
            return _SELECT_DEFAULT_QUERY_STRING_;
        }

        public override string GetDbTableName()
        {
            return _DB_TABLE_NAME_;
        }
        public override string GetDbSeqName()
        {
            return _DB_SEQ_NAME_;
        }

        public override bool IsEmpty()
        {
            return FILE_NO == null && FILE_CHECK == null && FILE_CHECK_SUB == null;
        }

        public override bool IsValid()
        {
            return FILE_NO != null;
        }

        public override bool SetDbInsert(IHxDb db, string? userText = null, decimal? uno = null)
        {
            bool Result = false;
            bool isValid = IsValid();
            if (isValid != true) { return Result; }
            if (db == null) throw new ArgumentNullException("Database Resource");
            if (db.Open() != true) { return Result; }

            string SQL = $@"INSERT INTO {GetDbTableName()} (
    file_no, file_check, file_check_sub, file_name, file_save, file_path, file_ext, file_type, file_size, file_remark
) VALUES (
    :file_no, :file_check, :file_check_sub, :file_name, :file_save, :file_path, :file_ext, :file_type, :file_size, :file_remark
)";
            int n = db.Query(SQL, new Dictionary<string, object>()
            {
                { "file_no", this.FILE_NO ?? DbNullToObject },
                { "file_check", this.FILE_CHECK  ?? DbNullToObject },
                { "file_check_sub", this.FILE_CHECK_SUB ?? DbNullToObject },
                { "file_name", this.FILE_NAME ?? DbNullToObject },
                { "file_save", this.FILE_SAVE ?? DbNullToObject },
                { "file_path", this.FILE_PATH ?? DbNullToObject },
                { "file_ext", this.FILE_EXT ?? DbNullToObject },
                { "file_type", this.FILE_TYPE ?? DbNullToObject },
                { "file_size", this.FILE_SIZE ?? DbNullToObject },
                { "file_remark", this.FILE_REMARK ?? DbNullToObject },
            });
            if (n > 0)
            {
                Result = true;
            }
            return Result;
        }

        public override bool SetDbInsert(IHxDb db, (string? userText, decimal? uno) woker)
        {
            throw new NotImplementedException();
        }

        public static DataTable? ToDataTable(IHxDb db, string? additionalConditions = null)
        {
            if (db == null) throw new ArgumentNullException("Database Resource");

            if (db.Open() != true) { return null; }

            string SQL = string.Format(_SELECT_DEFAULT_QUERY_STRING_, string.Empty);
            if (additionalConditions.IsNullOrWhiteSpaceEx() != true)
            {
                SQL = GetQueryString(SQL, additionalConditions);
            }
            SQL = HxUtils.OrderByQueryString(SQL, $"{_CDF_FILE_NO_} ASC");

            DataTable Result = db.QueryDataTable(SQL);
            if (Result != null) { Result.TableName = _DB_TABLE_NAME_; }

            return Result;
        }
    }
    public class SQL_TXFD_Helper<T>
        where T : SQL_TXFD_BASE, ISQL_TXFD_BASE_Table, new()
    {
        private T Source;
        public IHxDb DB => Source.DB;
        public SQL_TXFD_Helper(IHxDb db = null)
        {
            Source = new T();
            if (db != null)
            {
                SetDbConn(db);
            }
        }
        public static SQL_TXFD_Helper<T> Create(IHxDb db = null)
        {
            return new SQL_TXFD_Helper<T>(db);
        }
        public void SetDbConn(IHxDb db)
        {
            Source.SetDbConn(db);
        }
        public decimal? NextID(string seqName = null)
        {
            if(seqName.IsNullOrWhiteSpaceEx() == true)
            {
                seqName = Source.GetDbSeqName();
            }
            if(seqName.IsNullOrWhiteSpaceEx() != true)
            {
                return DB.NextID(seqName);
            }
            return null;
        }

        [JsonProperty("dbTableName")]
        public string? DbTableName => Source.GetDbTableName();

        [JsonProperty("dbSelectDefaultQueryString")]
        public string? DbSelectDefaultQueryString => Source.GetDbSelectDefaultQueryString();
        protected string ToQueryString(string baseQuery, string? additionalConditions)
        {
            return HxUtils.GetQueryString(baseQuery, additionalConditions);
        }
        public string ToDbSelectDefaultQueryString(string? additionalConditions = null)
        {
            string SQL = string.Format(DbSelectDefaultQueryString, string.Empty);
            if (additionalConditions.IsNullOrWhiteSpaceEx() != true)
            {
                SQL = ToQueryString(SQL, additionalConditions);
            }
            return SQL;
        }
        public bool ExecuteDbInsert(IHxDb db, T record, string? userText = null, decimal? uno = null)
        {
            return Source!.SetDbInsert(db, userText, uno);
        }

        public DataTable? ToDataTable(IHxDb db = null, string? addWhereQuery = null)
        {
            if (db == null) { db = this.DB; }
            if (db == null) throw new ArgumentNullException("Database Resource");

            if (db.Open() != true) { return null; }

            string SQL = string.Format(DbSelectDefaultQueryString, string.Empty);
            if (addWhereQuery.IsNullOrWhiteSpaceEx() != true)
            {
                SQL = ToQueryString(SQL, addWhereQuery);
            }
            DataTable Result = db.QueryDataTable(SQL);
            if (Result != null) { Result.TableName = DbTableName; }
            return Result;
        }

        public T[]? ToRecordSet(IHxDb db = null, string? addWhereQuery = null)
        {
            DataTable? dt = ToDataTable(db, addWhereQuery);
            if (dt == null || dt.Rows.Count <= 0) { return null; }
            return dt.ToRecordSetEx<T>();
        }

        public T[]? ConvertRecordSet(DataTable dt)
        {
            if (dt == null || dt.Rows.Count <= 0) { return null; }
            return dt.ToRecordSetEx<T>();
        }

        public string? ToJsonSerializeDataTable(IHxDb db, string? addWhereQuery = null)
        {
            DataTable? dt = ToDataTable(db, addWhereQuery);
            if (dt == null || dt.Rows.Count <= 0) { return null; }
            string Result = dt.ToJsonStringEx();
            return Result;
        }
        public string? ToJsonSerializeRecordSet(IHxDb db, string? addWhereQuery = null, HxNameingCaseType caseType = HxNameingCaseType.JsonCase)
        {
            T[]? rs = ToRecordSet(db, addWhereQuery);
            if (rs == null || rs.Length <= 0) { return null; }
            return rs.ToJsonStringWithNameingCaseEx(caseType);
        }
        public T? ToJsonDeserializeRecord(string json, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
        {
            return HxUtils.JsonDeserializeObjectWithNameingCase<T>(json, caseType);
        }
        public T[]? ToJsonDeserializeRecordSet(string json, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
        {
            return HxUtils.JsonDeserializeObjectWithNameingCase<T[]>(json, caseType);
        }
        public T? ToJsonDeserializeRecordFromResponseData(string json, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
        {
            return HxUtils.JsonDeserializeObjectWithNameingCase<T>(json, caseType);
        }
        public T[]? ToJsonDeserializeRecordSetFromResponseData(string json, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
        {
            return HxUtils.JsonDeserializeObjectWithNameingCase<T[]>(json, caseType);
        }
        public T? ToJsonDeserializeRecordFromResponseDataObject(object responseDataObj, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
        {
            string json = HxUtils.JsonSerializeObject(responseDataObj);
            return ToJsonDeserializeRecordFromResponseData(json, caseType);
        }
        public T[]? ToJsonDeserializeRecordSetFromResponseDataObject(object responseDataObj, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
        {
            string json = HxUtils.JsonSerializeObject(responseDataObj);
            return ToJsonDeserializeRecordSetFromResponseData(json, caseType);
        }
        public T? ToJsonDeserializeRecordFromDataTable(DataTable dt, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
        {
            string json = dt.ToJsonStringEx();
            return HxUtils.JsonDeserializeObjectWithNameingCase<T>(json, caseType);
        }
        public T[]? ToJsonDeserializeRecordSetFromDataTable(DataTable dt, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
        {
            string json = dt.ToJsonStringEx();
            return HxUtils.JsonDeserializeObjectWithNameingCase<T[]>(json, caseType);
        }
        public T? ToJsonDeserializeRecordFromDataRow(DataRow dr, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
        {
            string json = HxUtils.JsonSerializeObject(dr);
            return HxUtils.JsonDeserializeObjectWithNameingCase<T>(json, caseType);
        }
        /**
        public static T[]? ToJsonDeserializeRecordSetFromDataRowCollection(DataRowCollection drc, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
        {
            List<T> list = new List<T>();
            foreach (DataRow dr in drc)
            {
                string json = HxUtils.JsonSerializeObject(dr);
                T? record = HxUtils.JsonDeserializeObjectWithNameingCase<T>(json, caseType);
                if (record != null)
                {
                    list.Add(record);
                }
            }
            return list.ToArray();
        }
        public static T? ToJsonDeserializeRecordFromDataRowObject(object dataRowObj, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
        {
            string json = HxUtils.JsonSerializeObject(dataRowObj);
            return HxUtils.JsonDeserializeObjectWithNameingCase<T>(json, caseType);
        }
        public static T?[]? ToJsonDeserializeRecordSetFromDataRowObjectCollection(object dataRowObjCollection, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
        {
            string json = HxUtils.JsonSerializeObject(dataRowObjCollection);
            return HxUtils.JsonDeserializeObjectWithNameingCase<T[]>(json, caseType);
        }
        public static T? ToJsonDeserializeRecordFromDataRowCollectionObject(object dataRowCollectionObj, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
        {
            string json = HxUtils.JsonSerializeObject(dataRowCollectionObj);
            return HxUtils.JsonDeserializeObjectWithNameingCase<T>(json, caseType);
        }
        public static T?[]? ToJsonDeserializeRecordSetFromDataRowCollectionObject(object dataRowCollectionObj, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
        {
            string json = HxUtils.JsonSerializeObject(dataRowCollectionObj);
            return HxUtils.JsonDeserializeObjectWithNameingCase<T[]>(json, caseType);
        }
        public static T? ToJsonDeserializeRecordFromDataRowArrayObject(object dataRowArrayObj, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
        {
            string json = HxUtils.JsonSerializeObject(dataRowArrayObj);
            return HxUtils.JsonDeserializeObjectWithNameingCase<T>(json, caseType);
        }
        public static T?[]? ToJsonDeserializeRecordSetFromDataRowArrayObject(object dataRowArrayObj, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
        {
            string json = HxUtils.JsonSerializeObject(dataRowArrayObj);
            return HxUtils.JsonDeserializeObjectWithNameingCase<T[]>(json, caseType);
        }
        public static T? ToJsonDeserializeRecordFromDataRowArray(DataRow[] dra, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
        {
            string json = HxUtils.JsonSerializeObject(dra);
            return HxUtils.JsonDeserializeObjectWithNameingCase<T>(json, caseType);
        }
        public static T[]? ToJsonDeserializeRecordSetFromDataRowArray(DataRow[] dra, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
        {
            string json = HxUtils.JsonSerializeObject(dra);
            return HxUtils.JsonDeserializeObjectWithNameingCase<T[]>(json, caseType);
        }
        public static T? ToJsonDeserializeRecordFromDataRowEnumerable(IEnumerable<DataRow> dre, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
        {
            string json = HxUtils.JsonSerializeObject(dre);
            return HxUtils.JsonDeserializeObjectWithNameingCase<T>(json, caseType);
        }
        public static T[]? ToJsonDeserializeRecordSetFromDataRowEnumerable(IEnumerable<DataRow> dre, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
        {
            string json = HxUtils.JsonSerializeObject(dre);
            return HxUtils.JsonDeserializeObjectWithNameingCase<T[]>(json, caseType);
        }
        public static T? ToJsonDeserializeRecordFromDataRowList(List<DataRow> drl, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
        {
            string json = HxUtils.JsonSerializeObject(drl);
            return HxUtils.JsonDeserializeObjectWithNameingCase<T>(json, caseType);
        }
        public static T[]? ToJsonDeserializeRecordSetFromDataRowList(List<DataRow> drl, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
        {
            string json = HxUtils.JsonSerializeObject(drl);
            return HxUtils.JsonDeserializeObjectWithNameingCase<T[]>(json, caseType);
        }
        public static T? ToJsonDeserializeRecordFromDataRowListObject(object dataRowListObj, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
        {
            string json = HxUtils.JsonSerializeObject(dataRowListObj);
            return HxUtils.JsonDeserializeObjectWithNameingCase<T>(json, caseType);
        }
        public static T[]? ToJsonDeserializeRecordSetFromDataRowListObject(object dataRowListObj, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
        {
            string json = HxUtils.JsonSerializeObject(dataRowListObj);
            return HxUtils.JsonDeserializeObjectWithNameingCase<T[]>(json, caseType);
        }
        public static T? ToJsonDeserializeRecordFromDataRowEnumerableObject(object dataRowEnumerableObj, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
        {
            string json = HxUtils.JsonSerializeObject(dataRowEnumerableObj);
            return HxUtils.JsonDeserializeObjectWithNameingCase<T>(json, caseType);
        }
        public static T[]? ToJsonDeserializeRecordSetFromDataRowEnumerableObject(object dataRowEnumerableObj, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
        {
            string json = HxUtils.JsonSerializeObject(dataRowEnumerableObj);
            return HxUtils.JsonDeserializeObjectWithNameingCase<T[]>(json, caseType);
        }
        public static T? ToJsonDeserializeRecordFromDataRowArrayObjectCollection(object dataRowArrayObjCollection, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
        {
            string json = HxUtils.JsonSerializeObject(dataRowArrayObjCollection);
            return HxUtils.JsonDeserializeObjectWithNameingCase<T>(json, caseType);
        }
        public static T[]? ToJsonDeserializeRecordSetFromDataRowArrayObjectCollection(object dataRowArrayObjCollection, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
        {
            string json = HxUtils.JsonSerializeObject(dataRowArrayObjCollection);
            return HxUtils.JsonDeserializeObjectWithNameingCase<T[]>(json, caseType);
        }
        public static T? ToJsonDeserializeRecordFromDataRowEnumerableObjectCollection(object dataRowEnumerableObjCollection, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
        {
            string json = HxUtils.JsonSerializeObject(dataRowEnumerableObjCollection);
            return HxUtils.JsonDeserializeObjectWithNameingCase<T>(json, caseType);
        }
        public static T[]? ToJsonDeserializeRecordSetFromDataRowEnumerableObjectCollection(object dataRowEnumerableObjCollection, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
        {
            string json = HxUtils.JsonSerializeObject(dataRowEnumerableObjCollection);
            return HxUtils.JsonDeserializeObjectWithNameingCase<T[]>(json, caseType);
        }
        public static T? ToJsonDeserializeRecordFromDataRowListObjectCollection(object dataRowListObjCollection, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
        {
            string json = HxUtils.JsonSerializeObject(dataRowListObjCollection);
            return HxUtils.JsonDeserializeObjectWithNameingCase<T>(json, caseType);
        }
        public static T[]? ToJsonDeserializeRecordSetFromDataRowListObjectCollection(object dataRowListObjCollection, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
        {
            string json = HxUtils.JsonSerializeObject(dataRowListObjCollection);
            return HxUtils.JsonDeserializeObjectWithNameingCase<T[]>(json, caseType);
        }
        public static T? ToJsonDeserializeRecordFromDataRowCollectionObjectCollection(object dataRowCollectionObjCollection, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
        {
            string json = HxUtils.JsonSerializeObject(dataRowCollectionObjCollection);
            return HxUtils.JsonDeserializeObjectWithNameingCase<T>(json, caseType);
        }
        public static T[]? ToJsonDeserializeRecordSetFromDataRowCollectionObjectCollection(object dataRowCollectionObjCollection, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
        {
            string json = HxUtils.JsonSerializeObject(dataRowCollectionObjCollection);
            return HxUtils.JsonDeserializeObjectWithNameingCase<T[]>(json, caseType);
        }
        public static T? ToJsonDeserializeRecordFromDataTableObject(object dataTableObj, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
        {
            string json = HxUtils.JsonSerializeObject(dataTableObj);
            return HxUtils.JsonDeserializeObjectWithNameingCase<T>(json, caseType);
        }
        public static T[]? ToJsonDeserializeRecordSetFromDataTableObject(object dataTableObj, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
        {
            string json = HxUtils.JsonSerializeObject(dataTableObj);
            return HxUtils.JsonDeserializeObjectWithNameingCase<T[]>(json, caseType);
        }
        public static T? ToJsonDeserializeRecordFromDataTableObjectCollection(object dataTableObjCollection, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
        {
            string json = HxUtils.JsonSerializeObject(dataTableObjCollection);
            return HxUtils.JsonDeserializeObjectWithNameingCase<T>(json, caseType);
        }*/
    }

    public class SQL_TXFD_SITE_SET_Table : HxDbModelSetValue, IHxSetValue
    {
        public const string _TABLE_NAME_ = "TXFD_SITE_SET";
        public const string _SELECT_DEFAULT_QUERY_STRING_ = $@"SELECT 
    sno, site_name, site_memo, status, stn_code, stn_name, loc_addr, loc_latitude, loc_longitude, loc_road, etc, is_use, raw_guid, reg_date, reg_agent, reg_user, reg_uno, mod_date, mod_agent, mod_user, mod_uno 
FROM {_TABLE_NAME_} 
WHERE 1 = 1 
    AND {_CDF_IS_USE_} = 'Y' {{0}}";

        public const string _CDF_SNO_ = "sno";
        public const string _CDF_SITE_NAME_ = "site_name";
        public const string _CDF_SITE_MEMO_ = "site_memo";
        public const string _CDF_STATUS_ = "status";
        public const string _CDF_STN_CODE_ = "stn_code";
        public const string _CDF_STN_NAME_ = "stn_name";
        public const string _CDF_LOC_ADDR_ = "loc_addr";
        public const string _CDF_LOC_LATITUDE_ = "loc_latitude";
        public const string _CDF_LOC_LONGITUDE_ = "loc_longitude";
        public const string _CDF_LOC_ROAD_ = "LocRoad";


        [JsonProperty(_CDF_SNO_)]
        public decimal SNO { get; set; }
        [JsonProperty(_CDF_SITE_NAME_)]
        public string SITE_NAME { get; set; }
        [JsonProperty(_CDF_STN_CODE_)]
        public string STN_CODE { get; set; }
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


        
        public static DataTable? ToDataTable(IHxDb db, string? additionalConditions = null)
        {
            if (db == null) throw new ArgumentNullException("Database Resource");

            if (db.Open() != true) { return null; }

            string SQL = string.Format(_SELECT_DEFAULT_QUERY_STRING_, string.Empty);
            if (additionalConditions.IsNullOrWhiteSpaceEx() != true)
            {
                SQL = GetQueryString(SQL, additionalConditions);
            }

            DataTable Result = db.QueryDataTable(SQL);
            if (Result != null) { Result.TableName = _TABLE_NAME_; }

            return Result;
        }

        public static SQL_TXFD_SITE_SET_Table[]? ToRecordSet(IHxDb db, string? additionalConditions = null)
        {
            DataTable? dt = ToDataTable(db, additionalConditions);
            if (dt == null || dt.Rows.Count <= 0) { return null; }

            return dt.ToRecordSetEx<SQL_TXFD_SITE_SET_Table>();
        }

        public static string? ToJsonSerializeDataTable(IHxDb db, string? addWhereQuery = null)
        {
            DataTable? dt = ToDataTable(db, addWhereQuery);
            if (dt == null || dt.Rows.Count <= 0)
            {
                return null;
            }
            string Result = dt.ToJsonStringEx();
            return Result;
        }
        public static string? ToJsonSerializeRecordSet(IHxDb db, string? addWhereQuery = null, HxNameingCaseType caseType = HxNameingCaseType.JsonCase)
        {
            SQL_TXFD_SITE_SET_Table[]? rs = ToRecordSet(db, addWhereQuery);
            if (rs == null || rs.Length <= 0)
            {
                return null;
            }
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
        

        public SQL_TXFD_SITE_SET_Table()
        {
            Clear();
        }
        public void Clear()
        {
            this.SNO = int.MinValue;
            this.SITE_NAME = string.Empty;
            this.STN_CODE = string.Empty;
            this.STN_NAME = null;
            this.LOC_ADDR = null;
            this.LOC_LATITUDE = null;
            this.LOC_LONGITUDE = null;
            this.LOC_ROAD = null;
        }

        public bool IsEmpty()
        {
            if (this.SNO != int.MinValue ||
                this.SITE_NAME.IsNullOrWhiteSpaceEx() == false ||
                this.STN_CODE.IsNullOrWhiteSpaceEx() == false ||
                this.STN_NAME != null ||
                this.LOC_ADDR != null ||
                this.LOC_LATITUDE != null ||
                this.LOC_LONGITUDE != null ||
                this.LOC_ROAD != null
                )
            {
                return false;
            }
            return true;
        }

        public bool IsValid()
        {
            if (this.SNO == int.MinValue &&
                this.SITE_NAME.IsNullOrWhiteSpaceEx() &&
                this.STN_CODE.IsNullOrWhiteSpaceEx()
                )
            {
                return true;
            }
            return false;
        }

        public string GetDbTableName()
        {
            return _TABLE_NAME_;
        }

        public string GetDbSelectDefaultQueryString()
        {
            return _SELECT_DEFAULT_QUERY_STRING_;
        }

        public bool SetDbInsert(IHxDb db, string? userText = null, decimal? uno = null)
        {
            bool Result = false;
            bool isValid = IsValid();
            if (isValid != true) { return Result; }

            if (db == null) throw new ArgumentNullException("Database Resource");

            if (db.Open() != true) { return Result; }

            string SQL = $@"INSERT INTO {GetDbTableName()} (
    sno, site_name, stn_code, stn_name, loc_addr, loc_latitude, loc_longitude, loc_road, is_use, raw_guid, reg_date, reg_agent, reg_user, reg_uno
) VALUES (
    :sno, :site_name, :stn_code, :stn_name, :loc_addr, :loc_latitude, :loc_longitude, :loc_road, 'Y', SYS_GUID(), SYSDATE, :reg_agent, :reg_user, :reg_uno, SYSDATE, :mod_agent, :mod_user, :mod_uno
)";
            int n = db.Query(SQL, new Dictionary<string, object>()
            {
                { "sno", this.SNO },
                { "site_name", this.SITE_NAME },
                { "stn_code", this.STN_CODE },
                { "stn_name", this.STN_NAME ?? DbNullToObject },
                { "loc_addr", this.LOC_ADDR ?? DbNullToObject },
                { "loc_latitude", this.LOC_LATITUDE ?? DbNullToObject },
                { "loc_longitude", this.LOC_LONGITUDE ?? DbNullToObject },
                { "loc_road", this.LOC_ROAD ?? DbNullToObject },
                { "reg_agent", CUSTOM_USER_AGENT },
                { "reg_user", userText! },
                { "reg_uno", uno! },
                { "mod_agent", CUSTOM_USER_AGENT },
                { "mod_user", userText! },
                { "mod_uno", uno! },
            });
            if (n > 0)
            {
                Result = true;
            }
            return Result;

        }
    }

    public class SQL_TXFD_DIARY_SET_Table : SQL_TXFD_BASE
    {
        public const string _DB_TABLE_NAME_ = "TXFD_DIARY_SET";
        public const string _DB_SEQ_NAME_ = $"SEQ_{_DB_TABLE_NAME_}";
        public const string _SELECT_DEFAULT_QUERY_STRING_ = @$"SELECT 
 dno, sno, ocr_no, diary_date, tpl_code, tpl_name, file_no
 FROM {_DB_TABLE_NAME_}
 WHERE 1 = 1";

        public const string _CDF_DNO_ = "dno";
        public const string _CDF_PARENT_NO_ = "parent_no";
        public const string _CDF_SNO_ = "sno";
        public const string _CDF_OCR_NO_ = "ocr_no";
        public const string _CDF_DIARY_DATE_ = "diary_date";
        public const string _CDF_TPL_CODE_ = "tpl_code";
        public const string _CDF_TPL_NAME_ = "tpl_name";
        public const string _CDF_FILE_NO_ = "file_no";
        public const string _CDF_FORM_DATA_ = "form_data";

        [JsonProperty(_CDF_DNO_)]       public decimal? DNO { get; set; }
        [JsonProperty(_CDF_PARENT_NO_)] public decimal? PARENT_NO { get; set; }
        [JsonProperty(_CDF_SNO_)]       public decimal? SNO { get; set; }
        [JsonProperty(_CDF_OCR_NO_)]    public decimal? OCR_NO { get; set; }
        [JsonProperty(_CDF_DIARY_DATE_)]public DateTime? DIARY_DATE { get; set; }
        [JsonProperty(_CDF_TPL_CODE_)]  public string? TPL_CODE { get; set; }
        [JsonProperty(_CDF_TPL_NAME_)]  public string? TPL_NAME { get; set; }
        [JsonProperty(_CDF_FILE_NO_)]   public decimal? FILE_NO { get; set; }
        [JsonProperty(_CDF_FORM_DATA_)] public string FORM_DATA { get; set; }

        public SQL_TXFD_DIARY_SET_Table()
        {
            Clear();
        }

        public override void Clear()
        {
            DNO = null; 
            PARENT_NO = null;
            SNO = null;
            OCR_NO = null;
            DIARY_DATE = null;
            TPL_CODE = null;
            TPL_NAME = null;
            FILE_NO = null;
            FORM_DATA = null;
        }

        public override string GetDbSelectDefaultQueryString()
        {
            return _SELECT_DEFAULT_QUERY_STRING_;
        }

        public override string GetDbTableName()
        {
            return _DB_TABLE_NAME_;
        }
        public override string GetDbSeqName()
        {
            return _DB_SEQ_NAME_;
        }

        public override bool IsEmpty()
        {
            throw new NotImplementedException();
        }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }

        public override bool SetDbInsert(IHxDb db, string? userText = null, decimal? uno = null)
        {
            if (DbOpenCheck(db) == true)
            {
                return false;
            }

            bool Result = false;

            string SQL = $@"INSERT INTO {GetDbTableName()} (
    dno, parent_no, sno, ocr_no, diary_date, tpl_code, tpl_name, file_no, form_data
) VALUES (
    :dno,:parent_no,:sno,:ocr_no,:diary_date,:tpl_code,:tpl_name,:file_no,:form_data
)";
            try
            {
                int n = db.Query(SQL, new Dictionary<string, object>()
                {
                    { "dno"         ,  this.DNO ?? DbNullToObject},
                    { "parent_no"   ,  this.PARENT_NO ?? DbNullToObject},
                    { "sno"         ,  this.SNO ?? DbNullToObject},
                    { "ocr_no"      ,  this.OCR_NO ?? DbNullToObject},
                    { "diary_date"  ,  this.DIARY_DATE ?? DbNullToObject},
                    { "tpl_code"    ,  this.TPL_CODE ?? DbNullToObject},
                    { "tpl_name"    ,  this.TPL_NAME ?? DbNullToObject},
                    { "file_no"     ,  this.FILE_NO ?? DbNullToObject},
                    { "form_data"   ,  this.FORM_DATA ?? DbNullToObject},
                    //{ "reg_user"    ,  userText ?? DbNullToObject},
                    //{ "reg_uno"     ,  uno ?? DbNullToObject},
                    //{ "mod_user"    ,  userText ?? DbNullToObject},
                    //{ "mod_uno"     ,  uno ?? DbNullToObject}
                });
                    if (n > 0)
                    {
                        Result = true;
                    }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return Result;
        }

        public override bool SetDbInsert(IHxDb db, (string? userText, decimal? uno) woker)
        {
            return SetDbInsert(db, woker.userText, woker.uno);
        }
    }
    public class SQL_TXFD_DIARY_FIELD_Table : SQL_TXFD_BASE
    {
        public const string _DB_TABLE_NAME_ = "TXFD_DIARY_FIELD";
        public const string _DB_SEQ_NAME_ = $"SEQ_{_DB_TABLE_NAME_}";
        public const string _SELECT_DEFAULT_QUERY_STRING_ = @$"SELECT 
 field_no, parent_no, dno, bind_sno, bind_file_no, field_id, field_name, field_data
 FROM {_DB_TABLE_NAME_}
 WHERE 1 = 1 {{0}}";

        public const string _CDF_FIELD_NO_      = "field_no";
        public const string _CDF_PARENT_NO_     = "parent_no";
        public const string _CDF_DNO_           = "dno";
        public const string _CDF_BIND_SNO_      = "bind_sno";
        public const string _CDF_BIND_FILE_NO_  = "bind_file_no";
        public const string _CDF_FIELD_ID_      = "field_id";
        public const string _CDF_FIELD_NAME_    = "field_name";
        public const string _CDF_FIELD_DATA_    = "field_data";

        [JsonProperty(_CDF_FIELD_NO_)]      public decimal? FIELD_NO     { get; set; }
        [JsonProperty(_CDF_PARENT_NO_)]     public decimal? PARENT_NO    { get; set; }
        [JsonProperty(_CDF_DNO_)]           public decimal? DNO          { get; set; }
        [JsonProperty(_CDF_BIND_SNO_)]      public decimal? BIND_SNO   { get; set; }
        [JsonProperty(_CDF_BIND_FILE_NO_)]  public decimal? BIND_FILE_NO   { get; set; }
        [JsonProperty(_CDF_FIELD_ID_)]      public string?  FIELD_ID   { get; set; }
        [JsonProperty(_CDF_FIELD_NAME_)]    public string?  FIELD_NAME   { get; set; }
        [JsonProperty(_CDF_FIELD_DATA_)]    public string?  FIELD_DATA { get; set; }

        public override void Clear()
        {
            FIELD_NO        = null;
            PARENT_NO       = null;
            DNO             = null;
            BIND_SNO        = null;
            BIND_FILE_NO    = null;
            FIELD_ID        = null;
            FIELD_NAME      = null;
            FIELD_DATA      = null;
        }

        public override string GetDbSelectDefaultQueryString()
        {
            return _SELECT_DEFAULT_QUERY_STRING_;
        }

        public override string GetDbSeqName()
        {
            return _DB_SEQ_NAME_;
        }

        public override string GetDbTableName()
        {
            return _DB_TABLE_NAME_;
        }

        public override bool IsEmpty()
        {
            throw new NotImplementedException();
        }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }

        public override bool SetDbInsert(IHxDb db, string? userText = null, decimal? uno = null)
        {
            if (DbOpenCheck(db) == true)
            {
                return false;
            }

            bool Result = false;

            string SQL = $@"INSERT INTO {GetDbTableName()} (
    field_no, parent_no, dno, bind_sno, bind_file_no, field_id, field_name, field_data
) VALUES (
    :field_no,:parent_no,:dno,:bind_sno,:bind_file_no,:field_id,:field_name,:field_data
)";
            int n = db.Query(SQL, new Dictionary<string, object>()
            {
                { "field_no"     , this.FIELD_NO  ?? DbNullToObject },
                { "parent_no"    , this.PARENT_NO    ?? DbNullToObject },
                { "dno"          , this.DNO          ?? DbNullToObject },
                { "bind_sno"     , this.BIND_SNO     ?? DbNullToObject },
                { "bind_file_no" , this.BIND_FILE_NO ?? DbNullToObject },   
                { "field_id"     , this.FIELD_ID     ?? DbNullToObject },
                { "field_name"   , this.FIELD_NAME   ?? DbNullToObject },
                { "field_data"   , this.FIELD_DATA   ?? DbNullToObject },
                //{ "reg_user"    ,  userText ?? DbNullToObject},
                //{ "reg_uno"     ,  uno ?? DbNullToObject},
                //{ "mod_user"    ,  userText ?? DbNullToObject},
                //{ "mod_uno"     ,  uno ?? DbNullToObject},
            });
            if (n > 0)
            {
                Result = true;
            }
            return Result;
        }

        public override bool SetDbInsert(IHxDb db, (string? userText, decimal? uno) woker)
        {
            return SetDbInsert(db, woker.userText, woker.uno);
        }

        public static DataTable? ToDataTable(IHxDb db, string? additionalConditions = null)
        {
            if (db == null) throw new ArgumentNullException("Database Resource");

            if (db.Open() != true) { return null; }

            string SQL = string.Format(_SELECT_DEFAULT_QUERY_STRING_, string.Empty);
            if (additionalConditions.IsNullOrWhiteSpaceEx() != true)
            {
                SQL = GetQueryString(SQL, additionalConditions);
            }
            SQL = HxUtils.OrderByQueryString(SQL, $"{_CDF_FIELD_NO_} ASC, {_CDF_FIELD_ID_} ASC");

            DataTable Result = db.QueryDataTable(SQL);
            if (Result != null) { Result.TableName = _DB_TABLE_NAME_; }

            return Result;
        }
    }

    public class SQL_TXFD_OCR_ENV_Table : SQL_TXFD_BASE
    {
        public const string _DB_TABLE_NAME_ = "TXFD_OCR_ENV";
        public const string _DB_SEQ_NAME_ = $"SEQ_{_DB_TABLE_NAME_}";
        public const string _SELECT_DEFAULT_QUERY_STRING_ = @$"SELECT 
    ocr_no, parent_no, img_no, tpl_code, tpl_name, response_data, response_data_type, response_version, response_requestid, response_timestamp, etc
FROM {_DB_TABLE_NAME_}
WHERE 1 = 1
    AND {_CDF_IS_USE_} = 'Y' {{0}}
";

        public const string _CDF_OCR_NO_ = "ocr_no";
        public const string _CDF_PARENT_NO_ = "parent_no";
        public const string _CDF_IMG_NO_ = "img_no";
        public const string _CDF_TPL_CODE_ = "tpl_code";
        public const string _CDF_TPL_NAME_ = "tpl_name";
        public const string _CDF_RESPONSE_DATA_ = "response_data";
        public const string _CDF_RESPONSE_DATA_TYPE_ = "response_data_type";
        public const string _CDF_RESPONSE_VERSION_ = "response_version";
        public const string _CDF_RESPONSE_REQUESTID_ = "response_requestid";
        public const string _CDF_RESPONSE_TIMESTAMP_ = "response_timestamp";
        public const string _CDF_ETC_ = "etc";

        [JsonProperty(_CDF_OCR_NO_)] public decimal? OCR_NO { get; set; }
        [JsonProperty(_CDF_PARENT_NO_)] public decimal? PARENT_NO { get; set; }
        [JsonProperty(_CDF_IMG_NO_)] public decimal? IMG_NO { get; set; }
        [JsonProperty(_CDF_TPL_CODE_)] public string? TPL_CODE { get; set; }
        [JsonProperty(_CDF_TPL_NAME_)] public string? TPL_NAME { get; set; }
        [JsonProperty(_CDF_RESPONSE_DATA_)] public string RESPONSE_DATA { get; set; }
        [JsonProperty(_CDF_RESPONSE_DATA_TYPE_)] public string? RESPONSE_DATA_TYPE { get; set; }
        [JsonProperty(_CDF_RESPONSE_VERSION_)] public string? RESPONSE_VERSION { get; set; }
        [JsonProperty(_CDF_RESPONSE_REQUESTID_)] public string? RESPONSE_REQUESTID { get; set; }
        [JsonProperty(_CDF_RESPONSE_TIMESTAMP_)] public decimal? RESPONSE_TIMESTAMP { get; set; }
        [JsonProperty(_CDF_ETC_)] public string? ETC { get; set; }

        public SQL_TXFD_OCR_ENV_Table()
        {
            Clear();
        }
        public override void Clear()
        {
            this.OCR_NO = int.MinValue;
            this.PARENT_NO = null;
            this.IMG_NO = int.MinValue;
            this.TPL_CODE = null;
            this.TPL_NAME = null;
            this.RESPONSE_DATA = string.Empty;
            this.RESPONSE_DATA_TYPE = null;
            this.RESPONSE_VERSION = null;
            this.RESPONSE_REQUESTID = null;
            this.RESPONSE_TIMESTAMP = null;
            this.ETC = null;
        }
        public override bool IsEmpty()
        {
            if (this.OCR_NO == int.MinValue &&
                this.PARENT_NO == null &&
                this.IMG_NO == int.MinValue &&
                this.TPL_CODE.IsNullOrWhiteSpaceEx() &&
                this.TPL_NAME.IsNullOrWhiteSpaceEx() &&
                this.RESPONSE_DATA.IsNullOrWhiteSpaceEx() &&
                this.RESPONSE_DATA_TYPE.IsNullOrWhiteSpaceEx() &&
                this.RESPONSE_VERSION.IsNullOrWhiteSpaceEx() &&
                this.RESPONSE_REQUESTID.IsNullOrWhiteSpaceEx() &&
                this.RESPONSE_TIMESTAMP == null &&
                this.ETC.IsNullOrWhiteSpaceEx())
            {
                return true;
            }
            return false;
        }
        public override bool IsValid()
        {
            if (this.OCR_NO != int.MinValue &&
                this.IMG_NO != int.MinValue &&
                this.RESPONSE_DATA.IsNullOrWhiteSpaceEx() != true)
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

            string SQL = $@"INSERT INTO {GetDbTableName()} (
    ocr_no, parent_no, img_no, tpl_code, tpl_name, response_data, response_data_type, response_version, response_requestid, response_timestamp, etc, is_use, raw_guid, reg_date, reg_agent, reg_user, reg_uno, mod_date, mod_agent, mod_user, mod_uno
) VALUES (
    :ocr_no, :parent_no, :img_no, :tpl_code, :tpl_name, :response_data, :response_data_type, :response_version, :response_requestid, :response_timestamp, :etc, 'Y', SYS_GUID(), SYSDATE, :reg_agent, :reg_user, :reg_uno, SYSDATE, :mod_agent, :mod_user, :mod_uno
)";
            int n = db.Query(SQL, new Dictionary<string, object>()
            {
                { "ocr_no", this.OCR_NO ?? (object)DBNull.Value},
                { "parent_no", this.PARENT_NO ?? (object)DBNull.Value },
                { "img_no", this.IMG_NO ?? (object)DBNull.Value},
                { "tpl_code", this.TPL_CODE ?? (object)DBNull.Value },
                { "tpl_name", this.TPL_NAME ?? (object)DBNull.Value },
                { "response_data", this.RESPONSE_DATA ?? (object)DBNull.Value},
                { "response_data_type", this.RESPONSE_DATA_TYPE ?? (object)DBNull.Value },
                { "response_version", this.RESPONSE_VERSION ?? (object)DBNull.Value },
                { "response_requestid", this.RESPONSE_REQUESTID ?? (object)DBNull.Value },
                { "response_timestamp", this.RESPONSE_TIMESTAMP ?? (object)DBNull.Value },
                { "etc", this.ETC ?? (object)DBNull.Value },
                { "reg_agent", CUSTOM_USER_AGENT },
                { "reg_user", userText! },
                { "reg_uno", uno! },
                { "mod_agent", CUSTOM_USER_AGENT },
                { "mod_user", userText! },
                { "mod_uno", uno! },
            });
            if (n > 0)
            {
                Result = true;
            }
            return Result;
        }

        

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
            return SetDbInsert(db, woker.userText, woker.uno);
        }

        /*
public static SQL_TXFD_OCR_SET_Table[]? ToJsonDeserializeRecordSetFromResponseDataObject(object responseDataObj, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
{
   string json = HxUtils.JsonSerializeObject(responseDataObj);
   return ToJsonDeserializeRecordSetFromResponseData(json, caseType);
}
public static SQL_TXFD_OCR_SET_Table? ToJsonDeserializeRecordFromResponseDataDataTable(DataTable dt, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
{
   string json = HxUtils.JsonSerializeObject(dt);
   return ToJsonDeserializeRecordFromResponseData(json, caseType);
}
public static SQL_TXFD_OCR_SET_Table[]? ToJsonDeserializeRecordSetFromResponseDataDataTable(DataTable dt, HxNameingCaseType caseType = HxNameingCaseType.PascalCase)
{
   string json = HxUtils.JsonSerializeObject(dt);
   return ToJsonDeserializeRecordSetFromResponseData(json, caseType);
}
*/
    }
    public class SQL_TXFD_OCR_JSON_Table : SQL_TXFD_BASE
    {
        public const string _DB_TABLE_NAME_ = "TXFD_OCR_JSON";
        public const string _DB_SEQ_NAME_ = $"SEQ_{_DB_TABLE_NAME_}";
        public const string _SELECT_DEFAULT_QUERY_STRING_ = @$"SELECT
    json_no, parent_no, ocr_no, bind_img_no, kind_code, kind_name, json_uid, json_name, infer_result, message, matchedtemplate_id, matchedtemplate_nm, validation_result, title_name, bounding_top, bounding_left, bounding_width, bounding_height, infer_text, infer_confidence, etc
FROM {_DB_TABLE_NAME_}
WHERE 1 = 1
    AND {_CDF_IS_USE_} = 'Y' {{0}}";

        public const string _CDF_JSON_NO_ = "json_no";
        public const string _CDF_PARENT_NO_ = "parent_no";
        public const string _CDF_OCR_NO_ = "ocr_no";
        public const string _CDF_BIND_IMG_NO_ = "bind_img_no";
        public const string _CDF_KIND_CODE_ = "kind_code";
        public const string _CDF_KIND_NAME_ = "kind_name";
        public const string _CDF_JSON_UID_ = "json_uid";
        public const string _CDF_JSON_NAME_ = "json_name";
        public const string _CDF_INFER_RESULT_ = "infer_result";
        public const string _CDF_MESSAGE_ = "message";
        public const string _CDF_MATCHEDTEMPLATE_ID_ = "matchedtemplate_id";
        public const string _CDF_MATCHEDTEMPLATE_NM_ = "matchedtemplate_nm";
        public const string _CDF_VALIDATION_RESULT_ = "validation_result";
        public const string _CDF_TITLE_NAME_ = "title_name";
        public const string _CDF_TITLE_BOUNDING_TOP_ = "title_bounding_top";
        public const string _CDF_TITLE_BOUNDING_LEFT_ = "title_bounding_left";
        public const string _CDF_TITLE_BOUNDING_WIDTH_ = "title_bounding_width";
        public const string _CDF_TITLE_BOUNDING_HEIGHT_ = "title_bounding_height";
        public const string _CDF_TITLE_INFER_TEXT_ = "title_infer_text";
        public const string _CDF_TITLE_INFER_CONFIDENCE_ = "title_infer_confidence";
        public const string _CDF_ETC_ = "etc";

        [JsonProperty(_CDF_JSON_NO_)] public decimal? JSON_NO { get; set; }
        [JsonProperty(_CDF_PARENT_NO_)] public decimal? PARENT_NO { get; set; }
        [JsonProperty(_CDF_OCR_NO_)] public decimal? OCR_NO { get; set; }
        [JsonProperty(_CDF_BIND_IMG_NO_)] public decimal? BIND_IMG_NO { get; set; }
        [JsonProperty(_CDF_KIND_CODE_)] public string? KIND_CODE { get; set; }
        [JsonProperty(_CDF_KIND_NAME_)] public string? KIND_NAME { get; set; }
        [JsonProperty(_CDF_JSON_UID_)] public string JSON_UID { get; set; }
        [JsonProperty(_CDF_JSON_NAME_)] public string? JSON_NAME { get; set; }
        [JsonProperty(_CDF_INFER_RESULT_)] public string? INFER_RESULT { get; set; }
        [JsonProperty(_CDF_MESSAGE_)] public string? MESSAGE { get; set; }
        [JsonProperty(_CDF_MATCHEDTEMPLATE_ID_)] public decimal? MATCHEDTEMPLATE_ID { get; set; }
        [JsonProperty(_CDF_MATCHEDTEMPLATE_NM_)] public string? MATCHEDTEMPLATE_NM { get; set; }
        [JsonProperty(_CDF_VALIDATION_RESULT_)] public string? VALIDATION_RESULT { get; set; }
        [JsonProperty(_CDF_TITLE_NAME_)] public string? TITLE_NAME { get; set; }
        [JsonProperty(_CDF_TITLE_BOUNDING_TOP_)] public decimal? TITTLE_BOUNDING_TOP { get; set; }
        [JsonProperty(_CDF_TITLE_BOUNDING_LEFT_)] public decimal? TITLE_BOUNDING_LEFT { get; set; }
        [JsonProperty(_CDF_TITLE_BOUNDING_WIDTH_)] public decimal? TITLE_BOUNDING_WIDTH { get; set; }
        [JsonProperty(_CDF_TITLE_BOUNDING_HEIGHT_)] public decimal? TITLE_BOUNDING_HEIGHT { get; set; }
        [JsonProperty(_CDF_TITLE_INFER_TEXT_)] public string? TITLE_INFER_TEXT { get; set; }
        [JsonProperty(_CDF_TITLE_INFER_CONFIDENCE_)] public decimal? TITLE_INFER_CONFIDENCE { get; set; }
        [JsonProperty(_CDF_ETC_)] public string? ETC { get; set; }

        public override void Clear()
        {
            this.JSON_NO = int.MinValue;
            this.PARENT_NO = null;
            this.OCR_NO = int.MinValue;
            this.BIND_IMG_NO = null;
            this.KIND_CODE = null;
            this.KIND_NAME = null;
            this.JSON_UID = string.Empty;
            this.JSON_NAME = null;
            this.INFER_RESULT = null;
            this.MESSAGE = null;
            this.MATCHEDTEMPLATE_ID = null;
            this.MATCHEDTEMPLATE_NM = null;
            this.VALIDATION_RESULT = null;
            this.TITLE_NAME = null;
            this.TITTLE_BOUNDING_TOP = null;
            this.TITLE_BOUNDING_LEFT = null;
            this.TITLE_BOUNDING_WIDTH = null;
            this.TITLE_BOUNDING_HEIGHT = null;
            this.TITLE_INFER_TEXT = null;
            this.TITLE_INFER_CONFIDENCE = null;
            this.ETC = null;
        }
        public override bool IsEmpty()
        {
            if (this.JSON_NO == int.MinValue &&
                this.PARENT_NO == null &&
                this.OCR_NO == int.MinValue &&
                this.BIND_IMG_NO == null &&
                this.KIND_CODE.IsNullOrWhiteSpaceEx() &&
                this.KIND_NAME.IsNullOrWhiteSpaceEx() &&
                this.JSON_UID.IsNullOrWhiteSpaceEx() &&
                this.JSON_NAME.IsNullOrWhiteSpaceEx() &&
                this.INFER_RESULT.IsNullOrWhiteSpaceEx() &&
                this.MESSAGE.IsNullOrWhiteSpaceEx() &&
                this.MATCHEDTEMPLATE_ID.IsNullOrWhiteSpaceEx() &&
                this.MATCHEDTEMPLATE_NM.IsNullOrWhiteSpaceEx() &&
                this.VALIDATION_RESULT.IsNullOrWhiteSpaceEx() &&
                this.TITLE_NAME.IsNullOrWhiteSpaceEx() &&
                this.TITTLE_BOUNDING_TOP == null &&
                this.TITLE_BOUNDING_LEFT == null &&
                this.TITLE_BOUNDING_WIDTH == null &&
                this.TITLE_BOUNDING_HEIGHT == null &&
                this.TITLE_INFER_TEXT.IsNullOrWhiteSpaceEx() &&
                this.TITLE_INFER_CONFIDENCE == null &&
                this.ETC.IsNullOrWhiteSpaceEx())
            {
                return true;
            }
            return false;
        }

        public override bool IsValid()
        {
            if (this.JSON_NO != int.MinValue &&
                this.OCR_NO != int.MinValue &&
                this.JSON_UID.IsNullOrWhiteSpaceEx() != true)
            {
                return true;
            }
            return false;
        }
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

        public override bool SetDbInsert(IHxDb db, string? userText = null, decimal? uno = null)
        {
            bool Result = false;
            bool isValid = IsValid();
            if (isValid != true) { return Result; }
            if (db == null) throw new ArgumentNullException("Database Resource");
            if (db.Open() != true) { return Result; }
            string SQL = $@"INSERT INTO {GetDbTableName()} (
    json_no, parent_no, ocr_no, bind_img_no, kind_code, kind_name, json_uid, json_name, infer_result, message, matchedtemplate_id, matchedtemplate_nm, validation_result, title_name, title_bounding_top, title_bounding_left, title_bounding_width, title_bounding_height, title_infer_text, title_infer_confidence, etc, is_use, raw_guid, reg_date, reg_agent, reg_user, reg_uno, mod_date, mod_agent, mod_user, mod_uno
) VALUES (
    :json_no, :parent_no, :ocr_no, :bind_img_no, :kind_code, :kind_name, :json_uid, :json_name, :infer_result, :message, :matchedtemplate_id, :matchedtemplate_nm, :validation_result, :title_name, :title_bounding_top, :title_bounding_left, :title_bounding_width, :title_bounding_height, :title_infer_text, :title_infer_confidence, :etc, 'Y', SYS_GUID(), SYSDATE, :reg_agent, :reg_user, :reg_uno, SYSDATE, :mod_agent, :mod_user, :mod_uno
)";
            int n = db.Query(SQL, new Dictionary<string, object>()
            {
                { "json_no", this.JSON_NO  ?? (object)DBNull.Value },
                { "parent_no", this.PARENT_NO ?? (object)DBNull.Value },
                { "ocr_no", this.OCR_NO  ?? (object)DBNull.Value },
                { "bind_img_no", this.BIND_IMG_NO ?? (object)DBNull.Value },
                { "kind_code", this.KIND_CODE ?? (object)DBNull.Value },
                { "kind_name", this.KIND_NAME ?? (object)DBNull.Value },
                { "json_uid", this.JSON_UID  ?? (object)DBNull.Value },
                { "json_name", this.JSON_NAME ?? (object)DBNull.Value },
                { "infer_result", this.INFER_RESULT ?? (object)DBNull.Value },
                { "message", this.MESSAGE ?? (object)DBNull.Value },
                { "matchedtemplate_id", this.MATCHEDTEMPLATE_ID ?? (object)DBNull.Value },
                { "matchedtemplate_nm", this.MATCHEDTEMPLATE_NM ?? (object)DBNull.Value },
                { "validation_result", this.VALIDATION_RESULT ?? (object)DBNull.Value },
                { "title_name", this.TITLE_NAME ?? (object)DBNull.Value },
                { "title_bounding_top", this.TITTLE_BOUNDING_TOP ?? (object)DBNull.Value },
                { "title_bounding_left", this.TITLE_BOUNDING_LEFT ?? (object)DBNull.Value },
                { "title_bounding_width", this.TITLE_BOUNDING_WIDTH ?? (object)DBNull.Value },
                { "title_bounding_height", this.TITLE_BOUNDING_HEIGHT ?? (object)DBNull.Value },
                { "title_infer_text", this.TITLE_INFER_TEXT ?? (object)DBNull.Value },
                { "title_infer_confidence", this.TITLE_INFER_CONFIDENCE ?? (object)DBNull.Value },
                { "etc", this.ETC ?? (object)DBNull.Value },
                { "reg_agent", CUSTOM_USER_AGENT },
                { "reg_user", userText! },
                { "reg_uno", uno! },
                { "mod_agent", CUSTOM_USER_AGENT },
                { "mod_user", userText! },
                { "mod_uno", uno! },
            });
            if (n > 0)
            {
                Result = true;
            }
            return Result;
        }

        public override bool SetDbInsert(IHxDb db, (string? userText, decimal? uno) woker)
        {
            return SetDbInsert(db, woker.userText, woker.uno);
        }
    }

    public class SQL_TXFD_OCR_FIELD_Table : SQL_TXFD_BASE
    {
        public const string _DB_TABLE_NAME_ = "TXFD_OCR_FIELD";
        public const string _DB_SEQ_NAME_ = $"SEQ_{_DB_TABLE_NAME_}";
        public const string _SELECT_DEFAULT_QUERY_STRING_ = @$"SELECT
    field_no, parent_no, json_no, bind_ocr_no, bind_img_no, kind_code, kind_name, field_id, field_name, bounding_top, bounding_left, bounding_width, bounding_height, value_type, infer_text, infer_confidence, etc
FROM {_DB_TABLE_NAME_}
WHERE 1 = 1
    AND {_CDF_IS_USE_} = 'Y' {{0}}";

        public const string _CDF_FIELD_NO_          = "field_no";
        public const string _CDF_PARENT_NO_         = "parent_no";
        public const string _CDF_JSON_NO_           = "json_no";
        public const string _CDF_BIND_OCR_NO_       = "bind_ocr_no";
        public const string _CDF_BIND_IMG_NO_       = "bind_img_no";
        public const string _CDF_KIND_CODE_         = "kind_code";
        public const string _CDF_KIND_NAME_         = "kind_name";
        public const string _CDF_FIELD_ID_          = "field_id";
        public const string _CDF_FIELD_NAME_        = "field_name";
        public const string _CDF_BOUNDING_TOP_      = "bounding_top";
        public const string _CDF_BOUNDING_LEFT_     = "bounding_left";
        public const string _CDF_BOUNDING_WIDTH_    = "bounding_width";
        public const string _CDF_BOUNDING_HEIGHT_   = "bounding_height";
        public const string _CDF_VALUE_TYPE_        = "value_type";
        public const string _CDF_INFER_TEXT_        = "infer_text";
        public const string _CDF_INFER_CONFIDENCE_  = "infer_confidence";
        public const string _CDF_ETC_               = "etc";

        [JsonProperty(_CDF_FIELD_NO_)]              public decimal? FIELD_NO { get; set; }
        [JsonProperty(_CDF_PARENT_NO_)]             public decimal? PARENT_NO { get; set; }
        [JsonProperty(_CDF_JSON_NO_)]               public decimal? JSON_NO { get; set; }
        [JsonProperty(_CDF_BIND_OCR_NO_)]           public decimal? BIND_OCR_NO { get; set; }
        [JsonProperty(_CDF_BIND_IMG_NO_)]           public decimal? BIND_IMG_NO { get; set; }
        [JsonProperty(_CDF_KIND_CODE_)]             public string? KIND_CODE { get; set; }
        [JsonProperty(_CDF_KIND_NAME_)]             public string? KIND_NAME { get; set; }
        [JsonProperty(_CDF_FIELD_ID_)]              public string? FIELD_ID { get; set; }
        [JsonProperty(_CDF_FIELD_NAME_)]            public string? FIELD_NAME { get; set; }
        [JsonProperty(_CDF_BOUNDING_TOP_)]          public decimal? BOUNDING_TOP { get; set; }
        [JsonProperty(_CDF_BOUNDING_LEFT_)]         public decimal? BOUNDING_LEFT { get; set; }
        [JsonProperty(_CDF_BOUNDING_WIDTH_)]        public decimal? BOUNDING_WIDTH { get; set; }
        [JsonProperty(_CDF_BOUNDING_HEIGHT_)]       public decimal? BOUNDING_HEIGHT { get; set; }
        [JsonProperty(_CDF_VALUE_TYPE_)]            public string? VALUE_TYPE { get; set; }
        [JsonProperty(_CDF_INFER_TEXT_)]            public string? INFER_TEXT { get; set; }
        [JsonProperty(_CDF_INFER_CONFIDENCE_)]      public decimal? INFER_CONFIDENCE { get; set; }
        [JsonProperty(_CDF_ETC_)]                   public string? ETC { get; set; }

        public override void Clear()
        {
            this.FIELD_NO = int.MinValue;
            this.PARENT_NO = null;
            this.JSON_NO = int.MinValue;
            this.BIND_OCR_NO = null;
            this.BIND_IMG_NO = null;
            this.KIND_CODE = null;
            this.KIND_NAME = null;
            this.FIELD_ID = string.Empty;
            this.FIELD_NAME = null;
            this.BOUNDING_TOP = null;
            this.BOUNDING_LEFT = null;
            this.BOUNDING_WIDTH = null;
            this.BOUNDING_HEIGHT = null;
            this.VALUE_TYPE = null;
            this.INFER_TEXT = null;
            this.INFER_CONFIDENCE = null;
            this.ETC = null;
        }

        public override string GetDbSelectDefaultQueryString()
        {
            return _SELECT_DEFAULT_QUERY_STRING_;
        }

        

        public override string GetDbTableName()
        {
            return _DB_TABLE_NAME_;
        }
        public override string GetDbSeqName()
        {
            return _DB_SEQ_NAME_;
        }

        public override bool IsEmpty()
        {
            if (this.FIELD_NO == int.MinValue &&
                this.PARENT_NO == null &&
                this.JSON_NO == int.MinValue &&
                this.BIND_OCR_NO == null &&
                this.BIND_IMG_NO == null &&
                this.KIND_CODE.IsNullOrWhiteSpaceEx() &&
                this.KIND_NAME.IsNullOrWhiteSpaceEx() &&
                this.FIELD_ID.IsNullOrWhiteSpaceEx() &&
                this.FIELD_NAME.IsNullOrWhiteSpaceEx() &&
                this.BOUNDING_TOP == null &&
                this.BOUNDING_LEFT == null &&
                this.BOUNDING_WIDTH == null &&
                this.BOUNDING_HEIGHT == null &&
                this.VALUE_TYPE.IsNullOrWhiteSpaceEx() &&
                this.INFER_TEXT.IsNullOrWhiteSpaceEx() &&
                this.INFER_CONFIDENCE == null &&
                this.ETC.IsNullOrWhiteSpaceEx())
            {
                return true;
            }
            return false;
        }

        public override bool IsValid()
        {
            if (this.FIELD_NO != int.MinValue &&
                this.JSON_NO != int.MinValue &&
                this.FIELD_ID.IsNullOrWhiteSpaceEx() != true)
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
            string SQL = $@"INSERT INTO {GetDbTableName()} (
    field_no, parent_no, json_no, bind_ocr_no, bind_img_no, kind_code, kind_name, field_id, field_name, bounding_top, bounding_left, bounding_width, bounding_height, value_type, infer_text, infer_confidence, etc, is_use, raw_guid, reg_date, reg_agent, reg_user, reg_uno, mod_date, mod_agent, mod_user, mod_uno
) VALUES (
    :field_no, :parent_no, :json_no, :bind_ocr_no, :bind_img_no, :kind_code, :kind_name, :field_id, :field_name, :bounding_top, :bounding_left, :bounding_width, :bounding_height, :value_type, :infer_text, :infer_confidence, :etc, 'Y', SYS_GUID(), SYSDATE, :reg_agent, :reg_user, :reg_uno, SYSDATE, :mod_agent, :mod_user, :mod_uno
)";
            int n = db.Query(SQL, new Dictionary<string, object>()
            {
                { "field_no", this.FIELD_NO ?? (object)DBNull.Value },
                { "parent_no", this.PARENT_NO ?? (object)DBNull.Value },
                { "json_no", this.JSON_NO ?? (object)DBNull.Value },
                { "bind_ocr_no", this.BIND_OCR_NO ?? (object)DBNull.Value },
                { "bind_img_no", this.BIND_IMG_NO ?? (object)DBNull.Value },
                { "kind_code", this.KIND_CODE ?? (object)DBNull.Value },
                { "kind_name", this.KIND_NAME ?? (object)DBNull.Value },
                { "field_id", this.FIELD_ID ?? (object)DBNull.Value },
                { "field_name", this.FIELD_NAME ?? (object)DBNull.Value },
                { "bounding_top", this.BOUNDING_TOP ?? (object)DBNull.Value },
                { "bounding_left", this.BOUNDING_LEFT ?? (object)DBNull.Value },
                { "bounding_width", this.BOUNDING_WIDTH ?? (object)DBNull.Value },
                { "bounding_height", this.BOUNDING_HEIGHT ?? (object)DBNull.Value },
                { "value_type", this.VALUE_TYPE ?? (object)DBNull.Value },
                { "infer_text", this.INFER_TEXT ?? (object)DBNull.Value },
                { "infer_confidence", this.INFER_CONFIDENCE ?? (object)DBNull.Value },
                { "etc", this.ETC ?? (object)DBNull.Value },
                { "reg_agent", CUSTOM_USER_AGENT ?? (object)DBNull.Value },
                { "reg_user", userText ?? (object)DBNull.Value },
                { "reg_uno", uno ?? (object)DBNull.Value },
                { "mod_agent", CUSTOM_USER_AGENT ?? (object)DBNull.Value },
                { "mod_user", userText ?? (object)DBNull.Value },
                { "mod_uno", uno ?? (object)DBNull.Value },
            });
            if (n > 0)
            {
                Result = true;
            }
            return Result;
        }

        public override bool SetDbInsert(IHxDb db, (string? userText, decimal? uno) woker)
        {
            return SetDbInsert(db, woker.userText, woker.uno);
        }
    }

    public class SQL_TXFD_DIARY_INFO_View : SQL_TXFD_DIARY_SET_Table
    {
        public const string _DB_VIEW_NAME_ = "V_TXFD_DIARY_INFO";

        public const string _SELECT_VIEW_QUERY_FORMAT_STRING_ = $@"WITH W_DI AS (
	SELECT * 
	FROM TXFD_DIARY_SET di
	WHERE 1 = 1 {{0}}
),
W_DF AS (
	SELECT di.sno, di.DIARY_DATE, df.*
	FROM TXFD_DIARY_FIELD df
		, W_DI di
	WHERE df.dno = di.dno
),
W_OCR_ENV AS (
	SELECT di.sno, di.DIARY_DATE, di.dno, toe.*
	FROM TXFD_OCR_ENV toe
		, W_DI di
	WHERE di.ocr_no IS NOT NULL AND toe.ocr_no = di.ocr_no
),
W_OCR_JSON AS (
	SELECT oce.sno, oce.DIARY_DATE, oce.dno, oce.img_no, ocj.*
	FROM TXFD_OCR_JSON ocj
		, W_OCR_ENV oce
	WHERE ocj.OCR_NO = oce.OCR_NO
),
W_OCR_FIELD AS (
	SELECT ocj.sno, ocj.DIARY_DATE, ocj.dno, ocj.ocr_no, ocj.img_no, ocf.*
	FROM TXFD_OCR_FIELD ocf
		, W_OCR_JSON ocj
	WHERE ocf.json_no = ocj.json_no
),
W_DF_CNT AS (
	SELECT df.dno, count(0) field_cnt
	FROM W_DF df
	WHERE EXISTS (SELECT 1 FROM W_DI di WHERE df.dno = di.dno)
	GROUP BY df.dno
),
W_OCR_JSON_CNT AS (
	SELECT ocj.dno, count(0) json_cnt
	FROM W_OCR_JSON ocj
	WHERE EXISTS (SELECT 1 FROM W_OCR_ENV oce WHERE ocj.ocr_no = oce.ocr_no)
	GROUP BY ocj.dno
),
W_OCR_FIELD_CNT AS (
	SELECT ocf.dno, count(0) ocr_field_cnt
	FROM W_OCR_FIELD ocf
	WHERE EXISTS (SELECT 1 FROM W_OCR_ENV oce WHERE ocf.dno = oce.dno)
	GROUP BY ocf.dno
),
W_DIARY_INPUT_DATE AS (
	SELECT di.DNO, di.DIARY_DATE, df.FIELD_ID, df.FIELD_NAME, df.FIELD_DATA, df.FIELD_DATA INPUT_DATE
	FROM W_DF df
		, W_DI di
	WHERE df.DNO = di.DNO
		AND df.FIELD_ID = '작업일'
),
W_DIARY_INPUT_WRITER AS (
	SELECT di.DNO, di.DIARY_DATE, df.FIELD_ID, df.FIELD_NAME, df.FIELD_DATA, df.FIELD_DATA INPUT_WRITER
	FROM W_DF df
		, W_DI di
	WHERE df.DNO = di.DNO
		AND df.FIELD_ID = '작성자'
),
W_DIARY_INPUT_CROPS AS (
	SELECT di.DNO, di.DIARY_DATE, df.FIELD_ID, df.FIELD_NAME, df.FIELD_DATA, df.FIELD_DATA INPUT_CROPS
	FROM W_DF df
		, W_DI di
	WHERE df.DNO = di.DNO
		AND df.FIELD_ID = '작목'
),
W_DIARY_INPUT_ADDR AS (
	SELECT di.DNO, di.DIARY_DATE, df.FIELD_ID, df.FIELD_NAME, df.FIELD_DATA, df.FIELD_DATA INPUT_ADDR
	FROM W_DF df
		, W_DI di
	WHERE df.DNO = di.DNO
		AND df.FIELD_ID = '농장_필지'
),
W_DIARY_INPUT_WEATHER AS (
	SELECT di.DNO, di.DIARY_DATE, df.FIELD_ID, df.FIELD_NAME, df.FIELD_DATA, df.FIELD_DATA INPUT_WEATHER
	FROM W_DF df
		, W_DI di
	WHERE df.DNO = di.DNO
		AND df.FIELD_ID = '날씨_기상'
), 
A AS (
    SELECT 
	    di.DNO, di.PARENT_NO, di.SNO, di.OCR_NO, di.DIARY_DATE, di.TPL_CODE, di.TPL_NAME, di.FILE_NO, di.FORM_DATA
	    , dfc.FIELD_CNT
	    , ojc.JSON_CNT
	    , ofc.OCR_FIELD_CNT
	    , did.INPUT_DATE
	    , diwr.INPUT_WRITER
	    , diwe.INPUT_WEATHER
	    , dicr.INPUT_CROPS
	    , diad.INPUT_ADDR
	    , di.IS_USE, di.REG_DATE , di.MOD_DATE
    FROM W_DI di
	    , W_DF_CNT dfc
	    , W_OCR_JSON_CNT ojc
	    , W_OCR_FIELD_CNT ofc
	    , W_DIARY_INPUT_DATE did
	    , W_DIARY_INPUT_WRITER diwr
	    , W_DIARY_INPUT_WEATHER diwe
	    , W_DIARY_INPUT_CROPS dicr
	    , W_DIARY_INPUT_ADDR diad
    WHERE di.DNO = dfc.DNO (+)
	    AND di.DNO = ojc.DNO(+)
	    AND di.DNO = ofc.DNO(+)
	    AND di.DNO = did.DNO(+)
	    AND di.DNO = diwr.DNO(+)
	    AND di.DNO = diwe.DNO(+)
	    AND di.DNO = dicr.DNO(+)
	    AND di.DNO = diad.DNO(+)
)
SELECT * FROM A
WHERE 1 = 1 {{1}}";

        public const string _CDF_FIELD_CNT_       = "field_cnt";
        public const string _CDF_JSON_CNT_        = "json_cnt";
        public const string _CDF_OCR_FIELD_CNT_   = "ocr_field_cnt";
        public const string _CDF_INPUT_DATE_      = "input_date";
        public const string _CDF_INPUT_WRITER_    = "input_writer";
        public const string _CDF_INPUT_WEATHER_   = "input_weather";
        public const string _CDF_INPUT_CROPS_     = "input_crops";
        public const string _CDF_INPUT_ADDR_      = "input_addr";


        [JsonProperty(_CDF_FIELD_CNT_    )] public decimal?  FIELD_CNT     { get; set; }
        [JsonProperty(_CDF_JSON_CNT_     )] public decimal?  JSON_CNT      { get; set; }
        [JsonProperty(_CDF_OCR_FIELD_CNT_)] public decimal?  OCR_FIELD_CNT { get; set; }
        [JsonProperty(_CDF_INPUT_DATE_   )] public string?  INPUT_DATE    { get; set; }
        [JsonProperty(_CDF_INPUT_WRITER_ )] public string?  INPUT_WRITER  { get; set; }
        [JsonProperty(_CDF_INPUT_WEATHER_)] public string?  INPUT_WEATHER { get; set; }
        [JsonProperty(_CDF_INPUT_CROPS_  )] public string?  INPUT_CROPS   { get; set; }
        [JsonProperty(_CDF_INPUT_ADDR_   )] public string?  INPUT_ADDR    { get; set; }

        public string GetDbSelectQueryFormatString(string addMainWhere, string? addSubWhere = null)
        {
            return ToDbSelectQueryFormatString(addMainWhere, addSubWhere);
        }
        public static string ToDbSelectQueryFormatString(string addMainWhere, string? addSubWhere = null)
        {
            string strQueryFormat = _SELECT_VIEW_QUERY_FORMAT_STRING_;
            return string.Format(strQueryFormat, addMainWhere, (addSubWhere ?? string.Empty));
        }

        public static DataTable? ToDataTable(IHxDb db, string? additionalConditions = null)
        {
            if (db == null) throw new ArgumentNullException("Database Resource");

            if (db.Open() != true) { return null; }

            string SQL = ToDbSelectQueryFormatString(string.Empty, string.Empty);
            if (additionalConditions.IsNullOrWhiteSpaceEx() != true)
            {
                SQL = GetQueryString(SQL, additionalConditions);
            }

            DataTable Result = db.QueryDataTable(SQL);
            if (Result != null) { Result.TableName = _DB_VIEW_NAME_; }

            return Result;
        }

    }
}
