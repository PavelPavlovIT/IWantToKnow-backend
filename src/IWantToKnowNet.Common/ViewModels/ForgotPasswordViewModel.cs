using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWantToKnowNet.Common.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [EmailAddress]
        [Display(Name = "Email")]
        public required string Email { get; set; }

    }
}
