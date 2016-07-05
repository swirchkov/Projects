using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace BllPartCompatible.Docs.Tokens
{
    public class TextToken : IToken
    {
        private string text;

        public TextToken(string text)
        {
            this.text = text;
        }

        public IToken FromXml(XmlNode node)
        {
            if (node.Name != "paragraph")
            {
                return null;
            }
            return new TextToken(node.InnerText);
        }

        public string ToXml()
        {
            text = text.Replace("<", "&lt;");
            text = text.Replace(">", "&gt;");
            text = text.Replace("&", "&amp;");
            text = text.Replace("'", "&apos;");
            text = text.Replace("\"", "&quot;");

            return $"<paragraph> { text } </paragraph>";
        }

        public string ToHtml()
        {
            // TODO: replace html inside text
            text = text.Replace("<", "&lt;");
            text = text.Replace(">", "&gt;");
            text = text.Replace(Environment.NewLine, "<br />");
            text = text.Replace("&lt;br /&gt;", "<br />");

            return $" <span> { text } </span> ";
        }
        public override string ToString()
        {
            return text;
        }
    }
}
