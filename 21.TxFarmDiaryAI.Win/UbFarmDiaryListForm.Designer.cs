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
            barbtnChildRefresh = new DevExpress.XtraBars.BarButtonItem();
            pnlTop = new DevExpress.XtraEditors.SidePanel();
            sidePanel2 = new DevExpress.XtraEditors.SidePanel();
            sidePanel3 = new DevExpress.XtraEditors.SidePanel();
            sidePanel4 = new DevExpress.XtraEditors.SidePanel();
            spcBody = new DevExpress.XtraEditors.SplitContainerControl();
            grdcFarmDiaryList = new DevExpress.XtraGrid.GridControl();
            grdvFarmDiaryList = new DevExpress.XtraGrid.Views.Grid.GridView();
            sidePanel6 = new DevExpress.XtraEditors.SidePanel();
            sidePanel5 = new DevExpress.XtraEditors.SidePanel();
            tabpageDetailCtl = new DevExpress.XtraTab.XtraTabControl();
            tabpProperty = new DevExpress.XtraTab.XtraTabPage();
            grdcProperties = new DevExpress.XtraGrid.GridControl();
            grdvProperties = new DevExpress.XtraGrid.Views.Grid.GridView();
            tabpPDFViewer = new DevExpress.XtraTab.XtraTabPage();
            pdfViewer = new DevExpress.XtraPdfViewer.PdfViewer();
            tabpImageViewer = new DevExpress.XtraTab.XtraTabPage();
            picViewer = new DevExpress.XtraEditors.PictureEdit();
            sidePanel8 = new DevExpress.XtraEditors.SidePanel();
            sidePanel7 = new DevExpress.XtraEditors.SidePanel();
            ((System.ComponentModel.ISupportInitialize)rcChildMenu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)spcBody).BeginInit();
            ((System.ComponentModel.ISupportInitialize)spcBody.Panel1).BeginInit();
            spcBody.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)spcBody.Panel2).BeginInit();
            spcBody.Panel2.SuspendLayout();
            spcBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdcFarmDiaryList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grdvFarmDiaryList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tabpageDetailCtl).BeginInit();
            tabpageDetailCtl.SuspendLayout();
            tabpProperty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdcProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grdvProperties).BeginInit();
            tabpPDFViewer.SuspendLayout();
            tabpImageViewer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picViewer.Properties).BeginInit();
            SuspendLayout();
            // 
            // rcChildMenu
            // 
            rcChildMenu.EmptyAreaImageOptions.ImagePadding = new Padding(30, 28, 30, 28);
            rcChildMenu.ExpandCollapseItem.Id = 0;
            rcChildMenu.Items.AddRange(new DevExpress.XtraBars.BarItem[] { barbtnChildRefresh });
            rcChildMenu.MaxItemId = 2;
            rcChildMenu.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { rpChildFarmDiaryList });
            rcChildMenu.Size = new Size(1240, 150);
            // 
            // rsbChildStatusBar
            // 
            rsbChildStatusBar.Location = new Point(0, 617);
            rsbChildStatusBar.Size = new Size(1240, 22);
            // 
            // rpChildFarmDiaryList
            // 
            rpChildFarmDiaryList.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1 });
            rpChildFarmDiaryList.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("rpChildFarmDiaryList.ImageOptions.SvgImage");
            rpChildFarmDiaryList.Name = "rpChildFarmDiaryList";
            rpChildFarmDiaryList.Text = "Farm Diary";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(barbtnChildRefresh);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "List";
            // 
            // barbtnChildRefresh
            // 
            barbtnChildRefresh.Caption = "Refresh";
            barbtnChildRefresh.Id = 1;
            barbtnChildRefresh.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barbtnChildRefresh.ImageOptions.SvgImage");
            barbtnChildRefresh.Name = "barbtnChildRefresh";
            // 
            // pnlTop
            // 
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 150);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1240, 10);
            pnlTop.TabIndex = 2;
            pnlTop.Text = "sidePanel1";
            // 
            // sidePanel2
            // 
            sidePanel2.Dock = DockStyle.Bottom;
            sidePanel2.Location = new Point(0, 607);
            sidePanel2.Name = "sidePanel2";
            sidePanel2.Size = new Size(1240, 10);
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
            sidePanel4.Location = new Point(1230, 160);
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
            spcBody.Panel1.Controls.Add(grdcFarmDiaryList);
            spcBody.Panel1.Controls.Add(sidePanel6);
            spcBody.Panel1.Controls.Add(sidePanel5);
            spcBody.Panel1.Text = "Panel1";
            // 
            // spcBody.Panel2
            // 
            spcBody.Panel2.Controls.Add(tabpageDetailCtl);
            spcBody.Panel2.Controls.Add(sidePanel8);
            spcBody.Panel2.Controls.Add(sidePanel7);
            spcBody.Panel2.Text = "Panel2";
            spcBody.Size = new Size(1220, 447);
            spcBody.SplitterPosition = 594;
            spcBody.TabIndex = 6;
            // 
            // grdcFarmDiaryList
            // 
            grdcFarmDiaryList.Dock = DockStyle.Fill;
            grdcFarmDiaryList.Location = new Point(0, 10);
            grdcFarmDiaryList.MainView = grdvFarmDiaryList;
            grdcFarmDiaryList.MenuManager = rcChildMenu;
            grdcFarmDiaryList.Name = "grdcFarmDiaryList";
            grdcFarmDiaryList.Size = new Size(616, 427);
            grdcFarmDiaryList.TabIndex = 2;
            grdcFarmDiaryList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { grdvFarmDiaryList });
            // 
            // grdvFarmDiaryList
            // 
            grdvFarmDiaryList.GridControl = grdcFarmDiaryList;
            grdvFarmDiaryList.Name = "grdvFarmDiaryList";
            grdvFarmDiaryList.OptionsSelection.MultiSelect = true;
            grdvFarmDiaryList.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            // 
            // sidePanel6
            // 
            sidePanel6.Dock = DockStyle.Bottom;
            sidePanel6.Location = new Point(0, 437);
            sidePanel6.Name = "sidePanel6";
            sidePanel6.Size = new Size(616, 10);
            sidePanel6.TabIndex = 1;
            sidePanel6.Text = "sidePanel6";
            sidePanel6.Visible = false;
            // 
            // sidePanel5
            // 
            sidePanel5.Dock = DockStyle.Top;
            sidePanel5.Location = new Point(0, 0);
            sidePanel5.Name = "sidePanel5";
            sidePanel5.Size = new Size(616, 10);
            sidePanel5.TabIndex = 0;
            sidePanel5.Text = "sidePanel5";
            sidePanel5.Visible = false;
            // 
            // tabpageDetailCtl
            // 
            tabpageDetailCtl.Dock = DockStyle.Fill;
            tabpageDetailCtl.Location = new Point(0, 10);
            tabpageDetailCtl.Name = "tabpageDetailCtl";
            tabpageDetailCtl.SelectedTabPage = tabpProperty;
            tabpageDetailCtl.Size = new Size(594, 427);
            tabpageDetailCtl.TabIndex = 3;
            tabpageDetailCtl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] { tabpProperty, tabpPDFViewer, tabpImageViewer });
            // 
            // tabpProperty
            // 
            tabpProperty.Controls.Add(grdcProperties);
            tabpProperty.Name = "tabpProperty";
            tabpProperty.Size = new Size(592, 403);
            tabpProperty.Text = "Property";
            // 
            // grdcProperties
            // 
            grdcProperties.Dock = DockStyle.Fill;
            grdcProperties.Location = new Point(0, 0);
            grdcProperties.MainView = grdvProperties;
            grdcProperties.MenuManager = rcChildMenu;
            grdcProperties.Name = "grdcProperties";
            grdcProperties.Size = new Size(592, 403);
            grdcProperties.TabIndex = 0;
            grdcProperties.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { grdvProperties });
            // 
            // grdvProperties
            // 
            grdvProperties.GridControl = grdcProperties;
            grdvProperties.Name = "grdvProperties";
            grdvProperties.OptionsView.ShowGroupPanel = false;
            // 
            // tabpPDFViewer
            // 
            tabpPDFViewer.Controls.Add(pdfViewer);
            tabpPDFViewer.Name = "tabpPDFViewer";
            tabpPDFViewer.Size = new Size(592, 401);
            tabpPDFViewer.Text = "Preview";
            // 
            // pdfViewer
            // 
            pdfViewer.Dock = DockStyle.Fill;
            pdfViewer.Location = new Point(0, 0);
            pdfViewer.MenuManager = rcChildMenu;
            pdfViewer.Name = "pdfViewer";
            pdfViewer.Size = new Size(592, 401);
            pdfViewer.TabIndex = 0;
            // 
            // tabpImageViewer
            // 
            tabpImageViewer.Controls.Add(picViewer);
            tabpImageViewer.Name = "tabpImageViewer";
            tabpImageViewer.Size = new Size(592, 401);
            tabpImageViewer.Text = "Image";
            // 
            // picViewer
            // 
            picViewer.Dock = DockStyle.Fill;
            picViewer.Location = new Point(0, 0);
            picViewer.MenuManager = rcChildMenu;
            picViewer.Name = "picViewer";
            picViewer.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            picViewer.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            picViewer.Size = new Size(592, 401);
            picViewer.TabIndex = 0;
            // 
            // sidePanel8
            // 
            sidePanel8.Dock = DockStyle.Bottom;
            sidePanel8.Location = new Point(0, 437);
            sidePanel8.Name = "sidePanel8";
            sidePanel8.Size = new Size(594, 10);
            sidePanel8.TabIndex = 2;
            sidePanel8.Text = "sidePanel8";
            sidePanel8.Visible = false;
            // 
            // sidePanel7
            // 
            sidePanel7.Dock = DockStyle.Top;
            sidePanel7.Location = new Point(0, 0);
            sidePanel7.Name = "sidePanel7";
            sidePanel7.Size = new Size(594, 10);
            sidePanel7.TabIndex = 1;
            sidePanel7.Text = "sidePanel7";
            sidePanel7.Visible = false;
            // 
            // UbFarmDiaryListForm
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1240, 639);
            Controls.Add(spcBody);
            Controls.Add(sidePanel4);
            Controls.Add(sidePanel3);
            Controls.Add(sidePanel2);
            Controls.Add(pnlTop);
            IconOptions.Image = (Image)resources.GetObject("UbFarmDiaryListForm.IconOptions.Image");
            Name = "UbFarmDiaryListForm";
            Text = "Search / List";
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
            ((System.ComponentModel.ISupportInitialize)grdcFarmDiaryList).EndInit();
            ((System.ComponentModel.ISupportInitialize)grdvFarmDiaryList).EndInit();
            ((System.ComponentModel.ISupportInitialize)tabpageDetailCtl).EndInit();
            tabpageDetailCtl.ResumeLayout(false);
            tabpProperty.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grdcProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)grdvProperties).EndInit();
            tabpPDFViewer.ResumeLayout(false);
            tabpImageViewer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picViewer.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonPage rpChildFarmDiaryList;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem barbtnChildRefresh;
        private DevExpress.XtraEditors.SidePanel pnlTop;
        private DevExpress.XtraEditors.SidePanel sidePanel2;
        private DevExpress.XtraEditors.SidePanel sidePanel3;
        private DevExpress.XtraEditors.SidePanel sidePanel4;
        private DevExpress.XtraEditors.SplitContainerControl spcBody;
        private DevExpress.XtraEditors.SidePanel sidePanel6;
        private DevExpress.XtraEditors.SidePanel sidePanel5;
        private DevExpress.XtraEditors.SidePanel sidePanel8;
        private DevExpress.XtraEditors.SidePanel sidePanel7;
        private DevExpress.XtraGrid.GridControl grdcFarmDiaryList;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvFarmDiaryList;
        private DevExpress.XtraTab.XtraTabControl tabpageDetailCtl;
        private DevExpress.XtraTab.XtraTabPage tabpPDFViewer;
        private DevExpress.XtraPdfViewer.PdfViewer pdfViewer;
        private DevExpress.XtraTab.XtraTabPage tabpProperty;
        private DevExpress.XtraTab.XtraTabPage tabpImageViewer;
        private DevExpress.XtraGrid.GridControl grdcProperties;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvProperties;
        private DevExpress.XtraEditors.PictureEdit picViewer;
    }
}