using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.NotesAppFinal1.DTOs.UserDTOs
{
	public class CreateUserDto
	{
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string UserName { get; set; } = string.Empty;

		public int Age { get; set; }
	}
}
