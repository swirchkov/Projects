using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Tournament
{
    public class TournamentSearchViewModel
    {
        public TournamentSearchViewModel(TournamentDTO tour, int currentNumber, UserInTournamentStatus status)
        {
            this.Id = tour.Id;
            this.CurrentParticipateNumber = currentNumber;
            this.Logo = tour.Logo;
            this.Name = tour.Name;
            this.RequiredParticipateNumber = tour.ParticipateNumber;
            this.Status = status;
            this.IsStarted = tour.IsStarted;
        }

        public int Id { get; }
        public string Name { get; }
        public string Logo { get; }
        public int CurrentParticipateNumber { get; }
        public int RequiredParticipateNumber { get; }
        public UserInTournamentStatus Status { get; }
        public bool IsStarted { get; }
    }
}