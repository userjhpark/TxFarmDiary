namespace FarmDiaryAI.Win
{
    partial class frmRibbonMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRibbonMain));
            ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            barbtnSettings = new DevExpress.XtraBars.BarButtonItem();
            barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            barEditItem2 = new DevExpress.XtraBars.BarEditItem();
            repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            barEditItem3 = new DevExpress.XtraBars.BarEditItem();
            repositoryItemRadioGroup1 = new DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup();
            barCheckItem1 = new DevExpress.XtraBars.BarCheckItem();
            barbtnFarmManagement = new DevExpress.XtraBars.BarButtonItem();
            barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            barStaticItem2 = new DevExpress.XtraBars.BarStaticItem();
            barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem9 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem10 = new DevExpress.XtraBars.BarButtonItem();
            rpMainHome = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            rpMainView = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            popupMenu1 = new DevExpress.XtraBars.PopupMenu(components);
            ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemLookUpEdit1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemButtonEdit1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemRadioGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)popupMenu1).BeginInit();
            SuspendLayout();
            // 
            // ribbon
            // 
            ribbon.CaptionBarItemLinks.Add(barbtnSettings);
            ribbon.ExpandCollapseItem.Id = 0;
            ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] { barbtnSettings, ribbon.ExpandCollapseItem, barEditItem1, barEditItem2, barEditItem3, barCheckItem1, barbtnFarmManagement, barStaticItem1, barStaticItem2, barButtonItem2, barButtonItem3, barButtonItem4, barButtonItem5, barButtonItem6, barButtonItem7, barButtonItem8, barButtonItem9, barButtonItem10 });
            ribbon.Location = new Point(0, 0);
            ribbon.MaxItemId = 19;
            ribbon.Name = "ribbon";
            ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { rpMainHome, rpMainView });
            ribbon.QuickToolbarItemLinks.Add(barButtonItem3);
            ribbon.QuickToolbarItemLinks.Add(barButtonItem5);
            ribbon.QuickToolbarItemLinks.Add(barEditItem1);
            ribbon.QuickToolbarItemLinks.Add(barCheckItem1);
            ribbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemLookUpEdit1, repositoryItemButtonEdit1, repositoryItemRadioGroup1 });
            ribbon.Size = new Size(1186, 167);
            ribbon.StatusBar = ribbonStatusBar;
            // 
            // barbtnSettings
            // 
            barbtnSettings.Caption = "환경설정";
            barbtnSettings.Id = 2;
            barbtnSettings.ImageOptions.SvgImage = Properties.Resources.SettingsSolid;
            barbtnSettings.Name = "barbtnSettings";
            // 
            // barEditItem1
            // 
            barEditItem1.Caption = "작업 농장 : ";
            barEditItem1.Edit = repositoryItemLookUpEdit1;
            barEditItem1.EditWidth = 300;
            barEditItem1.Id = 1;
            barEditItem1.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barEditItem1.ImageOptions.SvgImage");
            barEditItem1.Name = "barEditItem1";
            // 
            // repositoryItemLookUpEdit1
            // 
            repositoryItemLookUpEdit1.AutoHeight = false;
            repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // barEditItem2
            // 
            barEditItem2.Caption = "저장 폴더 : ";
            barEditItem2.Edit = repositoryItemButtonEdit1;
            barEditItem2.EditWidth = 300;
            barEditItem2.Id = 3;
            barEditItem2.ImageOptions.SvgImage = Properties.Resources.FolderFill;
            barEditItem2.Name = "barEditItem2";
            // 
            // repositoryItemButtonEdit1
            // 
            repositoryItemButtonEdit1.AutoHeight = false;
            repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(), new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search) });
            repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // barEditItem3
            // 
            barEditItem3.Caption = "       필터 : ";
            barEditItem3.Edit = repositoryItemRadioGroup1;
            barEditItem3.EditWidth = 300;
            barEditItem3.Id = 4;
            barEditItem3.ImageOptions.SvgImage = Properties.Resources.Filter;
            barEditItem3.Name = "barEditItem3";
            // 
            // repositoryItemRadioGroup1
            // 
            repositoryItemRadioGroup1.Columns = 3;
            repositoryItemRadioGroup1.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] { new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "전체"), new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "운영 중"), new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "완료") });
            repositoryItemRadioGroup1.Name = "repositoryItemRadioGroup1";
            // 
            // barCheckItem1
            // 
            barCheckItem1.Caption = "현재(Current) Workspace";
            barCheckItem1.Id = 6;
            barCheckItem1.ImageOptions.SvgImage = Properties.Resources.PresenceChicklet;
            barCheckItem1.Name = "barCheckItem1";
            // 
            // barbtnFarmManagement
            // 
            barbtnFarmManagement.Caption = "농장 관리";
            barbtnFarmManagement.Id = 7;
            barbtnFarmManagement.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItem1.ImageOptions.SvgImage");
            barbtnFarmManagement.Name = "barbtnFarmManagement";
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
            // barButtonItem2
            // 
            barButtonItem2.Caption = "스캔";
            barButtonItem2.Id = 10;
            barButtonItem2.ImageOptions.SvgImage = Properties.Resources.Scan;
            barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            barButtonItem3.Caption = "등록";
            barButtonItem3.Id = 11;
            barButtonItem3.ImageOptions.SvgImage = Properties.Resources.Document;
            barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem4
            // 
            barButtonItem4.Caption = "보고서";
            barButtonItem4.Id = 12;
            barButtonItem4.ImageOptions.SvgImage = Properties.Resources.ReportDocument;
            barButtonItem4.Name = "barButtonItem4";
            // 
            // barButtonItem5
            // 
            barButtonItem5.Caption = "검색/조회";
            barButtonItem5.Id = 13;
            barButtonItem5.ImageOptions.SvgImage = Properties.Resources.SearchAndApps;
            barButtonItem5.Name = "barButtonItem5";
            // 
            // barButtonItem6
            // 
            barButtonItem6.Caption = "내보내기";
            barButtonItem6.Id = 14;
            barButtonItem6.ImageOptions.SvgImage = Properties.Resources.Export;
            barButtonItem6.Name = "barButtonItem6";
            // 
            // barButtonItem7
            // 
            barButtonItem7.Caption = "정보";
            barButtonItem7.Id = 15;
            barButtonItem7.ImageOptions.SvgImage = Properties.Resources.InfoSolid;
            barButtonItem7.Name = "barButtonItem7";
            // 
            // barButtonItem8
            // 
            barButtonItem8.Caption = "기술지원";
            barButtonItem8.Id = 16;
            barButtonItem8.ImageOptions.SvgImage = Properties.Resources.Help;
            barButtonItem8.Name = "barButtonItem8";
            barButtonItem8.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItem9
            // 
            barButtonItem9.Caption = "매뉴얼";
            barButtonItem9.Id = 17;
            barButtonItem9.ImageOptions.SvgImage = Properties.Resources.PhoneBook;
            barButtonItem9.Name = "barButtonItem9";
            // 
            // barButtonItem10
            // 
            barButtonItem10.Caption = "Log-out";
            barButtonItem10.Id = 18;
            barButtonItem10.ImageOptions.SvgImage = Properties.Resources.SignOut;
            barButtonItem10.Name = "barButtonItem10";
            // 
            // rpMainHome
            // 
            rpMainHome.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1, ribbonPageGroup2, ribbonPageGroup3, ribbonPageGroup4 });
            rpMainHome.Name = "rpMainHome";
            rpMainHome.Text = "Home";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(barEditItem1);
            ribbonPageGroup1.ItemLinks.Add(barEditItem3);
            ribbonPageGroup1.ItemLinks.Add(barEditItem2);
            ribbonPageGroup1.ItemLinks.Add(barCheckItem1);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "Workspace";
            // 
            // ribbonPageGroup2
            // 
            ribbonPageGroup2.ItemLinks.Add(barbtnFarmManagement);
            ribbonPageGroup2.ItemLinks.Add(barbtnSettings);
            ribbonPageGroup2.Name = "ribbonPageGroup2";
            ribbonPageGroup2.Text = "환경설정";
            // 
            // ribbonPageGroup3
            // 
            ribbonPageGroup3.ItemLinks.Add(barButtonItem2);
            ribbonPageGroup3.ItemLinks.Add(barButtonItem3, true);
            ribbonPageGroup3.ItemLinks.Add(barButtonItem5);
            ribbonPageGroup3.ItemLinks.Add(barButtonItem4);
            ribbonPageGroup3.ItemLinks.Add(barButtonItem6);
            ribbonPageGroup3.Name = "ribbonPageGroup3";
            ribbonPageGroup3.Text = "영농일지";
            // 
            // ribbonPageGroup4
            // 
            ribbonPageGroup4.ItemLinks.Add(barButtonItem7);
            ribbonPageGroup4.ItemLinks.Add(barButtonItem8);
            ribbonPageGroup4.ItemLinks.Add(barButtonItem9);
            ribbonPageGroup4.ItemLinks.Add(barButtonItem10, true);
            ribbonPageGroup4.Name = "ribbonPageGroup4";
            ribbonPageGroup4.Text = "Application";
            // 
            // rpMainView
            // 
            rpMainView.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup5 });
            rpMainView.Name = "rpMainView";
            rpMainView.Text = "View";
            // 
            // ribbonPageGroup5
            // 
            ribbonPageGroup5.Name = "ribbonPageGroup5";
            ribbonPageGroup5.Text = "Options";
            // 
            // ribbonStatusBar
            // 
            ribbonStatusBar.ItemLinks.Add(barStaticItem2);
            ribbonStatusBar.ItemLinks.Add(barStaticItem1);
            ribbonStatusBar.Location = new Point(0, 599);
            ribbonStatusBar.Name = "ribbonStatusBar";
            ribbonStatusBar.Ribbon = ribbon;
            ribbonStatusBar.Size = new Size(1186, 22);
            // 
            // popupMenu1
            // 
            popupMenu1.ItemLinks.Add(barButtonItem3);
            popupMenu1.ItemLinks.Add(barButtonItem5);
            popupMenu1.Name = "popupMenu1";
            popupMenu1.Ribbon = ribbon;
            // 
            // frmRibbonMain
            // 
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1186, 621);
            Controls.Add(ribbonStatusBar);
            Controls.Add(ribbon);
            IconOptions.Image = (Image)resources.GetObject("frmRibbonMain.IconOptions.Image");
            Name = "frmRibbonMain";
            Ribbon = ribbon;
            StatusBar = ribbonStatusBar;
            Text = "Farming Diary Automation System";
            ((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemLookUpEdit1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemButtonEdit1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemRadioGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)popupMenu1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpMainHome;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraBars.BarButtonItem barbtnSettings;
        private DevExpress.XtraBars.BarEditItem barEditItem2;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraBars.BarEditItem barEditItem3;
        private DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup repositoryItemRadioGroup1;
        private DevExpress.XtraBars.BarCheckItem barCheckItem1;
        private DevExpress.XtraBars.BarButtonItem barbtnFarmManagement;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraBars.BarButtonItem barButtonItem8;
        private DevExpress.XtraBars.BarButtonItem barButtonItem9;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem10;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpMainView;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
    }
}