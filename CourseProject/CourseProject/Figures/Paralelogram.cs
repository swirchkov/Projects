using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject
{
    [Serializable]
    class Paralelogram : Polygone
    {
        public Paralelogram()
        { 
        }

        public Paralelogram(params Point[] p): base(p)
        {
            if (p.Length != 4)
            {
                throw new ArgumentException();
            }

            try
            {
                if (!CheckParalel(Points))
                {
                    throw new ArgumentException();
                }
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
        }

        public Paralelogram(double a, double b, double arc)
        {
            points = new Point[4];

            arc = (arc / 180) * Math.PI;
            points[0] = new Point(0, 0);

            points[1] = new Point(b * Math.Cos(arc), b * Math.Sin(arc));

            points[2] = new Point(b * Math.Cos(arc) + a, b * Math.Sin(arc));

            points[3] = new Point(a, 0);
        }

        public static bool CheckParalel(Point[] Points)
        {
            Section s1 = new Section(Points[0], Points[1]);
            Section s2 = new Section(Points[3], Points[2]);

            if (s1.k != s2.k)
            {
                return false; 
            }

            s1 = new Section(Points[0], Points[3]);
            s2 = new Section(Points[1], Points[2]);

            if (s1.k != s2.k)
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            string s = "Paralelogram";

            for (int i = 0; i < points.Length; i++)
            {
                s += points[i].X + " " + points[i].Y + "/n";
            }
            return s;
        }
    }
}
