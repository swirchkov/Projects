using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject
{
    [Serializable]
    public class Point3D : Point
    {
        public double Z;

        public Point3D()
        { 
        }

        public Point3D(double x, double y, double z)
            : base(x, y)
        {
            Z = z;
        }

        public override string ToString()
        {
            return base.ToString() + " Z - " + Z;
        }

        public static double Distance3D(Point3D p1, Point3D p2)
        {
            return Math.Sqrt(Math.Pow((p1.X - p2.X), 2) + Math.Pow((p1.Y - p2.Y), 2) + Math.Pow((p1.Z - p2.Z), 2));
        }

        public static Point3D operator - (Point3D lhs, Point3D rhs)
        {
            return new Point3D(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z);
        }
    }
}
