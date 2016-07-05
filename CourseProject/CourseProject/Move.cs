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
    public partial class Move : Form
    {

        public double Distance;
        public double Arc;

        public Move()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Distance = Math.Abs(Convert.ToDouble(distanceTextBox.Text));
                Arc = (Convert.ToDouble(arcTextBox.Text) / 180) * Math.PI;
            }
            catch (FormatException)
            {
                MessageBox.Show("Enter valid values");
                return;
            }
            this.Close();
        }
    }
}
