using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using Licensing.Client;
using License = Licensing.Client.License;

namespace Licensing.App
{
    public partial class GenLicenseForm : Form
    {
        public GenLicenseForm()
        {
            InitializeComponent();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            var name = saveFileDialog1.FileName;
            var license = License.New()
                .WithProductId(new Guid(LicenseValidationExtensions.ProductID))
                .As(LicenseType.Standard)
                .WithComputerInformation(computerID.Text)
                .WithComputerName(txtComputerName.Text)
                .WithUserName(txtUserName.Text)
                .CreateAndSignWithPrivateKey(LicenseValidationExtensions.PrivateKey,
                    LicenseValidationExtensions.PassPhrase);
            using (TextWriter writer = File.CreateText(name))
            {
                license.Save(writer);
            }
        }

        private void GenLicenseForm_Load(object sender, EventArgs e)
        {

        }
    }
}