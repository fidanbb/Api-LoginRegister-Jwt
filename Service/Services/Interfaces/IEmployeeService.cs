using System;
using Service.DTOs.Employee;
using Service.Helpers.Responses;

namespace Service.Services.Interfaces
{
	public interface IEmployeeService
	{
		Task<List<EmployeeDto>> GetAllAsync();

		Task CreateAsync(EmployeeCreateDto request);

		Task<BaseResponse> DeleteAsync(int? id);

		Task<EmployeeDto> GetByIdAsync(int? id);

		Task<BaseResponse> UpdateAsync(int? id,EmployeeEditDto request);

		Task<List<EmployeeDto>> GetAllByFullNameAsync(string fullName);
	}
}

