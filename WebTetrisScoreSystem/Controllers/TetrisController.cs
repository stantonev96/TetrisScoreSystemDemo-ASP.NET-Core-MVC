using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebTetrisScoreSystem.Data;
using WebTetrisScoreSystem.Services;
using WebTetrisScoreSystem.ViewModels;

namespace WebTetrisScoreSystem.Controllers
{
    public class TetrisController : Controller
    {
        private readonly ITetrisService tetrisService;

        public TetrisController(ITetrisService tetrisService)
        {
            this.tetrisService = tetrisService;
        }

        [Authorize(Roles = "Player")]
        public IActionResult Index()
        {
            return this.View();
        }

        [Authorize(Roles = "Player")]
        public IActionResult PlayGame()
        {
            return this.View();
        }

        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Player")]
        [HttpPost]
        public async Task<IActionResult> PlayGame(PlayGameInputModel input)
        {
            input.UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            
            if(!ModelState.IsValid)
            {
                return this.View();
            }

            await tetrisService.AddScoreForCurrentPlayerAsync(input);

            return this.Redirect("/Tetris/Index");
        }

        [Authorize(Roles = "Player")]
        public IActionResult ChangeNickname()
        {
            return this.View();
        }

        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Player")]
        [HttpPost]
        public async Task<IActionResult> ChangeNickname(ChangeNicknameInputModel input)
        {
            input.UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (!ModelState.IsValid)
            {
                return this.View();
            }

            await tetrisService.ChangePlayerNicknameAsync(input);

            return this.Redirect("/Tetris/Index");
        }
    }
}
