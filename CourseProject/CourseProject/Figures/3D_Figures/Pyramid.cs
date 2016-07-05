using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CourseProject
{
    class Pyramid : AbstractFigure
    {
        public Point3D[] down;
        public double deltaZ;
        private double downZ;
        public Point3D up;

        public override Point3D[] Points
        {
            get
            {
                Point3D[] res = new Point3D[down.Length + 1];

                for (int i = 0; i < down.Length; i++)
                {
                    res[i] = down[i];
                }

                res[res.Length - 1] = up;
                return res;
            }
        }

        public Pyramid()
        { 
        }

        public Pyramid(params Point3D[] points)
        {
            up = new Point3D(points[points.Length - 1].X, points[points.Length - 1].Y, points[points.Length - 1].Z);

            down = new Point3D[points.Length - 1];

            for (int i = 0; i < down.Length; i++)
            {
                down[i] = new Point3D(points[i].X, points[i].Y, points[i].Z);
            }

            double sumZ =0;
            for (int i = 0; i < down.Length; i++)
            {
                sumZ += down[i].Z;
            }

            downZ = sumZ / down.Length;
            deltaZ = up.Z - downZ;

        }

        public override void Move(double distance, double arc)
        {
            for (int i = 0; i < down.Length; i++)
            {
                down[i].Move(distance, arc);
            }
            up.Move(distance, arc);
        }

        public override double Perimeter()
        {
            double s = 0;

            s = Point3D.Distance3D(down[down.Length - 1], down[0]);

            for (int i = 0; i < down.Length -1; i++)
            {
                s += Point3D.Distance3D(down[i], down[i + 1]);
            }

            for (int i = 0; i < down.Length; i++)
            {
                s += Point3D.Distance3D(down[i] , up);
            }

            return s;
        }

        public override double Square()
        {
            double res = 0;

            double a, b, c;
            double p;

            for (int i = 1; i < down.Length - 1 ; i++)
            {
                a = Point3D.Distance3D(down[0], down[i]);
                b = Point3D.Distance3D(down[i], down[i + 1]);
                c = Point3D.Distance3D(down[i + 1], down[0]);

                p = (a + b + c) / 2;

                res += Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            }

            for (int i = 0; i < down.Length - 1 ; i++)
            {
                a = Point3D.Distance3D(up, down[i]);
                b = Point3D.Distance3D(down[i], down[i + 1]);
                c = Point3D.Distance3D(down[i + 1], up);

                p = (a + b + c) / 2;

                res += Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            }
            return res;
        }

        public override void Scale(double procent)
        {
            double centX = 0;
            double centY = 0;

            foreach (var p in down)
            {
                centX += p.X;
                centY += p.Y;
            }

            var Center = new Point(centX / down.Length, centY / down.Length);

            MessageBox.Show(Center.ToString());

            double[] eq;
            double k;
            double b;

            double distance;
            double arc;

            foreach (Point3D p in down)
            {
                eq = Section.Equation(p, Center);
                k = eq[0];
                b = eq[1];

                distance = Point.Distance(p, Center);
                arc = Math.Atan(k);

                if (procent > 1)
                {
                    distance *= (procent - 1);
                }
                else
                {
                    distance = distance - distance * procent;
                    arc = Math.PI - arc;
                }

                p.Move(distance, arc);
            }

            deltaZ *= procent;

            up.Z = downZ + deltaZ;
        }

        public override void Paint(object sender, PaintEventArgs e)
        {
            float x1, y1, x2, y2;

            x1 = (float) down[down.Length - 1].X;
            y1 = (float) down[down.Length - 1].Y;

            x2 = (float)down[0].X;
            y2 = (float)down[0].Y;

            Pen p = new Pen(Color.Black);
            e.Graphics.DrawLine(p, x1, y1, x2, y2);

            x2 = (float)up.X;
            y2 = (float)(up.Y + deltaZ);

            e.Graphics.DrawLine(p, x1, y1, x2, y2);

            for (int i = 0; i < down.Length - 1; i++)
            {
                x1 = (float)down[i].X;
                y1 = (float)down[i].Y;

                x2 = (float)down[i + 1].X;
                y2 = (float)down[i + 1].Y;

                e.Graphics.DrawLine(p, x1, y1, x2, y2);

                x2 = (float)up.X;
                y2 = (float)(up.Y + deltaZ);

                e.Graphics.DrawLine(p, x1, y1, x2, y2);
            }
        }

        public override string ToString()
        {
            string s = "";

            foreach (Point3D p in down)
            {
                s += p.ToString() + " ";
            }

            s = String.Format("Pyramid with /n Up Point {0} and points down {1}", up.ToString(), s);

            return s;
        }
    }
}
