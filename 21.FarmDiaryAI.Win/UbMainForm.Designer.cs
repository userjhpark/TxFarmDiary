namespace TxFarmDiaryAI.Win
{
    partial class UbMainForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UbMainForm));
            DevExpress.Utils.Animation.PushTransition pushTransition1 = new DevExpress.Utils.Animation.PushTransition();
            DevExpress.XtraBars.Ribbon.ReduceOperation reduceOperation1 = new DevExpress.XtraBars.Ribbon.ReduceOperation();
            DevExpress.XtraBars.Ribbon.ReduceOperation reduceOperation2 = new DevExpress.XtraBars.Ribbon.ReduceOperation();
            rcMainMenu = new DevExpress.XtraBars.Ribbon.RibbonControl();
            applicationMenu1 = new DevExpress.XtraBars.Ribbon.ApplicationMenu(components);
            barbtnFarmManagement = new DevExpress.XtraBars.BarButtonItem();
            barbtnScanner = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            barbtnSettings = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem9 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem10 = new DevExpress.XtraBars.BarButtonItem();
            baredtWorkspaceSelect = new DevExpress.XtraBars.BarEditItem();
            repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            baredtWorkspaceFolder = new DevExpress.XtraBars.BarEditItem();
            repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            baredtWorkspaceFillter = new DevExpress.XtraBars.BarEditItem();
            repositoryItemRadioGroup1 = new DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup();
            barchkWorkspaceCurrentOnly = new DevExpress.XtraBars.BarCheckItem();
            barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            barStaticItem2 = new DevExpress.XtraBars.BarStaticItem();
            barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
            skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            skinPaletteRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinPaletteRibbonGalleryBarItem();
            barWorkspaceMenuItem1 = new DevExpress.XtraBars.BarWorkspaceMenuItem();
            workspaceManager1 = new DevExpress.Utils.WorkspaceManager(components);
            barMdiChildrenListItem1 = new DevExpress.XtraBars.BarMdiChildrenListItem();
            rpMainHome = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            rpMainApplication = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            rpMainView = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            popupMenu1 = new DevExpress.XtraBars.PopupMenu(components);
            mdimngMain = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(components);
            ((System.ComponentModel.ISupportInitialize)rcMainMenu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)applicationMenu1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemLookUpEdit1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemButtonEdit1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemRadioGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)popupMenu1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mdimngMain).BeginInit();
            SuspendLayout();
            // 
            // rcMainMenu
            // 
            rcMainMenu.ApplicationButtonDropDownControl = applicationMenu1;
            rcMainMenu.CaptionBarItemLinks.Add(barbtnSettings);
            rcMainMenu.ExpandCollapseItem.Id = 0;
            rcMainMenu.Items.AddRange(new DevExpress.XtraBars.BarItem[] { barbtnSettings, rcMainMenu.ExpandCollapseItem, baredtWorkspaceSelect, baredtWorkspaceFolder, baredtWorkspaceFillter, barchkWorkspaceCurrentOnly, barbtnFarmManagement, barStaticItem1, barStaticItem2, barbtnScanner, barButtonItem3, barButtonItem4, barButtonItem5, barButtonItem6, barButtonItem7, barButtonItem8, barButtonItem9, barButtonItem10, skinRibbonGalleryBarItem1, skinPaletteRibbonGalleryBarItem1, barWorkspaceMenuItem1, barMdiChildrenListItem1 });
            rcMainMenu.Location = new Point(0, 0);
            rcMainMenu.MaxItemId = 28;
            rcMainMenu.Name = "rcMainMenu";
            rcMainMenu.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { rpMainHome, rpMainApplication, rpMainView });
            rcMainMenu.QuickToolbarItemLinks.Add(barbtnScanner);
            rcMainMenu.QuickToolbarItemLinks.Add(barButtonItem3);
            rcMainMenu.QuickToolbarItemLinks.Add(barButtonItem5);
            rcMainMenu.QuickToolbarItemLinks.Add(baredtWorkspaceSelect);
            rcMainMenu.QuickToolbarItemLinks.Add(barchkWorkspaceCurrentOnly);
            rcMainMenu.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemLookUpEdit1, repositoryItemButtonEdit1, repositoryItemRadioGroup1 });
            rcMainMenu.Size = new Size(1341, 167);
            rcMainMenu.StatusBar = ribbonStatusBar;
            rcMainMenu.Click += rcMainMenu_Click;
            // 
            // applicationMenu1
            // 
            applicationMenu1.ItemLinks.Add(barbtnFarmManagement);
            applicationMenu1.ItemLinks.Add(barbtnScanner);
            applicationMenu1.ItemLinks.Add(barButtonItem5);
            applicationMenu1.ItemLinks.Add(barButtonItem3);
            applicationMenu1.ItemLinks.Add(barButtonItem4);
            applicationMenu1.ItemLinks.Add(barButtonItem6);
            applicationMenu1.ItemLinks.Add(barbtnSettings);
            applicationMenu1.ItemLinks.Add(barButtonItem9);
            applicationMenu1.ItemLinks.Add(barButtonItem7);
            applicationMenu1.ItemLinks.Add(barButtonItem10);
            applicationMenu1.Name = "applicationMenu1";
            applicationMenu1.Ribbon = rcMainMenu;
            // 
            // barbtnFarmManagement
            // 
            barbtnFarmManagement.Caption = "Farm\r\nManagement";
            barbtnFarmManagement.Id = 7;
            barbtnFarmManagement.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barbtnFarmManagement.ImageOptions.SvgImage");
            barbtnFarmManagement.Name = "barbtnFarmManagement";
            // 
            // barbtnScanner
            // 
            barbtnScanner.Caption = "Scan To Image";
            barbtnScanner.Id = 10;
            barbtnScanner.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barbtnScanner.ImageOptions.SvgImage");
            barbtnScanner.Name = "barbtnScanner";
            barbtnScanner.ItemClick += barbtnScanner_ItemClick;
            // 
            // barButtonItem5
            // 
            barButtonItem5.Caption = "Search\r\n(View)";
            barButtonItem5.Id = 13;
            barButtonItem5.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItem5.ImageOptions.SvgImage");
            barButtonItem5.Name = "barButtonItem5";
            // 
            // barButtonItem3
            // 
            barButtonItem3.Caption = "Registration\r\n(Append)";
            barButtonItem3.Id = 11;
            barButtonItem3.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItem3.ImageOptions.SvgImage");
            barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem4
            // 
            barButtonItem4.Caption = "Report";
            barButtonItem4.Id = 12;
            barButtonItem4.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItem4.ImageOptions.SvgImage");
            barButtonItem4.Name = "barButtonItem4";
            // 
            // barButtonItem6
            // 
            barButtonItem6.Caption = "Export";
            barButtonItem6.Id = 14;
            barButtonItem6.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItem6.ImageOptions.SvgImage");
            barButtonItem6.Name = "barButtonItem6";
            // 
            // barbtnSettings
            // 
            barbtnSettings.Caption = "Settings";
            barbtnSettings.Id = 2;
            barbtnSettings.ImageOptions.SvgImage = Properties.Resources.SettingsSolid;
            barbtnSettings.Name = "barbtnSettings";
            // 
            // barButtonItem9
            // 
            barButtonItem9.Caption = "Manual";
            barButtonItem9.Id = 17;
            barButtonItem9.ImageOptions.SvgImage = Properties.Resources.PhoneBook;
            barButtonItem9.Name = "barButtonItem9";
            // 
            // barButtonItem7
            // 
            barButtonItem7.Caption = "About";
            barButtonItem7.Id = 15;
            barButtonItem7.ImageOptions.SvgImage = Properties.Resources.InfoSolid;
            barButtonItem7.Name = "barButtonItem7";
            // 
            // barButtonItem10
            // 
            barButtonItem10.Caption = "Log-out";
            barButtonItem10.Id = 18;
            barButtonItem10.ImageOptions.SvgImage = Properties.Resources.SignOut;
            barButtonItem10.Name = "barButtonItem10";
            // 
            // baredtWorkspaceSelect
            // 
            baredtWorkspaceSelect.Caption = "Selecte Farm : ";
            baredtWorkspaceSelect.Edit = repositoryItemLookUpEdit1;
            baredtWorkspaceSelect.EditWidth = 248;
            baredtWorkspaceSelect.Id = 1;
            baredtWorkspaceSelect.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("baredtWorkspaceSelect.ImageOptions.SvgImage");
            baredtWorkspaceSelect.Name = "baredtWorkspaceSelect";
            baredtWorkspaceSelect.Tag = "{{#WORK_FARM}}";
            // 
            // repositoryItemLookUpEdit1
            // 
            repositoryItemLookUpEdit1.AutoHeight = false;
            repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // baredtWorkspaceFolder
            // 
            baredtWorkspaceFolder.Caption = "Save folder : ";
            baredtWorkspaceFolder.Edit = repositoryItemButtonEdit1;
            baredtWorkspaceFolder.EditWidth = 255;
            baredtWorkspaceFolder.Id = 3;
            baredtWorkspaceFolder.ImageOptions.SvgImage = Properties.Resources.FolderFill;
            baredtWorkspaceFolder.Name = "baredtWorkspaceFolder";
            // 
            // repositoryItemButtonEdit1
            // 
            repositoryItemButtonEdit1.AutoHeight = false;
            repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(), new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search) });
            repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // baredtWorkspaceFillter
            // 
            baredtWorkspaceFillter.Caption = "   Farm Filter : ";
            baredtWorkspaceFillter.Edit = repositoryItemRadioGroup1;
            baredtWorkspaceFillter.EditWidth = 248;
            baredtWorkspaceFillter.Id = 4;
            baredtWorkspaceFillter.ImageOptions.SvgImage = Properties.Resources.Filter;
            baredtWorkspaceFillter.Name = "baredtWorkspaceFillter";
            baredtWorkspaceFillter.Tag = "       {{#MENU_FILTER}} : ";
            // 
            // repositoryItemRadioGroup1
            // 
            repositoryItemRadioGroup1.Columns = 3;
            repositoryItemRadioGroup1.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] { new DevExpress.XtraEditors.Controls.RadioGroupItem("ALL", "All"), new DevExpress.XtraEditors.Controls.RadioGroupItem("Y", "Operating"), new DevExpress.XtraEditors.Controls.RadioGroupItem("S", "Completed") });
            repositoryItemRadioGroup1.Name = "repositoryItemRadioGroup1";
            // 
            // barchkWorkspaceCurrentOnly
            // 
            barchkWorkspaceCurrentOnly.Caption = "Selected Farms Only";
            barchkWorkspaceCurrentOnly.Id = 6;
            barchkWorkspaceCurrentOnly.ImageOptions.SvgImage = Properties.Resources.PresenceChicklet;
            barchkWorkspaceCurrentOnly.Name = "barchkWorkspaceCurrentOnly";
            // 
            // barStaticItem1
            // 
            barStaticItem1.Caption = "Version : ";
            barStaticItem1.Id = 8;
            barStaticItem1.ImageOptions.SvgImage = Properties.Resources.BuildingEnergy;
            barStaticItem1.Name = "barStaticItem1";
            barStaticItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            barStaticItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barStaticItem2
            // 
            barStaticItem2.Caption = "Server : ";
            barStaticItem2.Id = 9;
            barStaticItem2.ImageOptions.SvgImage = Properties.Resources.Wheel;
            barStaticItem2.Name = "barStaticItem2";
            barStaticItem2.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            barStaticItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItem8
            // 
            barButtonItem8.Caption = "Support";
            barButtonItem8.Id = 16;
            barButtonItem8.ImageOptions.SvgImage = Properties.Resources.Help;
            barButtonItem8.Name = "barButtonItem8";
            barButtonItem8.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // skinRibbonGalleryBarItem1
            // 
            skinRibbonGalleryBarItem1.Caption = "skinRibbonGalleryBarItem1";
            skinRibbonGalleryBarItem1.Id = 22;
            skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";
            // 
            // skinPaletteRibbonGalleryBarItem1
            // 
            skinPaletteRibbonGalleryBarItem1.Caption = "skinPaletteRibbonGalleryBarItem1";
            skinPaletteRibbonGalleryBarItem1.Id = 23;
            skinPaletteRibbonGalleryBarItem1.Name = "skinPaletteRibbonGalleryBarItem1";
            // 
            // barWorkspaceMenuItem1
            // 
            barWorkspaceMenuItem1.Caption = "Workspace";
            barWorkspaceMenuItem1.Id = 24;
            barWorkspaceMenuItem1.Name = "barWorkspaceMenuItem1";
            barWorkspaceMenuItem1.WorkspaceManager = workspaceManager1;
            // 
            // workspaceManager1
            // 
            workspaceManager1.TargetControl = this;
            workspaceManager1.TransitionType = pushTransition1;
            // 
            // barMdiChildrenListItem1
            // 
            barMdiChildrenListItem1.Caption = "Children Tabs";
            barMdiChildrenListItem1.Id = 25;
            barMdiChildrenListItem1.Name = "barMdiChildrenListItem1";
            // 
            // rpMainHome
            // 
            rpMainHome.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup3 });
            rpMainHome.Name = "rpMainHome";
            rpMainHome.Text = "Home";
            // 
            // ribbonPageGroup3
            // 
            ribbonPageGroup3.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ribbonPageGroup3.ImageOptions.SvgImage");
            ribbonPageGroup3.ItemLinks.Add(barbtnScanner);
            ribbonPageGroup3.ItemLinks.Add(barButtonItem3, true);
            ribbonPageGroup3.ItemLinks.Add(barButtonItem5);
            ribbonPageGroup3.ItemLinks.Add(barButtonItem4);
            ribbonPageGroup3.ItemLinks.Add(barButtonItem6);
            ribbonPageGroup3.Name = "ribbonPageGroup3";
            ribbonPageGroup3.Text = "Farming Diary(Journal)";
            // 
            // rpMainApplication
            // 
            rpMainApplication.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1, ribbonPageGroup2, ribbonPageGroup7 });
            rpMainApplication.Name = "rpMainApplication";
            rpMainApplication.Text = "Application";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(baredtWorkspaceSelect);
            ribbonPageGroup1.ItemLinks.Add(baredtWorkspaceFillter);
            ribbonPageGroup1.ItemLinks.Add(baredtWorkspaceFolder);
            ribbonPageGroup1.ItemLinks.Add(barchkWorkspaceCurrentOnly);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "Workspace (Farm)";
            // 
            // ribbonPageGroup2
            // 
            ribbonPageGroup2.ItemLinks.Add(barbtnFarmManagement);
            ribbonPageGroup2.ItemLinks.Add(barbtnSettings);
            ribbonPageGroup2.Name = "ribbonPageGroup2";
            ribbonPageGroup2.Text = "Configuration";
            // 
            // ribbonPageGroup7
            // 
            ribbonPageGroup7.Alignment = DevExpress.XtraBars.Ribbon.RibbonPageGroupAlignment.Far;
            ribbonPageGroup7.ItemLinks.Add(barButtonItem7);
            ribbonPageGroup7.ItemLinks.Add(barButtonItem8);
            ribbonPageGroup7.ItemLinks.Add(barButtonItem9);
            ribbonPageGroup7.ItemLinks.Add(barButtonItem10, true);
            ribbonPageGroup7.Name = "ribbonPageGroup7";
            ribbonPageGroup7.Text = "Application";
            // 
            // rpMainView
            // 
            rpMainView.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup5, ribbonPageGroup6 });
            rpMainView.Name = "rpMainView";
            reduceOperation1.Behavior = DevExpress.XtraBars.Ribbon.ReduceOperationBehavior.Single;
            reduceOperation1.GroupName = null;
            reduceOperation1.ItemLinkIndex = 0;
            reduceOperation1.ItemLinksCount = 0;
            reduceOperation1.Operation = DevExpress.XtraBars.Ribbon.ReduceOperationType.Gallery;
            reduceOperation2.Behavior = DevExpress.XtraBars.Ribbon.ReduceOperationBehavior.Single;
            reduceOperation2.GroupName = null;
            reduceOperation2.ItemLinkIndex = 0;
            reduceOperation2.ItemLinksCount = 0;
            reduceOperation2.Operation = DevExpress.XtraBars.Ribbon.ReduceOperationType.ButtonGroups;
            rpMainView.ReduceOperations.Add(reduceOperation1);
            rpMainView.ReduceOperations.Add(reduceOperation2);
            rpMainView.Text = "View";
            // 
            // ribbonPageGroup5
            // 
            ribbonPageGroup5.ItemLinks.Add(barWorkspaceMenuItem1);
            ribbonPageGroup5.ItemLinks.Add(barMdiChildrenListItem1);
            ribbonPageGroup5.Name = "ribbonPageGroup5";
            ribbonPageGroup5.Text = "Options";
            // 
            // ribbonPageGroup6
            // 
            ribbonPageGroup6.ItemLinks.Add(skinRibbonGalleryBarItem1);
            ribbonPageGroup6.ItemLinks.Add(skinPaletteRibbonGalleryBarItem1);
            ribbonPageGroup6.Name = "ribbonPageGroup6";
            ribbonPageGroup6.Text = "Skin / Thema";
            // 
            // ribbonStatusBar
            // 
            ribbonStatusBar.ItemLinks.Add(barStaticItem2);
            ribbonStatusBar.ItemLinks.Add(barStaticItem1);
            ribbonStatusBar.Location = new Point(0, 600);
            ribbonStatusBar.Name = "ribbonStatusBar";
            ribbonStatusBar.Ribbon = rcMainMenu;
            ribbonStatusBar.Size = new Size(1341, 24);
            // 
            // popupMenu1
            // 
            popupMenu1.ItemLinks.Add(barButtonItem3);
            popupMenu1.ItemLinks.Add(barButtonItem5);
            popupMenu1.Name = "popupMenu1";
            popupMenu1.Ribbon = rcMainMenu;
            // 
            // mdimngMain
            // 
            mdimngMain.MdiParent = this;
            // 
            // UbMainForm
            // 
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1341, 624);
            Controls.Add(ribbonStatusBar);
            Controls.Add(rcMainMenu);
            Font = new Font("맑은 고딕", 9F);
            IconOptions.Image = (Image)resources.GetObject("UbMainForm.IconOptions.Image");
            IsMdiContainer = true;
            Name = "UbMainForm";
            Ribbon = rcMainMenu;
            StatusBar = ribbonStatusBar;
            Text = "Farming Diary Automation System";
            ((System.ComponentModel.ISupportInitialize)rcMainMenu).EndInit();
            ((System.ComponentModel.ISupportInitialize)applicationMenu1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemLookUpEdit1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemButtonEdit1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemRadioGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)popupMenu1).EndInit();
            ((System.ComponentModel.ISupportInitialize)mdimngMain).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonPage rpMainHome;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarEditItem baredtWorkspaceSelect;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraBars.BarButtonItem barbtnSettings;
        private DevExpress.XtraBars.BarEditItem baredtWorkspaceFolder;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraBars.BarEditItem baredtWorkspaceFillter;
        private DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup repositoryItemRadioGroup1;
        private DevExpress.XtraBars.BarCheckItem barchkWorkspaceCurrentOnly;
        private DevExpress.XtraBars.BarButtonItem barbtnFarmManagement;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem2;
        private DevExpress.XtraBars.BarButtonItem barbtnScanner;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraBars.BarButtonItem barButtonItem8;
        private DevExpress.XtraBars.BarButtonItem barButtonItem9;
        private DevExpress.XtraBars.BarButtonItem barButtonItem10;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpMainView;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager mdimngMain;
        internal DevExpress.XtraBars.Ribbon.RibbonControl rcMainMenu;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1;
        private DevExpress.XtraBars.SkinPaletteRibbonGalleryBarItem skinPaletteRibbonGalleryBarItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.BarWorkspaceMenuItem barWorkspaceMenuItem1;
        private DevExpress.Utils.WorkspaceManager workspaceManager1;
        private DevExpress.XtraBars.BarMdiChildrenListItem barMdiChildrenListItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpMainApplication;
        private DevExpress.XtraBars.Ribbon.ApplicationMenu applicationMenu1;
    }
}