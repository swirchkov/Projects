using BllPartCompatible.Docs.Tokens;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace BllPartCompatible.Docs.Helpers
{
    public class TxtHelper
    {
        private readonly int pageSize = 40;
        private string fileName = null;
        private ICollection<Page> pages = null;

        public TxtHelper(string fileName)
        {
            this.fileName = fileName;

            using (TextReader reader = new StreamReader(fileName, Encoding.Default))
            {
                string content = "";
                string line = null;

                int index = 0;
                pages = new List<Page>();

                while ((line = reader.ReadLine()) != null)
                {
                    index++;
                    content += line + Environment.NewLine;

                    if (index == pageSize)
                    {
                        pages.Add(new Page(new TextToken(content)));
                        index = 0;
                        content = "";
                    }
                }

                if (content.Length != 0)
                {
                    pages.Add(new Page(new TextToken(content)));
                }
            }
        }

        public void ConvertToXml(string fileName)
        {
            XmlGenerator.Save(pages, fileName);
        }
    }
}
