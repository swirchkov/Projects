using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.EntityWorkers
{
    internal class TournamentWorker : EntityWorker, IEntityWorker<Tournament>
    {
        public void Create(Tournament item)
        {
            db.Tournaments.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Tournament tournament = db.Tournaments.FirstOrDefault(t => t.Id == id);

            if (tournament == null)
            {
                throw new ArgumentException("Invalid tournament id");
            }

            db.Tournaments.Remove(tournament);
            db.SaveChanges();
        }

        public IEnumerable<Tournament> Find(Func<Tournament, bool> predicate)
        {
            return db.Tournaments.Where(predicate);
        }

        public Tournament Get(int id)
        {
            return db.Tournaments.FirstOrDefault(t => t.Id == id);
        }

        public void Update(Tournament item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
