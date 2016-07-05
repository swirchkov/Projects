using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.Models;
using DAL;
using BLL.Validators;
using BLL.DI;
using Autofac;

namespace BLL.Services
{
    internal class TournamentParticipateService : ITournamentParticipateService
    {
        private IRepository<Tournament> repo;
        private IRepository<ParticipateRequest> requestRepo;
        public TournamentParticipateService()
        {
            AutofacContainer auContainer = new AutofacContainer();
            repo = auContainer.Container.Resolve<IRepository<Tournament>>();
            requestRepo = auContainer.Container.Resolve<IRepository<ParticipateRequest>>();
        }

        public void AcceptParticipateRequest(int userId, int tournamentId)
        {
            Tournament tour = repo.Get(tournamentId);

            if (tour == null)
            {
                var message = ExceptionMessageProvider.FOREIGN_KEY_PROBLEMS;
                throw new ValidationException(message.Key, message.Value);
            }

            ParticipateRequest req = tour.ParticipateRequests.FirstOrDefault(pr => pr.UserId == userId);
            if (req == null)
            {
                var message = ExceptionMessageProvider.FOREIGN_KEY_PROBLEMS;
                throw new ValidationException(message.Key, message.Value);
            }
            AutofacContainer auContainer = new AutofacContainer();
            IRepository<User> userRepo = auContainer.Container.Resolve<IRepository<User>>();
            IRepository<ParticipateRequest> requestRepo = auContainer.Container.Resolve<IRepository<ParticipateRequest>>();

            requestRepo.Delete(req.Id);

            User user = userRepo.Get(userId);

            tour.Participates.Add(user);

            repo.SaveChanges();
        }

        public void CreateParticipateRequest(int userId, int tournamentId)
        {
            ParticipateRequest req = new ParticipateRequest()
            {
                UserId = userId,
                TournamentId = tournamentId
            };

            Tournament tour = repo.Get(tournamentId);
            if (tour.IsStarted)
            {
                var message = ExceptionMessageProvider.TOURNAMENT_ALREADY_STARTS;
                throw new ValidationException(message.Key, message.Value);
            }

            requestRepo.Create(req);
        }

        public void DeclineParticipateRequest(int userId, int tournamentId)
        {
            Tournament tour = repo.Get(tournamentId);

            if (tour == null)
            {
                var message = ExceptionMessageProvider.FOREIGN_KEY_PROBLEMS;
                throw new ValidationException(message.Key, message.Value);
            }

            ParticipateRequest req = tour.ParticipateRequests.FirstOrDefault(pr => pr.UserId == userId);
            if (req == null)
            {
                var message = ExceptionMessageProvider.FOREIGN_KEY_PROBLEMS;
                throw new ValidationException(message.Key, message.Value);
            }
            AutofacContainer auContainer = new AutofacContainer();
            IRepository<User> userRepo = auContainer.Container.Resolve<IRepository<User>>();
            IRepository<ParticipateRequest> requestRepo = auContainer.Container.Resolve<IRepository<ParticipateRequest>>();

            requestRepo.Delete(req.Id);

            repo.SaveChanges();
        }

        public void RemoveFromTournament(int userId, int tournamentId)
        {
            Tournament tour = repo.Find(t => t.Id == tournamentId).FirstOrDefault();

            if (tour == null)
            {
                var message = ExceptionMessageProvider.ID_NOT_FOUND_IN_DATABASE;
                throw new ValidationException(message.Key, message.Value);
            }

            User user = tour.Participates.FirstOrDefault(u => u.Id == userId);

            if (tour == null)
            {
                var message = ExceptionMessageProvider.FOREIGN_KEY_PROBLEMS;
                throw new ValidationException(message.Key, message.Value);
            }

            tour.Participates.Remove(user);
            repo.SaveChanges();
        }
    }
}
