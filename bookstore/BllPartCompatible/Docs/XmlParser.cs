using BllPartCompatible.Docs.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace BllPartCompatible.Docs
{
    public class XmlParser
    {
        private static List<Func<XmlNode, IToken>> nodeParsers = new List<Func<XmlNode, IToken>>()
        {
            (new TextToken("")).FromXml 
        };

        public static IEnumerable<Page> ParseFile(string fileName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);

            XmlNode rootNode = doc.FirstChild;

            ICollection<Page> pages = new List<Page>();

            foreach (XmlNode pageNode in rootNode.ChildNodes)
            {
                pages.Add(parsePage(pageNode));
            }

            return pages;
        }

        private static Page parsePage(XmlNode node)
        {
            List<IToken> tokens = new List<IToken>();

            foreach (XmlNode tokenNode in node.ChildNodes)
            {
                foreach (var parser in nodeParsers)
                {
                    IToken token = parser(tokenNode.FirstChild);

                    if (token != null)
                    {
                        tokens.Add(token);
                        break;
                    }
                }
            }

            return new Page(tokens.ToArray());
        }
    }
}
