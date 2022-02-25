using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTetrisScoreSystem.Areas.Administration.ViewModels;
using WebTetrisScoreSystem.ViewModels;

namespace WebTetrisScoreSystem.Areas.Administration.Services
{
    public interface IAdminService
    {
        IEnumerable<ManagePlayersViewModel> GetAllPlayers();

        IEnumerable<UpdateScoresViewModel> GetAllScoresCurrentPlayer(string playerId);

        PlayGameInputModel GetScoreCurrentPlayer(string scoreId);

        Task EditScoreForCurrentPlayerAsync(PlayGameInputModel input, string scoreId);

        Task DeleteScoreForCurrentPlayerAsync(string scoreId);

        Task DeleteCurrentPlayerAsync(string playerId);
    }
}
