using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TxFarmDiaryAI.Api.Controller
{
    [Route($"api/{Defs._DEF_WEBAPI_DEPLOY_VERSION_}/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public virtual IEnumerable<string> Get()
        {
            //return new string[] { "value1", "value2" };
            return [Defs._DEF_WEBAPI_DEPLOY_VERSION_ + " - Test value1", Defs._DEF_WEBAPI_DEPLOY_VERSION_ + " - Test value2"];
        }
    }
}
