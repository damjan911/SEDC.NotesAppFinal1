using SEDC.NotesAppFinal1.Domain.Models;
using SEDC.NotesAppFinal1.DTOs.NoteDTOs;
using SEDC.NotesAppFinal1.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.NotesAppFinal1.Mappers
{
	public static class NoteMapper
	{
		public static NoteDto MapToNoteDto(this Note note)
		{
			return new NoteDto()
			{
				Text = note.Text,
				Priority = note.Priority,
				Tag = note.Tag,
				User = note.User == null ? new UserDto() : note.User.MapToUserDto()
			};
		}

		public static Note MapToNote(this CreateNoteDto createNoteDto)
		{
			return new Note()
			{
				Text = createNoteDto.Text,
				Priority = createNoteDto.Priority,
				Tag = createNoteDto.Tag,
				Userid = createNoteDto.UserId
			};
		}
	}
}
