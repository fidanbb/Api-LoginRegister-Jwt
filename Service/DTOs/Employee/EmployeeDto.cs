using System;
using Service.DTOs.Common;

namespace Service.DTOs.Employee
{
	public class EmployeeDto:BaseDto
	{
		public string FullName { get; set; }
		public string Address { get; set; }
		public int Age { get; set; }
	}
}

