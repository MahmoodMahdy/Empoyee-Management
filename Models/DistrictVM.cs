using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class DistrictVM
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string DistrictName { get; set; }
        public int CityName { get; set; }
    }
}
