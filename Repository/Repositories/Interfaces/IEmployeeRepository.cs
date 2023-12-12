using System;
using Domain.Models;

namespace Repository.Repositories.Interfaces
{
	public interface IEmployeeRepository:IBaseRepository<Employee>
	{
		Task<List<Employee>> GetAllByFullNameAsync(string fullName);
	}
}

