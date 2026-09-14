using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FundooNotes.Models.DTOs;
using FundooNotes.Service.Interface;

namespace Fundoo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class LabelController : ControllerBase
    {
        private readonly ILabelService _labelService;

        public LabelController(ILabelService labelService)
        {
            _labelService = labelService;
        }

        private int GetCurrentUserId()
        {
            return Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? User.FindFirst("UserId")?.Value);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddLabel([FromBody] CreateLabelDto dto)
        {
            int userId = GetCurrentUserId();
            var label = await _labelService.AddLabelAsync(dto, userId);
            return Ok(new { success = true, message = "Label added successfully", data = label });
        }

        [HttpGet("get/{labelId}")]
        public async Task<IActionResult> GetLabelById(int labelId)
        {
            int userId = GetCurrentUserId();
            var label = await _labelService.GetLabelByIdAsync(labelId, userId);
            if (label == null)
                return NotFound(new { success = false, message = "Label not found." });

            return Ok(new { success = true, message = "Label retrieved successfully", data = label });
        }

        [HttpPut("edit/{labelId}")]
        public async Task<IActionResult> EditLabel(int labelId, [FromBody] UpdateLabelDto dto)
        {
            int userId = GetCurrentUserId();
            var label = await _labelService.EditLabelAsync(labelId, dto, userId);
            if (label == null)
                return NotFound(new { success = false, message = "Label not found or failed to update." });

            return Ok(new { success = true, message = "Label edited successfully", data = label });
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllLabels()
        {
            int userId = GetCurrentUserId();
            var labels = await _labelService.GetAllLabelsAsync(userId);
            return Ok(new { success = true, message = "All labels retrieved successfully", data = labels });
        }

        [HttpDelete("delete/{labelId}")]
        public async Task<IActionResult> DeleteLabel(int labelId)
        {
            int userId = GetCurrentUserId();
            var result = await _labelService.DeleteLabelAsync(labelId, userId);
            if (!result)
                return NotFound(new { success = false, message = "Label not found or failed to delete." });

            return Ok(new { success = true, message = "Label deleted successfully" });
        }
    }
}
