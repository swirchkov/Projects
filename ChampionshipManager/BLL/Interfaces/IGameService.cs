using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IGameService : IEntityService<GameDTO>
    {
        void AddParticipates(int gameId, IEnumerable<UserDTO> users);
        void CreateItem(GameDTO game, IEnumerable<UserDTO> participates);
    }
}
