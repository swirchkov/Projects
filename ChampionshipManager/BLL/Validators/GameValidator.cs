using BLL.DTO;
using System.Linq;
using DAL;
using DAL.Models;
using BLL.DI;
using Autofac;
using System;

namespace BLL.Validators
{
    internal class GameValidator : IEntityValidator<GameDTO>
    {
        private IRepository<Game> repo;

        public GameValidator()
        {
            AutofacContainer container = new AutofacContainer();
            repo = container.Container.Resolve<IRepository<Game>>();
        }

        private bool checkForExisting(int id)
        {
            Game item = repo.Find(g => g.Id == id).FirstOrDefault();

            return item != null;
        }

        private bool validateGame(GameDTO item)
        {
            if (item.Tournament == null)
            {
                // if it's new entity we should make more detailed scan, cause item.Tournament will always return null
                if (item.Id == 0)
                {
                    AutofacContainer auContainer = new AutofacContainer();
                    IRepository<Tournament> repo = auContainer.Container.Resolve<IRepository<Tournament>>();

                    try
                    {
                        Tournament t = repo.Get(item.TournamentId);
                    }
                    catch (InvalidOperationException)
                    {
                        var message = ExceptionMessageProvider.FOREIGN_KEY_PROBLEMS;
                        throw new ValidationException(message.Key, message.Value);
                    }
                }
                else
                {
                    var message = ExceptionMessageProvider.FOREIGN_KEY_PROBLEMS;
                    throw new ValidationException(message.Key, message.Value);
                }
            }

            return true;
        } 

        public bool ValidateEntityForDelete(int id)
        {
            if (checkForExisting(id))
            {
                return true;
            }
            else
            {
                var message = ExceptionMessageProvider.ID_NOT_FOUND_IN_DATABASE;
                throw new ValidationException(message.Key, message.Value);
            }
        }

        public bool ValidateEntityForCreate(GameDTO item)
        {
            if (checkForExisting(item.Id))
            {
                var message = ExceptionMessageProvider.ID_EXISTS_IN_DATABASE;
                throw new ValidationException(message.Key, message.Value);
            }

            return validateGame(item);
        }

        public bool ValidateEntityForUpdate(GameDTO item)
        {
            if (!checkForExisting(item.Id))
            {
                var message = ExceptionMessageProvider.ID_NOT_FOUND_IN_DATABASE;
                throw new ValidationException(message.Key, message.Value);
            }

            return validateGame(item);
        }
    }
}
