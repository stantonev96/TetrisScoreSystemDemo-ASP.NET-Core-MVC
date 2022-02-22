using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTetrisScoreSystem.ViewModels
{
    public class PlayerInputModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0, 999.999)]
        public string Score { get; set; }

        public IEnumerable<SelectListItem> PlayerScores { get; set; }
    }
}
