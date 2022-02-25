using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTetrisScoreSystem.ViewModels
{
    public class ChangeNicknameInputModel
    {
        public string UserId { get; set; }

        [Required]
        public string PlayerNickname { get; set; }
    }
}
