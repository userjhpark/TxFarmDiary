namespace TxFarmDiaryAI.Win
{
    partial class UbImageScanWizardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UbImageScanWizardForm));
            wizardControl1 = new DevExpress.XtraWizard.WizardControl();
            welcomeWizardPage1 = new DevExpress.XtraWizard.WelcomeWizardPage();
            wizardPage1 = new DevExpress.XtraWizard.WizardPage();
            completionWizardPage1 = new DevExpress.XtraWizard.CompletionWizardPage();
            ((System.ComponentModel.ISupportInitialize)wizardControl1).BeginInit();
            wizardControl1.SuspendLayout();
            SuspendLayout();
            // 
            // wizardControl1
            // 
            wizardControl1.Controls.Add(welcomeWizardPage1);
            wizardControl1.Controls.Add(wizardPage1);
            wizardControl1.Controls.Add(completionWizardPage1);
            wizardControl1.Dock = DockStyle.Fill;
            wizardControl1.ImageOptions.ImageWidth = 216;
            wizardControl1.Margin = new Padding(4, 3, 4, 3);
            wizardControl1.MinimumSize = new Size(117, 115);
            wizardControl1.Name = "wizardControl1";
            wizardControl1.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] { welcomeWizardPage1, wizardPage1, completionWizardPage1 });
            wizardControl1.Size = new Size(790, 498);
            // 
            // welcomeWizardPage1
            // 
            welcomeWizardPage1.Margin = new Padding(4, 3, 4, 3);
            welcomeWizardPage1.Name = "welcomeWizardPage1";
            welcomeWizardPage1.Size = new Size(542, 366);
            // 
            // wizardPage1
            // 
            wizardPage1.Margin = new Padding(4, 3, 4, 3);
            wizardPage1.Name = "wizardPage1";
            wizardPage1.Size = new Size(758, 355);
            // 
            // completionWizardPage1
            // 
            completionWizardPage1.Margin = new Padding(4, 3, 4, 3);
            completionWizardPage1.Name = "completionWizardPage1";
            completionWizardPage1.Size = new Size(542, 366);
            // 
            // frmImageScanWizardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(790, 498);
            Controls.Add(wizardControl1);
            Font = new Font("맑은 고딕", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            IconOptions.Image = (Image)resources.GetObject("frmImageScanWizardForm.IconOptions.Image");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmImageScanWizardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Paper to Image Scan";
            ((System.ComponentModel.ISupportInitialize)wizardControl1).EndInit();
            wizardControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraWizard.WizardControl wizardControl1;
        private DevExpress.XtraWizard.WelcomeWizardPage welcomeWizardPage1;
        private DevExpress.XtraWizard.WizardPage wizardPage1;
        private DevExpress.XtraWizard.CompletionWizardPage completionWizardPage1;
    }
}