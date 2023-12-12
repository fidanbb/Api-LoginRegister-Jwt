﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Service.DTOs.Account
{
	public class LoginDto
	{
		[Required]
		public string Email { get; set; }
		public string Password { get; set; }
	}
}

