using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ParticipateRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TournamentId { get; set; }
        public bool Accepted { get; set; }

        public virtual User User { get; set; }
        public virtual Tournament Tournament { get; set; }
    }
}
