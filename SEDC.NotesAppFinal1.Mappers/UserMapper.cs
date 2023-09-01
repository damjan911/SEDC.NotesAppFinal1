using SEDC.NotesAppFinal1.Domain.Models;
using SEDC.NotesAppFinal1.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.NotesAppFinal1.Mappers
{
	public static class UserMapper
	{
		public static UserDto MapToUserDto (this User user)
		{
			return new UserDto()
			{
				FirstName = user.FirstName,
				LastName = user.LastName,
				UserName = user.UserName,
				Age = user.Age
			};
		}

		public static User MapToUser (this CreateUserDto createUserDto)
		{
			return new User()
			{
				FirstName = createUserDto.FirstName,
				LastName = createUserDto.LastName,
				UserName = createUserDto.UserName,
				Age = createUserDto.Age
			};
		}
	}
}
