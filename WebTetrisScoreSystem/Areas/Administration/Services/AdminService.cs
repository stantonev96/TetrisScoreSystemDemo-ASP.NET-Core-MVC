using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTetrisScoreSystem.Areas.Administration.ViewModels;
using WebTetrisScoreSystem.Data;
using WebTetrisScoreSystem.ViewModels;

namespace WebTetrisScoreSystem.Areas.Administration.Services
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext tetrisDbContext;

        public AdminService(ApplicationDbContext tetrisDb)
        {
            this.tetrisDbContext = tetrisDb;
        }

        public async Task DeleteCurrentPlayerAsync(string playerId)
        {
            var scores = tetrisDbContext.PlayerGames.Where(x => x.PlayerId == playerId)
                                             .Select(x => new Game
                                             {
                                                 Id = x.GameId,
                                                 Score = x.Game.Score,
                                             }).ToList();
            tetrisDbContext.Games.RemoveRange(scores);

            var player = tetrisDbContext.Players.FirstOrDefault(x => x.Id == playerId);
            tetrisDbContext.Players.Remove(player);

            await tetrisDbContext.SaveChangesAsync();
        }

        public async Task DeleteScoreForCurrentPlayerAsync(string scoreId)
        {
            var score = tetrisDbContext.Games.FirstOrDefault(x => x.Id == scoreId);
            tetrisDbContext.Games.Remove(score);
            await tetrisDbContext.SaveChangesAsync();
        }

        public async Task EditScoreForCurrentPlayerAsync(PlayGameInputModel input, string scoreId)
        {
            var playerScore = tetrisDbContext.Games.FirstOrDefault(x => x.Id == scoreId);

            playerScore.Score = string.Format("{0:0.000}", input.Score);

            tetrisDbContext.Update(playerScore);
            await tetrisDbContext.SaveChangesAsync();
        }

        public IEnumerable<ManagePlayersViewModel> GetAllPlayers()
        {
            var players = tetrisDbContext.Players.Where(x => x.PlayerNickname != null)
                .Select(x => new ManagePlayersViewModel
                {
                    PlayerId = x.Id,
                    Nickname = x.PlayerNickname,
                }).ToList();

            return players;
        }

        public IEnumerable<UpdateScoresViewModel> GetAllScoresCurrentPlayer(string playerId)
        {
            var scores = tetrisDbContext.PlayerGames.Where(x => x.PlayerId == playerId)
                .Select(x => new UpdateScoresViewModel
                {
                    ScoreId = x.GameId,
                    Score = string.Format("{0:0.000}", x.Game.Score),
                    PlayerNickname = x.Player.PlayerNickname,
                }).ToList();

            return scores;
        }

        public UpdateScoresViewModel GetScoreCurrentPlayer(string scoreId)
        {
            var viewModel = tetrisDbContext.PlayerGames.Where(x => x.GameId == scoreId)
                .Select(x => new UpdateScoresViewModel
                {
                    ScoreId = x.GameId,
                    Score = string.Format("{0:0.000}", x.Game.Score),
                    PlayerNickname = x.Player.PlayerNickname,
                }).FirstOrDefault();

            return viewModel;
        }
    }
}
