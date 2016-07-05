using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace CourseProject
{
    public partial class Form1 : Form
    {
        private List<AbstractFigure> figures;

        public Form1()
        {
            InitializeComponent();
            figures = new List<AbstractFigure>();
            listFigures.Visible = false;

            foreach (var f in figures)
            {
                pictureBox1.Paint += f.Paint;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Section s = new Section();

            Creator<Section>.Create(ref s);

            if (Creator<Section>.CreateError == true)
            {
                return;
            }

            listFigures.Visible = true;
            listFigures.Items.Add(s);
            figures.Add(s);
            pictureBox1.Paint += s.Paint;

            pictureBox1.Refresh();
        }

        private void listFigures_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Move_Click(object sender, EventArgs e)
        {
            if (listFigures.SelectedIndex == -1)
            {
                return;
            }

            Move f = new Move();
            f.ShowDialog();

            double distance = f.Distance;
            double arc = f.Arc ;

            figures[listFigures.SelectedIndex].Move(distance, arc);

            UpdateView();

            pictureBox1.Refresh();
        }

        private void Scale_Click(object sender, EventArgs e)
        {
            if (listFigures.SelectedIndex == -1)
            {
                return;
            }
            Scale sc = new Scale();
            sc.ShowDialog();

            double proc = sc.ScaleKoefizient;

            figures[listFigures.SelectedIndex].Scale(proc);

            UpdateView();

            pictureBox1.Refresh();

        }

        private void P_Click(object sender, EventArgs e)
        {
            if (listFigures.SelectedIndex == -1)
            {
                return;
            }

            double res = 0;

            res = figures[listFigures.SelectedIndex].Perimeter();

            MessageBox.Show(res.ToString());
        }

        private void S_Click(object sender, EventArgs e)
        {
            if (listFigures.SelectedIndex == -1)
            {
                return;
            }

            double res = 0;

            res = figures[listFigures.SelectedIndex].Square();

            MessageBox.Show(res.ToString());
        }

        private void toString_Click(object sender, EventArgs e)
        {
            if (listFigures.SelectedIndex == -1)
            {
                return;
            }

            MessageBox.Show(figures[listFigures.SelectedIndex].ToString());
        }

        private void UpdateView()
        {
            listFigures.Items.Clear();

            foreach (var f in figures)
            {
                listFigures.Items.Add(f);
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Figure f = new Figure();

            Creator<Figure>.Create(ref f);

            if (Creator<Figure>.CreateError == true)
            {
                return;
            }

            listFigures.Visible = true;
            listFigures.Items.Add(f);
            figures.Add(f);
            pictureBox1.Paint += f.Paint;

            pictureBox1.Refresh();
        }

        private void filled_Rhombus_Button_Click(object sender, EventArgs e)
        {
            FiledRhombus r = new FiledRhombus();

            Creator<FiledRhombus>.Create(ref r);

            if (Creator<FiledRhombus>.CreateError == true)
            {
                return;
            }

            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();
            r.FillPen = new Pen(cd.Color);

            listFigures.Visible = true;
            listFigures.Items.Add(r);
            figures.Add(r);
            pictureBox1.Paint += r.Paint;

            pictureBox1.Refresh();
        }

        private void point_button_Click(object sender, EventArgs e)
        {
            Point p = new Point();

            Creator<Point>.Create(ref p);

            if (Creator<Point>.CreateError == true)
            {
                return;
            }

            listFigures.Visible = true;
            listFigures.Items.Add(p);
            figures.Add(p);
            pictureBox1.Paint += p.Paint;

            pictureBox1.Refresh();
        }

        private void square_button_Click(object sender, EventArgs e)
        {
            SquareFigure s = new SquareFigure();

            Creator<SquareFigure>.Create(ref s);

            if (Creator<SquareFigure>.CreateError == true)
            {
                return;
            }

            listFigures.Visible = true;
            listFigures.Items.Add(s);
            figures.Add(s);
            pictureBox1.Paint += s.Paint;

            pictureBox1.Refresh();
        }

        private void paralelogram_Button_Click(object sender, EventArgs e)
        {
            Paralelogram s = new Paralelogram();

            Creator<Paralelogram>.Create(ref s);

            if (Creator<Paralelogram>.CreateError == true)
            {
                return;
            }

            listFigures.Visible = true;
            listFigures.Items.Add(s);
            figures.Add(s);
            pictureBox1.Paint += s.Paint;

            pictureBox1.Refresh();
        }

        private void rectangle_Button_Click(object sender, EventArgs e)
        {
            Rectangle r = new Rectangle();

            Creator<Rectangle>.Create(ref r);

            if (Creator<Rectangle>.CreateError == true)
            {
                return;
            }

            listFigures.Visible = true;
            listFigures.Items.Add(r);
            figures.Add(r);
            pictureBox1.Paint += r.Paint;

            pictureBox1.Refresh();
        }

        private void poly_Button_Click(object sender, EventArgs e)
        {
            Polygone p = new Polygone();

            Creator<Polygone>.Create(ref p);

            if (Creator<Polygone>.CreateError == true)
            {
                return;
            }

            listFigures.Visible = true;
            listFigures.Items.Add(p);
            figures.Add(p);
            pictureBox1.Paint += p.Paint;

            pictureBox1.Refresh();
        }

        private void trapezien_Button_Click(object sender, EventArgs e)
        {
            Trapezien t = new Trapezien();

            Creator<Trapezien>.Create(ref t);

            if (Creator<Trapezien>.CreateError == true)
            {
                return;
            }

            listFigures.Visible = true;
            listFigures.Items.Add(t);
            figures.Add(t);
            pictureBox1.Paint += t.Paint;

            pictureBox1.Refresh();
        }

        private void oktaedr_Button_Click(object sender, EventArgs e)
        {
            Oktaedr o = new Oktaedr();

            Creator<Oktaedr>.Create(ref o);

            if (Creator<Oktaedr>.CreateError == true)
            {
                return;
            }

            listFigures.Visible = true;
            listFigures.Items.Add(o);
            figures.Add(o);
            pictureBox1.Paint += o.Paint;

            pictureBox1.Refresh();
        }

        private void parallelipiped_Button_Click(object sender, EventArgs e)
        {
            Paralelipiped p = new Paralelipiped();

            Creator<Paralelipiped>.Create(ref p);

            if (Creator<Paralelipiped>.CreateError == true)
            {
                return;
            }

            listFigures.Visible = true;
            listFigures.Items.Add(p);
            figures.Add(p);
            pictureBox1.Paint += p.Paint;

            pictureBox1.Refresh();
        }

        private void rhombus_Button_Click(object sender, EventArgs e)
        {
            Rhombus r = new Rhombus();

            Creator<Rhombus>.Create(ref r);

            if (Creator<Rhombus>.CreateError == true)
            {
                return;
            }

            listFigures.Visible = true;
            listFigures.Items.Add(r);
            figures.Add(r);
            pictureBox1.Paint += r.Paint;

            pictureBox1.Refresh();
        }

        private void cut_pyramid_Button_Click(object sender, EventArgs e)
        {
            CuttedPyramid cp = new CuttedPyramid();

            Creator<CuttedPyramid>.Create(ref cp);

            listFigures.Visible = true;
            listFigures.Items.Add(cp);
            figures.Add(cp);
            pictureBox1.Paint += cp.Paint;

            pictureBox1.Refresh();
        }

        private void inc_Prizma_Button_Click(object sender, EventArgs e)
        {
            InclinedPrisma ip = new InclinedPrisma();

            Creator<InclinedPrisma>.Create(ref ip);

            listFigures.Visible = true;
            listFigures.Items.Add(ip);
            figures.Add(ip);
            pictureBox1.Paint += ip.Paint;

            pictureBox1.Refresh();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (listFigures.SelectedIndex == -1)
            {
                return;
            }
            if (figures[listFigures.SelectedIndex].GetType() != typeof(Paralelipiped) &&
                figures[listFigures.SelectedIndex].GetType() != typeof(Image))
            {
                MovingInPosition mp = new MovingInPosition();
                mp.ShowDialog();
                Point end = mp.FinalPoint;
                figures[listFigures.SelectedIndex].MoveIntoPosition(end.X, end.Y);
            }
            else 
            {
                PosForm3D pf = new PosForm3D();
                pf.ShowDialog();
                Point3D end = pf.Value;
                if (figures[listFigures.SelectedIndex].GetType() == typeof(Paralelipiped))
                {
                    var p = (Paralelipiped)figures[listFigures.SelectedIndex];
                    p.MoveIntoPosition(end.X, end.Y, end.Z);
                }
                else
                {
                    var p = (Image)figures[listFigures.SelectedIndex];
                    p.MoveIntoPosition(end.X, end.Y, end.Z);
                }
            }

            UpdateView();

            pictureBox1.Refresh();
        }

        private void create_Image_Click(object sender, EventArgs e)
        {
            CreateImage ci = new CreateImage();
            ci.figures = new List<AbstractFigure>();

            foreach (var f in this.figures)
            {
                ci.figures.Add(f);
            }
            var dres = ci.ShowDialog();

            if (dres == DialogResult.Cancel)
            {
                return;
            }

            figures.Add(ci.Result);
            listFigures.Visible = true;
            foreach(var f in ci.Result.Figures)
            {
                if (figures.Contains(f))
                {
                    figures.Remove(f);
                }
            }
            UpdateView();

            pictureBox1.Paint += ci.Result.Paint;

            pictureBox1.Refresh();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (listFigures.SelectedIndex == -1)
            {
                return;
            }

            if (listFigures.Items[listFigures.SelectedIndex].GetType() != typeof(Image))
            {
                return;
            }

            Image im = (Image)listFigures.Items[listFigures.SelectedIndex];

            SaveFileDialog sd = new SaveFileDialog();
            var dres = sd.ShowDialog();

            if (dres == DialogResult.Cancel)
            {
                return;
            }

            im.ToFile(sd.FileName);
        }

        private void Load_Click(object sender, EventArgs e)
        {
            Image im = new Image();

            OpenFileDialog sd = new OpenFileDialog();
            var dres = sd.ShowDialog();

            if (dres == DialogResult.Cancel)
            {
                return;
            }

            im = im.FromFile(sd.FileName);

            im.InitPaint(pictureBox1);
            pictureBox1.Paint += im.Paint;

            pictureBox1.Refresh();

            listFigures.Items.Add(im);
            figures.Add(im);
            listFigures.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listFigures.SelectedIndex == -1)
            {
                return;
            }

            if (listFigures.Items[listFigures.SelectedIndex].GetType() != typeof(Image))
            {
                return;
            }

            Image im1 = (Image)listFigures.Items[listFigures.SelectedIndex];

            MessageBox.Show("Chose second Image");

            while (true)
            {
                MessageBox.Show("Chose second Image");
                Thread.Sleep(1500);

                if (listFigures.SelectedIndex == -1)
                {
                    continue;
                }

                if (listFigures.Items[listFigures.SelectedIndex].GetType() != typeof(Image))
                {
                    continue;
                }
                break;
            }

            Image im2 = (Image)listFigures.Items[listFigures.SelectedIndex];

            im1.Concat(im2);

            figures.Remove(im2);
            UpdateView();

            pictureBox1.Refresh();
            
        }


    }
}
