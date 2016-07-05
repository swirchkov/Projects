using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IUserService : IEntityService<UserDTO>
    {
        void Register(UserDTO user);
        UserDTO Login(UserDTO user);
        string GetTokenForUser(UserDTO user);
        UserDTO GetUserByToken(string token);
        bool VerifyEmailToken(string token, UserDTO user);
        void SendRestoreMail(UserDTO user);
    }
}
