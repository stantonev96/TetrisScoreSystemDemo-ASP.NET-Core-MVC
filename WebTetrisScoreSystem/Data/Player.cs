using System;
using System.Collections.Generic;

#nullable disable

namespace WebTetrisScoreSystem.Data
{
    public partial class Player
    {
        public Player()
        {
            PlayerScores = new HashSet<PlayerScore>();
        }

        public int Id { get; set; }
        public string Nickname { get; set; }

        public virtual ICollection<PlayerScore> PlayerScores { get; set; }
    }
}
