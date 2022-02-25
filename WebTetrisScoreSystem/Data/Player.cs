using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTetrisScoreSystem.Data
{
    public class Player : IdentityUser
    {
        public Player()
        {
            PlayerGames = new HashSet<PlayerGame>();
        }

        public string PlayerNickname { get; set; }

        public ICollection<PlayerGame> PlayerGames { get; set; }
    }
}
