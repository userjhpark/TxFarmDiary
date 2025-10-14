using DevExpress.Data;
//using Google.Protobuf.WellKnownTypes;
using HxCore;
using HxCore.Data;
//using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;
using System.Data;
using System.Diagnostics;
using TxFarmDiaryAI.Api;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TxFarmDiaryAI.Web.Controllers.v1
{
    
    [Route("api/[controller]")]
    [Route("api/v1/[controller]")]
    [Produces("application/json")] // 이 컨트롤러의 모든 응답은 application/json 임을 명시
    [ApiController]
    public class FarmSiteController : BaseController
    {
        // GET: api/<FarmSiteController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<FarmSiteController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FarmSiteController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FarmSiteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FarmSiteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        #region Site / Workspace
        protected DataTable? GetWorkspaceDataTable()
        {
            IHxDb db = GetDbConn();
            if (db == null || db.Open() != true) { return null; }

            DataTable? Result = null;
            try
            {
                //string SQL = "SELECT sno, site_name, site_memo, status, stn_code, stn_name, loc_addr, loc_latitude, loc_longitude, loc_road, etc, is_use, raw_guid, reg_date, reg_agent, reg_user, reg_uno, mod_date, mod_agent, mod_user, mod_uno FROM TXFD_SITE_SET";
                Result = SQL_TXFD_SITE_SET_Table.ToDataTable(db);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
            finally
            {
                db?.Free();
            }
            return Result;
        }

        [HttpGet("All")]
        [HttpGet("All/List")]
        //[Produces("application/json")]
        public IActionResult? GetAllValue2List(string name_case = null)
        {
            try
            {
                /*
                int phase = db.Query("SELECT * FROM TXFD_SITE_SET");
                if (phase >= 0)
                {
                    List<string> list = new List<string>();
                    while (db.NextRecord())
                    {
                        list.Add(db.f("site_name").ToStringEx());
                    }

                }
                */

                string strNamingCaseType = name_case?.ToLower().Trim() ?? "Default";
                HxNameingCaseType inputCaseType = HxCasing.ToCasingType(strNamingCaseType);
                HxNameingCaseType outputCaseType = inputCaseType;
                switch (inputCaseType)
                {
                    case HxNameingCaseType.PascalCase:
                    case HxNameingCaseType.CamelCase:
                    case HxNameingCaseType.SnakeCase:
                    case HxNameingCaseType.KebabCase:
                    case HxNameingCaseType.LowerCase:
                    case HxNameingCaseType.UpperCase:
                    case HxNameingCaseType.JsonCase:
                        outputCaseType = inputCaseType;
                        break;
                    case HxNameingCaseType.NormalCase:
                    case HxNameingCaseType.DefaultCase:
                    default:
                        outputCaseType = WebDefs._WEBAPI_DEFAULT_JSON_NAMING_CASE_;
                        break;
                }

                DataTable? dt = GetWorkspaceDataTable();
                if (dt == null || dt.Columns.Count <= 0  || dt.Rows.Count <= 0) { return BadRequest("Data Not Found!"); }

                List<Dictionary<string, object>> value = HxUtils.ToJsonListWithNamingCase(dt, outputCaseType);

                IActionResult? Result = GetResultValue(value);
                return Result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return GetResultValue(ex.Message, HxResultType.Exception);
                //throw ex;
            }
            finally
            {
                ; ;
            }


            /*
            System.Data.DataTable? data1 = SQL_TXFD_SITE_SET_Table.ToDataTable(db);
            string str = SQL_TXFD_SITE_SET_Table.ToJsonSerializeDataTable(db);
            System.Data.DataTable data2 = SQL_TXFD_SITE_SET_Table.ToJsonDeserializeDataTable(str);


            System.Data.DataTable dt = db.QueryDataTable(SQL);
            SQL_TXFD_SITE_SET_Table[] rs = dt.ToRecordSetEx<SQL_TXFD_SITE_SET_Table>();
            if (rs != null)
            {

                //var json = rs.ToJsonStringEx();

                HxNameingCaseType caseType = WebDefs._WEBAPI_DEFAULT_JSON_NAMING_CASE_;
                var json = rs.ToJsonStringWithNameingCaseEx(caseType);
                var obj = HxUtils.JsonDeserializeObjectWithNameingCase<SQL_TXFD_SITE_SET_Table[]>(json, caseType);
                return json;
            }
            return null;
            */
        }

        [HttpGet("All/String")]
        //[Produces("text/plain")]
        public IActionResult? GetAllValue2String(string name_case = null)
        {
            try
            {
                string strNamingCaseType = name_case?.ToLower().Trim() ?? "Default";
                HxNameingCaseType inputCaseType = HxCasing.ToCasingType(strNamingCaseType);
                HxNameingCaseType outputCaseType = inputCaseType;
                switch (inputCaseType)
                {
                    case HxNameingCaseType.PascalCase:
                    case HxNameingCaseType.CamelCase:
                    case HxNameingCaseType.SnakeCase:
                    case HxNameingCaseType.KebabCase:
                    case HxNameingCaseType.LowerCase:
                    case HxNameingCaseType.UpperCase:
                    case HxNameingCaseType.JsonCase:
                        outputCaseType = inputCaseType;
                        break;
                    case HxNameingCaseType.NormalCase:
                    case HxNameingCaseType.DefaultCase:
                    default:
                        outputCaseType = WebDefs._WEBAPI_DEFAULT_JSON_NAMING_CASE_;
                        break;
                }

                DataTable? dt = GetWorkspaceDataTable();
                if (dt == null || dt.Columns.Count <= 0 || dt.Rows.Count <= 0) { return BadRequest("Data Not Found!"); }

                //List<Dictionary<string, object>> Result = HxUtils.ToJsonListWithNamingCase(dt, outputCaseType);
                string value = dt.ToJsonStringWithNameingCaseEx(outputCaseType);
                return GetResultValue(value);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return GetResultValue(ex.Message, HxResultType.Exception);
                //throw ex;
            }
            finally
            {
                ; ;
            }


            /*
            System.Data.DataTable? data1 = SQL_TXFD_SITE_SET_Table.ToDataTable(db);
            string str = SQL_TXFD_SITE_SET_Table.ToJsonSerializeDataTable(db);
            System.Data.DataTable data2 = SQL_TXFD_SITE_SET_Table.ToJsonDeserializeDataTable(str);


            System.Data.DataTable dt = db.QueryDataTable(SQL);
            SQL_TXFD_SITE_SET_Table[] rs = dt.ToRecordSetEx<SQL_TXFD_SITE_SET_Table>();
            if (rs != null)
            {

                //var json = rs.ToJsonStringEx();

                HxNameingCaseType caseType = WebDefs._WEBAPI_DEFAULT_JSON_NAMING_CASE_;
                var json = rs.ToJsonStringWithNameingCaseEx(caseType);
                var obj = HxUtils.JsonDeserializeObjectWithNameingCase<SQL_TXFD_SITE_SET_Table[]>(json, caseType);
                return json;
            }
            return null;
            */
        }

        [HttpGet("All/DataTable")]
        public IActionResult? GetAllValue2DataTable(string name_case = null)
        {
            try
            {
                DataTable? dt = GetWorkspaceDataTable();
                if (dt == null || dt.Columns.Count <= 0 || dt.Rows.Count <= 0) { return BadRequest("Data Not Found!"); }

                IActionResult? Result = GetResultValue(dt.ToJsonStringEx());
                return Result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return GetResultValue(ex.Message, HxResultType.Exception);
                //throw ex;
            }
            finally
            {
                ; ;
            }
        }
        #endregion
    }
}
