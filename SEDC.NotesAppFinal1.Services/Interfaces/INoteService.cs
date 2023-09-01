using SEDC.NotesAppFinal1.DTOs.NoteDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.NotesAppFinal1.Services.Interfaces
{
	public interface INoteService
	{
		Task<NoteDto> GetNoteByIdAsync(int id);

		Task<List<NoteDto>> GetAllNotesAsync();

		Task CreateNoteAsync (CreateNoteDto note);

		Task DeleteNoteAsync (int id);

		Task EditNoteAsync(CreateNoteDto createNoteDto, int id);
	}
}
