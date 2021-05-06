using ChargeBackCalculation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChargeBackCalculation.ViewModels
{
    public class UserIdRecovery
    {
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Please Select Secret Question")]
        [Display(Name = "Secret Question")]
        public SecretQuestion SecretQuestions { get; set; }

        [Required(ErrorMessage = "Please Enter Answer")]
        [Display(Name = "Answer")]
        public string Answer { get; set; }

        [Required(ErrorMessage = "Email Id Required")]
        [Display(Name="Email ID")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$",
        ErrorMessage = "Email Format is wrong")]
        public string Email { get; set; }
    }
}