using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Photo { get; set; }
        public string Email { get; set; }
        public bool IsEmailVerified { get; set; }
        public string PhoneNumber { get; set; }
        public string Comment { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public virtual ICollection<Tournament> Tournaments { get; set; }
        public virtual ICollection<Game> Games { get; set; }
        public virtual ICollection<AuthehticationToken> Tokens { get; set; }
        public virtual ICollection<ParticipateRequest> ParticipateRequests { get; set; }

    }
}
