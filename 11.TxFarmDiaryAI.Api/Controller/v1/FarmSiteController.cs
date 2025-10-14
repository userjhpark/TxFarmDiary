using Google.Protobuf.WellKnownTypes;
using HxCore;
using HxCore.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TxFarmDiaryAI.Api.Controller.v1
{
    [Route("api/[controller]")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FarmSiteController : ControllerBase
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

        [HttpGet("All")]
        public string? GetAll()
        {
            HxDbOci db = new HxDbOci("txfd", "cimage1004a", "61.41.17.51:1521/PAMSORCL");
            if (db == null || db.Open() != true) { return null; }

            string SQL = "SELECT * FROM TXFD_SITE_SET";
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
            

            System.Data.DataTable dt = db.QueryDataTable(SQL);
            SQL_TXFD_SITE_SET_Table[] rs = dt.ToRecordSetEx<SQL_TXFD_SITE_SET_Table>();
            if (rs != null)
            {

                //var json = rs.ToJsonStringEx();

                HxNameingCaseType caseType = ApiDefs._DEFAULT_JSON_NAMING_CASE_;
                var json = rs.ToJsonStringWithNameingCaseEx(caseType);
                var obj = HxUtils.JsonDeserializeObjectWithNameingCase<SQL_TXFD_SITE_SET_Table[]>(json, caseType);
                return json;
            }
            return null;
        }
    }
}
