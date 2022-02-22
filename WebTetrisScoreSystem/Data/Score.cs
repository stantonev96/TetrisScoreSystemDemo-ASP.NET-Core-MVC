using System;
using System.Collections.Generic;

#nullable disable

namespace WebTetrisScoreSystem.Data
{
    public partial class Score
    {
        public Score()
        {
            PlayerScores = new HashSet<PlayerScore>();
        }

        public int Id { get; set; }
        public string Points { get; set; }

        public virtual ICollection<PlayerScore> PlayerScores { get; set; }
    }
}
