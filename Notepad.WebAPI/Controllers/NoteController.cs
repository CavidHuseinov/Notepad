using Microsoft.AspNetCore.Mvc;
using Notepad.Business.DTOs.Note;
using Notepad.Business.Services.Interfaces;
using Notepad.WebAPI.Controllers.Common;

namespace Notepad.WebAPI.Controllers
{
    public class NoteController : ApiController
    {
        private readonly INoteService _service;

        public NoteController(INoteService service)
        {
            _service = service;
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAllNoteAsync()
        {
            var note = await _service.GetAllNote();
            return Ok(note);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNoteByIdAsync(Guid id)
        {
            var note = await _service.GetNoteById(id);
            return Ok(note);
        }
        [HttpGet("secure/{id}")]
        public async Task<IActionResult> GetNoteByPassword(Guid id, string password)
        {
           var note = await _service.GetNoteWithPassword(id, password);
            return Ok(note);
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateNoteAsync(CreateNoteDto dto)
        {
            var note = await _service.CreateAsync(dto);
            return Ok(note);
        }
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateNoteAsync(UpdateNoteDto dto)
        {
            await _service.UpdateAsync(dto);
            return NoContent();
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteNoteAsync(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
