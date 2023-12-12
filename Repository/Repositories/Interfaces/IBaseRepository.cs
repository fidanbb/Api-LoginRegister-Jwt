using System;
using Domain.Common;

namespace Repository.Repositories.Interfaces
{
	public interface IBaseRepository<T> where T:BaseEntity
	{
		Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(int? id);

    }
}

