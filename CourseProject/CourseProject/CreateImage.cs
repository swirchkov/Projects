using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseProject
{
    public partial class CreateImage : Form
    {
        internal List<AbstractFigure> figures;
        internal Image Result;

        public CreateImage()
        {
            InitializeComponent();
            UpDateView();
            this.DialogResult = DialogResult.Cancel;
        }

        private void UpDateView()
        {
            if (figures == null)
            {
                return;
            }
            listFigures.Items.Clear();
            for (int i = 0; i < figures.Count; i++)
            {
                listFigures.Items.Add(figures[i]);
            }
        }

        private void figure_button_Click(object sender, EventArgs e)
        {
            Figure f = new Figure();

            Creator<Figure>.Create(ref f);

            if (Creator<Paralelogram>.CreateError == true)
            {
                return;
            }

            listFigures.Visible = true;
            listFigures.Items.Add(f);
            figures.Add(f);

            UpDateView();
            
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

            UpDateView();
        }

        private void CreateImage_Paint(object sender, PaintEventArgs e)
        {
            UpDateView();
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

            UpDateView();
        }

        private void section_Button_Click(object sender, EventArgs e)
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

            UpDateView();
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
            UpDateView();
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
            UpDateView();
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
        }

        private void pyramid_Button_Click(object sender, EventArgs e)
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
            UpDateView();
        }

        private void listFigures_KeyDown(object sender, KeyEventArgs e)
        {
            if (listFigures.SelectedIndex == -1)
            {
                return;
            }
            if (e.KeyData != Keys.Delete)
            {
                return;
            }

            int index = listFigures.SelectedIndex;

            listFigures.Items.RemoveAt(index);
            figures.RemoveAt(index);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Result = new Image(figures.ToArray<AbstractFigure>());
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


    }
}