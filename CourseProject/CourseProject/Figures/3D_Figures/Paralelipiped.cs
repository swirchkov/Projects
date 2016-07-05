using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject
{
    [Serializable]
    class Paralelipiped : Prizma
    {
        public Paralelipiped()
        { 
        }

        public Paralelipiped(params Point3D[] po)
            : base(po)
        {
            if (po.Length != 8)
            {
                throw new ArgumentException();
            }

            var d = new List<Point>();
            var u = new List<Point>();

            for (int i = 0; i < down.Length; i++)
            {
                d.Add((Point)down[i]);
                u.Add((Point)up[i]);
            }

            if (!(Paralelogram.CheckParalel(d.ToArray()) && Paralelogram.CheckParalel(u.ToArray())))
            {
                throw new ArgumentException();
            }
        }
    }
}
