using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTetrisScoreSystem.Areas.Administration.Services;
using WebTetrisScoreSystem.Areas.Administration.ViewModels;
using WebTetrisScoreSystem.ViewModels;

namespace WebTetrisScoreSystem.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Route("Administration/[controller]/[action]")]
    public class AdminController : Controller
    {
        private readonly IAdminService adminService;

        public AdminController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return this.View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult ManagePlayers(IEnumerable<ManagePlayersViewModel> viewModel)
        {
            viewModel = adminService.GetAllPlayers();
            return this.View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult UpdateScores(IEnumerable<UpdateScoresViewModel> viewModel, string Id)
        {
            viewModel = adminService.GetAllScoresCurrentPlayer(Id);
            return this.View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult EditScoreForCurrentPlayer(string scoreId)
        {
            UpdateScoresViewModel viewModel = adminService.GetScoreCurrentPlayer(scoreId);
            return this.View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditScoreForCurrentPlayer(PlayGameInputModel input, string scoreId)
        {
            if(!ModelState.IsValid)
            {
                return this.View(input);
            }

            await adminService.EditScoreForCurrentPlayerAsync(input, scoreId);
            return this.Redirect("/Administration/Admin/Index");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteScoreCurrentPlayer(string scoreId)
        {
            await adminService.DeleteScoreForCurrentPlayerAsync(scoreId);
            return this.Redirect("/Administration/Admin/ManagePlayers");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCurrentPlayer(string Id)
        {
            await adminService.DeleteCurrentPlayerAsync(Id);
            return this.Redirect("/Administration/Admin/ManagePlayers");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult ViewRanklist()
        {
            return this.View();
        }
    }
}
