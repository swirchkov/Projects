using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WebApp.Util
{
    internal interface IFileSaver
    {
        string SaveFile(string directoryPath, HttpPostedFileBase file);
    }
}
