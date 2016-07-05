using BLL.DI;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Autofac;

namespace BLL.DTO
{
    public class UserDTO 
    {
        private User user;
        private bool? exists = null;

        public UserDTO()
        {
        }

        public UserDTO(User u)
        {
            this.Id = u.Id;
            this.Comment = u.Comment;
            this.Email = u.Email;
            this.Name = u.Name;
            this.Password = u.Password;
            this.Patronymic = u.Patronymic;
            this.PhoneNumber = u.PhoneNumber;
            this.Photo = u.Photo;
            this.Role = u.Role;
            this.Surname = u.Surname;
            this.IsEmailVerified = u.IsEmailVerified;

            user = u;
            this.exists = true;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Photo { get; set; }
        public string Email { get; set; }
        public bool IsEmailVerified { get; set; }
        public string PhoneNumber { get; set; }
        public string Comment { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public IEnumerable<GameDTO> Games
        {
            get
            {
                if (user == null)
                {
                    getUser();
                }
                if (this.exists == true)
                {
                    return user.Games.Select(g => (GameDTO)g);
                }
                else
                {
                    return null;
                }
            }
        }

        public IEnumerable<TournamentDTO> Tournaments
        {
            get
            {
                if (user == null)
                {
                    getUser();
                }
                if (this.exists == true)
                {
                    return user.Tournaments.Select(t => (TournamentDTO)t);
                }
                else
                {
                    return null;
                }
            }
        }

        private void getUser()
        {
            AutofacContainer auContainer = new AutofacContainer();
            IRepository<User> userRepo = auContainer.Container.Resolve<IRepository<User>>();

            try
            {
                user = userRepo.Get(this.Id);
            }
            catch (InvalidOperationException)
            {
                this.exists = false;
                return;
            }
            this.exists = true;
        }

        public static explicit operator UserDTO(User u)
        {
            return new UserDTO(u);
        }

        public static explicit operator User(UserDTO u)
        {
            return new User()
            {
                Id = u.Id,
                Name = u.Name,
                Password = u.Password,
                Surname = u.Surname,
                Patronymic = u.Patronymic,
                Comment = u.Comment,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                Photo = u.Photo,
                Role = u.Role
            };
        }

        public override bool Equals(object obj)
        {
            UserDTO other = obj as UserDTO;

            if (other == null)
            {
                return false;
            }

            if (other.Id != 0 || this.Id != 0)
            {
                return other.Id == this.Id;
            }
            else
            {
                return other.Email == this.Email;
            }
        }

        public override int GetHashCode()
        { 
            return (Name + Patronymic + Surname + " -> " + Email).GetHashCode();
        }
    }
}
