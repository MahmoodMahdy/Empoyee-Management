﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class CountryVM
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string CountryName { get; set; }
    }
}
