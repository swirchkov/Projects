using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Models;

namespace BLL.UnitTest.FakeDataInitializer
{
    internal class GameRepository : IRepository<Game>
    {
        private List<Game> games = new List<Game>()
        {
            new Game()
            {
                Id = 1,
                ResultView = "game1",
                Start = new DateTime(2016,12,12),
                Tournament = new Tournament()
                {
                    Id = 1,
                    Name = "First Tournament"
                }
            },
            new Game()
            {
                Id = 2,
                ResultView = "game2",
                Start = new DateTime(2016, 9, 10),
                Competitors = new List<User>()
                {
                    new User()
                    {
                        Id = 1,
                        Name = "user1"
                    }
                }
            },
            new Game()
            {
                Id = 3,
                ResultView = "editGame",
                Start = new DateTime(2016, 9, 3),
                TournamentId = 1,
                Tournament = new Tournament()
                {
                    Id = 1,
                    Name = "First tournament"
                }
            },
            new Game()
            {
                Id = 4,
                ResultView = "deleteGame"
            } 
        };
        public void Create(Game item)
        {
            games.Add(item);
        }

        public void Delete(int id)
        {
            Game item = games.Where(g => g.Id == id).First();
            games.Remove(item);
        }

        public IEnumerable<Game> Find(Func<Game, bool> predicate)
        {
            return games.Where(predicate);
        }

        public Game Get(int id)
        {
            return games.Where(g => g.Id == id).First();
        }

        public void SaveChanges()
        {

        }

        public void Update(Game item)
        {
            games = new List<Game>(games.Select(g =>
            {
                if (g.Id == item.Id)
                {
                    return item;
                }
                return g;

            }));
        }
    }
}
