using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChargeBackCalculation.Models
{
      
        public class CustomerRegister
        {
            [Key]
            public int Id { get; set; }
            public int UserId { get; set; }

            // public string UserCatagery { get; set; }
            [Required(ErrorMessage = " First Name is Required")]

            [Display(Name = "First Name")]

            public string FirstName { get; set; }
            [Required(ErrorMessage = " Last Name is Required")]
            [Display(Name = "Last Name")]

            public string LastName { get; set; }
            [Required]
            [DataType(DataType.Date)]
            public DateTime? DateOfBirth { get; set; }
            public string Gender { get; set; }
            [Required(ErrorMessage = "You must provide a phone number")]
            [Display(Name = "Phone no")]
            [DataType(DataType.PhoneNumber)]
            [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
            public string PhoneNumber { get; set; }
            [Required(ErrorMessage = "Enter Address")]

            public string Address { get; set; }

            [StringLength(35)]
            public string City { get; set; }
            public string State { get; set; }

            [DataType(DataType.PostalCode)]
            public int ZipCode { get; set; }

            //[Required(ErrorMessage = "Email Id Required")]
            [Display(Name = "Email ID")]
            [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$",
           ErrorMessage = "Email Format is wrong")]
            public string Email { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "UserName can't be empty")]
            [MinLength(6, ErrorMessage = "Minium length 6 chracter")]

            [Display(Name = "UserName")]
            public string UserName { get; set; }



            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }


            [Required]
            [DataType(DataType.Password)]

            [Display(Name = "Confirm password")]

            [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]

            public string ConfirmPassword { get; set; }
            public SecretQuestion SecretQuestions { get; set; }

            [Required(ErrorMessage = "Please Enter Answer")]
            [Display(Name = "Answer")]
            public string Answer { get; set; }


            [Required]
            [DataType(DataType.Date)]
            public DateTime? RegisterDate { get; set; }
        }
    }
