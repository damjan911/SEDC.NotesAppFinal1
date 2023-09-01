using Microsoft.EntityFrameworkCore;
using SEDC.NotesAppFinal1.DataAccess.Interfaces;
using SEDC.NotesAppFinal1.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.NotesAppFinal1.DataAccess.Implementations
{
	public class UserRepository : IRepository<User>
	{
		private readonly NotesAppFinal1DbContext _db;

        public UserRepository(NotesAppFinal1DbContext db)
        {
			_db = db;
        }
        public async Task CreateAsync(User entity)
		{
			await _db.Users.AddAsync(entity);
			await _db.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			User userDb = await GetByIdAsync(id);

			_db.Remove(userDb);
			await _db.SaveChangesAsync();
		}

		public async Task<List<User>> GetAllAsync()
		{
			return await _db.Users.ToListAsync();
		}

		public async Task<User> GetByIdAsync(int id)
		{
			return await _db.Users
			.Include(x => x.Notes)
			.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task UpdateAsync(User entity)
		{
			_db.Users.Update(entity);
			await _db.SaveChangesAsync();
		}
	}
}
