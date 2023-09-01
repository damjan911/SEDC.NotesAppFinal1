using SEDC.NotesAppFinal1.Domain.Enums;
using SEDC.NotesAppFinal1.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.NotesAppFinal1.DTOs.NoteDTOs
{
	public class NoteDto
	{
		public string Text { get; set; } = string.Empty;

		public Priority Priority { get; set; }

		public Tag Tag { get; set; }

		public UserDto User { get; set; }
	}
}
