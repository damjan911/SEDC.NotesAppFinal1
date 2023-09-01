using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SEDC.NotesAppFinal1.DTOs.UserDTOs;
using SEDC.NotesAppFinal1.Services.Interfaces;

namespace SEDC.NotesAppFinal1.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
			_userService = userService;
        }

		[HttpGet("{id}")]

		public async Task<ActionResult<UserDto>> GetUserByIdAsync(int id)
		{
			try
			{
				if(id == 0)
				{
					return BadRequest("Id can not be null.");
				}

				if(id <= 0)
				{
					return BadRequest("Id can not be a negative number.");
				}

				UserDto userDto = await _userService.GetUserByIdAsync(id);

				return Ok(userDto);
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team.");
			}
		}

		[HttpGet]

		public async Task<ActionResult<List<UserDto>>> GetAllUsersAsync()
		{
			try
			{
				return Ok(await _userService.GetAllUsersAsync());
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team.");
			}
		}

		[HttpPost]

		public async Task<ActionResult> CreateUserAsync(CreateUserDto userDto)
		{
			try
			{
				if (userDto == null || userDto.FirstName == null || userDto.LastName == null || userDto.UserName == null || userDto.Age == 0)
				{
					return BadRequest("Invalid input");
				}

				await _userService.CreateUserAsync(userDto);
				return StatusCode(StatusCodes.Status201Created, "User added");
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team.");
			}
		}

		[HttpDelete]

		public async Task<ActionResult> DeleteUserAsync(int id)
		{
			try
			{
				if (id == 0)
				{
					return BadRequest("Id can not be null.");
				}

				if(id <= 0)
				{
					return BadRequest("Id can not be a negative number.");
				}

				await _userService.DeleteUserAsync(id);

				return Ok();
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team.");
			}
		}

		[HttpPatch]

		public async Task<ActionResult> EditUserAsync(CreateUserDto createUserDto, int id)
		{
			try
			{ 
				if(id == 0)
				{
					return BadRequest("Id can not be null.");
				}

				if(id <= 0)
				{
					return BadRequest("Id can not be a negative number");
				}

				await _userService.EditUserAsync(createUserDto, id);

				return Ok();
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team.");
			}
		}

	}
}
