using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using DAL.EntityWorkers;
using DAL.Models;

namespace DAL
{
    internal class AutofacContainer
    {
        private IContainer container;

        public AutofacContainer()
        {
            config();
        }

        public IContainer Container
        {
            get
            {
                return container;
            }
        }

        private void config()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<GameWorker>().As<IEntityWorker<Game>>();
            builder.RegisterType<TournamentWorker>().As<IEntityWorker<Tournament>>();
            builder.RegisterType<UserWorker>().As<IEntityWorker<User>>();
            builder.RegisterType<TokenWorker>().As<IEntityWorker<AuthehticationToken>>();
            builder.RegisterType<ParticipateRequestWorker>().As<IEntityWorker<ParticipateRequest>>();

            container = builder.Build();
        }
    }
}
