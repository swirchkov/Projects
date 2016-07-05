using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject
{
    class Section3D : Section
    {
        private Point3D start, end;

        public Section3D(Point3D st, Point3D end)
        {
            this.start = st;
            this.end = end;
        }

        public static void Scale(ref Point3D p1, ref Point3D p2, double procent)
        {
            double dx = p2.X - p1.X;
            double dy = p2.Y - p1.Y;
            double dz = p2.Z - p1.Z;

            dx *= procent;
            dy *= procent;
            dz *= procent;

            p2.X = p1.X + dx;
            p2.Y = p1.Y + dy;
            p2.Z = p1.Z + dz;
        }
    }
}
