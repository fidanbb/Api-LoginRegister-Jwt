using System;
using AutoMapper;
using Domain.Models;
using Service.DTOs.Account;
using Service.DTOs.Employee;

namespace Service.Mappings
{
	public class MappingProfile:Profile
	{
		public MappingProfile()
		{
			CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeCreateDto, Employee>();
            CreateMap<EmployeeEditDto, Employee>();
            CreateMap<RegisterDto, AppUser>();
            CreateMap<AppUser, UserDto>();



        }
    }
}

