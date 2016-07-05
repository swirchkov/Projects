using BllPartCompatible.Docs;
using BllPartCompatible.Docs.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleInitializer.DocTests
{
    public static class TxtTester
    {
        private static readonly string fileSrcPath = "src.txt";
        private static readonly string fileDestPath = "result.xml";

        public static void TestCreate()
        {
            TxtHelper helper = new TxtHelper(fileSrcPath);
            helper.ConvertToXml(fileDestPath);
        }

        public static void TestRead()
        {
            foreach (Page page in XmlParser.ParseFile(fileDestPath))
            {
                Console.WriteLine(page.First().ToString());
            }
        }
    }
}
