using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using HxCore;

namespace TxFarmDiaryAI.Win
{
    public partial class UbPDFViewerRibbonForm : UbBaseChildRibbonForm
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsDisplayTitleFullName { get; internal set; } = false;
        public UbPDFViewerRibbonForm()
        {
            InitializeComponent();
        }
        public UbPDFViewerRibbonForm(string filePath) : this()
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
            pdfViewer1.LoadDocument(filePath);
            this.Text = $"PDF Viewer - {HxFile.GetFileName(filePath)}";
            //this.Text = $"PDF Viewer - {HxFile.GetFileName(filePath)} ( {HxFile.GetFileDirPath(filePath)} )";
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            //pdfViewer1.Modify
            base.OnClosing(e);
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            pdfViewer1.CloseDocument();
            base.OnFormClosed(e);
        }

        public void SetDisplayTitleFullName(bool isTitleFullName)
        {
            this.IsDisplayTitleFullName = isTitleFullName;
        }

        public void ClearDocument()
        {
            pdfViewer1.CloseDocument();
            this.Text = "PDF Viewer";
        }
    }
}
