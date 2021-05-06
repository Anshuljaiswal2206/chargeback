using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChargeBackCalculation.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Display(Name = "Customer Id")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = " Account no is Required")]
        [StringLength(11)]
        public string BankAccountNumber { get; set; }

        [Required(ErrorMessage = " Bank Branch is Required")]
        public string BankBranchName { get; set; }
        [Required(ErrorMessage = "Enter Address")]

        public string BankAddress { get; set; }
        public int AvailableBalance { get; set; }
    }
}