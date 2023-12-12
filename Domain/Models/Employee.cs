using System;
using Domain.Common;

namespace Domain.Models
{
	public class Employee:BaseEntity
	{
		public string FullName { get; set; }
		public string Address { get; set; }
		public int Age { get; set; }
	}
}

