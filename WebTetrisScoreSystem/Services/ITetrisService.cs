using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTetrisScoreSystem.ViewModels;

namespace WebTetrisScoreSystem.Services
{
    public interface ITetrisService
    {
        Task AddScoreForCurrentPlayerAsync(PlayGameInputModel input);

        Task ChangePlayerNicknameAsync(ChangeNicknameInputModel input);
    }
}
