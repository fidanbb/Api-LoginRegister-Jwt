using System;
using Microsoft.AspNetCore.Identity;

namespace Domain.Models
{
	public class AppUser:IdentityUser
	{
		public string FullName { get; set; }
	}
}

