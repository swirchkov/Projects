using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using BLL.Services;
using BLL.Interfaces;
using BLL.DTO;
using DAL.Models;

namespace BLL.DI
{
    public class BllModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().As<IEntityService<UserDTO>>();
            builder.RegisterType<GameService>().As<IEntityService<GameDTO>>();
            builder.RegisterType<TournamentService>().As<IEntityService<TournamentDTO>>();

            builder.RegisterType<TournamentService>().As<ITournamentService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<TournamentParticipateService>().As<ITournamentParticipateService>();
            builder.RegisterType<GameService>().As<IGameService>();

            base.Load(builder);
        }
    }
}
