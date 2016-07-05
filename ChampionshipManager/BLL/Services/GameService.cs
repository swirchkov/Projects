using BLL.DI;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Validators;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using Autofac;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    internal class GameService : IGameService
    {
        private IRepository<Game> repo;
        private IEntityValidator<GameDTO> validator;

        public GameService()
        {
            AutofacContainer auContainer = new AutofacContainer();

            repo = auContainer.Container.Resolve<IRepository<Game>>();
            validator = auContainer.Container.Resolve<IEntityValidator<GameDTO>>();
        }

        public void AddParticipates(int gameId, IEnumerable<UserDTO> users)
        {
            Game item = repo.Get(gameId);

            foreach (var user in users)
            {
                item.Competitors.Add((User)user);
            }

            repo.SaveChanges();
        }

        public void CreateItem(GameDTO item)
        {
            if (!validator.ValidateEntityForCreate(item))
            {
                return;
            }

            repo.Create((Game)item);
        }

        public void CreateItem(GameDTO item, IEnumerable<UserDTO> participates)
        {
            if (!validator.ValidateEntityForCreate(item))
            {
                return;
            }

            Game game = (Game)item;

            if (game.Competitors == null)
                game.Competitors = new List<User>();

            foreach (var user in participates)
            {
                game.Competitors.Add((User)user);
            }

            repo.Create(game);
        }

        public void DeleteItem(int id)
        {
            if (!validator.ValidateEntityForDelete(id))
            {
                return;
            }

            repo.Delete(id);
        }

        public IEnumerable<GameDTO> Find(Func<GameDTO, bool> predicate)
        {
            return repo.Find(g => true).Select(g => (GameDTO)g).Where(predicate);
        }

        public void UpdateItem(GameDTO item)
        {
            if (!validator.ValidateEntityForUpdate(item))
            {
                return;
            }

            Game dbGame = repo.Get(item.Id);

            dbGame.ResultView = item.ResultView;
            dbGame.Start = item.Start;
            dbGame.TournamentId = item.TournamentId;
            dbGame.WinnerId = item.WinnerId;

            repo.Update(dbGame);
        }
    }
}
