using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Tournament
{
    public class TournamentMainViewModel
    {
        public IEnumerable<TournamentDTO> ProcessingTournaments { get; set; }
        public IEnumerable<TournamentDTO> NotStartedStournaments { get; set; }
        public IEnumerable<TournamentDTO> FinishedTournaments { get; set; }
        public IEnumerable<TournamentDTO> RequestSendedTournaments { get; set; }
    }
}