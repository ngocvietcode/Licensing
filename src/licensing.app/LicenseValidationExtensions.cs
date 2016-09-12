using System;
using System.IO;
using Licensing.Client;

namespace Licensing.App
{
    public static class LicenseValidationExtensions
    {
        internal const string ProductID = "1e9114a9-56b1-4e59-9ace-9df8504deca0";
        internal const string PassPhrase = "5be6d121-2d55-4b22-85dd-a34f6b1ebf3e";

        internal const string PrivateKey =
            "MIICITAjBgoqhkiG9w0BDAEDMBUEEJ4+S+7BTrJvM/OLWU5F1voCAQoEggH4dQHUqj1bSq5qLype8pkG/ELgW4S/rUiKIQ6fA/XrhYwRszH8R1B2xQfkMrMSvNlxzPb6xtcfQZDi58lH+t36nBJ6XS/lRmqjI1oq+c4sfgWGNvITeMDYy9fw0LGSiw8wqfePZtU0a65QzCZliOYCaiawpgyGxbWD//oN2FgJ2NERvIF1mEYi14VhdsaU096eMh3DGNbJ98NUwtvVbOgM9fpgrsyvGWbo60OsfoWTVDr9tO2s/Wh9dNKQgUlJuqRIzxSN7L/5GoyqF75uIBh0D6tam4drjKFznvAUX2mn1r5nYZ5Xp+5P/5tYmuhHLyhatFsZPsZR0jGZy4UjEiPWvfQMePSwFCorhxQgBzTjdqinVuw67GtTCp+A8Ilr9BamcOZNnwkllg2TAxDaJnPO9WrVyOpgEejWFWGlk1BDRSjvKSYwyBcW1hWNOUgOIuoeDYVQb2SCYjsrpgewrw7dhGt584pMWeNsOh4l1zADjoPQAzQLb537HOixafUMVru4FQFGgUGRnPx9QALVen1aRgaVvqhv/72dItVb8nBp6GmbEM+ndTL+q04+urtVdZxUYVhSAEuGcjj2bg/WFKfo2QSQYI76r7aC6y1AxI7KVoIRYIAXZoh5gi16P+KfmCDTXkQpAksfH7WUQEXU40iDQtG5d41xi7nX";

        internal const string PublicKey =
            "MIIBKjCB4wYHKoZIzj0CATCB1wIBATAsBgcqhkjOPQEBAiEA/////wAAAAEAAAAAAAAAAAAAAAD///////////////8wWwQg/////wAAAAEAAAAAAAAAAAAAAAD///////////////wEIFrGNdiqOpPns+u9VXaYhrxlHQawzFOw9jvOPD4n0mBLAxUAxJ02CIbnBJNqZnjhE50mt4GffpAEIQNrF9Hy4SxCR/i85uVjpEDydwN9gS3rM6D0oTlF2JjClgIhAP////8AAAAA//////////+85vqtpxeehPO5ysL8YyVRAgEBA0IABLjYGEBL0t/aDNgIA8h5c4EBQ6+FEUg7j82ni9TpWiM1iGYN/Nu9FPXLy4anXWVfYJDkLfkZEpYKokGcpgVCeUU=";

        public static License LoadLicenseFile()
        {
            try
            {
                return
                    License.Load(
                        File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                                         "\\key.xml"));
            }
            catch
            {
                return null;
            }
        }

        public static void SaveLicenseToFile(this License license)
        {
            using (
                TextWriter writer =
                    File.CreateText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\key.xml"))
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
            var infor = license.AdditionalAttributes.Get("computerInfor");
            if (string.IsNullOrEmpty(infor)) return true;
            return FingerPrint.Value().Equals(infor);
        }
    }
}