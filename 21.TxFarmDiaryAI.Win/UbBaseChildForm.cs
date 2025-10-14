using DevExpress.CodeParser;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HxCore;
using HxCore.Win;

using Utils = TxFarmDiaryAI.Win.SbUtils;

namespace TxFarmDiaryAI.Win
{
    public partial class UbBaseChildForm : DevExpress.XtraEditors.XtraForm
    {
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsStartUp { get; protected set; } = false;

        public UbBaseChildForm()
        {
            InitializeComponent();
            this.Load += OnFormLoad;
            this.FormClosed += OnFormClosed;
        }

        private void OnFormLoad(object? sender, EventArgs e)
        {
            
        }

        private void OnFormClosed(object? sender, FormClosedEventArgs e)
        {
            
        }


        protected virtual void ApplyResourcesStrings(string? cultureName = null)
        {
            Utils.ResourceLanguageStrings.SetCultureName(cultureName??SysEnv.CultureName);
        }
        /*
        // 예시: 언어 변경
        protected override void DoLanguageChange(object? sender, string cultureName)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureName);
            // 폼을 새로 로드하거나, 컨트롤의 텍스트를 재설정
            this.Controls.Clear();
            InitializeComponent(); // 모든 컨트롤의 Text 속성이 새 리소스 값으로 재설정
        }
        */

        protected DialogResult ShowMessageBox(string? text, string? caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton? messageBoxDefaultButton = null) => SbUtils.ShowMessageBox(text, caption, buttons, icon, messageBoxDefaultButton);
        protected DialogResult ShowMessageBox(string? text, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton? messageBoxDefaultButton = null)
        {
            string? caption = "Message";
            switch (icon)
            {
                //case MessageBoxIcon.Hand:
                //case MessageBoxIcon.Stop:
                case MessageBoxIcon.Error:
                    caption = "Error";
                    break;
                case MessageBoxIcon.Question:
                    caption = "Question?";
                    break;
                //case MessageBoxIcon.Exclamation:
                case MessageBoxIcon.Warning:
                    caption = "Warning";
                    break;
                //case MessageBoxIcon.Asterisk:
                case MessageBoxIcon.Information:
                    caption = "Information";
                    break;
                case MessageBoxIcon.None:
                default:
                    //caption = "Notice";
                    caption = "Message";
                    break;
            }
            return this.ShowMessageBox(text: text, caption: caption, buttons: buttons, icon: icon, messageBoxDefaultButton: messageBoxDefaultButton);
        }
        protected DialogResult ShowMessageBox(string? text, MessageBoxIcon icon)
        {
            string caption = GetMessageBoxCaption(icon);
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBoxDefaultButton messageBoxDefaultButton = MessageBoxDefaultButton.Button1;
            return this.ShowMessageBox(text: text, caption: caption, buttons: buttons, icon: icon, messageBoxDefaultButton: messageBoxDefaultButton);
        }

        private static string GetMessageBoxCaption(MessageBoxIcon icon)
        {
            string? Result = "Message";
            switch (icon)
            {
                //case MessageBoxIcon.Hand:
                //case MessageBoxIcon.Stop:
                case MessageBoxIcon.Error:
                    Result = "Error";
                    break;
                case MessageBoxIcon.Question:
                    Result = "Question?";
                    break;
                //case MessageBoxIcon.Exclamation:
                case MessageBoxIcon.Warning:
                    Result = "Warning";
                    break;
                //case MessageBoxIcon.Asterisk:
                case MessageBoxIcon.Information:
                    Result = "Information";
                    break;
                case MessageBoxIcon.None:
                default:
                    //caption = "Notice";
                    Result = "Message";
                    break;
            }

            return Result;
        }

        protected void ShowWaitLoadingForm(System.Windows.Forms.Form? sender = null, bool useFadeIn = false, bool useFadeOut = false, bool throwExceptionIfAlreadyOpened = false)
        {
            if (sender == null)
            {
                sender = this;
            }
            SbUtils.ShowWaitLoadingForm(sender, useFadeIn, useFadeOut, throwExceptionIfAlreadyOpened);
        }
        protected void CloseWaitLoadingForm(bool throwExceptionIfAlreadyClosed = false) => SbUtils.CloseWaitLoadingForm(throwExceptionIfAlreadyClosed);
    }
}