using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CourseProject
{
    static class Modifier<T>
    {
        public static T element;

        //public Modifier(ref T element)
        //{
        //    this.element = element;

        //    var t = typeof(T);

        //    FormMod f = new FormMod(t.GetMethods(), t.GetProperties(), t.GetFields();

        //}

        public static FormMod CreateForm()
        {
            if (element != null)
            {
                var t = typeof(T);
                FormMod f = new FormMod(t.GetMethods(), t.GetProperties(), t.GetFields());
                return f;
            }
            else
            {
                throw new NotImplementedException("Firstly you must set element");
            }
        }

        public static object testPropertie(PropertyInfo p, bool IsSet, object value, params object[][] index)
        {
            if (IsSet)
            {
                if (index[0].Length > 0)
                {
                    p.SetValue(element, value, index[0]);
                }

                p.SetValue(element, value);

                return new object();
            }
            else
            {
                return p.GetValue(element);
            }
        }
        public static object testField(FieldInfo field, bool IsSet, object value)
        {
            if (IsSet)
            {
                field.SetValue(element, value);
                return new object();
            }
            else
            {
                return field.GetValue(element);
            }
        }
        public static object testMethod(MethodInfo m, object[] parameters)
        {
            return m.Invoke(element, parameters);
        }
       
    }
}
