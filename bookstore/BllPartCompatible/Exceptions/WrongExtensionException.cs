using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BllPart.Exceptions
{
    public class WrongExtensionException : ArgumentException
    {
        public WrongExtensionException() : base()
        {
        }

        public WrongExtensionException(string message) : base(message)
        {
        }
    }
}
