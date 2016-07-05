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
    class Section : AbstractFigure
    {
        private Point start;
        private Point end;

        public double k;
        public double b;

        public override Point3D[] Points
        {
            get
            {
                Point3D[] p = new Point3D[2];
                p[0] = new Point3D(start.X, start.Y, 0);
                p[1] = new Point3D(end.X, end.Y, 0);

                return p;
            }
        }

        public static double[] Equation(Point start, Point end)                      // Find equation in y = k*x + b;
        {
            double[] res = new double[2];

            double x1 = start.X;
            double y1 = start.Y;

            double x2 = end.X;
            double y2 = end.Y;

            res[0] = (y2 - y1) / (x2 - x1);
            res[1] = (x2 * y1 - x1 * y2) / (x2 - x1);
            return res;
        }

        public Section()
        {
            start = new Point();
            end = new Point();
        }

        public Section(Point p1, Point p2)
        {
            start = p1;
            end = p2;
            double[] d = Section.Equation(start, end);

            this.k = d[0];
            this.b = d[1];
        }

        public override void Move(double distance, double arc)
        {
            start.Move( distance, arc );
            end.Move( distance, arc );
        }

        public override void MoveIntoPosition(double x, double y)
        {
            var dx = end.X - start.X;
            var dy = end.Y - start.Y;

            start = new Point(x, y);
            end = new Point(x + dx, y + dy);
        }

        public override void Scale(double procent)
        {
            //Point Centre = new Point((start.X + end.X) / 2, (start.Y + end.Y) / 2);

            //double arc = Math.Atan(Equation(Centre, start)[0]);              // k = tg(A);
            //double distance = Point.Distance(Centre, start);

            //if (procent > 1)
            //{
            //    distance = procent*distance - distance;
            //}
            //else 
            //{
            //    distance = distance - distance*procent;
            //    arc = Math.PI - arc;
            //}

            //start.Move(distance, Math.PI - arc);
            //end.Move(distance, arc);

            Section.Scale(ref start, ref end, procent);

        }

        //public static void Scale(ref Point p1, ref Point p2, double procent)
        //{
        //    double[] equation = Section.Equation(p1, p2);
        //    double k = equation[0];
        //    double b = equation[1];
        //    double L = Point.Distance(p1, p2);
        //    double Alfa = Math.Abs(procent - 1);

        //    double Descrim = 4 * (b * b) * (k * k) - 4 * ((k * k) + 1) * ((b * b) - (L * L) * (Alfa * Alfa));

        //    double x1 = ((-2) * b * k - Math.Sqrt(Descrim)) / (2 * ((k * k) + 1));
        //    double y1 = k * x1 + b;

        //    double x2 = ((-2) * b * k + Math.Sqrt(Descrim)) / (2 * ((k * k) + 1));
        //    double y2 = k * x2 + b;

        //    MessageBox.Show(x1.ToString() + " " + y1.ToString());
        //    MessageBox.Show(x2.ToString() + " " + y2.ToString());

        //    double dist1 = Point.Distance(p1, new Point(x1, y1));
        //    double dist2 = Point.Distance(p1, new Point(x1, y1));

        //    if (procent < 1)
        //    {
        //        if ( dist1 < dist2)
        //        {
        //            p2.X = x1;
        //            p2.Y = y1;
        //        }
        //        else
        //        {
        //            p2.X = x2;
        //            p2.Y = y2;
        //        }
        //    }
        //    else
        //    {
        //        if (dist1 > dist2)
        //        {
        //            p2.X = x1;
        //            p2.Y = y1;
        //        }
        //        else
        //        {
        //            p2.X = x2;
        //            p2.Y = y2;
        //        }
        //    }

        //}

        public static void Scale(ref Point p1, ref Point p2, double procent)
        {
            double dx = p2.X - p1.X;
            double dy = p2.Y - p1.Y;

            dx *= procent;
            dy *= procent;

            p2.X = p1.X + dx;
            p2.Y = p1.Y + dy;
        }

        public override void Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.Black), new PointF((float) start.X,  (float) start.Y), new PointF( (float) end.X, (float) end.Y));
        }

        public override double Perimeter()
        {
            return Point.Distance(start, end);
        }

        public override string ToString()
        {
            return "Section: " + start.ToString() + " " + end.ToString();
        }
    }
}
