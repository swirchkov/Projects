using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CourseProject
{
    [Serializable]
    class Image : AbstractFigure
    {
        private AbstractFigure[] figures;

        public AbstractFigure[] Figures
        {
            get
            {
                return figures;
            }
            private set
            {
                figures = value;
            }
        }

        public double X
        {
            get
            {
                double x = Double.MaxValue;

                foreach (var f in figures)
                {
                    foreach (var p in f.Points)
                    {
                        if (x > p.X)
                        {
                            x = p.X;
                        }
                    }
                }

                return x;
            }
        }

        public double Y
        {
            get
            {
                double y = Double.MaxValue;

                foreach (var f in figures)
                {
                    foreach (var p in f.Points)
                    {
                        if (y > p.Y)
                        {
                            
                            y = p.Y;
                        }
                    }
                }

                return y;
            }
        }

        public double Width
        {
            get
            {
                double x1 = Double.MaxValue;
                double x2 = Double.MinValue;

                foreach (var f in figures)
                {
                    foreach (var p in f.Points)
                    {
                        if (x1 > p.X)
                        {
                            x1 = p.X;
                        }
                        if (x2 < p.X)
                        {
                            x2 = p.X;
                        }
                    }
                }

                return Math.Abs(x2 - x1);
            }
        }

        public double Height
        {
            get
            {
                double y1 = Double.MaxValue;
                double y2 = Double.MinValue;

                foreach (var f in figures)
                {
                    foreach (var p in f.Points)
                    {
                        if (y1 > p.Y)
                        {
                            y1 = p.Y;
                        }
                        if (y2 < p.Y)
                        {
                            y2 = p.Y;
                        }
                    }
                }

                return Math.Abs(y2 - y1);
            }
        }

        public Image()
        { 
        }

        public Image(params AbstractFigure[] fig)
        {
            if (fig == null)
            {
                return;
            }

            this.figures = new AbstractFigure[fig.Length];

            for (int i = 0; i < fig.Length; i++ )
            {
                this.figures[i] = fig[i];
            }
                        
        }

        public override void Move(double distance, double arc)
        {
            if (figures == null)
            {
                return;
            }
            for (int i = 0; i < figures.Length; i++)
            {
                figures[i].Move(distance, arc);
            }
        }

        public void MoveIntoPosition(double x, double y, double z)
        {
            Point3D[] d = new Point3D[figures.Length];

            d[0] = figures[0].Points[0];

            for (int i = 0; i < figures.Length; i++)
            {
                d[i] = figures[i].Points[0] - d[0];
            }

            for (int i = 0; i < figures.Length; i++)
            {
                if (figures[i].GetType() != typeof(Paralelipiped))
                {
                    figures[i].MoveIntoPosition(x + d[i].X, y + d[i].Y);
                }
                else
                {
                    ((Paralelipiped)figures[i]).MoveIntoPosition(x + d[i].X, y + d[i].Y, z + d[i].Z);
                }
            }
        }

        public override void Scale(double procent)
        {
            if (figures == null)
            {
                return;
            }
            for (int i = 0; i < figures.Length; i++)
            {
                figures[i].Scale(procent);
            }
        }

        public override double Perimeter()
        {
            if (figures == null)
            {
                return 0;
            }

            double res = 0 ;

            for (int i = 0; i < figures.Length; i++)
            {
                res += figures[i].Perimeter();
            }

            return res;
        }

        public override double Square()
        {
            if (figures == null)
            {
                return 0;
            }
            double res = 0;

            for (int i = 0; i < figures.Length; i++)
            {
                res += figures[i].Square();
            }

            return res;
        }

        public override string ToString()
        {
            if (figures == null)
            {
                return "Empty Image";
            }

            string s = String.Format("Start point of Image ( X - {0}, Y - {1}), Width - {2}, Height - {3}", this.X, this.Y, this.Width, this.Height);

            return s;
        }

        public override void Paint(object sender, PaintEventArgs e)
        {
            if (figures == null)
            {
                return;
            }

            for (int i = 0; i < figures.Length; i++)
            {
                figures[i].Paint(sender, e);
            }
        }

        public void InitPaint(PictureBox m)
        {
            foreach (var f in figures)
            {
                m.Paint += f.Paint;
            }
        }

        public void Concat(Image other)
        {
            AbstractFigure[] newf = new AbstractFigure[figures.Length + other.Figures.Length];

            for (int i = 0; i < figures.Length; i++)
            {
                newf[i] = figures[i];
                newf[figures.Length + i] = other.Figures[i];
            }
            figures = newf;
        }

        public void ToFile1(string fileName)
        {
            if (figures == null)
            {
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    sw.WriteLine("Empty Image");
                }

                return;
            }
            List<string> lst = new List<string>();

            for (int i = 0; i < figures.Length; i++)
            {
                lst.Add(figures[i].GetType().ToString());
                
                foreach(Point p in figures[i].Points)
                {
                    lst.Add(p.ToString());
                }
            }

            FileStream f = new FileStream(fileName, FileMode.Create);

            using (StreamWriter sw = new StreamWriter(f))
            {
                for(int i=0; i<lst.Count; i++ )
                {
                    sw.WriteLine(lst[i]);
                }
            }

        }

        public Image FromFile1(string fileName)
        {
            List<AbstractFigure> lst = new List<AbstractFigure>();
            AbstractFigure f = null;
            List<Point3D> points = new List<Point3D>();

            using (StreamReader sr = new StreamReader(fileName))
            {
                string line = sr.ReadLine();

                if (line == "Empty Image")
                {
                    return new Image();
                }

                while (sr.EndOfStream != true)
                {                   
                    if (line.StartsWith("Lab2_2"))
                    {
                        if (f != null)
                        {
                            MessageBox.Show(f.ToString());
                            lst.Add(f);
                        }

                        string typ = line.Substring(7);
                        MessageBox.Show(typ);

                        line = sr.ReadLine();
                        while (line != null && !line.StartsWith("Lab2_2"))
                        {
                            string[] parts = line.Split(' ', ',');
                            double[] nums = new double[3];
                            int i = 0;
                            foreach (var s in parts)
                            {
                                double n = 0;
                                try
                                {
                                    n = Convert.ToDouble(s);
                                }
                                catch (FormatException)
                                {
                                    continue;
                                }

                                nums[i++] = n;
                                if (i == 3)
                                {
                                    break;
                                }
                            }
                            points.Add(new Point3D(nums[0], nums[1], nums[2]));
                            line = sr.ReadLine();
                        }

                        switch (typ)
                        {
                            case "Figure":
                                var point2d = To2D(points.ToArray());
                                f = new Figure(point2d);
                                points = new List<Point3D>();
                                break;
                            case "Point":
                                point2d = To2D(points.ToArray());
                                f = new Point(point2d[0].X, point2d[0].Y);
                                points = new List<Point3D>();
                                break;
                            case "Paralelogram":
                                point2d = To2D(points.ToArray());
                                f = new Paralelogram(point2d);
                                points = new List<Point3D>();
                                break;
                            case "Section":
                                MessageBox.Show("Creating Section");
                                point2d = To2D(points.ToArray());
                                f = new Section(point2d[0], point2d[1]);
                                points = new List<Point3D>();
                                break;
                            case "Paralelipiped":
                                f = new Paralelipiped(points.ToArray());
                                points = new List<Point3D>();
                                break;
                            case "Trapezien":
                                point2d = To2D(points.ToArray());
                                f = new Trapezien(point2d);
                                points = new List<Point3D>();
                                break;
                            case "Rhombus":
                                point2d = To2D(points.ToArray());
                                f = new Rhombus(point2d);
                                points = new List<Point3D>();
                                break;
                            case "FiledRhombus":
                                point2d = To2D(points.ToArray());
                                f = new FiledRhombus(point2d);
                                points = new List<Point3D>();
                                break;
                            case "Image":
                                break;
                            default:
                                MessageBox.Show("File has invalid content");
                                return new Image(lst.ToArray());
                        }
                    }
                    else
                    {
                        line = sr.ReadLine();
                    }
                }
            }

            Image im = new Image(lst.ToArray());
            return im;
        }

        public void ToFile(string filename)
        {
            BinaryFormatter bf = new BinaryFormatter();

            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                bf.Serialize(fs, this);
            }
        }

        public Image FromFile(string filename)
        {
            BinaryFormatter bf = new BinaryFormatter();
            Image im;

            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                im = (Image)bf.Deserialize(fs);
            }
            return im;
        }

        public Point[] To2D(Point3D[] m)
        {
            List<Point> res = new List<Point>();

            foreach (var p in m)
            {
                res.Add(new Point(p.X, p.Y));
            }

            return res.ToArray();
        }
    }
}
