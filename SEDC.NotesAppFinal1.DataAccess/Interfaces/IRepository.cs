using SEDC.NotesAppFinal1.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.NotesAppFinal1.DataAccess.Interfaces
{
	public interface IRepository<T> where T : BaseEntity
	{
		Task<T> GetByIdAsync(int id);

		Task<List<T>> GetAllAsync();

		Task CreateAsync(T entity);

		Task UpdateAsync(T entity);

		Task DeleteAsync(int id);
	}
}
