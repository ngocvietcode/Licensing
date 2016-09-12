using System;
using System.IO;
using Licensing.App;

namespace Licensing.Client
{
    public static class LicenseValidationExtensions
    {
        internal const string PassPhrase = "5be6d121-2d55-4b22-85dd-a34f6b1ebf3e";

        internal const string PublicKey =
            "MIIBKjCB4wYHKoZIzj0CATCB1wIBATAsBgcqhkjOPQEBAiEA/////wAAAAEAAAAAAAAAAAAAAAD///////////////8wWwQg/////wAAAAEAAAAAAAAAAAAAAAD///////////////wEIFrGNdiqOpPns+u9VXaYhrxlHQawzFOw9jvOPD4n0mBLAxUAxJ02CIbnBJNqZnjhE50mt4GffpAEIQNrF9Hy4SxCR/i85uVjpEDydwN9gS3rM6D0oTlF2JjClgIhAP////8AAAAA//////////+85vqtpxeehPO5ysL8YyVRAgEBA0IABLjYGEBL0t/aDNgIA8h5c4EBQ6+FEUg7j82ni9TpWiM1iGYN/Nu9FPXLy4anXWVfYJDkLfkZEpYKokGcpgVCeUU=";

        public static License LoadLicenseFile()
        {
            try
            {
                return
                    License.Load(
                        File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                                         "\\CEGCustomMenu\\license.xml"));
            }
            catch
            {
                return null;
            }
        }
        private static void EnsureFolderExist(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public static void SaveLicenseToFile(this License license)
        {
            string licensePath = (Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                                  "\\CEGCustomMenu");
            EnsureFolderExist(licensePath);
            using (
                TextWriter writer =
                    File.CreateText(licensePath +
                                    "\\license.xml"))
            {
                license.Save(writer);
            }
        }

        public static bool Validate(this License license, string publicKey = PublicKey)
        {
             return license.VerifySignature(publicKey) && license.IsNotExprired() && license.IsForThisComputer();
             
        }

        private static bool IsNotExprired(this License license)
        {
            return license.Type == LicenseType.Standard || license.Expiration > DateTime.Now;
        }

        private static bool IsForThisComputer(this License license)
        {
            var computerInfor = license.AdditionalAttributes.Get("computerInfor");
            var computerName = license.AdditionalAttributes.Get("computerName");
            var userName = license.AdditionalAttributes.Get("userName");

            if (!FingerPrint.Value().Equals(computerInfor))
                throw new Exception("Invalid Computer Information");

            if (!Environment.MachineName.Equals(computerName))
                throw new Exception("Invalid Computer Name");

            if (!Environment.UserName.Equals(userName))
                throw new Exception("Invalid User Name");

            return true;
        }

        public static bool ShowLicenseForm()
        {
            var form = new  LicenseForm();
            form.ShowDialog();
            return form.IsValid;
        }
    }
}