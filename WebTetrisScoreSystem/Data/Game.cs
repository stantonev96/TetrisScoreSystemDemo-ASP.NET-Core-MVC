using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTetrisScoreSystem.Data
{
    public class Game
    {
        public Game()
        {
            Id = Guid.NewGuid().ToString();
            PlayerGames = new HashSet<PlayerGame>();
        }

        public string Id { get; set; }
        
        public string Score { get; set; }

        public ICollection<PlayerGame> PlayerGames { get; set; }
    }
}
