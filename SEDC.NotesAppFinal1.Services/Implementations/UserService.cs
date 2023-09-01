using SEDC.NotesAppFinal1.DataAccess.Interfaces;
using SEDC.NotesAppFinal1.Domain.Models;
using SEDC.NotesAppFinal1.DTOs.UserDTOs;
using SEDC.NotesAppFinal1.Mappers;
using SEDC.NotesAppFinal1.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.NotesAppFinal1.Services.Implementations
{
	public class UserService : IUserService
	{
		private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
			_userRepository = userRepository;
        }
        public async Task CreateUserAsync(CreateUserDto userDto)
		{
			User user = userDto.MapToUser();

			await _userRepository.CreateAsync(user);
		}

		public async Task DeleteUserAsync(int id)
		{
			await _userRepository.DeleteAsync(id);
		}

		public async Task EditUserAsync(CreateUserDto createUserDto, int id)
		{
			User userDb = await _userRepository.GetByIdAsync(id);

			if(userDb == null) 
			{
				throw new Exception("User is null.");
			}

			userDb.FirstName = createUserDto.FirstName;
			userDb.LastName = createUserDto.LastName;
			userDb.UserName = createUserDto.UserName;
			userDb.Age = createUserDto.Age;

			await _userRepository.UpdateAsync(userDb);
		}

		public async Task<List<UserDto>> GetAllUsersAsync()
		{
			List<User> users = await _userRepository.GetAllAsync();

			if(users == null) 
			{
				throw new Exception("User is null.");
			}

			return users.Select(user=>user.MapToUserDto()).ToList();
		}

		public async Task<UserDto> GetUserByIdAsync(int id)
		{
			User user = await _userRepository.GetByIdAsync(id);

			if(user == null)
			{
				throw new Exception("User is null.");
			}

			return user.MapToUserDto();
		}
	}
}
