using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Licensing.Client;

namespace Licensing.App
{
    public partial class LicenseForm : Form
    {
        public bool IsValid = false;
        public LicenseForm()
        {
            InitializeComponent();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            var result = openLicenseFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                var file = openLicenseFile.FileName;

                try
                {
                    txtLicense.Text = File.ReadAllText(file);
                    var license = License.Load(txtLicense.Text);
                    if (license.ValidateWithException())
                    {
                        license.SaveLicenseToFile();
                        IsValid = true;
                        labelLicenseStatus.Text = "Valid";
                        labelLicenseStatus.ForeColor = Color.Green;
                    }
                    else
                    {
                        labelLicenseStatus.Text = "Invalid";
                        labelLicenseStatus.ForeColor = Color.Red;
                    }
                }
                catch (Exception exception)
                {
                    labelLicenseStatus.Text = exception.Message;
                    labelLicenseStatus.ForeColor = Color.Red;
                }
            }
        }

        private void LicenseForm_Load(object sender, EventArgs e)
        {
            textComputerID.Text = FingerPrint.Value();
            txtComputerName.Text = Environment.MachineName;
            txtUserName.Text = Environment.UserName;
            
            try
            {
                var license = LicenseValidationExtensions.LoadLicenseFile();
                if (license == null)
                {
                    labelLicenseStatus.Text = "License not found.";
                    labelLicenseStatus.ForeColor = Color.Indigo;
                }
                if (license != null)
                {
                    txtLicense.Text = license.ToString();

                    if (license.ValidateWithException())
                    {
                        IsValid = true;
                        labelLicenseStatus.Text = "Valid";
                        labelLicenseStatus.ForeColor = Color.Green;
                    }
                    else
                    {
                        labelLicenseStatus.Text = "Invalid";
                        labelLicenseStatus.ForeColor = Color.Red;
                    }
                }
            }
            catch (Exception exception)
            {
                labelLicenseStatus.Text = exception.Message;
                labelLicenseStatus.ForeColor = Color.Red;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}