using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTetrisScoreSystem.Data;
using WebTetrisScoreSystem.ViewModels.ViewComponents;

namespace WebTetrisScoreSystem.ViewComponents
{
    public class PlayerScoreViewComponent : ViewComponent
    {
        private readonly TetrisDBContext dbContext;

        public PlayerScoreViewComponent(TetrisDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IViewComponentResult Invoke()
        {
            var viewModel = dbContext.Players
                                     .Select(x => new PlayerScoreViewModel
                                     {   
                                         NickName = x.Nickname,
                                         MaxoutsCount = x.PlayerScores
                                                        .Count(x => x.Score.Points == "999.999"),
                                         Kicker = x.PlayerScores
                                                   .Where(x => x.Score.Points != "999.999")
                                                   .Max(x => x.Score.Points) ?? "0",
                                     })
                                     .OrderByDescending(x => x.MaxoutsCount)
                                     .ThenByDescending(x => x.Kicker)
                                     .ToList();

            RankPlayers(viewModel);

            return this.View(viewModel);
        }

        private void RankPlayers(List<PlayerScoreViewModel> players)
        {
            int rank = 1;
            foreach (var player in players)
            {
                player.Rank = rank;
                rank++;
            }
        }
    }
}
