using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject
{
    class Rectangle: Paralelogram
    {
        public Rectangle()
        { 
        }

        public bool IsPerpendicular( Point[] p )
        {
            double[] d1 = Section.Equation(p[0], p[1]);
            double[] d2 = Section.Equation(p[2], p[3]);

            double arc1 = Math.Atan(d1[0]);
            double arc2 = Math.Atan(d2[0]);

            if ( (arc1 - (1.5*Math.PI + arc2)) <= 0.00000001 )
            {
                return true;
            }
            return false;
        }


        public Rectangle(params Point[] p)
        {
            if (p.Length == 0)
            {
                return;
            }
            //if ( !IsPerpendicular(p) )
            //{
            //    throw new ArgumentException();
            //}

            points = new Point[4];

            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new Point(p[i].X, p[i].Y);
            }

        }

        //public override void Move(double distance, double arc)
        //{
        //    foreach (var p in points)
        //    {
        //        p.Move(distance, arc);
        //    }
        //}

        //public override void Scale(double procent)
        //{
        //    Section diag1 = new Section(points[0], points[2]);
        //    Section diag2 = new Section(points[1], points[3]);

        //    diag1.Scale(procent);
        //    diag2.Scale(procent);
        //}

        public override double Square()
        {
            return Point.Distance(points[0] , points[1]) * Point.Distance(points[1], points[2]);
        }

        public override string ToString()
        {
            if (points == null)
            {
                return "";
            } 
            string s = " Rectangle  /n";
            s += "Begin Point - " + points[0].ToString() + "/n";
            s += "Width - " + Point.Distance(points[0], points[3]) + "/n";
            s += "Height - " + Point.Distance(points[0], points[1]);

            return s;

        }

    }
}
