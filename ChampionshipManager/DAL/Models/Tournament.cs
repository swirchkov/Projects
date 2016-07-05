using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Tournament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public int ParticipateNumber { get; set; }
        public string SportKind { get; set; }
        public bool IsStarted { get; set; }
        public bool IsFinished { get; set; }

        public virtual ICollection<User> Participates { get; set; }
        public virtual ICollection<Game> Games { get; set; }
        public virtual ICollection<ParticipateRequest> ParticipateRequests { get; set; }
    }
}
