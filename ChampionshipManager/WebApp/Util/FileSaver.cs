using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace WebApp.Util
{
    internal class FileSaver : IFileSaver
    {
        public string SaveFile(string directoryPath, HttpPostedFileBase file)
        {
            string fileName = file.FileName;
            string fullPath = Path.Combine(directoryPath, fileName);
            string extension = fileName.Split('.').Last();

            while (File.Exists(fullPath))
            {
                fileName = Guid.NewGuid().ToString().Substring(0, 11) + "." + extension; 
                fullPath = Path.Combine(directoryPath, fileName);
            }

            file.SaveAs(fullPath);

            return fileName;
        }
    }
}