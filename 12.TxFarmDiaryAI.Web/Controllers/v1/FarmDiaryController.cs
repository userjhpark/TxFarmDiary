using HxCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;

namespace TxFarmDiaryAI.Web.Controllers.v1
{
    [Route("api/[controller]")]
    [Route("api/v1/[controller]")]
    [Produces("application/json")] // 이 컨트롤러의 모든 응답은 application/json 임을 명시
    [ApiController]
    public class FarmDiaryController : BaseController
    {
        public FarmDiaryController(IWebHostEnvironment webEnv) : base(webEnv)
        {
            ; ;
        }
        #region Farming Diary APIs

        [HttpPost("Create/Form")]
        private IActionResult? SetPostCreateSync(IFormCollection form)
        {

            if (form != null && form.Count > 0 && form.ContainsKey("JSON_DATA") && form["JSON_DATA"].IsNullOrWhiteSpaceEx() != true)
            {
                TSmartDiaryPaperItem rawObj = HxUtils.JsonDeserializeObject<TSmartDiaryPaperItem>(form["JSON_DATA"]);
                Debug.WriteLine($"Title: {rawObj.Title}");
            }
            return Ok(new { message = "SetPostCreate API is under construction." });




            var rawBody = GeRawBodyDataAsync();
            if (rawBody != null && rawBody.IsCompleted == true)
            {
                if (rawBody.IsNullOrWhiteSpaceEx() == true)
                {
                    return BadRequest(new { error = "Invalid raw input data." });
                }

                TSmartDiaryPaperItem rawObj = HxUtils.JsonDeserializeObject<TSmartDiaryPaperItem>(rawBody);
                if (rawObj == null)
                {
                    return BadRequest(new { error = "Invalid raw input object." });
                }

                if (rawObj.DocFileBase64Data.IsNullOrWhiteSpaceEx() == true)
                {
                    return BadRequest(new { error = "Invalid raw file data." });
                }

                Debug.WriteLine($"Title: {rawObj.Title}");
            }

            /*
            if (value.Contains("diary_date") != true)
            {
                return BadRequest(new { error = "Invalid Diary Date data." });
            }
            */
            /*
            if (form == null || form.Count <= 0)
            {
                return BadRequest(new { error = "Invalid input data." });
            }
            
            
            if (form.ContainsKey("uno") != true || form["uno"].IsNullOrWhiteSpaceEx() == true)
            {
                return BadRequest(new { error = "Invalid User data." });
            }
            if (form.ContainsKey("sno") != true || form["sno"].IsNullOrWhiteSpaceEx() == true)
            {
                return BadRequest(new { error = "Invalid Farm data." });
            }
            
            if (form.ContainsKey("image_data") != true || form["image_data"].IsNullOrWhiteSpaceEx() == true)
            {
                return BadRequest(new { error = "Invalid Image data." });
            }
            if (form.ContainsKey("ocr_data") != true || form["ocr_data"].IsNullOrWhiteSpaceEx() == true)
            {
                return BadRequest(new { error = "Invalid OCR/JSON data." });
            }

            foreach (var item in form)
            {
                Debug.WriteLine($"Key: {item.Key}, Value: {item.Value}");

                if(item.Key == "image_data")
                {
                    string imageData = item.Value;
                    SQL_TXFD_IMAGE_SET_Table imageTableObj = HxUtils.JsonDeserializeObject<SQL_TXFD_IMAGE_SET_Table>(imageData);
                }
                else if(item.Key == "ocr_data")
                {
                    string ocrData = item.Value;
                    var ocrTableObj = HxUtils.JsonDeserializeObject<SQL_TXFD_OCR_SET_Table>(ocrData);
                }

            }
            */
            return Ok(new { message = "SetPostCreate API is under construction." });
        }
        [HttpPost("Create")]
        [HttpPost("Create/raw")]
        public async Task<IActionResult>? SetPostCreateAsync()
        {
            HxResultValue Result = new HxResultValue();
            string strMeesage = string.Empty;
            var rawBody = await GeRawBodyDataAsync();
            if (rawBody != null)
            {
                if (rawBody.IsNullOrWhiteSpaceEx() == true)
                {
                    strMeesage = "Invalid raw input data.";
                    Result.SetValue(strMeesage, HxResultType.Error);
                    return BadRequest(Result);
                }

                TSmartDiaryPaperItem rawObj = HxUtils.JsonDeserializeObject<TSmartDiaryPaperItem>(rawBody);
                if (rawObj == null)
                {
                    //return BadRequest(new { error = "Invalid raw input object." });
                    strMeesage = "Invalid raw input object.";
                    Result.SetValue(strMeesage, HxResultType.Error);
                    return BadRequest(Result);
                }

                if (rawObj.DocFileBase64Data.IsNullOrWhiteSpaceEx() == true)
                {
                    //return BadRequest(new { error = "Invalid raw file data." });
                    strMeesage = "Invalid raw file data.";
                    Result.SetValue(strMeesage, HxResultType.Error);
                    return BadRequest(Result);
                }

                Debug.WriteLine($"Title: {rawObj.Title}");

                if (this.UploadTempFolderPath.IsNullOrWhiteSpaceEx() == true || this.UploadSaveFolderPath.IsNullOrWhiteSpaceEx() == true || rawObj.DocFileBase64Data.IsNullOrWhiteSpaceEx() == true)
                {
                    //return BadRequest(new { error = "Invalid raw file data." });
                    strMeesage = "Invalid Upload/Temp Folder.";
                    Result.SetValue(strMeesage, HxResultType.Error);
                    return BadRequest(Result);
                }
                //return BadRequest("Test");

                HxFile.DirectoryCreate(this.UploadTempFolderPath);
                using IHxDb db = GetDbConn();

                decimal? ikeySiteFarmNo = rawObj.SNO ?? -1;

                #region TXFD_FILE_ENV : 파일 처리
                string strDocFileBase64 = rawObj.DocFileBase64Data!;
                byte[] byteDocFileData = HxUtils.ToByteFromBase64Decode(strDocFileBase64);
                string strDocFileBase64Checksum = HxString.GetMD5Checksum(strDocFileBase64);
                string strDocFileDataChecksum = HxString.GetMD5Checksum(byteDocFileData);
                string strDocFileTempName = $"{strDocFileDataChecksum}_{strDocFileBase64Checksum}.pdf";
                string strDocFileName = rawObj.DocFileName.IsNullOrWhiteSpaceEx() != true ? rawObj.DocFileName! : strDocFileTempName;
                string strDocFileExt = HxFile.GetFileExt(strDocFileName);
                string strDocFileTempFullPath = Path.Combine(this.UploadTempFolderPath!, $"{strDocFileDataChecksum}_{strDocFileBase64Checksum}.{strDocFileExt}");
                string? strDocFileSaveName = null;
                string? strDocFileSaveFullPath = null;

                strDocFileTempFullPath = HxFile.GetFileUniquePath(strDocFileTempFullPath, HxFileOverwriteType.RenameSequence);
                decimal? ikeyDocFileNo = null;
                bool bDocFilePrevExist = false;
                
                //SQL_TXFD_DIARY_SET
                SQL_TXFD_Helper<SQL_TXFD_FILE_ENV_Table> dbFileHelper = SQL_TXFD_Helper<SQL_TXFD_FILE_ENV_Table>.Create();
                dbFileHelper.SetDbConn(db);
                string strDocFile_AddWhere = $"{SQL_TXFD_FILE_ENV_Table._CDF_FILE_CHECK_} = '{strDocFileDataChecksum}' AND {SQL_TXFD_FILE_ENV_Table._CDF_FILE_CHECK_SUB_} = '{strDocFileBase64Checksum}'";
                SQL_TXFD_FILE_ENV_Table serverDocFileExist = dbFileHelper.ToRecordSet(addWhereQuery: strDocFile_AddWhere)?.FirstOrDefault();
                if (serverDocFileExist != null && serverDocFileExist.FILE_NO.IsNullOrWhiteSpaceEx() != true)
                {
                    bDocFilePrevExist = true;
                    ikeyDocFileNo = serverDocFileExist.FILE_NO;
                    //strMeesage = "Duplicate images exist. (중복된 이미지가 존재 함.)";
                    //Result.SetValue(strMeesage, HxResultType.Error);
                    //return BadRequest(Result);
                }
                else
                {
                    bDocFilePrevExist =false;
                    ikeyDocFileNo = dbFileHelper.NextID();
                    HxFile.WriteAllBytes(strDocFileTempFullPath, byteDocFileData);
                }

                string? strOcrImageBase64 = null;
                byte[]? byteOcrImageData = null;
                string? strOcrImageBase64Checksum = null;
                string? strOcrImageDataChecksum = null;
                string? strOcrFileTempName = null;
                string? strOcrFileName = null;
                string? strOcrFileExt = null;
                string? strOcrFileTempFullPath = null;
                string? strOcrFileSaveName = null;
                string? strOcrFileSaveFullPath = null;
                decimal? ikeyOcrImgNo = null;
                bool bOcrFilePrevExist = false;
                if (rawObj.OcrImageBase64Data.IsNullOrWhiteSpaceEx() != true)
                {
                    strOcrImageBase64 = rawObj.OcrImageBase64Data!;
                    byteOcrImageData = HxUtils.ToByteFromBase64Decode(strOcrImageBase64);
                    strOcrImageBase64Checksum = HxString.GetMD5Checksum(strOcrImageBase64);
                    strOcrImageDataChecksum = HxString.GetMD5Checksum(byteOcrImageData);
                    strOcrFileTempName = $"{strOcrImageDataChecksum}_{strOcrImageBase64Checksum}.tmp";
                    strOcrFileName = rawObj.OcrImageName.IsNullOrWhiteSpaceEx() != true ? rawObj.OcrImageName! : strOcrFileTempName;
                    strOcrFileExt = HxFile.GetFileExt(strOcrFileName);
                    strOcrFileTempFullPath = Path.Combine(this.UploadTempFolderPath!, $"{strOcrImageDataChecksum}_{strOcrImageBase64Checksum}.{strOcrFileExt}");
                    strOcrFileTempFullPath = HxFile.GetFileUniquePath(strOcrFileTempFullPath, HxFileOverwriteType.RenameSequence);

                    string strOcrFile_AddWhere = $"{SQL_TXFD_FILE_ENV_Table._CDF_FILE_CHECK_} = '{strOcrImageDataChecksum}' AND {SQL_TXFD_FILE_ENV_Table._CDF_FILE_CHECK_SUB_} = '{strOcrImageBase64Checksum}'";
                    SQL_TXFD_FILE_ENV_Table? serverOcrFileExist = dbFileHelper.ToRecordSet(addWhereQuery: strOcrFile_AddWhere)?.FirstOrDefault();
                    if (serverOcrFileExist != null && serverOcrFileExist.FILE_NO.IsNullOrWhiteSpaceEx() != true)
                    {
                        bOcrFilePrevExist = true;
                        ikeyOcrImgNo = serverOcrFileExist.FILE_NO;
                        //strMeesage = "Duplicate images exist. (중복된 이미지가 존재 함.)";
                        //Result.SetValue(strMeesage, HxResultType.Error);
                        //return BadRequest(Result);
                    }
                    else
                    {
                        bOcrFilePrevExist = false;
                        ikeyOcrImgNo = dbFileHelper.NextID();
                        HxFile.WriteAllBytes(strOcrFileTempFullPath, byteOcrImageData);
                    }
                }

                if (rawObj.SNO.IsNullOrWhiteSpaceEx() == true)
                {

                }

                if(strDocFileTempFullPath.IsNullOrWhiteSpaceEx() != true && HxFile.FileExists(strDocFileTempFullPath))
                {
                    
                }

                if (bDocFilePrevExist != true && HxFile.IsFileExists(strDocFileTempFullPath))
                {
                    HxFile.DirectoryCreate(this.UploadSaveFolderPath);
                    strDocFileSaveFullPath = Path.Combine(this.UploadSaveFolderPath!, HxFile.GetFileName(strDocFileTempFullPath));
                    strDocFileSaveFullPath = HxFile.GetFileUniquePath(strDocFileSaveFullPath);
                    FileInfo fiDoc = HxFile.FileMove(strDocFileTempFullPath, strDocFileSaveFullPath, HxFileOverwriteType.RenameSequence);
                    if (fiDoc == null || fiDoc.Exists != true)
                    {
                        strMeesage = "An error occurred while processing the file(DOC). (파일 처리 중 오류 발생.)";
                        Result.SetValue(strMeesage, HxResultType.Error);
                        return BadRequest(Result);
                    }
                    strDocFileSaveFullPath = fiDoc.FullName;
                    strDocFileSaveName = fiDoc.Name;

                    SQL_TXFD_FILE_ENV_Table dbTableDocFile = new SQL_TXFD_FILE_ENV_Table
                    {
                        FILE_NO = ikeyDocFileNo,
                        FILE_CHECK = strDocFileDataChecksum,
                        FILE_CHECK_SUB = strDocFileBase64Checksum,
                        FILE_NAME = strDocFileName,
                        FILE_SAVE = HxFile.GetFileName(strDocFileSaveName),
                        FILE_PATH = HxFile.GetFileDirPath(strDocFileSaveFullPath),
                        FILE_SIZE = fiDoc.Length,
                        FILE_EXT = HxFile.GetFileExt(strDocFileSaveFullPath),
                        FILE_TYPE = HxFile.GetFileMimeType(strDocFileSaveFullPath),
                    };
                    dbTableDocFile.SetDbInsert(db);
                }
                if (bOcrFilePrevExist != true && HxFile.IsFileExists(strOcrFileTempFullPath))
                {
                    HxFile.DirectoryCreate(this.UploadSaveFolderPath);
                    strOcrFileSaveFullPath = Path.Combine(this.UploadSaveFolderPath!, HxFile.GetFileName(strOcrFileTempFullPath));
                    strOcrFileSaveFullPath = HxFile.GetFileUniquePath(strOcrFileSaveFullPath);
                    FileInfo fiOcr = HxFile.FileMove(strOcrFileTempFullPath, strOcrFileSaveFullPath, HxFileOverwriteType.RenameSequence);
                    if (fiOcr == null || fiOcr.Exists != true)
                    {
                        strMeesage = "An error occurred while processing the file(OCR). (파일 처리 중 오류 발생.)";
                        Result.SetValue(strMeesage, HxResultType.Error);
                        return BadRequest(Result);
                    }
                    strOcrFileSaveFullPath = fiOcr.FullName;
                    strOcrFileSaveName = fiOcr.Name;

                    SQL_TXFD_FILE_ENV_Table dbTableOcrFile = new SQL_TXFD_FILE_ENV_Table
                    {
                        FILE_NO = ikeyOcrImgNo,
                        FILE_CHECK = strOcrImageDataChecksum,
                        FILE_CHECK_SUB = strOcrImageBase64Checksum,
                        FILE_NAME = strOcrFileName,
                        FILE_SAVE = strOcrFileSaveFullPath,
                        FILE_PATH = HxFile.GetFileDirPath(strOcrFileSaveFullPath),
                        FILE_SIZE = fiOcr.Length,
                        FILE_EXT = HxFile.GetFileExt(strOcrFileSaveFullPath),
                        FILE_TYPE = HxFile.GetFileMimeType(strOcrFileSaveFullPath),
                    };
                    dbTableOcrFile.SetDbInsert(db);
                }
                #endregion
                db.BeginTransaction();
                try
                {
                    #region TXFD_OCR_ENV > TXFD_OCR_JSON > TXFD_OCR_FIELD : OCR 정보 처리
                    decimal? ikeyOcrNo = null;
                    decimal? ikeyJsonNo = null;
                    if (rawObj.OcrJsonData != null && rawObj.OcrJsonData.HasValue == true)
                    {
                        OCR_NAVER_API_Response_Body OcrJsonResponseBody = rawObj.OcrJsonData.Value;

                        #region 1) TXFD_OCR_ENV
                        ikeyOcrNo = db.NextID(SQL_TXFD_OCR_ENV_Table._DB_SEQ_NAME_);
                        SQL_TXFD_OCR_ENV_Table dbTableOcrInfo = new SQL_TXFD_OCR_ENV_Table
                        {
                            OCR_NO = ikeyOcrNo,
                            IMG_NO = ikeyOcrImgNo,
                            TPL_CODE = rawObj.OcrTemplateCode,
                            TPL_NAME = rawObj.OcrTemplateName,
                            RESPONSE_DATA = OcrJsonResponseBody.ToJsonStringEx(),
                            RESPONSE_DATA_TYPE = "json",
                            RESPONSE_VERSION = OcrJsonResponseBody.version,
                            RESPONSE_REQUESTID = OcrJsonResponseBody.requestId,
                            RESPONSE_TIMESTAMP = OcrJsonResponseBody.timestamp,
                        };
                        dbTableOcrInfo.SetDbInsert(db);
                        #endregion

                        #region 2) TXFD_OCR_JSON
                        string strOcrKindCode = "OCR_NAVER";
                        string strOcrKindName = "OCR_NAVER NAVER API";
                        OCR_NAVER_API_Response_image jsonResponseImage = OcrJsonResponseBody.images.FirstOrDefault();
                        if (jsonResponseImage.uid.IsNullOrWhiteSpaceEx() != true)
                        {
                            ikeyJsonNo = db.NextID(SQL_TXFD_OCR_JSON_Table._DB_SEQ_NAME_);
                            SQL_TXFD_OCR_JSON_Table dbTableOcrJson = new SQL_TXFD_OCR_JSON_Table
                            {
                                JSON_NO = ikeyJsonNo,
                                OCR_NO = ikeyOcrNo,
                                BIND_IMG_NO = ikeyOcrImgNo,
                                KIND_CODE = strOcrKindCode,
                                KIND_NAME = strOcrKindName,
                                JSON_UID = jsonResponseImage.uid,
                                JSON_NAME = jsonResponseImage.name,
                                INFER_RESULT = jsonResponseImage.inferResult,
                                MESSAGE = jsonResponseImage.message,
                                MATCHEDTEMPLATE_ID = jsonResponseImage.matchedTemplate.id,
                                MATCHEDTEMPLATE_NM = jsonResponseImage.matchedTemplate.name,
                                VALIDATION_RESULT = jsonResponseImage.validationResult.ToJsonStringEx(),
                                TITLE_NAME = jsonResponseImage.title.name,
                                TITTLE_BOUNDING_TOP = jsonResponseImage.title.bounding.top,
                                TITLE_BOUNDING_LEFT = jsonResponseImage.title.bounding.left,
                                TITLE_BOUNDING_WIDTH = jsonResponseImage.title.bounding.width,
                                TITLE_BOUNDING_HEIGHT = jsonResponseImage.title.bounding.height,
                                TITLE_INFER_TEXT = jsonResponseImage.title.inferText,
                                TITLE_INFER_CONFIDENCE = jsonResponseImage.title.inferConfidence,
                            };
                            dbTableOcrJson.SetDbInsert(db);
                        }
                        #endregion

                        #region 3) TXFD_OCR_FIELD (Multiple)
                        if (jsonResponseImage.uid.IsNullOrWhiteSpaceEx() != true)
                        {
                            IEnumerable<OCR_NAVER_API_Response_field> jsonResponseFields = jsonResponseImage.fields;
                            if (jsonResponseFields != null && jsonResponseFields.Any() == true)
                            {
                                foreach (OCR_NAVER_API_Response_field field in jsonResponseFields)
                                {
                                    string strFieldName = field.name;
                                    string strFieldValue = field.inferText;
                                    if (strFieldName.IsNullOrWhiteSpaceEx() == true || strFieldValue.IsNullOrWhiteSpaceEx() == true) { continue; }


                                    decimal? ikeyFieldNo = db.NextID(SQL_TXFD_OCR_FIELD_Table._DB_SEQ_NAME_);

                                    SQL_TXFD_OCR_FIELD_Table dbTableOcrField = new SQL_TXFD_OCR_FIELD_Table
                                    {
                                        FIELD_NO = ikeyFieldNo,
                                        JSON_NO = ikeyJsonNo,
                                        BIND_OCR_NO = ikeyOcrNo,
                                        BIND_IMG_NO = ikeyOcrImgNo,
                                        KIND_CODE = strOcrKindCode,
                                        KIND_NAME = strOcrKindName,
                                        FIELD_ID = field.name,
                                        FIELD_NAME = field.name,
                                        BOUNDING_TOP = field.bounding.top,
                                        BOUNDING_LEFT = field.bounding.left,
                                        BOUNDING_WIDTH = field.bounding.width,
                                        BOUNDING_HEIGHT = field.bounding.height,
                                        VALUE_TYPE = field.valueType,
                                        INFER_TEXT = field.inferText,
                                        INFER_CONFIDENCE = field.inferConfidence,
                                    };
                                    dbTableOcrField.SetDbInsert(db);

                                }
                            }
                        }
                        #endregion
                    }
                    #endregion

                    #region TXFD_DIARY_SET > TXFD_DIARY_FIELD : 영농일지 처리
                    decimal? ikeyDiaryNo = db.NextID(SQL_TXFD_DIARY_SET_Table._DB_SEQ_NAME_);
                    SQL_TXFD_DIARY_SET_Table dbTableDiaryInfo = new SQL_TXFD_DIARY_SET_Table
                    {
                        DNO = ikeyDiaryNo,
                        SNO = ikeySiteFarmNo,
                        OCR_NO = ikeyOcrNo,
                        TPL_CODE = rawObj.DocTemplateCode,
                        TPL_NAME = rawObj.DocTemplateName,
                        FILE_NO = ikeyDocFileNo,
                        FORM_DATA = rawObj.DocFieldsData.ToJsonStringEx(),
                    };
                    dbTableDiaryInfo.SetDbInsert(db);

                    if (rawObj.DocFieldsData != null && rawObj.DocFieldsData.Count > 0)
                    {
                        foreach (KeyValuePair<string, string> field in rawObj.DocFieldsData)
                        {
                            string strFieldName = field.Key;
                            string strFieldValue = field.Value;
                            if (strFieldName.IsNullOrWhiteSpaceEx() == true || strFieldValue.IsNullOrWhiteSpaceEx() == true) { continue; }

                            decimal? ikeyFieldNo = db.NextID(SQL_TXFD_DIARY_FIELD_Table._DB_SEQ_NAME_);
                            SQL_TXFD_DIARY_FIELD_Table dbTableDiaryField = new SQL_TXFD_DIARY_FIELD_Table
                            {
                                FIELD_NO = ikeyFieldNo,
                                DNO = ikeyDiaryNo,
                                BIND_SNO = ikeySiteFarmNo,
                                BIND_FILE_NO = ikeyDocFileNo,
                                FIELD_ID = strFieldName,
                                FIELD_NAME = strFieldName,
                                FIELD_DATA = strFieldValue
                            };
                            dbTableDiaryField.SetDbInsert(db);
                        }
                    }
                    #endregion
                    Debug.WriteLine($"DNO : {ikeyDiaryNo} / SNO : {ikeySiteFarmNo} / FILE_NO : {ikeyDocFileNo} / IMG_NO : {ikeyOcrImgNo} / OCR_NO : {ikeyOcrNo} / JSON_NO : {ikeyJsonNo}");
                    db.Commit();
                    Result.Value = ikeyDiaryNo;
                    return Ok(Result);
                }
                catch (Exception ex)
                {
                    Result.SetException(ex);
                    return BadRequest(Result);
                    //throw ex;
                }
                finally
                {
                    db.EndTransaction();
                    db.Close();
                    db.Free();
                }
                
            }
            return BadRequest(new { message = "Unknown." });
            
            /*
            if (value.Contains("diary_date") != true)
            {
                return BadRequest(new { error = "Invalid Diary Date data." });
            }
            */
            /*
            if (form == null || form.Count <= 0)
            {
                return BadRequest(new { error = "Invalid input data." });
            }
            
            
            if (form.ContainsKey("uno") != true || form["uno"].IsNullOrWhiteSpaceEx() == true)
            {
                return BadRequest(new { error = "Invalid User data." });
            }
            if (form.ContainsKey("sno") != true || form["sno"].IsNullOrWhiteSpaceEx() == true)
            {
                return BadRequest(new { error = "Invalid Farm data." });
            }
            
            if (form.ContainsKey("image_data") != true || form["image_data"].IsNullOrWhiteSpaceEx() == true)
            {
                return BadRequest(new { error = "Invalid Image data." });
            }
            if (form.ContainsKey("ocr_data") != true || form["ocr_data"].IsNullOrWhiteSpaceEx() == true)
            {
                return BadRequest(new { error = "Invalid OCR/JSON data." });
            }

            foreach (var item in form)
            {
                Debug.WriteLine($"Key: {item.Key}, Value: {item.Value}");

                if(item.Key == "image_data")
                {
                    string imageData = item.Value;
                    SQL_TXFD_IMAGE_SET_Table imageTableObj = HxUtils.JsonDeserializeObject<SQL_TXFD_IMAGE_SET_Table>(imageData);
                }
                else if(item.Key == "ocr_data")
                {
                    string ocrData = item.Value;
                    var ocrTableObj = HxUtils.JsonDeserializeObject<SQL_TXFD_OCR_SET_Table>(ocrData);
                }

            }
            */
            return Ok(new { message = "SetPostCreate API is under construction." });
        }
        #endregion
    }
}
