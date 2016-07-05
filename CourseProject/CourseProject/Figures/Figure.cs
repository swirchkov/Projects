using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CourseProject
{
    [Serializable]
    class Figure : AbstractFigure
    {
        protected Point[] points;

        public override Point3D[] Points
        {
            get
            {
                Point3D[] p = new Point3D[points.Length];

                for (int i = 0; i < points.Length; i++)
                {
                    p[i] = new Point3D(points[i].X, points[i].Y, 0);
                }

                return p;
            }
        }

        public Figure()
        { 
        }

        public Figure(params Point[] p)
        {
            points = new Point[p.Length];

            for (int i = 0; i < p.Length; i++ )
            {
                points[i] = new Point(p[i].X, p[i].Y);
            }
        }

        public override void Move(double distance, double arc)
        {
            foreach (Point p in points)
            {
                p.Move(distance, arc);
            }
        }

        public override void MoveIntoPosition(double x, double y)
        {
            Point min = points[0];

            double dx, dy;

            for (int i = 0; i < points.Length; i++)
            {
                dx = points[i].X - min.X;
                dy = points[i].Y - min.Y;

                points[i] = new Point(x + dx, y + dy);
            }

        }

        //public override void Scale1(double procent)
        //{
        //    double centX = 0;
        //    double centY = 0;

        //    foreach (var p in Points)
        //    {
        //        centX += p.X;
        //        centY += p.Y;
        //    }

        //    var Center = new Point(centX / Points.Length, centY / Points.Length);

        //    MessageBox.Show(Center.ToString());

        //    double[] eq;
        //    double k;
        //    double b;

        //    double distance;
        //    double arc;

        //    foreach ( Point p in Points)
        //    {
        //        eq = Section.Equation(p, Center);
        //        k = eq[0];
        //        b = eq[1];

        //        distance = Point.Distance(p, Center);
        //        arc = Math.Atan(k);

        //        if (procent > 1)
        //        {
        //            distance *= (procent-1);
        //        }
        //        else
        //        {
        //            distance = distance - distance * procent;
        //            arc = Math.PI - arc;
        //        }

        //        p.Move(distance, arc);
        //    }
        //}

        public override void Scale(double procent)
        {
            Point start = points[0];

            for (int i = 1; i < points.Length; i++)
            {
                Section.Scale(ref start, ref points[i], procent);
            }
        }

        public override double Perimeter()
        {
            double res = Point.Distance(points[points.Length - 1], points[0]);

            for (int i = 1; i < points.Length; i++)
            {
                res += Point.Distance(points[i - 1], points[i]);
            }

            return res;
        }

        public override double Square()
        {
            Point start = points[0];

            double a;
            double b;
            double c;

            double p;
            double S = 0;

            for (int i = 1; i < points.Length - 1; i++)
            {
                a = Point.Distance(start, points[i]);
                b = Point.Distance(points[i], points[i + 1]);
                c = Point.Distance(points[i + 1], start);

                p = (a + b + c) / 2;

                S += Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            }

            return S;
        }

        public override void Paint(object sender, PaintEventArgs e)
        {
            float x1,y1,x2,y2;

            for (int i = 0; i < points.Length - 1 ; i++)
            {
                x1 = (float)points[i].X;
                y1 = (float)points[i].Y;

                x2 = (float)points[i + 1].X;
                y2 = (float)points[i + 1].Y;

                e.Graphics.DrawLine(new Pen(Color.Black), x1, y1, x2, y2);
            }

            x1 = (float)points[points.Length - 1].X;
            y1 = (float)points[points.Length - 1].Y;

            x2 = (float)points[0].X;
            y2 = (float)points[0].Y;

            e.Graphics.DrawLine(new Pen(Color.Black), x1, y1, x2, y2);
        }

        public override string ToString()
        {
            return "Figure with " + this.points.Length + " Points";
        }
    }
}
