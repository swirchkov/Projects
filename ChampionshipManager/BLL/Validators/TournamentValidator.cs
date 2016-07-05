using BLL.DI;
using BLL.DTO;
using DAL;
using DAL.Models;
using System;
using Autofac;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Validators
{
    internal class TournamentValidator : IEntityValidator<TournamentDTO>
    {
        private bool checkForExisting(int id)
        {
            AutofacContainer aucontainer = new AutofacContainer();
            IRepository<Tournament> repo = aucontainer.Container.Resolve<IRepository<Tournament>>();

            return repo.Find(t => t.Id == id).FirstOrDefault() != null;
        }

        private bool validateItem(TournamentDTO tour)
        {
            if (tour.ParticipateNumber <= 0)
            {
                var message = ExceptionMessageProvider.ZERO_TOURNAMENT_PARTICIPATES_MESSAGE;
                throw new ValidationException(message.Key, message.Value);
            }

            if ( String.IsNullOrWhiteSpace(tour.Name) || String.IsNullOrWhiteSpace(tour.Logo) || String.IsNullOrWhiteSpace( tour.SportKind))
            {
                var message = ExceptionMessageProvider.NULL_VALUE_MESSAGE;
                throw new ValidationException(message.Key, message.Value);
            }
            return true;
        }
          
        public bool ValidateEntityForDelete(int id)
        {
            if (!checkForExisting(id))
            {
                var message = ExceptionMessageProvider.ID_NOT_FOUND_IN_DATABASE;
                throw new ValidationException(message.Key, message.Value);
            }
            return true;
        }

        public bool ValidateEntityForCreate(TournamentDTO item)
        {
            if (checkForExisting(item.Id))
            {
                var message = ExceptionMessageProvider.ID_EXISTS_IN_DATABASE;
                throw new ValidationException(message.Key, message.Value);
            }
            return validateItem(item);
        }

        public bool ValidateEntityForUpdate(TournamentDTO item)
        {
            if (!checkForExisting(item.Id))
            {
                var message = ExceptionMessageProvider.ID_NOT_FOUND_IN_DATABASE;
                throw new ValidationException(message.Key, message.Value);
            }

            return validateItem(item);
        }

    }
}
