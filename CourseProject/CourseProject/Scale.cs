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
    public partial class Scale : Form
    {
        public double ScaleKoefizient;

        public Scale()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                ScaleKoefizient = Convert.ToDouble(scaleTextBox.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid double value");
                scaleTextBox.Text = "";
                return;
            }
            this.Close();
        }
    }
}
