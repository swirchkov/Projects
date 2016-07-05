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
    public partial class ArrayCreator : Form
    {

        public Array result;

        private Type t;

        public ArrayCreator()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
        }

        public ArrayCreator(Type t)
        {
            InitializeComponent();
            this.t = t;
            this.DialogResult = DialogResult.OK;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var text = (TextBox)sender;
            int num;
            try
            {
                num = Convert.ToInt32(text.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Array length must be digit");
                return;
            }

            result = Array.CreateInstance(t, num);
            int i = 0;

            for (i = 0; i < num; i++)
            {
                Label l = new Label();

                l.Left = (i % 2) * 300 + 10 ;
                l.Top = textBox1.Top + textBox1.Height + (i / 2) * 30;

                l.Text = String.Format("a[{0}] - ", i);
                l.Width = 30;
                this.Controls.Add(l);

                TextBox c = new TextBox();

                c.Top = l.Top;
                c.Left = l.Left + l.Width + 10;

                c.Name = i.ToString();

                this.Controls.Add(c);

                Button b = new Button();

                b.Left = c.Left + c.Width + 10;

                b.Top = c.Top ;

                b.Text = "Run Create Object for this parameter";
                b.Width = 80;
                b.Name = i.ToString();
                b.MouseClick += buttonClick;
                this.Controls.Add(b);
            }

            Button submit = new Button();

            submit.Left = (i / 3) * (this.Width / 3);
            submit.Top = textBox1.Top + textBox1.Height + (i / 2) * 30 + 100;

            submit.MouseClick += submitClick;
            submit.Text = "Create";
            this.Controls.Add(submit);

        }

        private void submitClick(object sender, MouseEventArgs e)
        {
            var textboxes = new List<TextBox>();

            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i].GetType() == (new TextBox()).GetType())
                {
                    textboxes.Add((TextBox)this.Controls[i]);
                }
            }

            for (int i = 0; i < result.Length; i++)
            {
                if (result.GetValue(i) != null)
                {
                    continue;
                }

                var query = (from v in textboxes
                             where (v.Name == i.ToString())
                             select v).Take(1);
                var textbox = query.First<TextBox>();


                try
                {
                    result.SetValue(Convert.ChangeType(textbox.Text, t), i);
                }
                catch (Exception)
                {
                    MessageBox.Show(String.Format("Enter in the textbox {0} valid value", i));
                    return;
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonClick(object sender, MouseEventArgs e)
        {
            Button send = (Button)sender;

            int num = Convert.ToInt32(send.Name);

            CreateObj cr = new CreateObj(t.GetConstructors());

            cr.ShowDialog();

            var instance = Activator.CreateInstance(t);

            Thread.Sleep(200);

            var par = cr.selected.Invoke(instance, cr.parametres);

            result.SetValue(instance, num);

            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i].GetType() == (new TextBox()).GetType())
                {
                    if (this.Controls[i].Name == send.Name)
                    {
                        this.Controls[i].Text = "Created";
                        break;
                    }
                }
            }

        }

    }
}
