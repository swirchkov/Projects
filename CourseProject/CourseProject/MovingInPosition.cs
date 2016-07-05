using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseProject
{
    public partial class MovingInPosition : Form
    {
        internal Point FinalPoint;
        public MovingInPosition()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double x, y;
            try
            {
                x = Convert.ToDouble(textBox1.Text);
                y = Convert.ToDouble(textBox2.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Enter correct values");
                return;
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Enter correct values");
                return;
            }
            FinalPoint = new Point(x, y);
            this.Close();
        }
    }
}
