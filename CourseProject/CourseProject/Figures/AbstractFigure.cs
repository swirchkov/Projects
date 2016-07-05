using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseProject
{
    [Serializable]
    public abstract class AbstractFigure
    {
        public virtual Point3D[] Points { get; private set; }

        public virtual void Move(double distance, double arc) { }

        public virtual void MoveIntoPosition(double x, double y) { }

        public virtual void Scale(double procent) { }

        public virtual void Paint(object sender, PaintEventArgs e) {  }

        public virtual double Perimeter() { return 0;  }

        public virtual double Square() { return 0; }
    }
}
