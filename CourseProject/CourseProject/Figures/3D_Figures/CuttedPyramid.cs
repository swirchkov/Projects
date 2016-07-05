using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject
{
    class CuttedPyramid : Prizma
    {
        public new Point3D[] up;

        public CuttedPyramid(params Point3D[] points) : base(points)
        {
            if (!IsIntersect())
            {
                throw new ArgumentException();
            }

        }

        public bool IsIntersect()
        {
            return true;
        }
    }
}
