using SEDC.NotesAppFinal1.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.NotesAppFinal1.DTOs.NoteDTOs
{
	public class CreateNoteDto
	{
		public string Text { get; set; } = string.Empty;

		public Priority Priority { get; set; }

		public Tag Tag { get; set; }

		public int Age { get; set; }
		public int UserId { get; set; }
	}
}
