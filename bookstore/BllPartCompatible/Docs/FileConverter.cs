using BllPartCompatible.Docs.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BllPartCompatible.Docs
{
    public class FileConverter
    {
        private readonly string[] txtExtensions = { "txt" }; 
        public bool TryConvert(string fileName, string destPath)
        { 
            string extension = fileName.Split('.').Last();

            if (txtExtensions.Contains(extension))
            {
                TxtHelper helper = new TxtHelper(fileName);
                helper.ConvertToXml(destPath);

                return true;
            }

            return false;
        }
    }
}
