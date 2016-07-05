using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseProject
{
    class Oktaedr : AbstractFigure
    {
        private Pyramid down;
        private Pyramid up;

        public Oktaedr()
        {
 
        }

        public Oktaedr(Pyramid d, Pyramid u)
        {
            down = d;
            up = u;
        }

        public override void Move(double distance, double arc)
        {
            up.Move(distance, arc);
            down.up.Move(distance, arc);
        }

        public override void Scale(double procent)
        {
            up.Scale(procent);
            double sumZ = 0;
            for (int i = 0; i < down.down.Length; i++)
            {
                sumZ += down.down[i].Z;
            }

            double downZ = sumZ / down.down.Length;

            down.up.Z = downZ + down.deltaZ;
        }

        public override void Paint(object sender, PaintEventArgs e)
        {
            down.Paint(sender, e);
            up.Paint(sender, e);
        }

        public override double Perimeter()
        {
            double res = 0;

            var osn = down.down;

            res += Point3D.Distance3D(osn[osn.Length - 1], osn[0]);

            for (int i = 0; i < osn.Length; i++)
            {
                res += Point3D.Distance3D(osn[i], osn[i + 1]);
            }

            return up.Perimeter() + down.Perimeter() - res;
        }

        public override double Square()
        {
            double res = 0;

            double a, b, c;
            double p;

            var osn = down.down;

            for (int i = 1; i < osn.Length - 1; i++)
            {
                a = Point3D.Distance3D(osn[0], osn[i]);
                b = Point3D.Distance3D(osn[i], osn[i + 1]);
                c = Point3D.Distance3D(osn[i + 1], osn[0]);

                p = (a + b + c) / 2;

                res += Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            }

            return down.Square() + up.Square() - 2 * res;
        }

        public override string ToString()
        {
            string s = "";

            s = String.Format("Oktaedr with down Pyramid {0} and Up Pyramid {1}", down.ToString(), up.ToString());

            return s;
        }
    }
}
