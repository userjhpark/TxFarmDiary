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

namespace FarmDiaryAI.Win
{
    public partial class UbBaseForm : DevExpress.XtraEditors.XtraForm
    {
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsStartUp { get; protected set; } = false;

        public UbBaseForm()
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
            SysEnv.SetCultureName(cultureName??SysEnv.CultureName);
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

    }
}