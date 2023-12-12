using System;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
	public class EmployeeRepository:BaseRepository<Employee>,IEmployeeRepository
	{
		public EmployeeRepository(AppDbContext context):base(context) { }
		

        public async Task<List<Employee>> GetAllByFullNameAsync(string fullName)
        {
            return await _context.Employees.Where(m=>m.FullName==fullName).ToListAsync();
        }
    }
}

