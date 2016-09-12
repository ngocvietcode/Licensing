using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Licensing.Client
{
    public class LicenseAttributes
    {
        protected readonly XName childName;
        protected readonly XElement xmlData;


        internal LicenseAttributes(XElement xmlData, XName childName)
        {
            this.xmlData = xmlData ?? new XElement("null");
            this.childName = childName;
        }


        public virtual void Add( string value)
        {
            SetChildTag(nameof(value), value);
        }
        public virtual void Add(string key, string value)
        {
            SetChildTag(key, value);
        }


        public virtual void AddAll(IDictionary<string, string> features)
        {
            foreach (var feature in features)
                Add(feature.Key, feature.Value);
        }


        public virtual void Remove(string key)
        {
            var element =
                xmlData.Elements(childName)
                    .FirstOrDefault(e => e.Attribute("name") != null && e.Attribute("name").Value == key);

            if (element != null)
                element.Remove();
        }


        public virtual void RemoveAll()
        {
            xmlData.RemoveAll();
        }


        public virtual string Get(string key)
        {
            return GetChildTag(key);
        }


        public virtual IDictionary<string, string> GetAll()
        {
            return xmlData.Elements(childName).ToDictionary(e => e.Attribute("name").Value, e => e.Value);
        }


        public virtual bool Contains(string key)
        {
            return xmlData.Elements(childName).Any(e => e.Attribute("name") != null && e.Attribute("name").Value == key);
        }


        public virtual bool ContainsAll(string[] keys)
        {
            return
                xmlData.Elements(childName)
                    .All(e => e.Attribute("name") != null && keys.Contains(e.Attribute("name").Value));
        }

        protected virtual void SetTag(string name, string value)
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

        protected virtual void SetChildTag(string name, string value)
        {
            var element =
                xmlData.Elements(childName)
                    .FirstOrDefault(e => e.Attribute("name") != null && e.Attribute("name").Value == name);

            if (element == null)
            {
                element = new XElement(childName);
                element.Add(new XAttribute("name", name));
                xmlData.Add(element);
            }

            if (value != null)
                element.Value = value;
        }

        protected virtual string GetTag(string name)
        {
            var element = xmlData.Element(name);
            return element != null ? element.Value : null;
        }

        protected virtual string GetChildTag(string name)
        {
            var element =
                xmlData.Elements(childName)
                    .FirstOrDefault(e => e.Attribute("name") != null && e.Attribute("name").Value == name);

            return element != null ? element.Value : null;
        }
    }
}