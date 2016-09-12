using System.Xml.Linq;

namespace Licensing.Client
{
    public class Customer : LicenseAttributes
    {
        internal Customer(XElement xmlData)
            : base(xmlData, "CustomerData")
        {
        }


        public string Name
        {
            get { return GetTag("Name"); }
            set { SetTag("Name", value); }
        }


        public string Company
        {
            get { return GetTag("Company"); }
            set { SetTag("Company", value); }
        }


        public string Email
        {
            get { return GetTag("Email"); }
            set { SetTag("Email", value); }
        }
    }
}