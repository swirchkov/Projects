using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class TournamentTableDTO
    {
        private IEnumerable<UserDTO> users { get; set; }
        private Dictionary<KeyValuePair<UserDTO, UserDTO>, IEnumerable<GameDTO>> games { get; set; }

        public TournamentTableDTO()
        {
            users = new List<UserDTO>();
            games = new Dictionary<KeyValuePair<UserDTO, UserDTO>, IEnumerable<GameDTO>>();
        }

        public TournamentTableDTO(IEnumerable<UserDTO> users, IEnumerable<GameDTO> games)
        {
            this.users = users;

            this.games = new Dictionary<KeyValuePair<UserDTO, UserDTO>, IEnumerable<GameDTO>>();

            foreach(UserDTO user in users)
            {
                foreach (UserDTO user2 in users)
                {
                    IEnumerable<GameDTO> userGames = games.Where(g => compareParticipates(g.Participates, user, user2));
                    if (userGames.Count() > 0)
                    {
                        this.games[new KeyValuePair<UserDTO, UserDTO>(user, user2)] = userGames;
                    }
                    else
                    {
                        this.games[new KeyValuePair<UserDTO, UserDTO>(user, user2)] = null;
                    }
                }
            }
        }

        // is this game between this 2 participates ?
        private bool compareParticipates(IEnumerable<UserDTO> users, UserDTO user1, UserDTO user2)
        {
            if (users.Count() != 2)
            {
                return false;
            }
            if (user1.Email == users.First().Email)
            {
                return user2.Email == users.ElementAt(1).Email;
            }
            else
            {
                // positions play role cause it detects who plays at home
                return false;
            }
        }

        public IEnumerable<GameDTO> this[UserDTO user1, UserDTO user2]
        {
            get
            {
                if (games.ContainsKey(new KeyValuePair<UserDTO, UserDTO>(user1, user2)))
                {
                    return games[new KeyValuePair<UserDTO, UserDTO>(user1, user2)];
                }
                else
                {
                    return null;
                }

            }
        }

        public IEnumerable<UserDTO> Users {
            get
            {
                return this.users;
            }
        }
    }
}
