using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTetrisScoreSystem.ViewModels.ViewComponents
{
    public class PlayerScoreViewModel
    {
        public int Rank { get; set; }

        public string NickName { get; set; }

        public int MaxoutsCount { get; set; }

        public string Kicker { get; set; }
    }
}
