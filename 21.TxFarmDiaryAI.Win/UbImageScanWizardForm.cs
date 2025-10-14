using DevExpress.XtraEditors;
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
    public partial class UbImageScanWizardForm : UbBaseChildForm
    {
        public UbImageScanWizardForm()
        {
            InitializeComponent();

            Load += OnForm_Load;
            Shown += OnForm_Shown;
        }

        private void OnForm_Load(object? sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }
        private void OnForm_Shown(object? sender, EventArgs e)
        {
            if (this.IsStartUp != true)
            {

                this.IsStartUp = true;
            }
        }        
    }
}