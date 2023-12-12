using System;
using System.ComponentModel.DataAnnotations;

namespace Service.DTOs.Employee
{
	public class EmployeeCreateDto
	{
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int Age { get; set; }
    }
}

