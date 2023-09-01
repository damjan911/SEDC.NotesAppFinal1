using SEDC.NotesAppFinal1.DataAccess.Interfaces;
using SEDC.NotesAppFinal1.Domain.Models;
using SEDC.NotesAppFinal1.DTOs.NoteDTOs;
using SEDC.NotesAppFinal1.Mappers;
using SEDC.NotesAppFinal1.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.NotesAppFinal1.Services.Implementations
{
	public class NoteService : INoteService
	{
		private readonly IRepository<Note> _noteRepository;

        public NoteService(IRepository<Note> noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task CreateNoteAsync(CreateNoteDto note)
		{
			Note noteEntity = note.MapToNote();

			await _noteRepository.CreateAsync(noteEntity);
		}

		public async Task DeleteNoteAsync(int id)
		{
			await _noteRepository.DeleteAsync(id);
		}

		public async Task EditNoteAsync(CreateNoteDto createNoteDto, int id)
		{
			Note noteDb = await _noteRepository.GetByIdAsync(id);

			if (noteDb == null)
			{
				throw new Exception("Note is null");
			}

			noteDb.Text = createNoteDto.Text;
			noteDb.Priority = createNoteDto.Priority;
			noteDb.Tag = createNoteDto.Tag;
			noteDb.Userid = createNoteDto.UserId;

			await _noteRepository.UpdateAsync(noteDb);
		}

		public async Task<List<NoteDto>> GetAllNotesAsync()
		{
			List<Note> notes = await _noteRepository.GetAllAsync();

			if(notes == null)
			{
				throw new NotImplementedException("Note is null.");
			}

			return notes.Select(note => note.MapToNoteDto()).ToList();
		}

		public async Task<NoteDto> GetNoteByIdAsync(int id)
		{
			Note note = await _noteRepository.GetByIdAsync(id);

			if(note == null)
			{
				throw new NotImplementedException("Note is null.");
			}

			return note.MapToNoteDto();
		}
	}
}
