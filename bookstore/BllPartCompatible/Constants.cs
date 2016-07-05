using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BllPart
{
    public static class Constants
    {
        public static bool IsInitialized
        {
            get
            {
                return Connection != null;
            }
        }

        public static string Connection { get; set; }
    }
}
