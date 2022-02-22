using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTetrisScoreSystem.Data;
using WebTetrisScoreSystem.ViewModels;

namespace WebTetrisScoreSystem.Services
{
    public class TetrisService : ITetrisService
    {
        private readonly TetrisDBContext dbContext;

        public TetrisService(TetrisDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddPlayerScoreAsync(PlayerInputModel input)
        {
            var player = dbContext.Players.FirstOrDefault(x => x.Nickname == input.Name);

            if(player == null)
            {
                player = new Player
                {
                    Nickname = input.Name,
                };
            }

            var playerScore = new PlayerScore
            {
                Player = player,
                Score = new Score
                {
                    Points = input.Score.ToString(),
                }
            };

           await dbContext.PlayerScores.AddAsync(playerScore);
           await dbContext.SaveChangesAsync();

        }

        public IEnumerable<PlayerInputModel> GetPlayerScores()
        {
            var viewModel = dbContext.Players.Select(x => new PlayerInputModel
            {
                Name = x.Nickname,
                PlayerScores = x.PlayerScores.Select(y => new SelectListItem
                {
                    Value = y.Player.Id.ToString(),
                    Text = y.Score.Points,                   
                }),
            }).ToList();

            return viewModel;
        }
    }
}
