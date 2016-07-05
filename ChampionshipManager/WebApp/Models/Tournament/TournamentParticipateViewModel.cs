using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Tournament
{
    public class TournamentParticipateViewModel
    {
        public int Id { get; set; }
        public IEnumerable<ParticipateViewModel> Participates { get; set; }
        public IEnumerable<UserDTO> ParticipateRequests { get; set; }
        public bool IsStarted { get; set; }
        public bool IsFinished { get; set; }
    }

    public class ParticipateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public int PointNumber { get; set; }
    }
}