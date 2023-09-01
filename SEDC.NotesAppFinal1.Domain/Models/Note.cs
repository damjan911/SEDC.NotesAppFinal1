using SEDC.NotesAppFinal1.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.NotesAppFinal1.Domain.Models
{
	public class Note : BaseEntity
	{
		public string Text { get; set; } = string.Empty;

		public Priority Priority { get; set; }

		public Tag Tag { get; set; }

		[ForeignKey("User")]
		public int Userid { get; set; }

		public User User { get; set; }
	}
}
