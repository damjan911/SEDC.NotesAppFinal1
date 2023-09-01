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
	public class NoteRepository : IRepository<Note>
	{
		private readonly NotesAppFinal1DbContext _context;

        public NoteRepository(NotesAppFinal1DbContext context)
        {
			_context = context;
        }
        public async Task CreateAsync(Note entity)
		{
			await _context.Notes.AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			Note noteDb = await GetByIdAsync(id);

			_context.Remove(noteDb);
			await _context.SaveChangesAsync();
		}

		public async Task<List<Note>> GetAllAsync()
		{
			return await _context.Notes.ToListAsync();
		}

		public async Task<Note> GetByIdAsync(int id)
		{
			return await _context.Notes
			.Include(x => x.User)
			.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task UpdateAsync(Note entity)
		{
		     _context.Notes.Update(entity);
			await _context.SaveChangesAsync();
		}
	}
}
