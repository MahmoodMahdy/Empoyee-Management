using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class EmployeeVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Your Name")]
        [MinLength(3, ErrorMessage = "Less than 3")]
        [MaxLength(50, ErrorMessage = "More than 50")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Salary")]
        [Range(3000, 10000, ErrorMessage = "Enter Salary between 3K : 10K")]
        public float Salary { get; set; }
        [Required(ErrorMessage = "Enter Address")]
        [RegularExpression("[0-9]{2,5}-[a-zA-Z]{3,50}-[a-zA-Z]{3,50}-[a-zA-Z]{3,50}", ErrorMessage = "Enter Like 12-StreetName-CityName-CountryName")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Enter HireDAte")]
        public DateTime HireDate { get; set; }

        [Required(ErrorMessage = "Enter Email")]
        public string Email { get; set; }
        public bool IsActive { get; set; }

        public string Notes { get; set; }
        
        public string DepartmentId { get; set; }
        public string DistrictId { get; set; }
        public IFormFile PhotoUrl { get; set; }
        public string PhotoName { get; set; }
        public IFormFile CvUrl { get; set; }

        public string CvName { get; set; }
    }
}
