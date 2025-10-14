using DevExpress.Data;
using HxCore;
using HxCore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace TxFarmDiaryAI.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected virtual IHxDb GetDbConn()
        {
            HxDbOci db = new HxDbOci("txfd", "cimage1004a", "61.41.17.51:1521/PAMSORCL");
            return db;
        }
        protected virtual IActionResult? GetResultValue(object value, HxResultType resultType = HxResultType.None)
        {
            HxResultValue Result = new HxResultValue();
            try
            {
                if (Result == null)
                {
                    return new NotFoundResult();
                }

                Result.Value = value;
                if (resultType != HxResultType.None)
                {
                    Result.ResultType = resultType;
                }

                if (Result.Success != true)
                {
                    return BadRequest(Result);
                }

                return Ok(Result);
            }
            catch (Exception ex)
            {
                Result.SetException(ex);
                //throw ex;
            }
            return BadRequest(Result);
        }
    }
}
