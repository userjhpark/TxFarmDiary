using DevExpress.XtraBars.Ribbon;
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
    public partial class UbBaseChildRibbonForm : UbBaseChildForm
    {
        public UbBaseChildRibbonForm()
        {
            InitializeComponent();
        }

        protected virtual void OnForm_Load(object? sender, EventArgs e)
        {
            //base.OnLoad(e);

            if (this.IsStartUp != true)
            {
                this.SetRibbonSubMenuMergeStyle();
                this.ApplyResourcesStrings();
                //this.IsStartUp = true;
            }
        }

        public UbBaseChildRibbonForm(Form parentForm)
            : this()
        {
            this.Owner = parentForm;
        }

        protected internal virtual void SetRibbonSubMenuMergeStyle()
        {
            if (this.DesignMode)
                return;

            //rcSubMenu.MdiMergeStyle = RibbonMdiMergeStyle.OnlyWhenMaximized;
            rcChildMenu.MdiMergeStyle = RibbonMdiMergeStyle.Default;
            if (this.IsStartUp != true)
            {
                //rcSubMenu.MdiMergeStyle = RibbonMdiMergeStyle.Always;
                //rcSubMenu.Merge += OnRibbonForm_Merge;
                //rcSubMenu.UnMerge += OnRibbonForm_UnMerge;
            }
        }

        protected virtual void OnRibbonForm_UnMerge(object sender, RibbonMergeEventArgs e)
        {
            if (this.DesignMode) return;
            RibbonControl? parentRibbon = sender as RibbonControl;
            parentRibbon?.StatusBar?.UnMergeStatusBar();
        }

        protected virtual void OnRibbonForm_Merge(object sender, RibbonMergeEventArgs e)
        {
            if (this.DesignMode) return;
            RibbonControl? parentRibbon = sender as RibbonControl;
            RibbonControl? childRibbon = e?.MergedChild;
            if (parentRibbon != null && childRibbon != null)
            {
                parentRibbon?.StatusBar?.MergeStatusBar(childRibbon?.StatusBar);
            }
        }
    }
}
