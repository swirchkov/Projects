using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject
{
    [Serializable]
    class Polygone : Figure
    {

        public Polygone() : base()
        { 
        }

        public Polygone(params Point[] p)
            : base(p)
        {
            if (p.Length < 3)
            {
                if (p.Length == 0)
                {
                    return;
                }
                throw new ArgumentException("Многоугольник должен иметь больше 3 вершин");
            }
        }
    }
}
