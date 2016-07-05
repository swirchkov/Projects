using BLL.DTO;
using BLL.Interfaces;
using System;
using DAL.Models;
using Autofac;
using BLL.DI;
using DAL;
using System.Linq;
using System.Collections.Generic;
using BLL.Validators;

namespace BLL.Services
{
    internal class TournamentService : ITournamentService
    {
        private IRepository<Tournament> repo;
        private IRepository<ParticipateRequest> requestRepo;
        private IEntityValidator<TournamentDTO> validator;

        private UserInTournamentStatus getUserTournamentStatus(TournamentDTO tournament, UserDTO user)
        {
            if (tournament.Participates != null && tournament.Participates.Count(u => u.Id == user.Id) > 0)
            {
                return UserInTournamentStatus.Participate;
            }
            else if (tournament.ParticipateRequests != null && tournament.ParticipateRequests.Count(u => u.Id == user.Id) > 0)
            {
                return UserInTournamentStatus.SendedRequest;
            }
            else
            {
                return UserInTournamentStatus.NoRelation;
            }
        }

        public TournamentService()
        {
            AutofacContainer auContainer = new AutofacContainer();

            repo = auContainer.Container.Resolve<IRepository<Tournament>>();
            requestRepo = auContainer.Container.Resolve<IRepository<ParticipateRequest>>();
            validator = auContainer.Container.Resolve<IEntityValidator<TournamentDTO>>();

        }

        public void CreateItem(TournamentDTO item)
        {
            if (!validator.ValidateEntityForCreate(item))
            {
                return;
            }

            repo.Create((Tournament)item);
        }

        public void DeleteItem(int id)
        {
            if (!validator.ValidateEntityForDelete(id))
            {
                return;
            }

            repo.Delete(id);
        }

        public IEnumerable<TournamentDTO> Find(Func<TournamentDTO, bool> predicate)
        {
            return repo.Find(t => true).Select(t => (TournamentDTO)t).Where(predicate);
        }

        public TournamentTableDTO GetTournamentTable(int tournamentId)
        {
            AutofacContainer auContainer = new AutofacContainer();
            IRepository<Tournament> repo = auContainer.Container.Resolve<IRepository<Tournament>>();

            Tournament tour = repo.Get(tournamentId);

            return new TournamentTableDTO(tour.Participates.Select(u => (UserDTO)u), tour.Games.Select(g => (GameDTO)g));
        }

        public IEnumerable<TournamentSearchDTO> SearchTournamentsByQuery(string query, UserDTO user)
        {
            IEnumerable<TournamentSearchDTO> tournaments = this.Find(t => t.Name.Contains(query)).
                OrderBy(t => t.Name.IndexOf(query)).
                Select(t => new TournamentSearchDTO(t, t.Participates.Count(), getUserTournamentStatus(t, user)));

            return tournaments;
        }

        public void UpdateItem(TournamentDTO item)
        {
            if (!validator.ValidateEntityForUpdate(item))
            {
                return;
            }

            Tournament db = repo.Find(t => t.Id == item.Id).FirstOrDefault();

            db.IsStarted = item.IsStarted;
            db.IsFinished = item.IsFinished;
            db.Name = item.Name;
            db.Logo = item.Logo;
            db.ParticipateNumber = item.ParticipateNumber;
            db.SportKind = item.SportKind;

            repo.Update(db);
        }
    }
}
