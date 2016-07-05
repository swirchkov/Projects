using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITournamentService : IEntityService<TournamentDTO>
    {
        TournamentTableDTO GetTournamentTable(int TournamentId);
        IEnumerable<TournamentSearchDTO> SearchTournamentsByQuery(string query, UserDTO user);
    }
}
