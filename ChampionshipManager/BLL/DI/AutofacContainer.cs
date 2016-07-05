using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using DAL.DI;
using BLL.Validators;
using BLL.DTO;

namespace BLL.DI
{
    public class AutofacContainer
    {
        private static IContainer container;
        private static Module module = new DALModule();
        public AutofacContainer()
        {
        }

        public IContainer Container
        {
            get
            {
                if (container == null)
                {
                    config();   
                }
                return container;
            }
        }

        private void config()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterModule(module);

            // validators
            builder.RegisterType<UserValidator>().As <IEntityValidator<UserDTO>>();
            builder.RegisterType<GameValidator>().As<IEntityValidator<GameDTO>>();
            builder.RegisterType<TournamentValidator>().As<IEntityValidator<TournamentDTO>>();

            container = builder.Build();
        }

        public static void Config(Module mod)
        {
            module = mod;
        }
    }
}
