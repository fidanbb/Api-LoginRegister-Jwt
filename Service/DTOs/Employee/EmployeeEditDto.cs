using System;
using System.ComponentModel.DataAnnotations;
using Service.DTOs.Common;

namespace Service.DTOs.Employee
{
	public class EmployeeEditDto
	{
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int Age { get; set; }
    }
}

