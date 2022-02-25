using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTetrisScoreSystem.Data
{
    public class PlayerGame
    {
        public PlayerGame()
        {
            GameId = Guid.NewGuid().ToString();
        }

        public string PlayerId { get; set; }

        public string GameId { get; set; }

        public Player Player { get; set; }

        public Game Game { get; set; }
    }
}
