using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject
{
    class InclinedPrisma : Prizma
    {
        public InclinedPrisma(params Point3D[] p) : base(p)
        {
            if (IsPerpendicularToOsn())
            {
                throw new ArgumentException();
            }
        }

        public bool IsPerpendicularToOsn()
        {
            return false;
        }
    }
}
