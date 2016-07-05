using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.UnitTest.FakeDataInitializer
{
    public class UserRepository : IRepository<User>
    {
        private List<User> users = new List<User>()
        {
            new User()
            {
                Id =1,
                Name = "user1",
                Tournaments = new List<Tournament>()
                {
                    new Tournament()
                    {
                        Id = 1,
                        Name = "First tournament"
                    }
                }
            },
            new User()
            {
                Id = 2,
                Name = "user2",
                Tournaments = new List<Tournament>()
                {
                    new Tournament()
                    {
                        Id = 2,
                        Name = "Second tournament"
                    }
                }
            },
            new User()
            {
                Id = 3,
                Name = "editUser",
                Surname = "editSur",
                Password = "passe",
                Patronymic = "patrony",
                Email = "maill@mail.com",
                Photo = "photo",
                Role = "user",
                Comment = "something typed"
            },
            new User()
            {
                Id = 4,
                Name = "deleteUser",
                Surname = "",
                Password = "",
                Patronymic = "",
                Email = "maill@mail.com",
                Photo = "photo",
                Role = "",
                Comment = ""
            }
        };
        public void Create(User item)
        {
            users.Add(item);
        }

        public void Delete(int id)
        {
            users = new List<User>(users.Where(u => u.Id != id));
        }

        public IEnumerable<User> Find(Func<User, bool> predicate)
        {
            return users.Where(predicate);
        }

        public User Get(int id)
        {
            return users.FirstOrDefault(u => u.Id == id);
        }

        public void Update(User item)
        {
            users = new List<User>(users.Select(u => 
            {
                if (u.Id == item.Id)
                {
                    return item;
                }
                return u;
            }));
        }
    }
}
