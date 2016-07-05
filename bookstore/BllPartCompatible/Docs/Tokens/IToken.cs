using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace BllPartCompatible.Docs.Tokens
{
    public interface IToken
    {
        string ToXml();
        string ToHtml();
        IToken FromXml(XmlNode node);
    }
}
