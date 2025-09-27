namespace TxFarmDiaryAI.Win
{
    partial class UbBaseChildRibbonForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UbBaseChildRibbonForm));
            rcChildMenu = new DevExpress.XtraBars.Ribbon.RibbonControl();
            rsbChildStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ((System.ComponentModel.ISupportInitialize)rcChildMenu).BeginInit();
            SuspendLayout();
            // 
            // rcChildMenu
            // 
            rcChildMenu.ExpandCollapseItem.Id = 0;
            rcChildMenu.Items.AddRange(new DevExpress.XtraBars.BarItem[] { rcChildMenu.ExpandCollapseItem });
            rcChildMenu.Location = new Point(0, 0);
            rcChildMenu.MaxItemId = 1;
            rcChildMenu.Name = "rcChildMenu";
            rcChildMenu.Size = new Size(800, 53);
            rcChildMenu.StatusBar = rsbChildStatusBar;
            // 
            // rsbChildStatusBar
            // 
            rsbChildStatusBar.Location = new Point(0, 428);
            rsbChildStatusBar.Name = "rsbChildStatusBar";
            rsbChildStatusBar.Ribbon = rcChildMenu;
            rsbChildStatusBar.Size = new Size(800, 22);
            // 
            // UbBaseChildRibbonForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rsbChildStatusBar);
            Controls.Add(rcChildMenu);
            IconOptions.Image = (Image)resources.GetObject("UbBaseChildRibbonForm.IconOptions.Image");
            Name = "UbBaseChildRibbonForm";
            Text = "Farm Diary System for Windows";
            ((System.ComponentModel.ISupportInitialize)rcChildMenu).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        protected internal DevExpress.XtraBars.Ribbon.RibbonControl rcChildMenu;
        protected internal DevExpress.XtraBars.Ribbon.RibbonStatusBar rsbChildStatusBar;
    }
}