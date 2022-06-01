using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Mail Required")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Password Required")]
        [MinLength(3, ErrorMessage = "Min Length  3")]
        [DataType(DataType.Password)]

        public string Password { get; set; }
        public bool RememberME { get; set; }
    }
}
