using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChargeBackCalculation.Models
{
    public class ComplaintRegister
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = " Customer id is Required")]
        [Display(Name = "Customer Id")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = " First Name is Required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = " Last Name is Required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Contact Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email ID")]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = " Account no is Required")]
        [StringLength(11)]
        public string BankAccountNo { get; set; }

        [Required(ErrorMessage = " Bank Branch is Required")]
        public string BankBranch { get; set; }

        [Required(ErrorMessage = " First Name is Required")]
        [Display(Name = "Charge Back Amount")]
        public string ChargeBackAmount { get; set; }

        [Required(ErrorMessage = " Reason is Required")]
        public string Reason { get; set; }

        [Required]
        [Display(Name = "Date Of Transaction")]
        [DataType(DataType.Date)]
        public DateTime? DateOfTransaction { get; set; }

    }
}