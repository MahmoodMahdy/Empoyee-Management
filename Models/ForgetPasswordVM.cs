using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class ForgetPasswordVM
    {
        [Required(ErrorMessage = "Required Email")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
