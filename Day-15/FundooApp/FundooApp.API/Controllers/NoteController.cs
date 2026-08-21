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

        // ----- Queries: active / archived / trash / search (Day 15) -----

        [HttpGet]
        public async Task<IActionResult> GetActiveNotes()
        {
            var notes = await _noteBusiness.GetActiveNotesAsync(GetUserId());
            return Ok(new ResponseDTO<IEnumerable<NoteResponseDTO>> { Success = true, Message = "Active notes fetched.", Data = notes });
        }

        [HttpGet("archived")]
        public async Task<IActionResult> GetArchivedNotes()
        {
            var notes = await _noteBusiness.GetArchivedNotesAsync(GetUserId());
            return Ok(new ResponseDTO<IEnumerable<NoteResponseDTO>> { Success = true, Message = "Archived notes fetched.", Data = notes });
        }

        [HttpGet("trash")]
        public async Task<IActionResult> GetTrashedNotes()
        {
            var notes = await _noteBusiness.GetTrashedNotesAsync(GetUserId());
            return Ok(new ResponseDTO<IEnumerable<NoteResponseDTO>> { Success = true, Message = "Trashed notes fetched.", Data = notes });
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchNotes([FromQuery] string query)
        {
            var notes = await _noteBusiness.SearchNotesAsync(GetUserId(), query);
            return Ok(new ResponseDTO<IEnumerable<NoteResponseDTO>> { Success = true, Message = "Search results fetched.", Data = notes });
        }

        // ----- Commands: pin / archive / trash / restore (Day 15) -----

        [HttpPatch("{noteId}/pin")]
        public async Task<IActionResult> TogglePin(int noteId)
        {
            try
            {
                var note = await _noteBusiness.TogglePinAsync(noteId, GetUserId());
                return Ok(new ResponseDTO<NoteResponseDTO> { Success = true, Message = "Pin toggled.", Data = note });
            }
            catch (NoteNotFoundException ex)
            {
                return NotFound(new ResponseDTO<string> { Success = false, Message = ex.Message });
            }
        }

        [HttpPatch("{noteId}/archive")]
        public async Task<IActionResult> ToggleArchive(int noteId)
        {
            try
            {
                var note = await _noteBusiness.ToggleArchiveAsync(noteId, GetUserId());
                return Ok(new ResponseDTO<NoteResponseDTO> { Success = true, Message = "Archive toggled.", Data = note });
            }
            catch (NoteNotFoundException ex)
            {
                return NotFound(new ResponseDTO<string> { Success = false, Message = ex.Message });
            }
        }

        [HttpPatch("{noteId}/trash")]
        public async Task<IActionResult> MoveToTrash(int noteId)
        {
            try
            {
                var note = await _noteBusiness.MoveToTrashAsync(noteId, GetUserId());
                return Ok(new ResponseDTO<NoteResponseDTO> { Success = true, Message = "Note moved to trash.", Data = note });
            }
            catch (NoteNotFoundException ex)
            {
                return NotFound(new ResponseDTO<string> { Success = false, Message = ex.Message });
            }
        }

        [HttpPatch("{noteId}/restore")]
        public async Task<IActionResult> RestoreFromTrash(int noteId)
        {
            try
            {
                var note = await _noteBusiness.RestoreFromTrashAsync(noteId, GetUserId());
                return Ok(new ResponseDTO<NoteResponseDTO> { Success = true, Message = "Note restored from trash.", Data = note });
            }
            catch (NoteNotFoundException ex)
            {
                return NotFound(new ResponseDTO<string> { Success = false, Message = ex.Message });
            }
        }
    }
}
