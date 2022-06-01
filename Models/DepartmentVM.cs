﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; 

namespace WebApplication2.Models
{
    public class DepartmentVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Department Name")]
        [MinLength(3,ErrorMessage ="Less Length 3")]
        [MaxLength(10,ErrorMessage = "Max Length 10")] 
        public string DepartmentName { get; set; }
        [Required(ErrorMessage = "Enter Department Code")]
        public string DepartmentCode { get; set; }
    }
}
