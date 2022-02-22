using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public IActionResult ShowAll()
        {
            return this.View();
        }

        public IActionResult ShowScores()
        {
            var viewModel = new List<PlayerInputModel>();

            viewModel = tetrisService.GetPlayerScores() as List<PlayerInputModel>;

            return this.View(viewModel);
        }

        public IActionResult AddPlayer()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPlayer(PlayerInputModel input)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }
            
            await tetrisService.AddPlayerScoreAsync(input);
            return this.RedirectToAction("ShowAll");
        }
    }
}
