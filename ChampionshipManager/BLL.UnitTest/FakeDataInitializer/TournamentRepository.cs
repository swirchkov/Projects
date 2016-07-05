using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Models;

namespace BLL.UnitTest.FakeDataInitializer
{
    public class TournamentRepository : IRepository<Tournament>
    {
        private List<Tournament> tours = new List<Tournament>()
        {
            new Tournament()
            {
                Id = 1,
                Name = "First tournament",
                Logo = "logo1",
                Games = new List<Game>()
                {
                    new Game()
                    {
                        Id = 1,
                        ResultView = "game1"
                    }
                }
            },
            new Tournament()
            {
                Id = 2,
                Name = "Second tournament",
                Logo = "logo2",
                Games = new List<Game>()
                {
                    new Game()
                    {
                        Id = 2,
                        ResultView = "game2"
                    }
                }
            },
            new Tournament()
            {
                Id = 3,
                Name = "editTournament",
                Logo = "logo 12",
                ParticipateNumber = 3,
                SportKind = "box"
            },
            new Tournament()
            {
                Id = 4,
                Name = "deleteTournament"
            }
        };
        public void Create(Tournament item)
        {
            tours.Add(item);
        }

        public void Delete(int id)
        {
            tours = new List<Tournament>(tours.Where(t => t.Id != id));
        }

        public IEnumerable<Tournament> Find(Func<Tournament, bool> predicate)
        {
            return tours.Where(predicate);
        }

        public Tournament Get(int id)
        {
            return tours.First(t => t.Id == id);
        }

        public void SaveChanges()
        {
        }

        public void Update(Tournament item)
        {
            tours = new List<Tournament>(tours.Select(t =>
            {
                if (t.Id == item.Id)
                {
                    return item;
                }

                return t;
            }));
        }
    }
}
