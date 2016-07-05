using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DI;

namespace DbInitializer
{
    static class AutofacBLLContainer
    {
        static AutofacBLLContainer()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterModule(new BllModule());

            Container = builder.Build();
        }

        public static IContainer Container { get; }
    }
}
