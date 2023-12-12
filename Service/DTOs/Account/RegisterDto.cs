using System;
using System.ComponentModel.DataAnnotations;

namespace Service.DTOs.Account
{
	public class RegisterDto
	{
		[Required]
		public string FullName { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
	}
}

