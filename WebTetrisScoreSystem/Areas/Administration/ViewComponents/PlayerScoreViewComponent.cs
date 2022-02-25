using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTetrisScoreSystem.Areas.Administration.ViewModels.ViewComponents;
using WebTetrisScoreSystem.Data;

namespace WebTetrisScoreSystem.Areas.Administration.ViewComponents
{
    public class PlayerScoreViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext dbContext;

        public PlayerScoreViewComponent(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IViewComponentResult Invoke()
        {
            var viewModel = dbContext.Players.Where(x => x.PlayerNickname != null)
                                     .Select(x => new PlayerScoreViewModel
                                     {
                                         Nickname = x.PlayerNickname,
                                         MaxoutsCount = x.PlayerGames
                                                        .Count(x => x.Game.Score == "999.999"),
                                         Kicker = x.PlayerGames
                                                   .Where(x => x.Game.Score != "999.999")
                                                   .Max(x => x.Game.Score) ?? "0",
                                     })
                                     .OrderByDescending(x => x.MaxoutsCount)
                                     .ThenByDescending(x => x.Kicker)
                                     .ThenByDescending(x => x.Nickname)
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
