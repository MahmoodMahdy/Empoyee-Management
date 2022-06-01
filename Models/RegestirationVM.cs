using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; 

namespace WebApplication2.Models
{
    public class RegestirationVM
    {
        [Required(ErrorMessage = "Mail Required")]
        [EmailAddress(ErrorMessage ="Enter a valid email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Password Required")]
        [MinLength(3,ErrorMessage ="Min Length  3")]
        [DataType(DataType.Password)]

        public string Password { get; set; }


        [Required(ErrorMessage = "ConfirmPassword Required")]
        [MinLength(3, ErrorMessage = "Min Length  3")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "Not Matching")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
