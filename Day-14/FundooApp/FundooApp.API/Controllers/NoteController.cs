using System.Security.Claims;
using FundooApp.BusinessLayer.Interfaces;
using FundooApp.ModelLayer.DTOs;
using FundooApp.ModelLayer.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FundooApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class NoteController : ControllerBase
    {
        private readonly INoteBusiness _noteBusiness;

        public NoteController(INoteBusiness noteBusiness)
        {
            _noteBusiness = noteBusiness;
        }

        private int GetUserId() =>
            int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");

        [HttpPost]
        public async Task<IActionResult> AddNote([FromBody] NoteDTO noteDto)
        {
            var note = await _noteBusiness.AddNoteAsync(noteDto, GetUserId());
            return Ok(new ResponseDTO<NoteResponseDTO> { Success = true, Message = "Note added.", Data = note });
        }

        [HttpDelete("{noteId}")]
        public async Task<IActionResult> DeleteNote(int noteId)
        {
            try
            {
                await _noteBusiness.DeleteNoteAsync(noteId, GetUserId());
                return Ok(new ResponseDTO<string> { Success = true, Message = "Note deleted." });
            }
            catch (NoteNotFoundException ex)
            {
                return NotFound(new ResponseDTO<string> { Success = false, Message = ex.Message });
            }
        }

        // GetAllNotes (list/search) and UpdateNote (pin/archive/trash edits) are scoped to
        // Day 15-16 per the training roadmap (Entity Framework/CQRS deep-dive, Pin/Archive/Trash,
        // Search & Filter). The underlying INoteBusiness methods already exist and are ready to
        // expose here when that day's work begins.
    }
}
