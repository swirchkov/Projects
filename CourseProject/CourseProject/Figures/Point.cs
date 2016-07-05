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
    public class Point : AbstractFigure
    {
        public double X;
        public double Y;

        public Point()
        {
            X = 0;
            Y = 0;
        }

        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public override void Move( double d, double arc )
        {
            //arc = (arc / 180) * Math.PI;
            this.X += d * Math.Cos(arc);
            this.Y += d * Math.Sin(arc);
        }

        public override string ToString()
        {
            return String.Format("Point : X - {0}, Y - {1} ", this.X, this.Y );
        }

        public static double Distance( Point p1, Point p2 )
        {
            return Math.Sqrt(Math.Pow((p2.X - p1.X), 2) + Math.Pow((p2.Y - p1.Y), 2));
        }

        public override void Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.Black), (float)X, (float)Y, (float)X, (float)Y);
        }

        public static Point operator - (Point lhs, Point rhs)
        {
            return new Point(lhs.X - rhs.X, lhs.Y - rhs.Y);
        }
    }
}
