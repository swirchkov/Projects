using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Game
    {
        public int Id { get; set; }
        public int TournamentId { get; set; }
        public int WinnerId { get; set; }
        public string ResultView { get; set; }
        public DateTime Start { get; set; }


        public virtual ICollection<User> Competitors { get; set; }
        public virtual Tournament Tournament { get; set; }
    }
}
