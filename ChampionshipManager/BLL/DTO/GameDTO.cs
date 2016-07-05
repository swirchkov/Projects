using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL;
using BLL.DI;
using Autofac;

namespace BLL.DTO
{
    public class GameDTO
    {
        private Game game = null;
        private bool? exists = null;
        public GameDTO()
        {

        }

        public GameDTO(Game item)
        {
            this.Id = item.Id;
            this.ResultView = item.ResultView;
            this.Start = item.Start;
            this.TournamentId = item.TournamentId;
            this.WinnerId = item.WinnerId;

            game = item;
            this.exists = true;
        }

        public int Id { get; set; }
        public int TournamentId { get; set; }
        public int WinnerId { get; set; }
        public string ResultView { get; set; }
        public DateTime Start { get; set; }

        // Related objects

        public TournamentDTO Tournament
        {
            get
            {
                if (game == null)
                {
                    this.getGame();
                }

                if (this.exists == true)
                {
                    return (TournamentDTO)game.Tournament;
                }
                else
                {
                    return null;
                }
            }
        }

        public IEnumerable<UserDTO> Participates
        {
           get
           {
                if (game == null)
                {
                    this.getGame();
                }

                if (this.exists == true)
                {
                    return game.Competitors.Select(u => (UserDTO)u);
                }
                else
                {
                    return null;
                }
            }
        }

        private void getGame()
        {
            AutofacContainer auContainer = new AutofacContainer();
            IRepository<Game> gameRepo = auContainer.Container.Resolve<IRepository<Game>>();

            try
            {
                game = gameRepo.Get(this.Id);
            }
            catch (InvalidOperationException)
            {
                this.exists = false;
                return;
            }
            this.exists = game != null;
        }

        public static explicit operator GameDTO(Game param)
        {
            return new GameDTO(param);
        }

        public static explicit operator Game(GameDTO param)
        {
            return new Game()
            {
                Id = param.Id,
                ResultView = param.ResultView,
                WinnerId = param.WinnerId,
                TournamentId = param.TournamentId,
                Start = param.Start
            };
        }
    }
}
