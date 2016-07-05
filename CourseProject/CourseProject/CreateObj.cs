using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;

namespace CourseProject
{
    public partial class CreateObj : Form
    {

        public ConstructorInfo[] Constructors;

        public object[] parametres;

        public bool IsSubmit;

        public ConstructorInfo selected;

        private ParameterInfo[] parameters;

        public CreateObj()
        {
            InitializeComponent();
            IsSubmit = false;
            this.DialogResult = DialogResult.Cancel;
        }

        public CreateObj(ConstructorInfo[] c)
        {
            InitializeComponent();
            Constructors = c;
            IsSubmit = false;
            string s = "";

            for (int i = 0; i < Constructors.Length; i++)
            {
                s = Constructors[i].MemberType.ToString();

                s += " ( ";

                foreach (ParameterInfo par in Constructors[i].GetParameters())
                {
                    s += par.ParameterType.ToString() + " , ";
                }

                s += " )";

                listBox1.Items.Add(s);
            }

            this.DialogResult = DialogResult.Cancel;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                return;
            }

            ParameterInfo[] current = Constructors[listBox1.SelectedIndex].GetParameters();

            selected = Constructors[listBox1.SelectedIndex];
            parameters = current;
            parametres = new object[current.Length];

            for(int i=0; i < current.Length; i++)
            {
                Label l = new Label();
                l.Text = current[i].ParameterType.ToString();

                l.Left = listBox1.Left + listBox1.Width + 40;

                l.Top = listBox1.Top + i * 30 ;

                l.Width = 80;

                this.Controls.Add(l);

                TextBox t = new TextBox();

                t.Left = listBox1.Left + listBox1.Width + 120;
                t.Top = listBox1.Top + i * 30;

                t.Name = i.ToString() ;

                //t.MouseClick += textClick;

                t.Width = 80;

                this.Controls.Add(t);

                if (current[i].ParameterType.IsPrimitive)
                {
                    continue;
                }

                Button b = new Button();

                b.Left = listBox1.Left + listBox1.Width + 210;

                b.Top = listBox1.Top + i * 30;

                b.Text = "Run Create Object for this parameter";
                b.Width = 80;
                b.Name = i.ToString();

                if (!current[i].ParameterType.IsArray)
                {
                    b.MouseClick += buttonClick;
                }
                else
                {
                    b.MouseClick += ArrayCreate;
                }

                this.Controls.Add(b);

            }
        }

        private void buttonClick(object sender, MouseEventArgs e)
        {
            Button send = (Button)sender;

            int num = Convert.ToInt32(send.Name);
            var t = parameters[num].ParameterType;

            var instance = Activator.CreateInstance(t);

            while (true)
            {
                CreateObj cr = new CreateObj(t.GetConstructors());

                DialogResult dres = cr.ShowDialog();

                Thread.Sleep(200);

                if (dres == DialogResult.Cancel)
                {
                    return;
                }
                try
                {
                    var par = cr.selected.Invoke(instance, cr.parametres);
                }
                catch ( ArgumentException ex)
                {
                    MessageBox.Show(String.Format("Cannot create object with that parameters. Error add info {0}"), ex.Message);
                    continue;
                }


                break;
            }

            parametres[num] = instance;
            TextBox textbox = new TextBox();

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

        private void ArrayCreate(object sender, MouseEventArgs e)
        {
            Button send = (Button) sender;
            int num = Convert.ToInt32(send.Name);

            ArrayCreator ar = new ArrayCreator(parameters[num].ParameterType.GetElementType());
            var a = ar.ShowDialog();

            if (a == DialogResult.Cancel)
            {
                return;
            }

            parametres[num] = ar.result;

            string s = "";

            for (int i = 0; i < ar.result.Length; i++)
            {
                s += ar.result.GetValue(i);
            }

            MessageBox.Show(s);

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (parametres == null)
            {
                MessageBox.Show("Enter parameters to create object with that constructor.");
                return;
            }

            var textboxes = new List<TextBox>();

            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i].GetType() == (new TextBox()).GetType())
                {
                    textboxes.Add((TextBox)this.Controls[i]);
                }
            }
            
            for (int i = 0; i < parametres.Length; i++)
            {
                if (parametres[i] != null)
                {
                    continue;
                }

                var query = (from v in textboxes
                               where (v.Name == i.ToString())
                               select v).Take(1);
                var textbox = query.First<TextBox>();

                try
                {
                    parametres[i] = Convert.ChangeType(textbox.Text, parameters[i].ParameterType);
                }
                catch (InvalidCastException)
                {
                    MessageBox.Show(String.Format("Enter valid value in textbox {0}", i));
                    return;
                }
                catch (FormatException)
                {
                    MessageBox.Show(String.Format("Enter valid value in textbox {0}", i));
                    return;
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();

        }        

    }
}
