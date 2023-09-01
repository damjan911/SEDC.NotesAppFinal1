using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDC.NotesAppFinal1.DTOs.NoteDTOs;
using SEDC.NotesAppFinal1.Services.Interfaces;

namespace SEDC.NotesAppFinal1.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NotesController : ControllerBase
	{
		private readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
			_noteService = noteService;
        }

		[HttpGet("{id}")]

		public async Task<ActionResult<NoteDto>> GetNoteByIdAsync(int id)
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

				NoteDto noteDto = await _noteService.GetNoteByIdAsync(id);

				return Ok(noteDto);
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team.");
			}
		}

		[HttpGet]

		public async Task<ActionResult<List<NoteDto>>> GetAllNotesAsync()
		{
			try
			{
				return Ok(await _noteService.GetAllNotesAsync());
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team.");
			}
		}

		[HttpPost]

		public async Task<ActionResult> CreateNoteAsync(CreateNoteDto note)
		{
			try
			{
				if (note == null || note.UserId == 0 || note.Text == null || note.Priority == 0 || note.Tag == 0)
				{
					return BadRequest("Invalid input");
				}

				await _noteService.CreateNoteAsync(note);
				return StatusCode(StatusCodes.Status201Created, "Note added");
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team.");

			}
		}

		[HttpDelete]

		public async Task<ActionResult> DeleteNoteAsync(int id)
		{
			try
			{
				if(id == 0)
				{
					return BadRequest("Id can not be null");
				}

				if(id <= 0)
				{
					return BadRequest("Id can not be a negative number");
				}

				await _noteService.DeleteNoteAsync(id);

				return Ok();
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team.");
			}
		}

		[HttpPatch]

		public async Task<ActionResult> EditNoteAsync(CreateNoteDto createNoteDto, int id)
		{
			try
			{
				if (id == 0)
				{
					return BadRequest("Id can not be null");
				}

				if (id <= 0)
				{
					return BadRequest("Id can not be a negative number");
				}

				await _noteService.EditNoteAsync(createNoteDto,id);

				return Ok();
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team.");
			}
		}

	}
}
