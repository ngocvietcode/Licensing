namespace Licensing.App
{
    partial class LicenseForm
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
            this.lableComputerID = new System.Windows.Forms.Label();
            this.textComputerID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openLicenseFile = new System.Windows.Forms.OpenFileDialog();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.txtLicense = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelLicenseStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtComputerName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lableComputerID
            // 
            this.lableComputerID.AutoSize = true;
            this.lableComputerID.Location = new System.Drawing.Point(12, 60);
            this.lableComputerID.Name = "lableComputerID";
            this.lableComputerID.Size = new System.Drawing.Size(115, 13);
            this.lableComputerID.TabIndex = 0;
            this.lableComputerID.Text = "Computer Hardware ID";
            // 
            // textComputerID
            // 
            this.textComputerID.Location = new System.Drawing.Point(151, 57);
            this.textComputerID.Name = "textComputerID";
            this.textComputerID.ReadOnly = true;
            this.textComputerID.Size = new System.Drawing.Size(418, 20);
            this.textComputerID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "License Key";
            // 
            // openLicenseFile
            // 
            this.openLicenseFile.DefaultExt = "xml";
            this.openLicenseFile.Filter = "XML Files (*.xml)|*.xml";
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(463, 113);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(106, 23);
            this.buttonOpen.TabIndex = 4;
            this.buttonOpen.Text = "Import License";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // txtLicense
            // 
            this.txtLicense.Location = new System.Drawing.Point(152, 151);
            this.txtLicense.Multiline = true;
            this.txtLicense.Name = "txtLicense";
            this.txtLicense.ReadOnly = true;
            this.txtLicense.Size = new System.Drawing.Size(417, 134);
            this.txtLicense.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(12, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "License Status";
            // 
            // labelLicenseStatus
            // 
            this.labelLicenseStatus.AutoSize = true;
            this.labelLicenseStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelLicenseStatus.ForeColor = System.Drawing.Color.Red;
            this.labelLicenseStatus.Location = new System.Drawing.Point(149, 23);
            this.labelLicenseStatus.Name = "labelLicenseStatus";
            this.labelLicenseStatus.Size = new System.Drawing.Size(55, 17);
            this.labelLicenseStatus.TabIndex = 7;
            this.labelLicenseStatus.Text = "Invalid";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Computer Name";
            // 
            // txtComputerName
            // 
            this.txtComputerName.Location = new System.Drawing.Point(151, 87);
            this.txtComputerName.Name = "txtComputerName";
            this.txtComputerName.ReadOnly = true;
            this.txtComputerName.Size = new System.Drawing.Size(139, 20);
            this.txtComputerName.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(316, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "User Name";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(382, 84);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(187, 20);
            this.txtUserName.TabIndex = 11;
            // 
            // LicenseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 297);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtComputerName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelLicenseStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLicense);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textComputerID);
            this.Controls.Add(this.lableComputerID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LicenseForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "License Information";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.LicenseForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lableComputerID;
        private System.Windows.Forms.TextBox textComputerID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openLicenseFile;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.TextBox txtLicense;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelLicenseStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtComputerName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUserName;
    }
}