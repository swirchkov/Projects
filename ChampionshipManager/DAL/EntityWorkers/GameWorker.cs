using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.EntityWorkers
{
    internal class GameWorker : EntityWorker, IEntityWorker<Game>
    {
        public void Create(Game item)
        {
            db.Games.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Game game = db.Games.FirstOrDefault(g => g.Id == id);

            if (game == null)
            {
                throw new ArgumentException("Invalid game id");
            }

            db.Games.Remove(game);
            db.SaveChanges();
        }

        public IEnumerable<Game> Find(Func<Game, bool> predicate)
        {
            return db.Games.Where(predicate);
        }

        public Game Get(int id)
        {
            return db.Games.FirstOrDefault(g => g.Id == id);
        }

        public void Update(Game item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
