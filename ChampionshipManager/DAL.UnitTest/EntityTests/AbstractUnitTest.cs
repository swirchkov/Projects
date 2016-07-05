using DAL.Models;
using Effort;
using Effort.DataLoaders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace DAL.UnitTest.EntityTests
{
    public abstract class AbstractUnitTest
    {
        protected ManagerContext db;

        protected Repository<User> userRepo;
        protected Repository<Tournament> tournamentRepo;
        protected Repository<Game> gameRepo;

        [TestInitialize]
        public void Initialize_Fake_Context()
        {
            DirectoryInfo di = new DirectoryInfo(Directory.GetCurrentDirectory());
            di = di.Parent.Parent;
            string path = Path.Combine(di.FullName, "CSVDataFiles");
            IDataLoader loader = new CsvDataLoader(path);

            ManagerContext mContext = ManagerContext.CreateInstance(DbConnectionFactory.CreateTransient(loader));
            db = mContext;

            userRepo = new Repository<User>();
            tournamentRepo = new Repository<Tournament>();
            gameRepo = new Repository<Game>();
        }
    }
}
