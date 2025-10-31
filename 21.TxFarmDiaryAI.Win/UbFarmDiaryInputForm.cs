using DevExpress.CodeParser;
using DevExpress.Data.Filtering.Helpers;
using DevExpress.Mvvm.POCO;
using DevExpress.Office.Crypto;
using DevExpress.Pdf;
using DevExpress.Utils.Drawing;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls.Rtf;
using DevExpress.XtraPdfViewer;
using DevExpress.XtraPdfViewer.Bars;
using DevExpress.XtraPdfViewer.Commands;
using DevExpress.XtraReports.Design;
using HxCore;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Utils = TxFarmDiaryAI.Win.SbUtils;

namespace TxFarmDiaryAI.Win
{
    public partial class UbFarmDiaryInputForm : UbBaseChildRibbonFormWithWS
    {
        private const string _V작업일_ = "작업일";
        private const string _V구매일_ = "구매일";
        private const string _V농장_필지_ = "농장_필지";
        private const string _V작업단계_작업명_ = "작업단계_작업명";
        private const string _V세부작업_ = "세부작업";

        internal TImageCartItem? SourceImageItem { get; private set; }
        internal HxResultValue? ResultObj { get; private set; }
        //internal OCR_NAVER_API_Response_Body JsonObj { get; private set; }
        private string DefaultTitle => "Farming Diary(Journal) - Registration(Append)";
        private string TplSample01Full => Path.Combine(SysEnv.GetAppBaseDir(), "Template", "tpl-영농일지_R1-1Page.pdf");
        private string TplSample02Full => Path.Combine(SysEnv.GetAppBaseDir(), "Template", "tpl-영농일지_R1-2Page.pdf");

        private decimal? SNo => SysEnv.CurrWorkspaceSNO.ToNullableDecimalEx();
        private decimal? UNo => SysEnv.LoginUserSNO.ToNullableDecimalEx();
        private DateTime? DiaryDate
        {
            get => baredtChildDocDate.EditValue.ToNullableDateTimeEx();
            set => baredtChildDocDate.EditValue = value;
        }
        private void SetDiaryDate(string? inputDate = null)
        {
            if (inputDate.IsNullOrWhiteSpaceEx() == true || inputDate!.ToLower() == "today" || inputDate!.ToLower() == "now")
            {
                DiaryDate = DateTime.Now;
                return;
            }
            string dateValue = HxString.GetConvertDateString(inputDate);
            DiaryDate = dateValue.IsNullOrWhiteSpaceEx() == true ? DateTime.Now : dateValue.ToNullableDateEx("yyyy-MM-dd");
        }

        private string? InputFormFieldDiaryDateStr
        {
            get
            {
                string? Result = GetAcroFormFieldByName(_V작업일_);
                if (Result.IsNullOrWhiteSpaceEx() == true)
                {
                    Result = GetAcroFormFieldByName(_V구매일_);
                }
                return Result;
            }
            set
            {
                string strDate = HxString.GetConvertDateString(value, "yyyy-MM-dd");
                bool bAction = SetAcroFormFieldByName(_V작업일_, strDate);
                if(bAction != true)
                {
                    _ = SetAcroFormFieldByName(_V구매일_, strDate);
                }
            }
        }
        private DateTime? InputFormFieldDiaryDateTime => HxString.GetConvertDateString(InputFormFieldDiaryDateStr).ToNullableDateEx()?.ToDateStartEx();
        

        internal IEnumerable<TTemplateItem>? FarmingDiaryTemplateList => (repluTemplateList.DataSource as IEnumerable<TTemplateItem>) ?? SysEnv.FarmingDiaryTemplates;
        internal TTemplateItem? FarmingDiaryTemplateItem
        {
            get
            {
                if(baredtChildTemplateList.EditValue != null && this.FarmingDiaryTemplateList != null && this.FarmingDiaryTemplateList.Any() == true)
                {
                    if (baredtChildTemplateList.EditValue is TTemplateItem val && val.TemplateCode.IsNullOrWhiteSpaceEx() != true)
                    {
                        TTemplateItem? item = this.FarmingDiaryTemplateList.Where(r => r.TemplateCode == val.TemplateCode).FirstOrDefault();
                        if (item != null && item.TemplateCode.IsNullOrWhiteSpaceEx() != true)
                        {
                            return item;
                        }
                    }
                }
                return null;
            }
        }
        internal string? DocTemplateCode
        {
            get
            {
                return this.FarmingDiaryTemplateItem?.TemplateCode ?? null;
            }
            private set
            {
                if (value == null || value.IsNullOrWhiteSpaceEx() == true)
                {
                    baredtChildTemplateList.EditValue = null;
                }
                else
                {
                    if (this.FarmingDiaryTemplateList != null && this.FarmingDiaryTemplateList.Any() == true)
                    {
                        TTemplateItem? item = this.FarmingDiaryTemplateList.Where(r => r.TemplateCode == value.ToStringEx()).FirstOrDefault();
                        if (item != null && item.TemplateCode.IsNullOrWhiteSpaceEx() != true)
                        {
                            baredtChildTemplateList.EditValue = item;
                        }
                    }
                }
            }
        }
        
        internal string? DocTemplateName => this.FarmingDiaryTemplateItem?.TemplateName;
        internal string? DocTemplateFullPath => this.FarmingDiaryTemplateItem?.TemplateFullPath;

        public UbFarmDiaryInputForm()
        {
            InitializeComponent();

            this.Load += (s, e) =>
            {

                this.Text = this.DefaultTitle;
                rcChildMenu.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
                //PdfViewerCommandId commandId = PdfViewerCommandId.HandTool;
                //pdfCtl.UpdateMethodToCommandCanExecute(commandId);
                //pdfCtl.DocumentProperties.moid
                //pdfFileOpenBarItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                /*
                docCtl.Options.Behavior.CreateNew = DevExpress.XtraRichEdit.DocumentCapability.Disabled;
                //fileNewItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                docCtl.Options.Behavior.SaveAs = DevExpress.XtraRichEdit.DocumentCapability.Disabled;
                //fileSaveAsItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                docCtl.Options.Behavior.Encrypt = DevExpress.XtraRichEdit.DocumentCapability.Disabled;
                //encryptDocumentItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                */


                //BindingList<TemplateItem>? templateFarmingDiaryList = (BindingList<TemplateItem>)SysEnv.FarmingDiaryTemplates;
#if DEBUG
                if (baredtChildTemplateList.Visibility == DevExpress.XtraBars.BarItemVisibility.Never)
                {
                    baredtChildTemplateList.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                }
                //barbtnExecute_OCR.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                //rpgTestDebug.Visible = true;
#endif
            };
            this.Shown += (s, e) =>
            {
                SbUtils.ShowWaitLoadingForm();
                try
                {
                    if (this.IsStartUp != true)
                    {
                        LoadWorkspaceSelectList(true);
                        LoadFarmDiaryTemplateList(true);
                        //repluTemplateList.DataSource = SysEnv.FarmingDiaryTemplateBindingList;
                        //baredtChildWorkspaceSelect.Refresh();
                        //baredtChildTemplateList.Refresh();

                        if (SysEnv.CurrWorkspaceSNO.IsNullOrWhiteSpaceEx() != true)
                        {
                            baredtChildWorkspaceSelect.EditValue = SysEnv.CurrWorkspaceSNO;
                        }

                        if (this.SourceImageItem != null && this.SourceImageItem.ImageData != null)
                        {
                            OpenOcrToFarmingDiary();
                        }
                        else
                        {
                            //SetLoadTemplateSample();
                            baredtChildTemplateList.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                            OpenTemplateToFramDiary(true);
                            SetDiaryDate();
                        }
                        
                        this.IsStartUp = true;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    //throw;
                }
                finally
                {
                    SbUtils.CloseWaitLoadingForm();
                }
            };

            this.FormClosed += (s, e) =>
            {
                pdfCtl.CloseDocument();
            };

            barbtnChildAppend_FarmingDiary.ItemClick += (s, e) =>
            {
                if (this.SourceImageItem == null || this.SourceImageItem.ImageData == null) { return; }
                //using MemoryStream ms = new MemoryStream(this.SourceImageItem.ImageData);
                //pdfCtl.AppendDocument(ms);
            };

            repdateChildDocDate.ButtonClick += (s, e) =>
            {
                string strTag = e.Button.Tag.ToStringEx().ToUpper();
                if (strTag.IsNullOrWhiteSpaceEx() != true)
                {
                    if (strTag == "T")
                    {
                        SetDiaryDate();
                    }
                    else if (strTag == "N")
                    {
                        SetDiaryDate("NOW");
                    }
                    else if (strTag == "C")
                    {
                        DiaryDate = null;
                    }
                    else if (strTag == "G")
                    {
                        string? strDate = GetAcroFormFieldByName(_V작업일_);
                        if (strDate.IsNullOrWhiteSpaceEx() == true)
                        {
                            strDate = GetAcroFormFieldByName(_V구매일_);
                        }
                        if (strDate.IsNullOrWhiteSpaceEx() != true)
                        {
                            SetDiaryDate(strDate);
                        }
                    }
                    else if (strTag == "S")
                    {
                        if(DiaryDate.IsNullOrWhiteSpaceEx() != true && InputFormFieldDiaryDateTime.IsNullOrWhiteSpaceEx() != true)
                        {
                            if(DiaryDate.ToDateStartEx() != InputFormFieldDiaryDateTime)
                            {
                                string strCaption = Utils.GetLanguageResourceString(TDefs._RESOURCEKEY_DATEDIFF_APPLY_QUESTION_, defaultText: "There is already a date entered, and the date you are trying to specify is different.\n\nDo you want to continue?\n\n(이미 입력된 날짜가 있으며, 지정할려는 날짜가 서로 다릅니다. 계속 진행하시겠습니까?)");
                                DialogResult dlg = Utils.ShowMessageBox(this, strCaption, icon: MessageBoxIcon.Question, buttons: MessageBoxButtons.YesNo, defaultButton: MessageBoxDefaultButton.Button2);
                                if (dlg != DialogResult.Yes) { return; }
                            }
                        }

                        bool bAction = SetAcroFormFieldByName(_V작업일_, DiaryDate?.ToString("yyyy-MM-dd") ?? string.Empty);
                        if (bAction != true)
                        {
                            _ = SetAcroFormFieldByName(_V구매일_, DiaryDate?.ToString("yyyy-MM-dd") ?? string.Empty);
                        }
                    }
                }
            };

            repluTemplateList.ButtonClick += (s, e) =>
            {
                string strTag = e.Button.Tag.ToStringEx().ToUpper();
                if (strTag.IsNullOrWhiteSpaceEx() != true)
                {
                    if (strTag == "R")
                    {
                        LoadFarmDiaryTemplateList();
                    }
                    else if (strTag == "L")
                    {
                        if (s is not GridLookUpEdit sender || baredtChildTemplateList.EditValue.IsNullOrWhiteSpaceEx()) { return; }
                        /*
                        TemplateItem? selectedTemplate = sender.DataBindings.OfType<BindingSource>()
                            .FirstOrDefault()?
                            .List
                            .OfType<TemplateItem>()
                            .Where(r => r.TemplateId == baredtChildTemplateList.EditValue.ToStringEx())
                            .FirstOrDefault();
                        */
                        bool flowControl = OpenTemplateToFramDiary();
                        if (!flowControl)
                        {
                            return;
                        }
                    }
                }
            };



            barbtnChildAppend_FarmingDiary.ItemClick += (s, e) => SetAppendFarmingDiary();

        }

        public UbFarmDiaryInputForm(TImageCartItem item)
            : this()
        {
            this.SourceImageItem = item;
        }

        private void LoadFarmDiaryTemplateList(bool isInit = false)
        {
            SysEnv.LoadFarmingDiaryTemplate(true);
            if (SysEnv.FarmingDiaryTemplateBindingList == null || isInit == true)
            {
                SysEnv.InitFarmingDiaryTemplateFromBarItem(baredtChildTemplateList, SysEnv.FarmingDiaryTemplateBindingList);
            }
            else
            {
                repluTemplateList.DataSource = SysEnv.FarmingDiaryTemplateBindingList;
            }
        }

        private void LoadWorkspaceSelectList(bool isInit = false)
        {
            SysEnv.LoadWorkspace(true);
            if (SysEnv.WorkspaceDataTable == null || isInit == true)
            {
                SysEnv.InitWorkspaceSelectFromSearchLookupEdit(repsluChildWorkspaceSelect, SysEnv.WorkspaceDataTable);
            }
            else
            {
                repsluChildWorkspaceSelect.DataSource = SysEnv.WorkspaceDataTable;
            }
        }

        private bool OpenTemplateToFramDiary(bool IsInit = false)
        {
            IEnumerable<TTemplateItem>? data = repluTemplateList.DataSource as IEnumerable<TTemplateItem>;
            if (data == null || data.Any() != true) { return false; }

            if(IsInit == true || baredtChildTemplateList.EditValue == null) 
            {
                baredtChildTemplateList.EditValue = data.FirstOrDefault();
            }

            TTemplateItem? item = (baredtChildTemplateList.EditValue as TTemplateItem) ?? data.FirstOrDefault();

            TTemplateItem? selectedTemplate = data.Where(r => r.TemplateCode == item?.TemplateCode).FirstOrDefault();
            if (selectedTemplate != null)
            {
                //repluTemplateList.EditValue = selectedTemplate.SNO;
                if (HxFile.IsFileExists(selectedTemplate.TemplateFullPath) != true)
                {
                    XtraMessageBox.Show($"The selected template file does not exist.{Environment.NewLine}{selectedTemplate.TemplateFullPath}"
                        , "Load Template Error"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Warning);
                    return false;
                }
                try
                {
                    /*
                    using PdfDocumentProcessor processor = new PdfDocumentProcessor();
                    processor.LoadDocument(selectedTemplate.TemplateFullPath);
                    using MemoryStream ms = new MemoryStream();
                    processor.SaveDocument(ms);
                    pdfCtl.CloseDocument();
                    pdfCtl.LoadDocument(ms);
                    */
                    pdfCtl.LoadDocument(selectedTemplate.TemplateFullPath);
                }
                catch (Exception ex)
                {
                    SbUtils.ShowMessageBox(ex.Message, icon: MessageBoxIcon.Error);
                    //throw;
                }

            }

            return true;
        }

        private bool OpenOcrToFarmingDiary()
        {
            if (this.SourceImageItem == null || this.SourceImageItem.ImageData == null) { return false; }
            try
            {
                this.Text = $"{this.DefaultTitle} with AI-OCR";
                bool bTest = false;
#if DEBUG
                Debug.WriteLine("Start OCR-NAVER API Call");
                bTest = true;
#endif
                ResultObj = SysEnv.CallOcrNaverApi_GetJson(this.SourceImageItem.ImageData, bTest);
                if (ResultObj.Value.IsNullOrWhiteSpaceEx() != true)
                {
                    OCR_NAVER_API_Response_Body jsonObj = HxUtils.JsonDeserializeObject<OCR_NAVER_API_Response_Body>(ResultObj.Value);
                    if (jsonObj.requestId.IsNullOrWhiteSpaceEx() == true
                        || jsonObj.images.Any() != true
                        )
                    { return false; }

                    /*
                    foreach(var img in json.images)
                    {
                        Debug.WriteLine($"Image UID: {img.uid}, Name: {img.name}, InferResult: {img.inferResult}, Message: {img.message}");
                        foreach(var field in img.fields)
                        {
                            Debug.WriteLine($" - Field Name: {field.name}, ValueType: {field.valueType}, InferText: {field.inferText}, InferConfidence: {field.inferConfidence}");
                        }
                    }
                    */
                    OCR_NAVER_API_Response_image? jsonImage = jsonObj.images.First();
                    if (jsonImage == null || jsonImage.IsNullOrWhiteSpaceEx() == true) { return false; }

                    //HxFile.IsFileExists(TplSample01Full) == true
                    string strTempateCode = jsonImage?.matchedTemplate.name;
                    this.DocTemplateCode = strTempateCode;
                    //string strTemplatePath = Path.Combine(SysEnv.GetAppBaseDir(), Defs._TEMPLATE_DIR_NAME_, strTempateFileName);
                    string strTemplatePath = this.DocTemplateFullPath;
                    string strTempateFileName = HxFile.GetFileName(strTemplatePath); //$"tpl-영농일지_{strTemplateName}.pdf";
                    if (strTemplatePath.IsNullOrWhiteSpaceEx() == true || HxFile.IsFileExists(strTemplatePath) != true)
                    {
                        string strMsg = $"The template file for the recognized document does not exist.";
                        strMsg = Utils.GetLanguageResourceString(Defs._RESOURCEKEY_TEMPLATE_FILE_NOT_EXIST_, cultureName: null, defaultText: strMsg);
                        SbUtils.ShowMessageBox(text: $"{strMsg}{Environment.NewLine}{strTempateFileName}", icon: MessageBoxIcon.Warning);
                        return false;
                    }
                    //LoadTemplateSample();
                    //DevExpress.Office.Core
                    using PdfDocumentProcessor processor = new PdfDocumentProcessor();
                    processor.LoadDocument(strTemplatePath);
                    IList<string> fields = processor.GetFormFieldNames();

                    PdfDocumentFacade documentFacade = processor.DocumentFacade;
                    PdfAcroFormFacade acroForm = documentFacade.AcroForm;
                    IEnumerable<PdfFormFieldFacade> collisions = acroForm.GetFields();
                    if (collisions.Any() != true)
                    {
                        Debug.WriteLine("No name conflicts are detected");
                        return false;
                    }
                    else
                    {
                        if (jsonImage?.uid.IsNullOrWhiteSpaceEx() == true || jsonImage?.fields.Any() != true) { return false; }

                        IEnumerable<OCR_NAVER_API_Response_field>? jsonFields = jsonImage?.fields;

                        foreach (PdfFormFieldFacade formField in collisions)
                        {
                            PdfTextFormFieldFacade formText = acroForm.GetTextFormField(formField.FullName);
                            if (formText == null || formText.FullName.IsNullOrWhiteSpaceEx() == true) { continue; }

                            OCR_NAVER_API_Response_field? jsonField = jsonFields?.Where(r => r.name == formField.FullName).FirstOrDefault();
                            if (jsonField?.name.IsNullOrWhiteSpaceEx() == true) { continue; }

                            formText.Value = jsonField?.inferText.Trim();

                            if((formField.FullName == _V작업일_ || formField.FullName == _V구매일_) && formText.Value.IsNullOrWhiteSpaceEx() != true)
                            {
                                SetDiaryDate(formText.Value.ToStringEx());
                            }

                        }
                    }
#if DEBUG
                    string strTestOuputPath = Path.Combine(SysEnv.GetAppOutputDir(false, true), $"FarmingDiary_OCR_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.pdf");
                    processor.SaveDocument(strTestOuputPath);
#endif
                    using MemoryStream ms = new MemoryStream();
                    processor.SaveDocument(ms);
                    pdfCtl.LoadDocument(ms);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                //throw;
            }

            return false;
        }
         
        private bool SetAppendFarmingDiary()
        {
            bool Result = false;

            pdfCtl.ClearSelection();

            string strAppyQuestionText = Utils.GetLanguageResourceString(TDefs._RESOURCEKEY_DIARY_SAVE_QUESTION_, defaultText: "Would you like to save the currently entered document?\n\n(현재 입력된 문서를 저장 하시겠습니까?)");
            var dlgApply = Utils.ShowMessageBox(this, strAppyQuestionText, icon: MessageBoxIcon.Question, buttons: MessageBoxButtons.YesNo, defaultButton: MessageBoxDefaultButton.Button2);
            if (dlgApply != DialogResult.Yes) { return Result; }

            Utils.ShowWaitLoadingForm();
            try
            {
                bool bImageOcrMode = false;
                if (this.SourceImageItem == null || this.SourceImageItem.ImageData == null)
                {
                    bImageOcrMode = false;
                }
                else
                {
                    bImageOcrMode = true;
                }
                PdfDocumentFacade documentFacade = pdfCtl.GetDocumentFacade();
                PdfAcroFormFacade acroForm = documentFacade.AcroForm;
                IEnumerable<PdfFormFieldFacade> collisions = acroForm.GetFields();

                //pdfCtl.sav
                //pdfCtl.SaveDocument();

                Dictionary<string, string> docInputFields = GetAcroFormFields(this.pdfCtl);
                if (docInputFields == null || docInputFields.Any() != true)
                {
                    Debug.WriteLine("No form field data to append.");
                    Result = false;
                    return Result;
                }



                if(DiaryDate == null || DiaryDate.IsNullOrWhiteSpaceEx() == true)
                {
                    if(InputFormFieldDiaryDateTime != null && InputFormFieldDiaryDateTime.IsNullOrWhiteSpaceEx() != true)
                    {
                        DiaryDate = InputFormFieldDiaryDateTime;
                    }
                } 
                else if(InputFormFieldDiaryDateTime == null || InputFormFieldDiaryDateTime.IsNullOrWhiteSpaceEx() == true)
                {
                    if (DiaryDate != null && DiaryDate.IsNullOrWhiteSpaceEx() != true)
                    {
                        InputFormFieldDiaryDateStr = DiaryDate?.ToDateStartEx().ToDateStringEx();
                    }
                }

                if(DiaryDate.ToDateStartEx() != InputFormFieldDiaryDateTime.ToDateStartEx())
                {
                    string strDlgText = Utils.GetLanguageResourceString(TDefs._RESOURCEKEY_DATEDIFF_NOTEQUALS_QUESTION_, defaultText: "The specified date and the date entered in the document are different.\n\nDo you want to continue?\n\n(지정된 날짜와 문서에 입력된 날짜가 다릅니다. 이대로 계속 진행하시겠습니까?)");
                    DialogResult dlg = Utils.ShowMessageBox(this, strDlgText, icon: MessageBoxIcon.Question, buttons: MessageBoxButtons.YesNo);
                    if (dlg != DialogResult.Yes) { return Result; }
                }

                if(DiaryDate == null || InputFormFieldDiaryDateStr.IsNullOrWhiteSpaceEx() == true)
                {
                    string strDlgText = Utils.GetLanguageResourceString(TDefs._RESOURCEKEY_DIARY_NOT_DATE_, defaultText: "No date has been specified.\n\nPlease check again.\n\n(날짜가 지정되지 않았습니다. 다시 확인하시기 바랍니다.)");
                    Utils.ShowMessageBox(this, strDlgText, icon: MessageBoxIcon.Stop);
                    return Result;
                }

                string? strValAddr = GetAcroFormFieldByName(_V농장_필지_);
                if(strValAddr.IsNullOrWhiteSpaceEx() == true)
                {
                    Utils.ShowMessageBox(this, Utils.GetLanguageResourceString(TDefs._RESOURCEKEY_DIARY_NOT_ADDR_, defaultText: "Farm and address information was not entered.\n\nPlease check again.\n\n(농장 및 주소 정보가 입력되지 않았습니다. 다시 확인하시기 바랍니다.)"), icon: MessageBoxIcon.Stop);
                    return Result;
                }
                string? strValTask = GetAcroFormFieldByName(_V작업단계_작업명_);
                if (strValTask.IsNullOrWhiteSpaceEx() == true)
                {
                    Utils.ShowMessageBox(this, Utils.GetLanguageResourceString(TDefs._RESOURCEKEY_DIARY_NOT_TASK_, defaultText: "The task step (task name) information has not been entered.\n\nPlease check again.\n\n(작업단계(작업명) 정보가 입력되지 않았습니다. 다시 확인하시기 바랍니다.)"), icon: MessageBoxIcon.Stop);
                    return Result;
                }
                string? strValDetail = GetAcroFormFieldByName(_V세부작업_);
                if (strValDetail.IsNullOrWhiteSpaceEx() == true)
                {
                    Utils.ShowMessageBox(this, Utils.GetLanguageResourceString(TDefs._RESOURCEKEY_DIARY_NOT_DETAIL_, defaultText: "Detailed task information has not been entered.\n\nPlease check again.\n\n(세부작업 정보가 입력되지 않았습니다. 다시 확인하시기 바랍니다.)"), icon: MessageBoxIcon.Stop);
                    return Result;
                }


                string strFileName = Path.Combine(SysEnv.GetAppTempDir(), $"{HxString.GetNowDateTime("yyyy-MM-dd")}_{this.DocTemplateCode}.pdf");
                strFileName = HxFile.GetFileUniquePath(strFileName, HxFileOverwriteType.RenameSequence);
                pdfCtl.SaveDocument(strFileName);
                /*
                using MemoryStream ms = new MemoryStream();
                pdfCtl.SaveDocument(ms);
                ms.Position = 0;
                byte[] bytesDocFile = ms.ToArray();
                ms.Close();
                ms.Dispose();
                */
                byte[] bytesDocFile = HxFile.ReadAllBytes(strFileName);
                decimal? iSNo = this.SNo;
                DateTime? dDiaryDate = this.DiaryDate;
                decimal? iUNo = this.UNo;



                string? strTitle = docInputFields.ContainsKey("제목") ? docInputFields["제목"] : "No Title";
                string? strDescription = docInputFields.ContainsKey("설명") ? docInputFields["설명"] : null;

                string? strDocTemplateCode = this.DocTemplateCode;
                string? strDocTemplateName = this.DocTemplateName;

                string strDocFileBase64Data = HxString.GetByteToBase64Encode(bytesDocFile);
                string strDocFileBase64Checksum = HxUtils.GetMD5String(strDocFileBase64Data);
                string strDocFileName = HxFile.GetFileName(pdfCtl.DocumentFilePath);
                string strDocFileChecksum = HxUtils.GetMD5String(HxString.ByteToString(bytesDocFile));

                string? strOcrTemplateCode = null;
                string? strOcrTemplateName = null;
                string? strOcrImageName = null;
                string? strOcrImageChecksum = null;
                string? strOcrImageBase64Data = null;
                string? strOcrImageBase64Checksum = null;
                OCR_NAVER_API_Response_Body? ocrJsonObj = null;
                Dictionary<string, string>? ocrJsonFields = null;
                if (bImageOcrMode == true)
                {

                    ocrJsonObj = HxUtils.JsonDeserializeObject<OCR_NAVER_API_Response_Body>(ResultObj!.Value);
                    if (ocrJsonObj != null)
                    {
                        OCR_NAVER_API_Response_Body ocrJsonValue = ocrJsonObj.Value;
                        strOcrTemplateCode = ocrJsonValue.images?.First().matchedTemplate.name ?? ocrJsonValue.images?.First().title.name;
                        strOcrTemplateName = ocrJsonValue.images?.First().title.name;
                        byte[] bytesOcrImage = this.SourceImageItem!.ImageBytes;
                        if (bytesOcrImage == null || bytesOcrImage.Length > 0)
                        {
                            strOcrImageName = HxFile.GetFileName(this.SourceImageItem.Name);
                            strOcrImageChecksum = this.SourceImageItem.FileChecksum; // HxUtils.GetMD5String(HxString.ByteToString(bytesOcrImage));
                            strOcrImageBase64Data = HxString.GetByteToBase64Encode(bytesOcrImage);
                            strOcrImageBase64Checksum = HxUtils.GetMD5String(strOcrImageBase64Data);
                        }



                        ocrJsonFields = new Dictionary<string, string>();
                        foreach (OCR_NAVER_API_Response_field ocrField in ocrJsonValue.images!.First().fields)
                        {
                            string strFieldName = ocrField.name.Trim();
                            string strFieldValue = ocrField.inferText.Trim();
                            if (ocrJsonFields.ContainsKey(strFieldName) != true)
                            {
                                ocrJsonFields.Add(strFieldName, strFieldValue);
                            }
                        }
                        /*
                        SQL_TXFD_IMAGE_SET_Table imgRec = new SQL_TXFD_IMAGE_SET_Table
                        {
                            IMG_NO = int.MinValue,
                            SOURCE_TYPE = "OCR",
                            SOURCE_DATE = DateTime.Now,
                            FILE_CHECK = this.SourceImageItem.FileChecksum,
                            FILE_SIZE = this.SourceImageItem.FileSize,
                            FILE_EXT = this.SourceImageItem.FileExt,
                            FILE_TYPE = HxFile.GetMimeType(this.SourceImageItem.FileExt),
                            FILE_NAME = HxString.GetNowLongDateTimeString(),
                            FILE_DATA = HxString.GetImageToBase64Encode(this.SourceImageItem.ImageData),
                            FILE_CONTENTS = inputFields.ToJsonStringEx()
                        };

                        string strTplCode = null;
                        string strTplName = null;
                        if (inputFields.ContainsKey("제목"))
                        {
                            strTplName = inputFields["제목"].Replace(" ",string.Empty);
                            switch (strTplName)
                            {
                                case "영농일지":
                                    strTplCode = "R1-1";
                                    break;
                                case "자재구매내역":
                                    strTplCode = "R1-2";
                                    break;
                                case "미분류":
                                default:
                                    strTplCode = "NONE";
                                    break;
                            }
                        }
                        SQL_TXFD_OCR_SET_Table ocrRec = new SQL_TXFD_OCR_SET_Table
                        {
                            OCR_NO = int.MinValue,
                            PARENT_NO = null,
                            IMG_NO = int.MinValue,
                            TPL_CODE = strTplCode,
                            TPL_NAME = strTplName,
                            RESPONSE_DATA = jsonObj.ToJsonStringEx(),
                            RESPONSE_DATA_TYPE = "JSON",
                            RESPONSE_VERSION = jsonObj.version,
                            RESPONSE_REQUESTID = jsonObj.requestId,
                            RESPONSE_TIMESTAMP = jsonObj.timestamp
                        };


                        var res = SysEnv.CallOcrNaverApi_SaveOcrResultToDb(imgRec, ocrRec, inputFields);

                        */
                        //string jsonData = jsonObj.ToJsonStringEx();
                        //string inputData = inputFields.ToJsonStringEx();

                    }

                }

                TSmartDiaryPaperItem item = new TSmartDiaryPaperItem
                {
                    SNO = SysEnv.CurrWorkspaceSNO,
                    DiaryDate = DateTime.Now,
                    UNO = SysEnv.LoginUserSNO,
                    Title = docInputFields.ContainsKey("제목") ? docInputFields["제목"] : "No Title",
                    Description = docInputFields.ContainsKey("설명") ? docInputFields["설명"] : null,
                    DocTemplateCode = strDocTemplateCode,
                    DocTemplateName = strDocTemplateName,
                    //CreatedDate = DateTime.Now,
                    //ModifiedDate = DateTime.Now,
                    DocFileName = strDocFileName,
                    DocFileChecksum = strDocFileChecksum,
                    DocFileBase64Data = strDocFileBase64Data,
                    DocFieldsData = docInputFields,
                    OcrTemplateCode = strOcrTemplateCode,
                    OcrTemplateName = strOcrTemplateName,
                    OcrImageName = strOcrImageName,
                    OcrImageChecksum = strOcrImageChecksum,
                    OcrImageBase64Data = strOcrImageBase64Data,
                    OcrFieldsData = ocrJsonFields,
                    OcrJsonData = ocrJsonObj,
                };

                var res = SysEnv.CallSmartDiaryApi_SaveFarmingDiaryPaperItem(item);

            }
            catch (Exception ex)
            {
                Result = false;
                Debug.WriteLine(ex);
                //throw;
            }
            finally
            {
                Utils.CloseWaitLoadingForm();
            }

            return Result;
        }

        private Dictionary<string, string>? GetAcroFormFields(PdfViewer? pdfViewer = null)
        {
            if(pdfViewer == null)
            {
                pdfViewer = this.pdfCtl;
            }
            PdfDocumentFacade documentFacade = pdfViewer.GetDocumentFacade();
            PdfAcroFormFacade acroForm = documentFacade.AcroForm;
            IEnumerable<PdfFormFieldFacade> collisions = acroForm.GetFields();
            if (collisions.Any() != true)
            {
                Debug.WriteLine("No name conflicts are detected");
                return null;
            }
            Dictionary<string, string> Result = [];
            foreach (var formField in collisions)
            {
                PdfTextFormFieldFacade formText = acroForm.GetTextFormField(formField.FullName);
                if (formText == null || formText.FullName.IsNullOrWhiteSpaceEx() == true) { continue; }

                //Debug.WriteLine($"Field Name: {formText.FullName}, Value: {strFieldValue}");
                // Append to Farming Diary Logic Here
                // ...
                string strFieldName = formText.FullName.Trim();
                string strFieldValue = formText.Value.ToStringEx().Trim();
                /*
                OCR_NAVER_API_Response_field jsonField = new OCR_NAVER_API_Response_field
                {
                    name = strFieldName,
                    inferText = strFieldValue
                };
                if (jsonField.name.IsNullOrWhiteSpaceEx() == true) { continue; }
                jsonFields.Add(strFieldName, jsonField);
                */
                //OCR_NAVER_API_Response_field? jsonField = jsonFields?.Where(r => r.name == formField.FullName).FirstOrDefault();
                if (Result.ContainsKey(strFieldName) != true)
                {
                    Result.Add(strFieldName, strFieldValue);
                }
            }

            return Result;
        }

        private string? GetAcroFormFieldByName(string name)
        {
            Dictionary<string, string> docInputFields = GetAcroFormFields(this.pdfCtl);
            IEnumerable<KeyValuePair<string, string>> findFields = docInputFields.Where(r => r.Key.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (findFields != null && findFields.Any() == true)
            {
                foreach (KeyValuePair<string, string> field in findFields)
                {
                    if(field.Value.IsNullOrWhiteSpaceEx() != true)
                    {
                        return field.Value;
                    }
                }
                return string.Empty;
            }
            return null;
        }
        private bool SetAcroFormFieldByName(string name, string value)
        {
            bool Result = false;
            PdfDocumentFacade documentFacade = pdfCtl.GetDocumentFacade();
            if (documentFacade == null) { return Result; }

            PdfAcroFormFacade acroForm = documentFacade.AcroForm;
            if(acroForm == null) { return Result; }

            PdfTextFormFieldFacade? findFormText = acroForm.GetTextFormField(name);
            if (findFormText != null)
            {
                findFormText.Value = value;
                Result = true;
            }

            if (Result != true)
            {
                IEnumerable<PdfFormFieldFacade> collisions = acroForm.GetFields();
                if (collisions.Any() != true)
                {
                    foreach (PdfFormFieldFacade field in collisions)
                    {
                        if (field.FullName.Equals(name, StringComparison.OrdinalIgnoreCase))
                        {
                            PdfTextFormFieldFacade formText = acroForm.GetTextFormField(field.FullName);
                            if (formText != null)
                            {
                                formText.Value = value;
                                Result = true;
                            }
                        }
                    }
                }
            }
            return Result;
        }

        private void SetLoadTemplateSample()
        {

            if (TplSample01Full.IsNullOrWhiteSpaceEx() != true && HxFile.IsFileExists(TplSample01Full))
            {
                //pdfViewerCtl.DocumentFilePath.IsNullOrWhiteSpaceEx();
                try
                {
                    pdfCtl.LoadDocument(TplSample01Full);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);

                    //throw;
                }

            }
        }

        

        

        
    }
}
