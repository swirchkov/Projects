using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using BLL.DI;
using WebApp.Util;

namespace WebApp.DI
{
    public static class AutofacContainer
    {
        public static void ConfigContainer()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterModule(new BllModule());
            builder.RegisterType<FileSaver>().As<IFileSaver>();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
        }
    }
}