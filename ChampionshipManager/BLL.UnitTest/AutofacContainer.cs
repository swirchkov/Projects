using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using BLL.DI;
using BLL.UnitTest.FakeDataInitializer;

namespace BLL.UnitTest
{
    public class AutofacContainer
    {
        private IContainer container;

        public AutofacContainer()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterModule<BllModule>();
            builder.RegisterModule<FakeDalModule>();

            container = builder.Build();
        }

        public IContainer Container
        {
            get
            {
                return container;
            }
        }
    }
}
