using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.EntityWorkers
{
    internal class UserWorker : EntityWorker, IEntityWorker<User>
    {
        public void Create(User item)
        {
            db.Users.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            User user = db.Users.FirstOrDefault(us => us.Id == id);

            if (user == null)
            {
                throw new ArgumentException("Invalid user id");
            }

            db.Users.Remove(user);
            db.SaveChanges();
        }

        public IEnumerable<User> Find(Func<User, bool> predicate)
        {
            return db.Users.Where(predicate);
        }

        public User Get(int id)
        {
            return db.Users.First(user => user.Id == id);
        }

        public void Update(User item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
