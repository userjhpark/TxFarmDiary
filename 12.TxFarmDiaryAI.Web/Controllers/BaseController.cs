using DevExpress.Data;
using HxCore;
using HxCore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using System.Drawing;
using System.Text;
using TxFarmDiaryAI.Api;

namespace TxFarmDiaryAI.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IWebHostEnvironment? WebEnv { get; set; }

        // 기존 코드에서 HostingEnvironment.MapPath("~") 부분을 제거하고, ContentRootPath를 WebEnv?.ContentRootPath로만 반환하도록 수정합니다.
        protected string? ContentRootPath => WebEnv?.ContentRootPath;
        protected string? DocumentRootPath => ContentRootPath;
        //wwwroot 폴더 경로
        protected string? WebRootPath => WebEnv?.WebRootPath;

        protected string? UploadSaveFolderPath => ContentRootPath.IsNullOrWhiteSpaceEx() || WebDefs._UPLOAD_SAVE_FOLDER_NAME_.IsNullOrWhiteSpaceEx() ? null : Path.Combine(ContentRootPath!, WebDefs._UPLOAD_SAVE_FOLDER_NAME_, HxString.GetNowDateString());
        protected string? UploadTempFolderPath => ContentRootPath.IsNullOrWhiteSpaceEx() || WebDefs._UPLOAD_TEMP_FOLDER_NAME_.IsNullOrWhiteSpaceEx() ? null : Path.Combine(ContentRootPath!, WebDefs._UPLOAD_TEMP_FOLDER_NAME_, HxString.GetNowDateString("yyyy"));

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

                //Result.Value = value;
                Result.SetObjectValue(value);
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

        protected virtual IActionResult? GetResultValue(HxResultValue Result, HxResultType resultType = HxResultType.None)
        {
            try
            {
                if (Result == null)
                {
                    return new NotFoundResult();
                }

                //Result.Value = value;
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


        public BaseController(IWebHostEnvironment webEnv)
        {
            WebEnv = webEnv;
        }
        public IActionResult GetPaths()
        {
            // 2. 프로젝트 루트 경로 (실제 실행 경로)
            string contentRootPath = WebEnv.ContentRootPath;

            // 3. wwwroot 폴더 경로
            string webRootPath = WebEnv.WebRootPath;

            return Ok(new
            {
                ContentRoot = contentRootPath,
                WebRoot = webRootPath
            });
        }

        public async Task<string> GeRawBodyDataAsync()
        {
            string rawBody = string.Empty;

            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                // 비동기적으로 스트림의 끝까지 모든 문자열을 읽어옵니다.
                rawBody = await reader.ReadToEndAsync();
            }
            return rawBody;

            /*
            if (Request.Body != null && Request.Body.Length > 0 && Request.Method == "POST")
            {
                // Request.Body(Stream)를 StreamReader로 읽습니다.
                
            }
            return rawBody;
            */
        }
        public string GeRawBodyData()
        {
            string rawBody = string.Empty;

            if (Request.Body != null && Request.Body.Length > 0)
            {
                // Request.Body(Stream)를 StreamReader로 읽습니다.
                using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    rawBody = reader.ReadToEnd();
                }
            }
            return rawBody;
        }
    }
}
