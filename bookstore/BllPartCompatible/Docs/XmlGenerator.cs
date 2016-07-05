using BllPartCompatible.Docs.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace BllPartCompatible.Docs
{
    public static class XmlGenerator
    {
        public static void Save(IEnumerable<Page> pages, string fileName)
        {
            XmlDocument doc = new XmlDocument();

            XmlElement rootElement = doc.CreateElement("pages");

            foreach (var page in pages)
            {
                rootElement.AppendChild(getPageElement(page, doc));
            }

            doc.AppendChild(rootElement);

            doc.Save(fileName);
        }

        private static XmlElement getPageElement(Page page, XmlDocument doc)
        {
            XmlElement element = doc.CreateElement("page");

            foreach (IToken token in page)
            {
                XmlNode node = doc.CreateElement("token");
                node.InnerXml = token.ToXml();
                element.AppendChild(node);
            }

            return element;
        }
    }
}
