using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITournamentParticipateService
    {
        void CreateParticipateRequest(int userId, int tournamentId);
        void AcceptParticipateRequest(int userId, int tournamentId);
        void DeclineParticipateRequest(int userId, int tournamentId);
        void RemoveFromTournament(int userId, int tournamentId);
    }
}
