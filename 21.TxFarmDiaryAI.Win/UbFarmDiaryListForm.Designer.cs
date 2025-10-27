namespace TxFarmDiaryAI.Win
{
    partial class UbFarmDiaryListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UbFarmDiaryListForm));
            rpChildFarmDiaryList = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            pnlTop = new DevExpress.XtraEditors.SidePanel();
            sidePanel2 = new DevExpress.XtraEditors.SidePanel();
            sidePanel3 = new DevExpress.XtraEditors.SidePanel();
            sidePanel4 = new DevExpress.XtraEditors.SidePanel();
            spcBody = new DevExpress.XtraEditors.SplitContainerControl();
            sidePanel6 = new DevExpress.XtraEditors.SidePanel();
            sidePanel5 = new DevExpress.XtraEditors.SidePanel();
            sidePanel8 = new DevExpress.XtraEditors.SidePanel();
            sidePanel7 = new DevExpress.XtraEditors.SidePanel();
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            pdfViewer1 = new DevExpress.XtraPdfViewer.PdfViewer();
            propertyGridControl1 = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            ((System.ComponentModel.ISupportInitialize)rcChildMenu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)spcBody).BeginInit();
            ((System.ComponentModel.ISupportInitialize)spcBody.Panel1).BeginInit();
            spcBody.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)spcBody.Panel2).BeginInit();
            spcBody.Panel2.SuspendLayout();
            spcBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)xtraTabControl1).BeginInit();
            xtraTabControl1.SuspendLayout();
            xtraTabPage1.SuspendLayout();
            xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)propertyGridControl1).BeginInit();
            SuspendLayout();
            // 
            // rcChildMenu
            // 
            rcChildMenu.EmptyAreaImageOptions.ImagePadding = new Padding(30, 28, 30, 28);
            rcChildMenu.ExpandCollapseItem.Id = 0;
            rcChildMenu.Items.AddRange(new DevExpress.XtraBars.BarItem[] { barButtonItem1 });
            rcChildMenu.MaxItemId = 2;
            rcChildMenu.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { rpChildFarmDiaryList });
            rcChildMenu.Size = new Size(1325, 150);
            // 
            // rsbChildStatusBar
            // 
            rsbChildStatusBar.Location = new Point(0, 617);
            rsbChildStatusBar.Size = new Size(1325, 22);
            // 
            // rpChildFarmDiaryList
            // 
            rpChildFarmDiaryList.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1 });
            rpChildFarmDiaryList.Name = "rpChildFarmDiaryList";
            rpChildFarmDiaryList.Text = "Farm Diary";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(barButtonItem1);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "Gird / List";
            // 
            // barButtonItem1
            // 
            barButtonItem1.Caption = "Refresh";
            barButtonItem1.Id = 1;
            barButtonItem1.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItem1.ImageOptions.SvgImage");
            barButtonItem1.Name = "barButtonItem1";
            // 
            // pnlTop
            // 
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 150);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1325, 10);
            pnlTop.TabIndex = 2;
            pnlTop.Text = "sidePanel1";
            // 
            // sidePanel2
            // 
            sidePanel2.Dock = DockStyle.Bottom;
            sidePanel2.Location = new Point(0, 607);
            sidePanel2.Name = "sidePanel2";
            sidePanel2.Size = new Size(1325, 10);
            sidePanel2.TabIndex = 3;
            sidePanel2.Text = "sidePanel2";
            // 
            // sidePanel3
            // 
            sidePanel3.Dock = DockStyle.Left;
            sidePanel3.Location = new Point(0, 160);
            sidePanel3.Name = "sidePanel3";
            sidePanel3.Size = new Size(10, 447);
            sidePanel3.TabIndex = 4;
            sidePanel3.Text = "sidePanel3";
            // 
            // sidePanel4
            // 
            sidePanel4.Dock = DockStyle.Right;
            sidePanel4.Location = new Point(1315, 160);
            sidePanel4.Name = "sidePanel4";
            sidePanel4.Size = new Size(10, 447);
            sidePanel4.TabIndex = 5;
            sidePanel4.Text = "sidePanel4";
            // 
            // spcBody
            // 
            spcBody.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel2;
            spcBody.Dock = DockStyle.Fill;
            spcBody.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            spcBody.Location = new Point(10, 160);
            spcBody.Name = "spcBody";
            // 
            // spcBody.Panel1
            // 
            spcBody.Panel1.Controls.Add(gridControl1);
            spcBody.Panel1.Controls.Add(sidePanel6);
            spcBody.Panel1.Controls.Add(sidePanel5);
            spcBody.Panel1.Text = "Panel1";
            // 
            // spcBody.Panel2
            // 
            spcBody.Panel2.Controls.Add(xtraTabControl1);
            spcBody.Panel2.Controls.Add(sidePanel8);
            spcBody.Panel2.Controls.Add(sidePanel7);
            spcBody.Panel2.Text = "Panel2";
            spcBody.Size = new Size(1305, 447);
            spcBody.SplitterPosition = 429;
            spcBody.TabIndex = 6;
            // 
            // sidePanel6
            // 
            sidePanel6.Dock = DockStyle.Bottom;
            sidePanel6.Location = new Point(0, 437);
            sidePanel6.Name = "sidePanel6";
            sidePanel6.Size = new Size(866, 10);
            sidePanel6.TabIndex = 1;
            sidePanel6.Text = "sidePanel6";
            sidePanel6.Visible = false;
            // 
            // sidePanel5
            // 
            sidePanel5.Dock = DockStyle.Top;
            sidePanel5.Location = new Point(0, 0);
            sidePanel5.Name = "sidePanel5";
            sidePanel5.Size = new Size(866, 10);
            sidePanel5.TabIndex = 0;
            sidePanel5.Text = "sidePanel5";
            sidePanel5.Visible = false;
            // 
            // sidePanel8
            // 
            sidePanel8.Dock = DockStyle.Bottom;
            sidePanel8.Location = new Point(0, 437);
            sidePanel8.Name = "sidePanel8";
            sidePanel8.Size = new Size(429, 10);
            sidePanel8.TabIndex = 2;
            sidePanel8.Text = "sidePanel8";
            sidePanel8.Visible = false;
            // 
            // sidePanel7
            // 
            sidePanel7.Dock = DockStyle.Top;
            sidePanel7.Location = new Point(0, 0);
            sidePanel7.Name = "sidePanel7";
            sidePanel7.Size = new Size(429, 10);
            sidePanel7.TabIndex = 1;
            sidePanel7.Text = "sidePanel7";
            sidePanel7.Visible = false;
            // 
            // gridControl1
            // 
            gridControl1.Dock = DockStyle.Fill;
            gridControl1.Location = new Point(0, 10);
            gridControl1.MainView = gridView1;
            gridControl1.MenuManager = rcChildMenu;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new Size(866, 427);
            gridControl1.TabIndex = 2;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            // 
            // xtraTabControl1
            // 
            xtraTabControl1.Dock = DockStyle.Fill;
            xtraTabControl1.Location = new Point(0, 10);
            xtraTabControl1.Name = "xtraTabControl1";
            xtraTabControl1.SelectedTabPage = xtraTabPage1;
            xtraTabControl1.Size = new Size(429, 427);
            xtraTabControl1.TabIndex = 3;
            xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] { xtraTabPage1, xtraTabPage2 });
            // 
            // xtraTabPage1
            // 
            xtraTabPage1.Controls.Add(pdfViewer1);
            xtraTabPage1.Name = "xtraTabPage1";
            xtraTabPage1.Size = new Size(427, 403);
            xtraTabPage1.Text = "Preview";
            // 
            // xtraTabPage2
            // 
            xtraTabPage2.Controls.Add(propertyGridControl1);
            xtraTabPage2.Name = "xtraTabPage2";
            xtraTabPage2.Size = new Size(427, 403);
            xtraTabPage2.Text = "Property";
            // 
            // pdfViewer1
            // 
            pdfViewer1.Dock = DockStyle.Fill;
            pdfViewer1.Location = new Point(0, 0);
            pdfViewer1.MenuManager = rcChildMenu;
            pdfViewer1.Name = "pdfViewer1";
            pdfViewer1.Size = new Size(427, 403);
            pdfViewer1.TabIndex = 0;
            // 
            // propertyGridControl1
            // 
            propertyGridControl1.Dock = DockStyle.Fill;
            propertyGridControl1.Location = new Point(0, 0);
            propertyGridControl1.MenuManager = rcChildMenu;
            propertyGridControl1.Name = "propertyGridControl1";
            propertyGridControl1.OptionsView.AllowReadOnlyRowAppearance = DevExpress.Utils.DefaultBoolean.True;
            propertyGridControl1.Size = new Size(427, 403);
            propertyGridControl1.TabIndex = 0;
            // 
            // UbFarmDiaryListForm
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1325, 639);
            Controls.Add(spcBody);
            Controls.Add(sidePanel4);
            Controls.Add(sidePanel3);
            Controls.Add(sidePanel2);
            Controls.Add(pnlTop);
            IconOptions.Image = (Image)resources.GetObject("UbFarmDiaryListForm.IconOptions.Image");
            Name = "UbFarmDiaryListForm";
            Text = "UbFarmDiaryListForm";
            Controls.SetChildIndex(rcChildMenu, 0);
            Controls.SetChildIndex(rsbChildStatusBar, 0);
            Controls.SetChildIndex(pnlTop, 0);
            Controls.SetChildIndex(sidePanel2, 0);
            Controls.SetChildIndex(sidePanel3, 0);
            Controls.SetChildIndex(sidePanel4, 0);
            Controls.SetChildIndex(spcBody, 0);
            ((System.ComponentModel.ISupportInitialize)rcChildMenu).EndInit();
            ((System.ComponentModel.ISupportInitialize)spcBody.Panel1).EndInit();
            spcBody.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)spcBody.Panel2).EndInit();
            spcBody.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)spcBody).EndInit();
            spcBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)xtraTabControl1).EndInit();
            xtraTabControl1.ResumeLayout(false);
            xtraTabPage1.ResumeLayout(false);
            xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)propertyGridControl1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonPage rpChildFarmDiaryList;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraEditors.SidePanel pnlTop;
        private DevExpress.XtraEditors.SidePanel sidePanel2;
        private DevExpress.XtraEditors.SidePanel sidePanel3;
        private DevExpress.XtraEditors.SidePanel sidePanel4;
        private DevExpress.XtraEditors.SplitContainerControl spcBody;
        private DevExpress.XtraEditors.SidePanel sidePanel6;
        private DevExpress.XtraEditors.SidePanel sidePanel5;
        private DevExpress.XtraEditors.SidePanel sidePanel8;
        private DevExpress.XtraEditors.SidePanel sidePanel7;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraPdfViewer.PdfViewer pdfViewer1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraVerticalGrid.PropertyGridControl propertyGridControl1;
    }
}