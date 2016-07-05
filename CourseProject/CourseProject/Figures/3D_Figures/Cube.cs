using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject
{
    class Cube : Paralelipiped
    {
        public Cube()
        { 
        }

        public Cube(params Point3D[] po)
            : base(po)
        {
            if (!Rhombus.CheckEquality(po))
            {
                throw new ArgumentException();
            }
        }
    }
}
