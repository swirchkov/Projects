using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EntityWorkers;
using Autofac;
namespace DAL
{
    public class Repository<T> : IRepository<T> where T : class 
    {
        private IEntityWorker<T> dbWorker;
        public Repository() 
        {
            AutofacContainer auContainer = new AutofacContainer();
            IContainer dependencyContainer = auContainer.Container;

            dbWorker = dependencyContainer.Resolve<IEntityWorker<T>>();
        }

        public T Get(int id)
        {
            return dbWorker.Get(id);
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return dbWorker.Find(predicate);
        }

        public void Create(T item)
        {
            dbWorker.Create(item);
        }

        public void Update(T item)
        {
            dbWorker.Update(item);
        }

        public void Delete(int id)
        {
            dbWorker.Delete(id);
        }

        public void SaveChanges()
        {
            ManagerContext db = ManagerContext.CreateInstance();
            db.SaveChanges();
        }
    }
}
