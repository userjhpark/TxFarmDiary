namespace TxFarmDiaryAI.Win
{
    partial class UbSplashScreenStartup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UbSplashScreenStartup));
            progressBarControl = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            labelCopyright = new DevExpress.XtraEditors.LabelControl();
            labelStatus = new DevExpress.XtraEditors.LabelControl();
            peImage = new DevExpress.XtraEditors.PictureEdit();
            peLogo = new DevExpress.XtraEditors.PictureEdit();
            pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)progressBarControl.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)peImage.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)peLogo.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureEdit1.Properties).BeginInit();
            SuspendLayout();
            // 
            // progressBarControl
            // 
            progressBarControl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBarControl.EditValue = 0;
            progressBarControl.Location = new Point(21, 383);
            progressBarControl.Margin = new Padding(4, 3, 4, 3);
            progressBarControl.Name = "progressBarControl";
            progressBarControl.Size = new Size(469, 13);
            progressBarControl.TabIndex = 5;
            // 
            // labelCopyright
            // 
            labelCopyright.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            labelCopyright.Location = new Point(21, 442);
            labelCopyright.Margin = new Padding(4, 3, 4, 3);
            labelCopyright.Name = "labelCopyright";
            labelCopyright.Size = new Size(276, 15);
            labelCopyright.TabIndex = 6;
            labelCopyright.Text = "Copyright ⓒ 2025-{0} Ju-hyun, Park (South Korea)";
            // 
            // labelStatus
            // 
            labelStatus.Location = new Point(21, 365);
            labelStatus.Margin = new Padding(4, 3, 4, 1);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(51, 15);
            labelStatus.TabIndex = 7;
            labelStatus.Text = "Starting...";
            // 
            // peImage
            // 
            peImage.Dock = DockStyle.Top;
            peImage.EditValue = resources.GetObject("peImage.EditValue");
            peImage.Location = new Point(1, 1);
            peImage.Margin = new Padding(4, 3, 4, 3);
            peImage.Name = "peImage";
            peImage.Properties.AllowFocused = false;
            peImage.Properties.Appearance.BackColor = Color.Transparent;
            peImage.Properties.Appearance.Options.UseBackColor = true;
            peImage.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            peImage.Properties.ShowMenu = false;
            peImage.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            peImage.Properties.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None;
            peImage.Size = new Size(523, 10);
            peImage.TabIndex = 9;
            // 
            // peLogo
            // 
            peLogo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            peLogo.EditValue = resources.GetObject("peLogo.EditValue");
            peLogo.Location = new Point(319, 421);
            peLogo.Margin = new Padding(4, 3, 4, 3);
            peLogo.Name = "peLogo";
            peLogo.Properties.AllowFocused = false;
            peLogo.Properties.Appearance.BackColor = Color.Transparent;
            peLogo.Properties.Appearance.Options.UseBackColor = true;
            peLogo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            peLogo.Properties.ShowMenu = false;
            peLogo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            peLogo.Size = new Size(184, 45);
            peLogo.TabIndex = 8;
            peLogo.Visible = false;
            // 
            // pictureEdit1
            // 
            pictureEdit1.Dock = DockStyle.Top;
            pictureEdit1.EditValue = resources.GetObject("pictureEdit1.EditValue");
            pictureEdit1.Location = new Point(1, 11);
            pictureEdit1.Margin = new Padding(4, 3, 4, 3);
            pictureEdit1.Name = "pictureEdit1";
            pictureEdit1.Properties.AllowFocused = false;
            pictureEdit1.Properties.Appearance.BackColor = Color.Transparent;
            pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pictureEdit1.Properties.ShowMenu = false;
            pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            pictureEdit1.Properties.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None;
            pictureEdit1.Size = new Size(523, 348);
            pictureEdit1.TabIndex = 11;
            // 
            // UbSplashScreenStartup
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(525, 477);
            Controls.Add(pictureEdit1);
            Controls.Add(peImage);
            Controls.Add(peLogo);
            Controls.Add(labelStatus);
            Controls.Add(labelCopyright);
            Controls.Add(progressBarControl);
            Margin = new Padding(4, 3, 4, 3);
            Name = "UbSplashScreenStartup";
            Padding = new Padding(1);
            Text = "Splash Screen";
            ((System.ComponentModel.ISupportInitialize)progressBarControl.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)peImage.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)peLogo.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureEdit1.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.MarqueeProgressBarControl progressBarControl;
        private DevExpress.XtraEditors.LabelControl labelCopyright;
        private DevExpress.XtraEditors.LabelControl labelStatus;
        private DevExpress.XtraEditors.PictureEdit peLogo;
        private DevExpress.XtraEditors.PictureEdit peImage;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
    }
}
