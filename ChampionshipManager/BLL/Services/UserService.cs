using BLL.DI;
using BLL.DTO;
using BLL.Interfaces;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using BLL.Validators;
using BLL.Util;

namespace BLL.Services
{
    internal class UserService : Interfaces.IEntityService<UserDTO>, IUserService
    {
        private IRepository<User> repo;
        private IEntityValidator<UserDTO> validator;
        private const string siteUrl = "http://localhost:24766/";

        private void sendMessage(UserDTO user)
        {
            string token = BCrypt.Net.BCrypt.HashPassword(user.Email + " " + user.Password);
            string messageBody = 
                @"<header style='text-align:center'> <h3> Регистрация на сайте проведение турниров </h3> </header>
                    <article style='margin-top: 50px;'> Перейдите по следующей <a href='" + siteUrl + "/Account/VerifyEmail?token=" + token + "&&email="+ user.Email + "'> ссылке </a> чтобы закончить регистрацию. </article> ";

            string messageTitle = "Регистрация на сайте для проведение турниров";

            EmailSender.SendMessage(messageTitle, messageBody, user.Email);
        }

        public UserService()
        {
            AutofacContainer auContainer = new AutofacContainer();

            repo = auContainer.Container.Resolve<IRepository<User>>();
            validator = auContainer.Container.Resolve<IEntityValidator<UserDTO>>();
        }

        public void CreateItem(UserDTO item)
        {
            if (!validator.ValidateEntityForCreate(item))
            {
                return;
            }

            repo.Create((User)item);
        }

        public void DeleteItem(int id)
        {
            if (!validator.ValidateEntityForDelete(id))
            {
                return;
            }

            repo.Delete(id);
        }

        public IEnumerable<UserDTO> Find(Func<UserDTO, bool> predicate)
        {
            return repo.Find(u => true).Select(u => (UserDTO)u).Where(predicate);
        }

        public void Register(UserDTO user)
        {
            // validate
            if (!validator.ValidateEntityForCreate(user))
            {
                return;
            }
            
            // hash pass
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password, 12);
            
            // create object
            repo.Create((User)user);

            // send email
            this.sendMessage(user);
        }

        public void UpdateItem(UserDTO item)
        {
            if (!validator.ValidateEntityForUpdate(item))
            {
                return;
            }

            User dbUser = repo.Get(item.Id);

            dbUser.Comment = item.Comment;
            dbUser.Email = item.Email;
            dbUser.IsEmailVerified = item.IsEmailVerified;
            dbUser.Name = item.Name;
            if (dbUser.Password != item.Password)
            {
                dbUser.Password = BCrypt.Net.BCrypt.HashPassword(item.Password, 12);
            }
            dbUser.Patronymic = item.Patronymic;
            dbUser.PhoneNumber = item.PhoneNumber;
            dbUser.Photo = item.Photo;
            dbUser.Role = item.Role;
            dbUser.Surname = item.Surname;

            repo.Update(dbUser);
        }

        public UserDTO Login(UserDTO data)
        {
            User user = repo.Find(u => data.Email == u.Email).FirstOrDefault();

            if (user == null)
            {
                return null;
            }

            if (!BCrypt.Net.BCrypt.Verify(data.Password, user.Password))
            {
                return null;
            }

            return (UserDTO)user; 
        }

        public string GetTokenForUser(UserDTO user)
        {
            string token = Guid.NewGuid().ToString();

            AutofacContainer auContainer = new AutofacContainer();
            IRepository<AuthehticationToken> tokenRepo = auContainer.Container.Resolve<IRepository<AuthehticationToken>>();

            while (tokenRepo.Find(at => at.Token == token).FirstOrDefault() != null)
            {
                token = Guid.NewGuid().ToString();
            }

            DateTime datetime = DateTime.Now;
            datetime = datetime.AddDays(7);

            AuthehticationToken tokenEntity = new AuthehticationToken()
            {
                UserId = user.Id,
                Token = token,
                Expires = datetime
            };


            tokenRepo.Create(tokenEntity);

            return token;
        }

        public UserDTO GetUserByToken(string token)
        {
            AutofacContainer auContainer = new AutofacContainer();
            IRepository<AuthehticationToken> tokenRepo = auContainer.Container.Resolve<IRepository<AuthehticationToken>>();

            AuthehticationToken tokenEntity = tokenRepo.Find(at => at.Token == token).FirstOrDefault();
            if (tokenEntity == null)
            {
                return null;
            }
            return (UserDTO)tokenEntity.User;
        }

        public bool VerifyEmailToken(string token, UserDTO user)
        {
            return BCrypt.Net.BCrypt.Verify(user.Email + " " + user.Password, token);
        }

        public void SendRestoreMail(UserDTO user)
        {
            string token = BCrypt.Net.BCrypt.HashPassword(user.Email + " " + user.Password);
            string messageBody =
                @"<header style='text-align:center'> <h3> Восстановление пароля на сайте проведение турниров </h3> </header>
                    <article style='margin-top: 50px;'> Перейдите по следующей <a href='" + siteUrl + "/Account/RestorePasswordComplete?token=" + token + "&&email=" + user.Email + "'> ссылке </a> чтобы восстановить пароль доступа к сайту. </article> ";

            string messageTitle = "Восстановление пароля на сайте для проведение турниров";

            EmailSender.SendMessage(messageTitle, messageBody, user.Email);
        }
    }
}
