using DevExpress.XtraEditors;
using HxCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TxFarmDiaryAI.Win
{
    public partial class UbPDFViewerBarForm : UbBaseChildForm
    {
        public UbPDFViewerBarForm()
        {
            InitializeComponent();
        }
        public UbPDFViewerBarForm(string filePath) : this()
        {
            LoadPDF(filePath);
        }

        public void LoadPDF(string filePath)
        {
            // PDF 파일 로드 로직 구현
            if (filePath.IsNullOrWhiteSpaceEx() == true || HxFile.IsFileExists(filePath) != true)
            {
                return;
            }
            pdfViewerCtl.LoadDocument(filePath);
            this.Text = $"PDF Viewer - {HxFile.GetFileName(filePath)} ( {HxFile.GetFileDirPath(filePath)} )";
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            //pdfViewer1.Modify
            base.OnClosing(e);
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            pdfViewerCtl.CloseDocument();
            base.OnFormClosed(e);
        }
    }
}
