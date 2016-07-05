using Autofac;
using DAL;
using DAL.Models;

namespace BLL.UnitTest.FakeDataInitializer
{
    public class FakeDalModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IRepository<User>>().SingleInstance();
            builder.RegisterType<GameRepository>().As<IRepository<Game>>().SingleInstance();
            builder.RegisterType<TournamentRepository>().As<IRepository<Tournament>>().SingleInstance();

            base.Load(builder);
        }
    }
}
