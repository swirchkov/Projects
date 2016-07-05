using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace CourseProject
{
    class Creator<T>
    {
        public static bool CreateError;

        public static void Create (ref T element) 
        {
            var t = typeof(T);
            CreateError = false;

            while (true)
            {
                CreateObj cr = new CreateObj(t.GetConstructors());

                cr.ShowDialog();

                Thread.Sleep(200);

                if (cr.DialogResult == DialogResult.Cancel)
                {
                    CreateError = true;
                    return;
                }

                try
                {
                    var par = cr.selected.Invoke(element, cr.parametres);
                    
                }
                catch (TargetInvocationException tie)
                {
                    var ex = tie.InnerException;
                    MessageBox.Show(String.Format("Cannot create object with that parameters. Error add info {0}", ex.Message));
                    CreateError = true;
                    ex = null;
                }
                //catch (ArgumentException ex)
                //{
                //    MessageBox.Show(String.Format("Cannot create object with that parameters. Error add info {0}", ex.Message));
                //    Thread.Sleep(1000);
                //    ex = null;
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(String.Format("Cannot create object with that parameters. Error add info {0}", ex.Message));
                //    Thread.Sleep(1000);
                //}

                break;
            }
        }
    }
}
