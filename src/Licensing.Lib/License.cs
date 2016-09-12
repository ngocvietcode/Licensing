﻿using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Licensing.Client.Security.Cryptography;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Security;

namespace Licensing.Client
{
    public class License
    {
        private readonly string signatureAlgorithm = X9ObjectIdentifiers.ECDsaWithSha512.Id;
        private readonly XElement xmlData;


        internal License()
        {
            xmlData = new XElement("License");
        }


        internal License(XElement xmlData)
        {
            this.xmlData = xmlData;
        }


        public Guid Id
        {
            get { return new Guid(GetTag("Id") ?? Guid.Empty.ToString()); }
            set { if (!IsSigned) SetTag("Id", value.ToString()); }
        }


        public LicenseType Type
        {
            get
            {
                return
                    (LicenseType)
                        Enum.Parse(typeof (LicenseType), GetTag("Type") ?? LicenseType.Trial.ToString(), false);
            }
            set { if (!IsSigned) SetTag("Type", value.ToString()); }
        }


        public Customer Customer
        {
            get
            {
                var xmlElement = xmlData.Element("Customer");

                if (!IsSigned && xmlElement == null)
                {
                    xmlData.Add(new XElement("Customer"));
                    xmlElement = xmlData.Element("Customer");
                }
                else if (IsSigned && xmlElement == null)
                {
                    return null;
                }

                return new Customer(xmlElement);
            }
        }


        public LicenseAttributes AdditionalAttributes
        {
            get
            {
                var xmlElement = xmlData.Element("LicenseAttributes");

                if (!IsSigned && xmlElement == null)
                {
                    xmlData.Add(new XElement("LicenseAttributes"));
                    xmlElement = xmlData.Element("LicenseAttributes");
                }
                else if (IsSigned && xmlElement == null)
                {
                    return null;
                }

                return new LicenseAttributes(xmlElement, "Attribute");
            }
        }

        public DateTime Expiration
        {
            get
            {
                return
                    DateTime.ParseExact(
                        GetTag("Expiration") ??
                        DateTime.MaxValue.ToUniversalTime().ToString("r", CultureInfo.InvariantCulture)
                        , "r", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
            }
            set
            {
                if (!IsSigned) SetTag("Expiration", value.ToUniversalTime().ToString("r", CultureInfo.InvariantCulture));
            }
        }

        public string Signature
        {
            get { return GetTag("Signature"); }
        }


        private bool IsSigned
        {
            get { return (!string.IsNullOrEmpty(Signature)); }
        }


        public void Sign(string privateKey, string passPhrase)
        {
            var signTag = xmlData.Element("Signature") ?? new XElement("Signature");

            try
            {
                if (signTag.Parent != null)
                    signTag.Remove();

                var privKey = KeyFactory.FromEncryptedPrivateKeyString(privateKey, passPhrase);

                var documentToSign = Encoding.UTF8.GetBytes(xmlData.ToString(SaveOptions.DisableFormatting));
                var signer = SignerUtilities.GetSigner(signatureAlgorithm);
                signer.Init(true, privKey);
                signer.BlockUpdate(documentToSign, 0, documentToSign.Length);
                var signature = signer.GenerateSignature();
                signTag.Value = Convert.ToBase64String(signature);
            }
            finally
            {
                xmlData.Add(signTag);
            }
        }


        public bool VerifySignature(string publicKey)
        {
            var signTag = xmlData.Element("Signature");

            if (signTag == null)
                return false;

            try
            {
                signTag.Remove();

                var pubKey = KeyFactory.FromPublicKeyString(publicKey);

                var documentToSign = Encoding.UTF8.GetBytes(xmlData.ToString(SaveOptions.DisableFormatting));
                var signer = SignerUtilities.GetSigner(signatureAlgorithm);
                signer.Init(false, pubKey);
                signer.BlockUpdate(documentToSign, 0, documentToSign.Length);

                return signer.VerifySignature(Convert.FromBase64String(signTag.Value));
            }
            finally
            {
                xmlData.Add(signTag);
            }
        }


        public static ILicenseBuilder New()
        {
            return new LicenseBuilder();
        }


        public static License Load(string xmlString)
        {
            return new License(XElement.Parse(xmlString, LoadOptions.None));
        }


        public static License Load(Stream stream)
        {
            return new License(XElement.Load(stream, LoadOptions.None));
        }


        public static License Load(TextReader reader)
        {
            return new License(XElement.Load(reader, LoadOptions.None));
        }


        public static License Load(XmlReader reader)
        {
            return new License(XElement.Load(reader, LoadOptions.None));
        }


        public void Save(Stream stream)
        {
            xmlData.Save(stream);
        }


        public void Save(TextWriter textWriter)
        {
            xmlData.Save(textWriter);
        }


        public void Save(XmlWriter xmlWriter)
        {
            xmlData.Save(xmlWriter);
        }


        public override string ToString()
        {
            return xmlData.ToString();
        }

        private void SetTag(string name, string value)
        {
            var element = xmlData.Element(name);

            if (element == null)
            {
                element = new XElement(name);
                xmlData.Add(element);
            }

            if (value != null)
                element.Value = value;
        }

        private string GetTag(string name)
        {
            var element = xmlData.Element(name);
            return element != null ? element.Value : null;
        }
    }
}