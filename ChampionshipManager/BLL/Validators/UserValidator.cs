using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.DI;
using DAL;
using DAL.Models;
using Autofac;
using System.Text.RegularExpressions;

namespace BLL.Validators
{
    internal class UserValidator : IEntityValidator<UserDTO>
    {
        private bool checkForExisting(int id)
        {
            AutofacContainer auContainer = new AutofacContainer();
            IRepository<User> repo = auContainer.Container.Resolve<IRepository<User>>();

            try
            {
                repo.Get(id);
            }
            catch (InvalidOperationException)
            {
                return false;
            }

            return true;
        }

        private bool validateEntity(UserDTO item)
        {
            if (String.IsNullOrWhiteSpace(item.Comment) || String.IsNullOrWhiteSpace(item.Email) || String.IsNullOrWhiteSpace(item.Name) || String.IsNullOrWhiteSpace(item.Password) || String.IsNullOrWhiteSpace(item.Patronymic) || String.IsNullOrWhiteSpace(item.Role) || String.IsNullOrWhiteSpace(item.Surname))
            {
                var message = ExceptionMessageProvider.NULL_VALUE_MESSAGE;
                throw new ValidationException(message.Key, message.Value);
            }
            // email validation
            Regex exp = new Regex("[^@]+@[A-Za-z0-9]+\\.[A-Za-z]+");

            if (!exp.IsMatch(item.Email))
            {
                var message = ExceptionMessageProvider.INVALID_EMAIL;
                throw new ValidationException(message.Key, message.Value);
            }

            return true;
        }

        public bool ValidateEntityForCreate(UserDTO item)
        {
            if (checkForExisting(item.Id))
            {
                var message = ExceptionMessageProvider.ID_EXISTS_IN_DATABASE;
                throw new ValidationException(message.Key, message.Value);
            }

            return validateEntity(item);
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

        public bool ValidateEntityForUpdate(UserDTO item)
        {
            if (!checkForExisting(item.Id))
            {
                var message = ExceptionMessageProvider.ID_NOT_FOUND_IN_DATABASE;
                throw new ValidationException(message.Key, message.Value);
            }

            return validateEntity(item);
        }
    }
}
