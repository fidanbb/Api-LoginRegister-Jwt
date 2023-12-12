using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Repository.Exceptions;
using Repository.Helpers.ErrorMessages;
using Service.DTOs.Account;
using Service.Helpers;
using Service.Helpers.Enums;
using Service.Helpers.Responses;
using Service.Services.Interfaces;

namespace Service.Services
{
	public class AccountService:IAccountService
	{
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly JWTSettings _jwt;

		public AccountService(RoleManager<IdentityRole>  roleManager,
                              UserManager<AppUser> userManager,
                              IMapper mapper,
                              IOptions<JWTSettings>options )
		{
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
            _jwt = options.Value;
		}

        public async Task AddRoleToUSerAsync(UserRoleDto request)
        {
            AppUser user = await _userManager.FindByIdAsync(request.UserId);

            IdentityRole role = await _roleManager.FindByIdAsync(request.RoleId);

            await _userManager.AddToRoleAsync(user,role.Name);

        }

        public async Task CreateRoleAsync()
        {
            foreach (var role in Enum.GetValues(typeof(Roles)))
            {
                if (!await _roleManager.RoleExistsAsync(role.ToString()))
                {
                    await _roleManager.CreateAsync(new IdentityRole { Name=role.ToString()});
                }
            }
        }

        public List<string> GetAllRoles()
        {
            return _roleManager.Roles.Select(m => m.Name).ToList();
        }

        public List<UserDto> GetAllUsers()
        {
            return _mapper.Map<List<UserDto>>(_userManager.Users.ToList());
        }

        public async Task<LoginResponse> SignInAsync(LoginDto request)
        {
            ArgumentNullException.ThrowIfNull(request);

            AppUser existUser =await _userManager.FindByEmailAsync(request.Email);

            if (existUser is null) return new LoginResponse { IsSuccess = false, Token = null, Errors = new List<string>() { ExceptionMessage.LoginMessage } };

            if (! await _userManager.CheckPasswordAsync(existUser,request.Password))
            {
                return new LoginResponse { IsSuccess = false, Token = null, Errors = new List<string>() { ExceptionMessage.LoginMessage } };

            }
            var userRoles = await _userManager.GetRolesAsync(existUser);

            string token = GenerateJwtToken(existUser.UserName,(List<string>)userRoles);
            return new LoginResponse { IsSuccess = true, Token = token, Errors = null };


        }

        public async Task<RegisterResponse> SignUpAsync(RegisterDto request)
        {
            ArgumentNullException.ThrowIfNull(request);

            AppUser user = _mapper.Map<AppUser>(request);

           IdentityResult response = await _userManager.CreateAsync(user,request.Password);

            if (!response.Succeeded)
            {
                return new RegisterResponse { IsSuccess = false, Errors = response.Errors.Select(m => m.Description).ToList() };
            }

            await _userManager.AddToRoleAsync(user,Roles.Member.ToString());

            return new RegisterResponse { IsSuccess = true, Errors =null };


        }


        private string GenerateJwtToken(string username, List<string> roles)
        {
            var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, username)
        };

            roles.ForEach(role =>
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            });

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_jwt.ExpireDays));

            var token = new JwtSecurityToken(
                _jwt.Issuer,
                _jwt.Issuer,
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}

