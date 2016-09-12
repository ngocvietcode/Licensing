using System;

namespace Licensing.Client
{
    internal class LicenseBuilder : ILicenseBuilder
    {
        private readonly License license;

        public LicenseBuilder()
        {
            license = new License();
        }

        public ILicenseBuilder WithProductId(Guid id)
        {
            license.Id = id;
            return this;
        }

        public ILicenseBuilder As(LicenseType type)
        {
            license.Type = type;
            return this;
        }

        public ILicenseBuilder ExpiresAt(DateTime date)
        {
            license.Expiration = date.ToUniversalTime();
            return this;
        }


        public ILicenseBuilder LicensedTo(string name, string email)
        {
            license.Customer.Name = name;
            license.Customer.Email = email;
            return this;
        }

        public ILicenseBuilder WithComputerInformation(string computerInformation)
        {
            license.AdditionalAttributes.Add("computerInfor", computerInformation);
            return this;
        }

        public License CreateAndSignWithPrivateKey(string privateKey, string passPhrase)
        {
            license.Sign(privateKey, passPhrase);
            return license;
        }

        public ILicenseBuilder WithComputerName(string computerName)
        {
            license.AdditionalAttributes.Add("computerName", computerName);
            return this;
        }

        public ILicenseBuilder WithUserName(string userName)
        {
            license.AdditionalAttributes.Add("userName", userName);
            return this;
        }

        //}
        //    return license;
        //    license.Sign(LicenseValidationExtensions.PrivateKey, LicenseValidationExtensions.PassPhrase);
        //{

        //public License CreateAndSignWithDefaultPrivateKey()
    }
}