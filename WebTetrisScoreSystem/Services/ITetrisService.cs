using System.Collections.Generic;
using System.Threading.Tasks;
using WebTetrisScoreSystem.ViewModels;

namespace WebTetrisScoreSystem.Services
{
    public interface ITetrisService
    {
        IEnumerable<PlayerInputModel> GetPlayerScores();

        Task AddPlayerScoreAsync(PlayerInputModel input);
    }
}
