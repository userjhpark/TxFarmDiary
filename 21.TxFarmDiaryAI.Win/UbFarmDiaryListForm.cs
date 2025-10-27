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
    public partial class UbFarmDiaryListForm : UbBaseChildRibbonForm
    {
        public UbFarmDiaryListForm()
        {
            InitializeComponent();

            this.Load += OnForm_Load;

        }

        private void OnForm_Load(object? sender, EventArgs e)
        {
            spcBody.Dock = DockStyle.Fill;
            spcBody.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            spcBody.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel2;
        }
    }
}
