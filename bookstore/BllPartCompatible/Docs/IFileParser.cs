using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BllPartCompatible.Docs
{
    public interface IFileParser
    {
        bool TryParse(string srcPath, string destPath);
    }
}
