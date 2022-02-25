using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTetrisScoreSystem.Areas.Administration.ViewModels
{
    public class UpdateScoresViewModel
    {
        public string PlayerNickname { get; set; }

        public string ScoreId { get; set; }

        public string Score { get; set; }
    }
}
