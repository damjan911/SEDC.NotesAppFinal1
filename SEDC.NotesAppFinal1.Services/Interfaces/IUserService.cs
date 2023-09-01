using SEDC.NotesAppFinal1.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.NotesAppFinal1.Services.Interfaces
{
	public interface IUserService
	{
		Task<UserDto> GetUserByIdAsync (int id);

		Task<List<UserDto>> GetAllUsersAsync();

		Task CreateUserAsync (CreateUserDto userDto);

		Task DeleteUserAsync(int id);

		Task EditUserAsync(CreateUserDto createUserDto, int id);
	}
}
