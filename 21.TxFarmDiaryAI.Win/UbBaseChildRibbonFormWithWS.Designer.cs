namespace TxFarmDiaryAI.Win
{
    partial class UbBaseChildRibbonFormWithWS
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UbBaseChildRibbonFormWithWS));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            rpChildHome = new DevExpress.XtraBars.Ribbon.RibbonPage();
            rpgChildWorkspace = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            baredtChildWorkspaceSelect = new DevExpress.XtraBars.BarEditItem();
            repsluChildWorkspaceSelect = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            baredtChildWorkspaceFillter = new DevExpress.XtraBars.BarEditItem();
            repradChildWorkspaceFillter = new DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup();
            ((System.ComponentModel.ISupportInitialize)rcChildMenu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repsluChildWorkspaceSelect).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemSearchLookUpEdit1View).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repradChildWorkspaceFillter).BeginInit();
            SuspendLayout();
            // 
            // rcChildMenu
            // 
            rcChildMenu.EmptyAreaImageOptions.ImagePadding = new Padding(30, 28, 30, 28);
            rcChildMenu.ExpandCollapseItem.Id = 0;
            rcChildMenu.Items.AddRange(new DevExpress.XtraBars.BarItem[] { baredtChildWorkspaceSelect, baredtChildWorkspaceFillter });
            rcChildMenu.MaxItemId = 3;
            rcChildMenu.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { rpChildHome });
            rcChildMenu.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repsluChildWorkspaceSelect, repradChildWorkspaceFillter });
            rcChildMenu.Size = new Size(800, 150);
            // 
            // rsbChildStatusBar
            // 
            rsbChildStatusBar.Location = new Point(0, 428);
            // 
            // rpChildHome
            // 
            rpChildHome.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { rpgChildWorkspace });
            rpChildHome.Name = "rpChildHome";
            rpChildHome.Text = "Home";
            // 
            // rpgChildWorkspace
            // 
            rpgChildWorkspace.ItemLinks.Add(baredtChildWorkspaceSelect);
            rpgChildWorkspace.ItemLinks.Add(baredtChildWorkspaceFillter);
            rpgChildWorkspace.Name = "rpgChildWorkspace";
            rpgChildWorkspace.Text = "Workspace (Farm)";
            // 
            // baredtChildWorkspaceSelect
            // 
            baredtChildWorkspaceSelect.Caption = "Select : ";
            baredtChildWorkspaceSelect.Edit = repsluChildWorkspaceSelect;
            baredtChildWorkspaceSelect.EditWidth = 255;
            baredtChildWorkspaceSelect.Id = 1;
            baredtChildWorkspaceSelect.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("baredtChildWorkspaceSelect.ImageOptions.SvgImage");
            baredtChildWorkspaceSelect.Name = "baredtChildWorkspaceSelect";
            // 
            // repsluChildWorkspaceSelect
            // 
            repsluChildWorkspaceSelect.AutoHeight = false;
            editorButtonImageOptions1.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("editorButtonImageOptions1.SvgImage");
            editorButtonImageOptions1.SvgImageSize = new Size(12, 12);
            repsluChildWorkspaceSelect.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default) });
            repsluChildWorkspaceSelect.Name = "repsluChildWorkspaceSelect";
            repsluChildWorkspaceSelect.PopupView = repositoryItemSearchLookUpEdit1View;
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // baredtChildWorkspaceFillter
            // 
            baredtChildWorkspaceFillter.Caption = "Filter ";
            baredtChildWorkspaceFillter.Edit = repradChildWorkspaceFillter;
            baredtChildWorkspaceFillter.EditWidth = 270;
            baredtChildWorkspaceFillter.Id = 2;
            baredtChildWorkspaceFillter.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("baredtChildWorkspaceFillter.ImageOptions.SvgImage");
            baredtChildWorkspaceFillter.Name = "baredtChildWorkspaceFillter";
            baredtChildWorkspaceFillter.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // repradChildWorkspaceFillter
            // 
            repradChildWorkspaceFillter.Columns = 3;
            repradChildWorkspaceFillter.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] { new DevExpress.XtraEditors.Controls.RadioGroupItem("ALL", "All"), new DevExpress.XtraEditors.Controls.RadioGroupItem("Y", "Operating"), new DevExpress.XtraEditors.Controls.RadioGroupItem("S", "Completed") });
            repradChildWorkspaceFillter.Name = "repradChildWorkspaceFillter";
            // 
            // UbBaseChildRibbonFormWithWS
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            IconOptions.Image = (Image)resources.GetObject("UbBaseChildRibbonFormWithWS.IconOptions.Image");
            Name = "UbBaseChildRibbonFormWithWS";
            Text = "UbChildBaseFormwithWorkspace";
            ((System.ComponentModel.ISupportInitialize)rcChildMenu).EndInit();
            ((System.ComponentModel.ISupportInitialize)repsluChildWorkspaceSelect).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemSearchLookUpEdit1View).EndInit();
            ((System.ComponentModel.ISupportInitialize)repradChildWorkspaceFillter).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        protected DevExpress.XtraBars.Ribbon.RibbonPage rpChildHome;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        protected DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgChildWorkspace;
        protected DevExpress.XtraBars.BarEditItem baredtChildWorkspaceSelect;
        protected DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repsluChildWorkspaceSelect;
        protected DevExpress.XtraBars.BarEditItem baredtChildWorkspaceFillter;
        protected DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup repradChildWorkspaceFillter;
    }
}