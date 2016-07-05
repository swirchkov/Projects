using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityWorkers
{
    internal class TokenWorker : EntityWorker, IEntityWorker<AuthehticationToken>
    {
        public void Create(AuthehticationToken item)
        {
            db.Tokens.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            AuthehticationToken token = db.Tokens.Where(t => t.Id == id).FirstOrDefault();

            if (token == null)
            {
                throw new ArgumentException("Invalid token id");
            }
        }

        public IEnumerable<AuthehticationToken> Find(Func<AuthehticationToken, bool> predicate)
        {
            return db.Tokens.Where(predicate);
        }

        public AuthehticationToken Get(int id)
        {
            return db.Tokens.Where(t => t.Id == id).FirstOrDefault();
        }

        public void Update(AuthehticationToken item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
