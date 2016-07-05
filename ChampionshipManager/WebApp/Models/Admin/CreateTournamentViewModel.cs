using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Admin
{
    public class CreateTournamentViewModel
    {
        public string Name { get; set; }
        public HttpPostedFileBase Logo { get; set; }
        public string SportKind { get; set; }
        public int ParticipateNumber { get; set; }
    }
}