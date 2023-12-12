using System;
using Service.DTOs.Account;
using Service.Helpers.Responses;

namespace Service.Services.Interfaces
{
	public interface IAccountService
	{
		Task CreateRoleAsync();
		Task<LoginResponse> SignInAsync(LoginDto request);
		Task<RegisterResponse> SignUpAsync(RegisterDto request);
		List<string> GetAllRoles();
		List<UserDto> GetAllUsers();
		Task AddRoleToUSerAsync(UserRoleDto request);
	}
}

