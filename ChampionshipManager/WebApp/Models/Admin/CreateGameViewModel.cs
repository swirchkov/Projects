using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Admin
{
    public class CreateGameViewModel
    {
        public int User1Id { get; set; }
        public int User2Id { get; set; }
        public int? FirstScore { get; set; }
        public int? SecondScore { get; set; }
        public int? Year { get; set; }
        public int? Month { get; set; }
        public int? Day { get; set; }
        public int? Hour { get; set; }
        public int? Minute { get; set; }
        public int TournamentId { get; set; }
    }
}