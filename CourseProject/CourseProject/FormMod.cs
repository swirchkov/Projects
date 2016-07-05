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
    enum TestingSubject
    {
        Method,
        Propertie,
        Field
    };

    public partial class FormMod : Form
    {

        public MethodInfo[] Methods;
        public PropertyInfo[] Properties;
        public FieldInfo[] Fields;

        private TestingSubject current;
        private object[] parametres;
        private ParameterInfo[] parameters;

        public FormMod()
        {
            InitializeComponent();
        }

        public FormMod(MethodInfo[] m, PropertyInfo[] p, FieldInfo[] f)
        {
            InitializeComponent();

            Methods = m;
            Properties = p;
            Fields = f;
        }

        private void MethodButton_Click(object sender, EventArgs e)
        {
            current = TestingSubject.Method;
            updateListBox();
        }

        private void Propertiebutton_Click(object sender, EventArgs e)
        {
            current = TestingSubject.Propertie;
            updateListBox();
        }

        private void Fieldbutton_Click(object sender, EventArgs e)
        {
            current = TestingSubject.Field;
            updateListBox();
        }

        private void updateListBox()
        {
            switch (current)
            {
                case TestingSubject.Method :

                    foreach (MethodInfo m in Methods)
                    {
                        listBox1.Items.Add(m);
                    }

                    break;

                case TestingSubject.Propertie:

                    foreach (PropertyInfo p in Properties)
                    {
                        listBox1.Items.Add(p);
                    }

                    break;

                case TestingSubject.Field:

                    foreach (FieldInfo f in Fields)
                    {
                        listBox1.Items.Add(f);
                    }

                    break;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (current)
            {
                case TestingSubject.Method:

                    MethodInfo m = Methods[listBox1.SelectedIndex];
                    InputParametres(m.GetParameters(), listBox1.Top);

                    break;
            }
        }

        private void InputParametres(ParameterInfo[] pars, int startTop)
        {
            parametres = new object[pars.Length];

            for (int i = 0; i < pars.Length; i++)
            {
                Label l = new Label();
                l.Text = pars[i].ParameterType.ToString();

                l.Left = listBox1.Left + listBox1.Width + 40;

                l.Top = startTop + i * 30;

                l.Width = 80;

                this.Controls.Add(l);

                TextBox t = new TextBox();

                t.Left = listBox1.Left + listBox1.Width + 120;
                t.Top = startTop + i * 30;

                t.Name = i.ToString();

                //t.MouseClick += textClick;

                t.Width = 80;

                this.Controls.Add(t);

                Button b = new Button();

                b.Left = listBox1.Left + listBox1.Width + 210;

                b.Top = startTop + i * 30;

                b.Text = "Run Create Object for this parameter";
                b.Width = 80;
                b.Name = i.ToString();

                b.MouseClick += buttonClick;

                this.Controls.Add(b);

            }
        }

        private void buttonClick(object sender, MouseEventArgs e)
        {
            Button send = (Button)sender;

            int num = Convert.ToInt32(send.Name);
            var t = parameters[num].ParameterType;

            CreateObj cr = new CreateObj(t.GetConstructors());

            cr.ShowDialog();

            var instance = Activator.CreateInstance(t);

            Thread.Sleep(200);

            var par = cr.selected.Invoke(instance, cr.parametres);

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

        private void button4_Click(object sender, EventArgs e)
        {
            switch (current)
            {
                case TestingSubject.Method:

                    MethodInfo m = Methods[listBox1.SelectedIndex];
                    Modifier<AbstractFigure>.testMethod(m, parametres);

                    MessageBox.Show(Modifier<AbstractFigure>.element.ToString());

                    break;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
