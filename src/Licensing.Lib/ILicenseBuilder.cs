using System;

namespace Licensing.Client
{
    public interface ILicenseBuilder : IFluentInterface
    {
        ILicenseBuilder WithProductId(Guid id);

        ILicenseBuilder As(LicenseType type);
        ILicenseBuilder ExpiresAt(DateTime date);
        ILicenseBuilder LicensedTo(string name, string email);
        ILicenseBuilder WithComputerInformation(string computerInformation);
        ILicenseBuilder WithComputerName(string computerName);
        ILicenseBuilder WithUserName(string userName);
        License CreateAndSignWithPrivateKey(string privateKey, string passPhrase);
    }
}