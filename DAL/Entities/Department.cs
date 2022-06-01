﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication2.DAL.Entities;

namespace WebApplication2.DAl.Entities
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string DepartmentName { get; set; }
        [StringLength(20)]
        public string DepartmentCode { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
