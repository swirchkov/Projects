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
    public class TournamentDTO
    {
        [NonSerialized]
        private Tournament tournament;
        [NonSerialized]
        private bool? exists = null;

        public TournamentDTO()
        {
        }

        public TournamentDTO(Tournament tour)
        {
            this.Id = tour.Id;
            this.IsFinished = tour.IsFinished;
            this.IsStarted = tour.IsStarted;
            this.Logo = tour.Logo;
            this.Name = tour.Name;
            this.ParticipateNumber = tour.ParticipateNumber;
            this.SportKind = tour.SportKind;

            tournament = tour;
            this.exists = true;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public int ParticipateNumber { get; set; }
        public string SportKind { get; set; }
        public bool IsStarted { get; set; }
        public bool IsFinished { get; set; }

        // related objects
        public IEnumerable<UserDTO> Participates
        {
            get
            {
                if (tournament == null)
                {
                    getTournament();
                }

                if (this.exists == true)
                {
                    return tournament.Participates?.Select(u => (UserDTO)u);
                }
                else
                {
                    return null;
                }
            }
        }

        public IEnumerable<GameDTO> Games
        {
            get
            {
                if (tournament == null)
                {
                    getTournament();
                }
                if (this.exists == true)
                {
                    return tournament.Games.Select(g => (GameDTO)g);
                }
                else
                {
                    return null;
                }
            }
        }

        public IEnumerable<UserDTO> ParticipateRequests
        {
            get
            {
                if (tournament == null)
                {
                    getTournament();
                }

                if (this.exists == true)
                {
                    return tournament.ParticipateRequests?.Select(part => (UserDTO)part.User);
                }
                else
                {
                    return null;
                }
            }
        }

        private void getTournament()
        {
            AutofacContainer container = new AutofacContainer();
            IRepository<Tournament> repo = container.Container.Resolve<IRepository<Tournament>>();

            try
            {
                tournament = repo.Get(this.Id);
            }
            catch (InvalidOperationException)
            {
                this.exists = false;
                return;
            }

            this.exists = true;
        }

        public static explicit operator TournamentDTO(Tournament t)
        {
            return new TournamentDTO(t);
        }

        public static explicit operator Tournament(TournamentDTO t)
        {
            return new Tournament()
            {
                Id = t.Id,
                Name = t.Name,
                IsFinished = t.IsFinished,
                IsStarted = t.IsStarted,
                Logo = t.Logo,
                ParticipateNumber = t.ParticipateNumber,
                SportKind = t.SportKind
            };
        }
    }
}
