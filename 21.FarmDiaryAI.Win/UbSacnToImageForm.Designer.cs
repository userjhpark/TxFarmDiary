namespace TxFarmDiaryAI.Win
{
    partial class UbSacnToImageForm
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UbSacnToImageForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            scBody = new DevExpress.XtraEditors.SplitContainerControl();
            groupControl1 = new DevExpress.XtraEditors.GroupControl();
            pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            groupControl2 = new DevExpress.XtraEditors.GroupControl();
            grdcFileList = new DevExpress.XtraGrid.GridControl();
            grdvFileList = new DevExpress.XtraGrid.Views.Grid.GridView();
            gcImageGridNo = new DevExpress.XtraGrid.Columns.GridColumn();
            gcImageGridLoadDateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            gcImageGridSource = new DevExpress.XtraGrid.Columns.GridColumn();
            gcImageGridFileSize = new DevExpress.XtraGrid.Columns.GridColumn();
            gcImageGridFilePath = new DevExpress.XtraGrid.Columns.GridColumn();
            panelControl1 = new DevExpress.XtraEditors.PanelControl();
            panelControl2 = new DevExpress.XtraEditors.PanelControl();
            pdfViewer1 = new DevExpress.XtraPdfViewer.PdfViewer();
            barsiChildEventStatus = new DevExpress.XtraBars.BarStaticItem();
            rpChildImageToPDF = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            beicbxScanners = new DevExpress.XtraBars.BarEditItem();
            repcbxScanners = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            bbibtnScanToPicture = new DevExpress.XtraBars.BarButtonItem();
            bbibtnCameraToPicture = new DevExpress.XtraBars.BarButtonItem();
            bbibtnLoadToPicture = new DevExpress.XtraBars.BarButtonItem();
            ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            bbibtnEditFromPicture = new DevExpress.XtraBars.BarButtonItem();
            bbibtnClearFromPicture = new DevExpress.XtraBars.BarButtonItem();
            bbibtnCopyFromPicture = new DevExpress.XtraBars.BarButtonItem();
            bbibtnCutFromPicture = new DevExpress.XtraBars.BarButtonItem();
            bbibtnPasteFromPicture = new DevExpress.XtraBars.BarButtonItem();
            ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            bbibtnLoadToGrid = new DevExpress.XtraBars.BarButtonItem();
            bbibtnRemoveFromGrid = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            barToggleSwitchItem1 = new DevExpress.XtraBars.BarToggleSwitchItem();
            ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            bbibtnExportAsPictureToImage = new DevExpress.XtraBars.BarButtonItem();
            bbibtnExportPictureToPDF = new DevExpress.XtraBars.BarButtonItem();
            repositoryItemPictureEdit11 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            barsiChildImageListStatus = new DevExpress.XtraBars.BarStaticItem();
            ((System.ComponentModel.ISupportInitialize)rcChildMenu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)scBody).BeginInit();
            ((System.ComponentModel.ISupportInitialize)scBody.Panel1).BeginInit();
            scBody.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)scBody.Panel2).BeginInit();
            scBody.Panel2.SuspendLayout();
            scBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)groupControl1).BeginInit();
            groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureEdit1.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)groupControl2).BeginInit();
            groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdcFileList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grdvFileList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panelControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panelControl2).BeginInit();
            panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)repcbxScanners).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemButtonEdit1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemPictureEdit11).BeginInit();
            SuspendLayout();
            // 
            // rcChildMenu
            // 
            rcChildMenu.EmptyAreaImageOptions.ImagePadding = new Padding(30, 28, 30, 28);
            rcChildMenu.ExpandCollapseItem.Id = 0;
            rcChildMenu.Items.AddRange(new DevExpress.XtraBars.BarItem[] { barsiChildEventStatus, beicbxScanners, bbibtnScanToPicture, bbibtnCameraToPicture, bbibtnLoadToPicture, bbibtnEditFromPicture, bbibtnClearFromPicture, bbibtnCopyFromPicture, bbibtnPasteFromPicture, bbibtnExportAsPictureToImage, bbibtnExportPictureToPDF, bbibtnCutFromPicture, barsiChildImageListStatus, bbibtnLoadToGrid, bbibtnRemoveFromGrid, barButtonItem1, barButtonItem2, barToggleSwitchItem1, barEditItem1 });
            rcChildMenu.MaxItemId = 23;
            rcChildMenu.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { rpChildImageToPDF });
            rcChildMenu.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repcbxScanners, repositoryItemButtonEdit1 });
            rcChildMenu.Size = new Size(1572, 155);
            // 
            // rsbChildStatusBar
            // 
            rsbChildStatusBar.ItemLinks.Add(barsiChildEventStatus);
            rsbChildStatusBar.ItemLinks.Add(barsiChildImageListStatus);
            rsbChildStatusBar.Location = new Point(0, 602);
            rsbChildStatusBar.Size = new Size(1572, 22);
            // 
            // scBody
            // 
            scBody.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel2;
            scBody.Dock = DockStyle.Fill;
            scBody.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            scBody.Location = new Point(0, 165);
            scBody.Name = "scBody";
            // 
            // scBody.scBody_Panel1
            // 
            scBody.Panel1.Controls.Add(groupControl1);
            scBody.Panel1.Text = "Panel1";
            // 
            // scBody.scBody_Panel2
            // 
            scBody.Panel2.Controls.Add(groupControl2);
            scBody.Panel2.Text = "Panel2";
            scBody.Size = new Size(1572, 363);
            scBody.SplitterPosition = 525;
            scBody.TabIndex = 0;
            // 
            // groupControl1
            // 
            groupControl1.Controls.Add(pictureEdit1);
            groupControl1.Dock = DockStyle.Fill;
            groupControl1.Location = new Point(0, 0);
            groupControl1.Name = "groupControl1";
            groupControl1.Size = new Size(1037, 363);
            groupControl1.TabIndex = 1;
            groupControl1.Text = "Picture";
            // 
            // pictureEdit1
            // 
            pictureEdit1.Dock = DockStyle.Fill;
            pictureEdit1.Location = new Point(2, 23);
            pictureEdit1.MenuManager = rcChildMenu;
            pictureEdit1.Name = "pictureEdit1";
            pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            pictureEdit1.Size = new Size(1033, 338);
            pictureEdit1.TabIndex = 1;
            // 
            // groupControl2
            // 
            groupControl2.Controls.Add(grdcFileList);
            groupControl2.Dock = DockStyle.Fill;
            groupControl2.Location = new Point(0, 0);
            groupControl2.Name = "groupControl2";
            groupControl2.Size = new Size(525, 363);
            groupControl2.TabIndex = 0;
            groupControl2.Text = "Image Grid/List";
            // 
            // grdcFileList
            // 
            grdcFileList.Dock = DockStyle.Fill;
            grdcFileList.EmbeddedNavigator.Appearance.Options.UseTextOptions = true;
            grdcFileList.EmbeddedNavigator.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdcFileList.EmbeddedNavigator.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            grdcFileList.EmbeddedNavigator.Buttons.Append.Enabled = false;
            grdcFileList.EmbeddedNavigator.Buttons.Append.Visible = false;
            grdcFileList.Location = new Point(2, 23);
            grdcFileList.MainView = grdvFileList;
            grdcFileList.MenuManager = rcChildMenu;
            grdcFileList.Name = "grdcFileList";
            grdcFileList.Size = new Size(521, 338);
            grdcFileList.TabIndex = 1;
            grdcFileList.UseEmbeddedNavigator = true;
            grdcFileList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { grdvFileList });
            // 
            // grdvFileList
            // 
            grdvFileList.Appearance.HeaderPanel.Options.UseTextOptions = true;
            grdvFileList.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdvFileList.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            grdvFileList.Appearance.Row.Options.UseTextOptions = true;
            grdvFileList.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            grdvFileList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { gcImageGridNo, gcImageGridLoadDateTime, gcImageGridSource, gcImageGridFileSize, gcImageGridFilePath });
            grdvFileList.GridControl = grdcFileList;
            grdvFileList.Name = "grdvFileList";
            grdvFileList.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            grdvFileList.OptionsSelection.MultiSelect = true;
            grdvFileList.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            // 
            // gcImageGridNo
            // 
            gcImageGridNo.AppearanceCell.Options.UseTextOptions = true;
            gcImageGridNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcImageGridNo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            gcImageGridNo.Caption = "No";
            gcImageGridNo.FieldName = "cno";
            gcImageGridNo.MaxWidth = 30;
            gcImageGridNo.Name = "gcImageGridNo";
            gcImageGridNo.Visible = true;
            gcImageGridNo.VisibleIndex = 1;
            gcImageGridNo.Width = 30;
            // 
            // gcImageGridLoadDateTime
            // 
            gcImageGridLoadDateTime.Caption = "Date Time";
            gcImageGridLoadDateTime.FieldName = "reg_date";
            gcImageGridLoadDateTime.Name = "gcImageGridLoadDateTime";
            gcImageGridLoadDateTime.Visible = true;
            gcImageGridLoadDateTime.VisibleIndex = 2;
            gcImageGridLoadDateTime.Width = 144;
            // 
            // gcImageGridSource
            // 
            gcImageGridSource.Caption = "Source";
            gcImageGridSource.Name = "gcImageGridSource";
            gcImageGridSource.Visible = true;
            gcImageGridSource.VisibleIndex = 3;
            gcImageGridSource.Width = 144;
            // 
            // gcImageGridFileSize
            // 
            gcImageGridFileSize.AppearanceCell.Options.UseTextOptions = true;
            gcImageGridFileSize.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            gcImageGridFileSize.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            gcImageGridFileSize.Caption = "Image Size";
            gcImageGridFileSize.Name = "gcImageGridFileSize";
            gcImageGridFileSize.Visible = true;
            gcImageGridFileSize.VisibleIndex = 4;
            gcImageGridFileSize.Width = 150;
            // 
            // gcImageGridFilePath
            // 
            gcImageGridFilePath.Caption = "Image Path";
            gcImageGridFilePath.Name = "gcImageGridFilePath";
            // 
            // panelControl1
            // 
            panelControl1.Dock = DockStyle.Top;
            panelControl1.Location = new Point(0, 155);
            panelControl1.Name = "panelControl1";
            panelControl1.Size = new Size(1572, 10);
            panelControl1.TabIndex = 1;
            // 
            // panelControl2
            // 
            panelControl2.Controls.Add(pdfViewer1);
            panelControl2.Dock = DockStyle.Bottom;
            panelControl2.Location = new Point(0, 528);
            panelControl2.Name = "panelControl2";
            panelControl2.Size = new Size(1572, 74);
            panelControl2.TabIndex = 4;
            // 
            // pdfViewer1
            // 
            pdfViewer1.Dock = DockStyle.Fill;
            pdfViewer1.Location = new Point(2, 2);
            pdfViewer1.MenuManager = rcChildMenu;
            pdfViewer1.Name = "pdfViewer1";
            pdfViewer1.Size = new Size(1568, 70);
            pdfViewer1.TabIndex = 0;
            // 
            // barsiChildEventStatus
            // 
            barsiChildEventStatus.Caption = "        ";
            barsiChildEventStatus.Id = 2;
            barsiChildEventStatus.Name = "barsiChildEventStatus";
            // 
            // rpChildImageToPDF
            // 
            rpChildImageToPDF.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1, ribbonPageGroup3, ribbonPageGroup4, ribbonPageGroup2 });
            rpChildImageToPDF.Name = "rpChildImageToPDF";
            rpChildImageToPDF.Text = "Scan To Image";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(beicbxScanners);
            ribbonPageGroup1.ItemLinks.Add(bbibtnScanToPicture);
            ribbonPageGroup1.ItemLinks.Add(bbibtnCameraToPicture, true);
            ribbonPageGroup1.ItemLinks.Add(bbibtnLoadToPicture);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "[Source] Scan / Camera / Picture";
            // 
            // beicbxScanners
            // 
            beicbxScanners.Caption = "Sacnner : ";
            beicbxScanners.Edit = repcbxScanners;
            beicbxScanners.EditWidth = 250;
            beicbxScanners.Id = 3;
            beicbxScanners.Name = "beicbxScanners";
            // 
            // repcbxScanners
            // 
            repcbxScanners.AutoHeight = false;
            editorButtonImageOptions2.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("editorButtonImageOptions2.SvgImage");
            editorButtonImageOptions2.SvgImageSize = new Size(12, 12);
            repcbxScanners.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Refresh", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", "{{#REFRESH}}", null, DevExpress.Utils.ToolTipAnchor.Default) });
            repcbxScanners.Name = "repcbxScanners";
            // 
            // bbibtnScanToPicture
            // 
            bbibtnScanToPicture.Caption = "Scan";
            bbibtnScanToPicture.Id = 4;
            bbibtnScanToPicture.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbibtnScanToPicture.ImageOptions.SvgImage");
            bbibtnScanToPicture.LargeWidth = 50;
            bbibtnScanToPicture.Name = "bbibtnScanToPicture";
            // 
            // bbibtnCameraToPicture
            // 
            bbibtnCameraToPicture.Caption = "Camera";
            bbibtnCameraToPicture.Hint = "Task Picture from Camera";
            bbibtnCameraToPicture.Id = 6;
            bbibtnCameraToPicture.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbibtnCameraToPicture.ImageOptions.SvgImage");
            bbibtnCameraToPicture.LargeWidth = 50;
            bbibtnCameraToPicture.Name = "bbibtnCameraToPicture";
            // 
            // bbibtnLoadToPicture
            // 
            bbibtnLoadToPicture.Caption = "Picture Load";
            bbibtnLoadToPicture.Id = 7;
            bbibtnLoadToPicture.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbibtnLoadToPicture.ImageOptions.SvgImage");
            bbibtnLoadToPicture.LargeWidth = 50;
            bbibtnLoadToPicture.Name = "bbibtnLoadToPicture";
            // 
            // ribbonPageGroup3
            // 
            ribbonPageGroup3.ItemLinks.Add(bbibtnEditFromPicture, true);
            ribbonPageGroup3.ItemLinks.Add(bbibtnClearFromPicture);
            ribbonPageGroup3.ItemLinks.Add(bbibtnCopyFromPicture);
            ribbonPageGroup3.ItemLinks.Add(bbibtnCutFromPicture);
            ribbonPageGroup3.ItemLinks.Add(bbibtnPasteFromPicture);
            ribbonPageGroup3.Name = "ribbonPageGroup3";
            ribbonPageGroup3.Text = "Picture Function";
            // 
            // bbibtnEditFromPicture
            // 
            bbibtnEditFromPicture.Caption = "Edit";
            bbibtnEditFromPicture.Id = 8;
            bbibtnEditFromPicture.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbibtnEditFromPicture.ImageOptions.SvgImage");
            bbibtnEditFromPicture.LargeWidth = 50;
            bbibtnEditFromPicture.Name = "bbibtnEditFromPicture";
            // 
            // bbibtnClearFromPicture
            // 
            bbibtnClearFromPicture.Caption = "Clear";
            bbibtnClearFromPicture.Id = 9;
            bbibtnClearFromPicture.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbibtnClearFromPicture.ImageOptions.SvgImage");
            bbibtnClearFromPicture.LargeWidth = 50;
            bbibtnClearFromPicture.Name = "bbibtnClearFromPicture";
            // 
            // bbibtnCopyFromPicture
            // 
            bbibtnCopyFromPicture.Caption = "Copy";
            bbibtnCopyFromPicture.Id = 10;
            bbibtnCopyFromPicture.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbibtnCopyFromPicture.ImageOptions.SvgImage");
            bbibtnCopyFromPicture.LargeWidth = 50;
            bbibtnCopyFromPicture.Name = "bbibtnCopyFromPicture";
            // 
            // bbibtnCutFromPicture
            // 
            bbibtnCutFromPicture.Caption = "Cut";
            bbibtnCutFromPicture.Id = 14;
            bbibtnCutFromPicture.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbibtnCutFromPicture.ImageOptions.SvgImage");
            bbibtnCutFromPicture.LargeWidth = 50;
            bbibtnCutFromPicture.Name = "bbibtnCutFromPicture";
            // 
            // bbibtnPasteFromPicture
            // 
            bbibtnPasteFromPicture.Caption = "Paste";
            bbibtnPasteFromPicture.Id = 11;
            bbibtnPasteFromPicture.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbibtnPasteFromPicture.ImageOptions.SvgImage");
            bbibtnPasteFromPicture.LargeWidth = 50;
            bbibtnPasteFromPicture.Name = "bbibtnPasteFromPicture";
            // 
            // ribbonPageGroup4
            // 
            ribbonPageGroup4.Alignment = DevExpress.XtraBars.Ribbon.RibbonPageGroupAlignment.Far;
            ribbonPageGroup4.ItemLinks.Add(bbibtnLoadToGrid);
            ribbonPageGroup4.ItemLinks.Add(bbibtnRemoveFromGrid);
            ribbonPageGroup4.ItemLinks.Add(barButtonItem1, true);
            ribbonPageGroup4.ItemLinks.Add(barButtonItem2, true);
            ribbonPageGroup4.ItemLinks.Add(barEditItem1);
            ribbonPageGroup4.ItemLinks.Add(barToggleSwitchItem1);
            ribbonPageGroup4.Name = "ribbonPageGroup4";
            ribbonPageGroup4.Text = "Image Grid/List";
            // 
            // bbibtnLoadToGrid
            // 
            bbibtnLoadToGrid.Caption = "Load";
            bbibtnLoadToGrid.Id = 16;
            bbibtnLoadToGrid.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbibtnLoadToGrid.ImageOptions.SvgImage");
            bbibtnLoadToGrid.LargeWidth = 55;
            bbibtnLoadToGrid.Name = "bbibtnLoadToGrid";
            // 
            // bbibtnRemoveFromGrid
            // 
            bbibtnRemoveFromGrid.Caption = "Remove";
            bbibtnRemoveFromGrid.Id = 17;
            bbibtnRemoveFromGrid.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbibtnRemoveFromGrid.ImageOptions.SvgImage");
            bbibtnRemoveFromGrid.LargeWidth = 55;
            bbibtnRemoveFromGrid.Name = "bbibtnRemoveFromGrid";
            // 
            // barButtonItem1
            // 
            barButtonItem1.Caption = "Save To Folder";
            barButtonItem1.Id = 18;
            barButtonItem1.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItem1.ImageOptions.SvgImage");
            barButtonItem1.LargeWidth = 55;
            barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            barButtonItem2.Caption = "Save To PDF";
            barButtonItem2.Id = 19;
            barButtonItem2.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItem2.ImageOptions.SvgImage");
            barButtonItem2.LargeWidth = 55;
            barButtonItem2.Name = "barButtonItem2";
            // 
            // barEditItem1
            // 
            barEditItem1.Caption = "Save Folder :";
            barEditItem1.Edit = repositoryItemButtonEdit1;
            barEditItem1.EditWidth = 122;
            barEditItem1.Id = 22;
            barEditItem1.Name = "barEditItem1";
            // 
            // repositoryItemButtonEdit1
            // 
            repositoryItemButtonEdit1.AutoHeight = false;
            repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // barToggleSwitchItem1
            // 
            barToggleSwitchItem1.Caption = "Merge into One PDF File";
            barToggleSwitchItem1.Id = 21;
            barToggleSwitchItem1.Name = "barToggleSwitchItem1";
            // 
            // ribbonPageGroup2
            // 
            ribbonPageGroup2.ItemLinks.Add(bbibtnExportAsPictureToImage);
            ribbonPageGroup2.ItemLinks.Add(bbibtnExportPictureToPDF);
            ribbonPageGroup2.Name = "ribbonPageGroup2";
            ribbonPageGroup2.Text = "Picture To File";
            // 
            // bbibtnExportAsPictureToImage
            // 
            bbibtnExportAsPictureToImage.Caption = "Export\r\n(To Image)";
            bbibtnExportAsPictureToImage.Id = 12;
            bbibtnExportAsPictureToImage.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbibtnExportAsPictureToImage.ImageOptions.SvgImage");
            bbibtnExportAsPictureToImage.LargeWidth = 65;
            bbibtnExportAsPictureToImage.Name = "bbibtnExportAsPictureToImage";
            // 
            // bbibtnExportPictureToPDF
            // 
            bbibtnExportPictureToPDF.Caption = "Export \n(To PDF)";
            bbibtnExportPictureToPDF.Id = 13;
            bbibtnExportPictureToPDF.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbibtnExportPictureToPDF.ImageOptions.SvgImage");
            bbibtnExportPictureToPDF.LargeWidth = 65;
            bbibtnExportPictureToPDF.Name = "bbibtnExportPictureToPDF";
            bbibtnExportPictureToPDF.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // repositoryItemPictureEdit11
            // 
            repositoryItemPictureEdit11.Name = "repositoryItemPictureEdit11";
            repositoryItemPictureEdit11.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            repositoryItemPictureEdit11.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            // 
            // barsiChildImageListStatus
            // 
            barsiChildImageListStatus.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            barsiChildImageListStatus.Caption = "                ";
            barsiChildImageListStatus.Id = 15;
            barsiChildImageListStatus.Name = "barsiChildImageListStatus";
            barsiChildImageListStatus.TextAlignment = StringAlignment.Far;
            // 
            // UbSacnToImageForm
            // 
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1572, 624);
            Controls.Add(scBody);
            Controls.Add(panelControl2);
            Controls.Add(panelControl1);
            IconOptions.Image = (Image)resources.GetObject("UbSacnToImageForm.IconOptions.Image");
            Name = "UbSacnToImageForm";
            Text = "Scanner/Camera To Image";
            Controls.SetChildIndex(rcChildMenu, 0);
            Controls.SetChildIndex(rsbChildStatusBar, 0);
            Controls.SetChildIndex(panelControl1, 0);
            Controls.SetChildIndex(panelControl2, 0);
            Controls.SetChildIndex(scBody, 0);
            ((System.ComponentModel.ISupportInitialize)rcChildMenu).EndInit();
            ((System.ComponentModel.ISupportInitialize)scBody.Panel1).EndInit();
            scBody.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)scBody.Panel2).EndInit();
            scBody.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)scBody).EndInit();
            scBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)groupControl1).EndInit();
            groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureEdit1.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)groupControl2).EndInit();
            groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grdcFileList).EndInit();
            ((System.ComponentModel.ISupportInitialize)grdvFileList).EndInit();
            ((System.ComponentModel.ISupportInitialize)panelControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)panelControl2).EndInit();
            panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)repcbxScanners).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemButtonEdit1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemPictureEdit11).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl scBody;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        protected internal DevExpress.XtraBars.BarStaticItem barsiChildEventStatus;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpChildImageToPDF;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarEditItem beicbxScanners;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repcbxScanners;
        private DevExpress.XtraBars.BarButtonItem bbibtnScanToPicture;
        private DevExpress.XtraBars.BarButtonItem bbibtnCameraToPicture;
        private DevExpress.XtraBars.BarButtonItem bbibtnLoadToPicture;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem bbibtnEditFromPicture;
        private DevExpress.XtraBars.BarButtonItem bbibtnClearFromPicture;
        private DevExpress.XtraBars.BarButtonItem bbibtnCopyFromPicture;
        private DevExpress.XtraBars.BarButtonItem bbibtnPasteFromPicture;
        private DevExpress.XtraBars.BarButtonItem bbibtnExportAsPictureToImage;
        private DevExpress.XtraBars.BarButtonItem bbibtnExportPictureToPDF;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit11;
        private DevExpress.XtraBars.BarButtonItem bbibtnCutFromPicture;
        private DevExpress.XtraPdfViewer.PdfViewer pdfViewer1;
        private DevExpress.XtraBars.BarStaticItem barsiChildImageListStatus;
        private DevExpress.XtraBars.BarButtonItem bbibtnLoadToGrid;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem bbibtnRemoveFromGrid;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarToggleSwitchItem barToggleSwitchItem1;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl grdcFileList;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvFileList;
        private DevExpress.XtraGrid.Columns.GridColumn gcImageGridNo;
        private DevExpress.XtraGrid.Columns.GridColumn gcImageGridLoadDateTime;
        private DevExpress.XtraGrid.Columns.GridColumn gcImageGridSource;
        private DevExpress.XtraGrid.Columns.GridColumn gcImageGridFileSize;
        private DevExpress.XtraGrid.Columns.GridColumn gcImageGridFilePath;
    }
}