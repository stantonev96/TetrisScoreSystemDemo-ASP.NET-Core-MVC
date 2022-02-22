using System;
using System.Collections.Generic;

#nullable disable

namespace WebTetrisScoreSystem.Data
{
    public partial class PlayerScore
    {
        public int PlayerId { get; set; }
        public int ScoreId { get; set; }

        public virtual Player Player { get; set; }
        public virtual Score Score { get; set; }
    }
}
