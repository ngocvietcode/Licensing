namespace Licensing.App
{
    partial class GenLicenseForm
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
            this.computerID = new System.Windows.Forms.TextBox();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtComputerName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lableComputerID
            // 
            this.lableComputerID.AutoSize = true;
            this.lableComputerID.Location = new System.Drawing.Point(13, 13);
            this.lableComputerID.Name = "lableComputerID";
            this.lableComputerID.Size = new System.Drawing.Size(115, 13);
            this.lableComputerID.TabIndex = 0;
            this.lableComputerID.Text = "Computer Hardware ID";
            // 
            // computerID
            // 
            this.computerID.Location = new System.Drawing.Point(152, 10);
            this.computerID.Name = "computerID";
            this.computerID.Size = new System.Drawing.Size(418, 20);
            this.computerID.TabIndex = 1;
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(456, 104);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(114, 23);
            this.buttonOpen.TabIndex = 4;
            this.buttonOpen.Text = "Generate License";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "XML-File | *.xml";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "User Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Computer Name";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(152, 78);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(418, 20);
            this.txtUserName.TabIndex = 3;
            // 
            // txtComputerName
            // 
            this.txtComputerName.Location = new System.Drawing.Point(152, 43);
            this.txtComputerName.Name = "txtComputerName";
            this.txtComputerName.Size = new System.Drawing.Size(418, 20);
            this.txtComputerName.TabIndex = 2;
            // 
            // GenLicenseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 145);
            this.Controls.Add(this.txtComputerName);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.computerID);
            this.Controls.Add(this.lableComputerID);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GenLicenseForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Licensing";
            this.Load += new System.EventHandler(this.GenLicenseForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lableComputerID;
        private System.Windows.Forms.TextBox computerID;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtComputerName;
    }
}