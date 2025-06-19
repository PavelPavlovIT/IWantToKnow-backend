using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWantToKnowNet.Common.ViewModels
{
    public class ResetPasswordViewModel
    {
        public required string UserId { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "NewPassword")]
        public required string NewPassword { get; set; }

        public required string Token { get; set; }
    }
}
