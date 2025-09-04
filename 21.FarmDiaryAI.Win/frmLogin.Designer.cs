namespace FarmDiaryAI.Win
{
    partial class frmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            peImage = new DevExpress.XtraEditors.PictureEdit();
            button1 = new Button();
            button2 = new Button();
            pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            btnLogin = new DevExpress.XtraEditors.SimpleButton();
            edtUserID = new DevExpress.XtraEditors.TextEdit();
            picLogin = new DevExpress.XtraEditors.PictureEdit();
            panel1 = new Panel();
            labelControl3 = new DevExpress.XtraEditors.LabelControl();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            chkSaveID = new DevExpress.XtraEditors.CheckEdit();
            grpUserIP = new DevExpress.XtraEditors.GroupControl();
            lblServerSource = new DevExpress.XtraEditors.LabelControl();
            btnCancel = new DevExpress.XtraEditors.SimpleButton();
            edtPassword = new DevExpress.XtraEditors.TextEdit();
            gluServerSource = new DevExpress.XtraEditors.GridLookUpEdit();
            gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            lblAppDescription = new DevExpress.XtraEditors.LabelControl();
            labelCopyright = new DevExpress.XtraEditors.LabelControl();
            lblUserIP = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)peImage.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureEdit1.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)edtUserID.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picLogin.Properties).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chkSaveID.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grpUserIP).BeginInit();
            grpUserIP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)edtPassword.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gluServerSource.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridLookUpEdit1View).BeginInit();
            SuspendLayout();
            // 
            // peImage
            // 
            peImage.Dock = DockStyle.Top;
            peImage.EditValue = resources.GetObject("peImage.EditValue");
            peImage.Location = new Point(0, 508);
            peImage.Margin = new Padding(4, 3, 4, 3);
            peImage.Name = "peImage";
            peImage.Properties.AllowFocused = false;
            peImage.Properties.Appearance.BackColor = Color.Transparent;
            peImage.Properties.Appearance.Options.UseBackColor = true;
            peImage.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            peImage.Properties.ShowMenu = false;
            peImage.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            peImage.Properties.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None;
            peImage.Size = new Size(780, 11);
            peImage.TabIndex = 10;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Location = new Point(693, 8);
            button1.Name = "button1";
            button1.Size = new Size(75, 25);
            button1.TabIndex = 11;
            button1.Text = "Show";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.Location = new Point(693, 39);
            button2.Name = "button2";
            button2.Size = new Size(75, 25);
            button2.TabIndex = 12;
            button2.Text = "Close";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // pictureEdit1
            // 
            pictureEdit1.Dock = DockStyle.Top;
            pictureEdit1.EditValue = resources.GetObject("pictureEdit1.EditValue");
            pictureEdit1.Location = new Point(0, 0);
            pictureEdit1.Margin = new Padding(4, 3, 4, 3);
            pictureEdit1.Name = "pictureEdit1";
            pictureEdit1.Properties.AllowFocused = false;
            pictureEdit1.Properties.Appearance.BackColor = Color.Transparent;
            pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pictureEdit1.Properties.ShowMenu = false;
            pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            pictureEdit1.Properties.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None;
            pictureEdit1.Size = new Size(780, 508);
            pictureEdit1.TabIndex = 13;
            // 
            // btnLogin
            // 
            btnLogin.ImageOptions.SvgImage = Properties.Resources.Contact1;
            btnLogin.Location = new Point(561, 22);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(100, 49);
            btnLogin.TabIndex = 14;
            btnLogin.Text = "로그인";
            btnLogin.Click += simpleButton1_Click;
            // 
            // edtUserID
            // 
            edtUserID.Location = new Point(396, 22);
            edtUserID.Name = "edtUserID";
            edtUserID.Size = new Size(159, 22);
            edtUserID.TabIndex = 15;
            // 
            // picLogin
            // 
            picLogin.EditValue = resources.GetObject("picLogin.EditValue");
            picLogin.Location = new Point(242, 25);
            picLogin.Name = "picLogin";
            picLogin.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            picLogin.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            picLogin.Size = new Size(55, 49);
            picLogin.TabIndex = 16;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(labelControl3);
            panel1.Controls.Add(labelControl2);
            panel1.Controls.Add(chkSaveID);
            panel1.Controls.Add(grpUserIP);
            panel1.Controls.Add(lblServerSource);
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(edtPassword);
            panel1.Controls.Add(gluServerSource);
            panel1.Controls.Add(picLogin);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(edtUserID);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 519);
            panel1.Name = "panel1";
            panel1.Size = new Size(780, 127);
            panel1.TabIndex = 17;
            // 
            // labelControl3
            // 
            labelControl3.Appearance.Options.UseTextOptions = true;
            labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            labelControl3.Location = new Point(330, 57);
            labelControl3.Name = "labelControl3";
            labelControl3.Size = new Size(60, 15);
            labelControl3.TabIndex = 24;
            labelControl3.Text = "Password : ";
            labelControl3.Visible = false;
            // 
            // labelControl2
            // 
            labelControl2.Appearance.Options.UseTextOptions = true;
            labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            labelControl2.Location = new Point(330, 25);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new Size(60, 15);
            labelControl2.TabIndex = 23;
            labelControl2.Text = "User ID : ";
            labelControl2.Visible = false;
            // 
            // chkSaveID
            // 
            chkSaveID.Location = new Point(396, 82);
            chkSaveID.Name = "chkSaveID";
            chkSaveID.Properties.Caption = "Save ID";
            chkSaveID.Size = new Size(75, 19);
            chkSaveID.TabIndex = 22;
            // 
            // grpUserIP
            // 
            grpUserIP.Controls.Add(lblUserIP);
            grpUserIP.Location = new Point(22, 50);
            grpUserIP.Name = "grpUserIP";
            grpUserIP.Size = new Size(200, 60);
            grpUserIP.TabIndex = 21;
            grpUserIP.Text = "IP";
            // 
            // lblServerSource
            // 
            lblServerSource.Appearance.Options.UseTextOptions = true;
            lblServerSource.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            lblServerSource.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblServerSource.Location = new Point(4, 5);
            lblServerSource.Name = "lblServerSource";
            lblServerSource.Size = new Size(60, 15);
            lblServerSource.TabIndex = 20;
            lblServerSource.Text = "Sever : ";
            lblServerSource.Visible = false;
            // 
            // btnCancel
            // 
            btnCancel.ImageOptions.SvgImage = Properties.Resources.PowerButtonUpdate;
            btnCancel.Location = new Point(667, 22);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 49);
            btnCancel.TabIndex = 18;
            btnCancel.Text = "취소";
            // 
            // edtPassword
            // 
            edtPassword.Location = new Point(396, 52);
            edtPassword.Name = "edtPassword";
            edtPassword.Properties.UseSystemPasswordChar = true;
            edtPassword.Size = new Size(159, 22);
            edtPassword.TabIndex = 17;
            // 
            // gluServerSource
            // 
            gluServerSource.Location = new Point(22, 22);
            gluServerSource.Name = "gluServerSource";
            gluServerSource.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            gluServerSource.Properties.PopupView = gridLookUpEdit1View;
            gluServerSource.Size = new Size(200, 22);
            gluServerSource.TabIndex = 19;
            // 
            // gridLookUpEdit1View
            // 
            gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // lblAppDescription
            // 
            lblAppDescription.Location = new Point(22, 652);
            lblAppDescription.Name = "lblAppDescription";
            lblAppDescription.Size = new Size(0, 15);
            lblAppDescription.TabIndex = 18;
            // 
            // labelCopyright
            // 
            labelCopyright.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            labelCopyright.Location = new Point(491, 652);
            labelCopyright.Margin = new Padding(4, 3, 4, 3);
            labelCopyright.Name = "labelCopyright";
            labelCopyright.Size = new Size(276, 15);
            labelCopyright.TabIndex = 19;
            labelCopyright.Text = "Copyright ⓒ 2025-{0} Ju-hyun, Park (South Korea)";
            // 
            // lblUserIP
            // 
            lblUserIP.Location = new Point(5, 34);
            lblUserIP.Name = "lblUserIP";
            lblUserIP.Size = new Size(136, 15);
            lblUserIP.TabIndex = 0;
            lblUserIP.Text = "                                  ";
            // 
            // frmLogin
            // 
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(780, 672);
            Controls.Add(labelCopyright);
            Controls.Add(lblAppDescription);
            Controls.Add(panel1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(peImage);
            Controls.Add(pictureEdit1);
            Font = new Font("맑은 고딕", 9F);
            IconOptions.Image = (Image)resources.GetObject("frmLogin.IconOptions.Image");
            Name = "frmLogin";
            Text = "Farming Diary Automation System - Login";
            ((System.ComponentModel.ISupportInitialize)peImage.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureEdit1.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)edtUserID.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)picLogin.Properties).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chkSaveID.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)grpUserIP).EndInit();
            grpUserIP.ResumeLayout(false);
            grpUserIP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)edtPassword.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)gluServerSource.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridLookUpEdit1View).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit peImage;
        private Button button1;
        private Button button2;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.SimpleButton btnLogin;
        private DevExpress.XtraEditors.TextEdit edtUserID;
        private DevExpress.XtraEditors.PictureEdit picLogin;
        private Panel panel1;
        private DevExpress.XtraEditors.TextEdit edtPassword;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.GroupControl grpUserIP;
        private DevExpress.XtraEditors.LabelControl lblServerSource;
        private DevExpress.XtraEditors.GridLookUpEdit gluServerSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraEditors.LabelControl lblAppDescription;
        private DevExpress.XtraEditors.LabelControl labelCopyright;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.CheckEdit chkSaveID;
        private DevExpress.XtraEditors.LabelControl lblUserIP;
    }
}
