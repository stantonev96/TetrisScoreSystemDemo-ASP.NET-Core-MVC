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
        private readonly ApplicationDbContext tetrisDbContext;

        public TetrisService(ApplicationDbContext tetrisDbContext)
        {
            this.tetrisDbContext = tetrisDbContext;
        }

        public async Task AddScoreForCurrentPlayerAsync(PlayGameInputModel input)
        {
            var score = new Game { Score = string.Format("{0:0.000}", input.Score) };
            await tetrisDbContext.Games.AddAsync(score);

            var playerScore = new PlayerGame { GameId = score.Id, PlayerId = input.UserId };
            await tetrisDbContext.PlayerGames.AddAsync(playerScore);

            await tetrisDbContext.SaveChangesAsync();
        }

        public async Task ChangePlayerNicknameAsync(ChangeNicknameInputModel input)
        {
            var currentPlayer = tetrisDbContext.Players.FirstOrDefault(x => x.Id == input.UserId);

            currentPlayer.PlayerNickname = input.PlayerNickname;
            tetrisDbContext.Players.Update(currentPlayer);
            await tetrisDbContext.SaveChangesAsync();
        }
    }
}
