using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject
{
    class Trapezien : Figure
    {
        public Trapezien()
        { 
        }

        public Trapezien(params Point[] poin) : base(poin)
        {
            Section s1 = new Section(poin[0], poin[3]);
            Section s3 = new Section(poin[1], poin[2]);

            Section s2 = new Section(poin[0], poin[1]);
            Section s4 = new Section(poin[2], poin[3]);

            if ((s1.k == s3.k) && (s2.k != s4.k))
            {
                return;
            }

            if ((s1.k != s3.k) && (s2.k == s4.k))
            {
                return;
            }

            throw new ArgumentException();
            
        }

        public Trapezien(double a, double b, double h, double arc)
        {
            if (a > b)
            {
                b = a;
            }

            points = new Point[4];
            points[0] = new Point(0, 0);
            points[1] = new Point(b*Math.Cos(arc), h);
            points[2] = new Point(b*Math.Cos(arc) + a, h);
            points[3] = new Point(b, 0);


        }
        public override string ToString()
        {
            string s = "Trapezien";

            foreach (var p in points)
            {
                s += " Point - " + p.X + " " + p.Y;
            }

            return s;
        }
    }
}
