using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject
{
    [Serializable]
    class SquareFigure : Rectangle
    {
        public SquareFigure()
        { 
        }

        public SquareFigure(params Point[] p) : base(p)
        {
            if (!Rhombus.CheckEquality(p))
            {
                points = null;
                throw new ArgumentException("Стороны квадрата должны быть равны");
            }
        }

        public override string ToString()
        {
            string s = "";

            if (points == null)
            {
                return "";
            } 

            s += "Square with storona - " + Point.Distance(points[0], points[1]);

            return s;
        }

    }
}
