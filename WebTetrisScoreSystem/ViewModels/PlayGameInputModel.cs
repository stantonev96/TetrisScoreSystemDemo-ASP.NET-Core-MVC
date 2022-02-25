using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTetrisScoreSystem.ViewModels
{
    public class PlayGameInputModel
    {
        public string UserId { get; set; }

        [Required]
        [Range(0, 999.999, ErrorMessage = "Score must be in range 0...999.999")]
        public double Score { get; set; }

        public string ScoreId { get; set; }
    }
}
