using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace CourseProject
{
    [Serializable]
    class FiledRhombus : Rhombus
    {
        public Pen FillPen;


        public FiledRhombus()
        { 
        }

        public FiledRhombus(params Point[] poin)
            : base(poin)
        {
            FillPen = new Pen(Color.Black);
        }

        public override void Paint(object sender, PaintEventArgs e)
        {
            PointF[] poins = new PointF[points.Length];
            
            for (int i = 0; i < points.Length; i++)
            {
                poins[i] = new PointF((float)points[i].X, (float)points[i].Y);
            }

            SolidBrush sb = new SolidBrush(FillPen.Color);
            e.Graphics.FillPolygon(sb, poins);
        }
    }
}
