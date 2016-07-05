using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject
{
    [Serializable]
    class Rhombus : Paralelogram
    {
        public Rhombus()
        { 
        }

        public Rhombus(params Point[] points)
            : base(points)
        {
            if (!CheckEquality(points))
            {
                throw new ArgumentException();
            }

        }

        public Rhombus(double a, double arc) : base (a,a,arc)
        {
        }
        public static bool CheckEquality(Point[] p)
        {
            double distance = Point.Distance(p[p.Length - 1], p[0]);

            for (int i = 0; i < p.Length - 1; i++)
            {
                if (distance - Point.Distance(p[i], p[i + 1]) > 0.0001)
                {
                    return false;
                }
            }

            return true;
        }

        public override string ToString()
        {
            string s = "Rhombus";

            foreach(var p in points)
            {
                s += " Point - " + p.X + " " + p.Y; 
            }

            return s;
        }
    }
}
