using Autofac;
using BLL.DTO;
using BLL.Interfaces;
using BLL.UnitTest.FakeDataInitializer;
using DAL;
using DAL.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.UnitTest
{
    public abstract class BaseUnitTest<T,V> where V : class
    {
        protected IEntityService<V> service;
        protected IRepository<T> repo;

        [TestInitialize]
        public void getService()
        {
            BLL.DI.AutofacContainer.Config(new FakeDalModule());

            AutofacContainer container = new AutofacContainer();
            service = container.Container.Resolve<IEntityService<V>>();

            BLL.DI.AutofacContainer bllContainer = new DI.AutofacContainer();
            repo = bllContainer.Container.Resolve<IRepository<T>>();
        }
    }
}
