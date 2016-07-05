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
    class Prizma : AbstractFigure
    {
        public Point3D[] down;
        public Point3D[] up;

        public override Point3D[] Points
        {
            get
            {
                Point3D[] res = new Point3D[up.Length + down.Length];

                for (int i = 0; i < down.Length; i++)
                {
                    res[i] = down[i];
                    res[down.Length + i] = up[i];
                }

                return res;
            }
        }

        public Prizma( params Point3D[] p)
        {
            if (p.Length % 2 != 0)
            {
                throw new ArgumentException();
            }

            int num = Convert.ToInt32(p.Length / 2);
            down = new Point3D[num];
            up = new Point3D[num];

            for (int i = 0; i < num; i++)
            {
                down[i] = p[i];
            }

            for (int i = num; i < 2 * num; i++)
            {
                up[i - num] = p[i];
            }

        }

        public override void Move(double distance, double arc)
        {
            for (int i = 0; i < down.Length; i++)
            {
                down[i].Move(distance, arc);
                up[i].Move(distance, arc);
            }
        }

        //public override void Scale(double procent)
        //{
        //    double downcentX = 0;
        //    double downcentY = 0;
        //    double upcentX = 0;
        //    double upcentY = 0;

        //    for(int i=0; i< down.Length; i++)
        //    {
        //        downcentX += down[i].X;
        //        downcentY += down[i].Y;
        //        upcentX += up[i].X;
        //        upcentY += up[i].Y;
        //    }

        //    var downCenter = new Point(downcentX / down.Length, downcentY / down.Length);
        //    var upCenter = new Point(upcentX / up.Length, upcentY / up.Length);

        //    double[] eq;
        //    double k;
        //    double b;

        //    double distance;
        //    double arc;

        //    for ( int i=0; i<down.Length; i++ )
        //    {
        //        eq = Section.Equation(down[i], downCenter);
        //        k = eq[0];
        //        b = eq[1];

        //        distance = Point.Distance(down[i], downCenter);
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

        //        down[i].Move(distance, arc);

        //        eq = Section.Equation(up[i], upCenter);
        //        k = eq[0];
        //        b = eq[1];

        //        distance = Point.Distance(up[i], upCenter);
        //        arc = Math.Atan(k);

        //        if (procent > 1)
        //        {
        //            distance *= (procent - 1);
        //        }
        //        else
        //        {
        //            distance = distance - distance * procent;
        //            arc = Math.PI - arc;
        //        }

        //        up[i].Move(distance, arc);
        //    }
        
        //    double deltaZ = 0;

        //    for (int i = 0; i < up.Length; i++)
        //    {
        //        deltaZ = up[i].Z - down[i].Z;
        //        deltaZ *= procent;
        //        up[i].Z = down[i].Z + deltaZ;
        //    }
        //}

        public void MoveIntoPosition(double x, double y, double z)
        {
            Point3D start = down[0];

            for (int i = 0; i < down.Length; i++)
            {
                down[i].X += x - start.X; 
                down[i].Y += y - start.Y; 
                down[i].Z += z - start.Z;
            }

            for (int i = 0; i < up.Length; i++)
            {
                up[i].X += x - start.X;
                up[i].Y += y - start.Y;
                up[i].Z += z - start.Z;
            }

        }

        public override void MoveIntoPosition(double x, double y)
        {
            this.MoveIntoPosition(x, y, 0);
            //Point3D start = down[0];

            //for (int i = 0; i < down.Length; i++)
            //{
            //    down[i].X += x - start.X;
            //    down[i].Y += y - start.Y;
            //}

            //start = up[0];

            //for (int i = 0; i < up.Length; i++)
            //{
            //    up[i].X += x - start.X;
            //    up[i].Y += y - start.Y;
            //}
        }

        public override void Scale(double procent)
        {
            var dStart = down[0];
            var uStart = up[0];

            for (int i = 1; i < down.Length; i++)
            {
                Section3D.Scale(ref dStart, ref down[i], procent);
                Section3D.Scale(ref dStart, ref up[i], procent);
            }


        }

        public override double Perimeter()
        {
            Figure f = new Figure(down);
            Figure u = new Figure(up);

            double res = f.Perimeter() + u.Perimeter();

            for (int i = 0; i < down.Length; i++)
            {
                res += Point3D.Distance3D(down[i], up[i]);
            }

            return res;
        }

        public override double Square()
        {
            Figure f = new Figure(down);
            Figure u = new Figure(up);

            double res = f.Square() + u.Square();

            int num = down.Length;

            f = new Figure(down[num - 1], up[num - 1], up[0], down[0]);

            res += f.Square();

            for (int i = 0; i < down.Length - 1; i++)
            {
                f = new Figure(down[i], up[i], up[i + 1], up[i]);
                res += f.Square();
            }

            return res;
        }

        public override string ToString()
        {
            string sd = "";
            string su = "";

            for (int i = 0; i < down.Length; i++)
            {
                sd += down[i].ToString() + " ";
                su += up[i].ToString() + " ";
            }

            return String.Format("Prizma with down points - {0} ; up points -{1}", sd, su);
        }

        public override void Paint(object sender, PaintEventArgs e)
        {
            Figure d = new Figure(down);
            Point[] u = new Point[up.Length];

            for (int i = 0; i < up.Length; i++)
            {
                if (up[i].X != down[i].X)
                {
                    u[i] = new Point(up[i].X, up[i].Y + up[i].Z);
                }
                else
                {
                    u[i] = new Point(up[i].X + up[i].Z / 2, up[i].Y + up[i].Z);
                }

            }

            Figure upper = new Figure(u);

            d.Paint(sender, e);
            upper.Paint(sender, e);
            float x1, y1, x2, y2;


            for (int i = 0; i < down.Length; i++)
            {
                x1 = (float) down[i].X;
                y1 = (float) down[i].Y;

                x2 = (float) u[i].X;
                y2 = (float) u[i].Y;

                e.Graphics.DrawLine(new Pen(Color.Black), x1, y1, x2, y2);
            }
        }
    }
}
