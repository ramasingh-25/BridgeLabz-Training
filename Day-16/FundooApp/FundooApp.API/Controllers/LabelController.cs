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
    public class LabelController : ControllerBase
    {
        private readonly ILabelBusiness _labelBusiness;

        public LabelController(ILabelBusiness labelBusiness)
        {
            _labelBusiness = labelBusiness;
        }

        private int GetUserId() =>
            int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");

        [HttpPost]
        public async Task<IActionResult> CreateLabel([FromBody] LabelDTO labelDto)
        {
            try
            {
                var label = await _labelBusiness.CreateLabelAsync(labelDto, GetUserId());
                return Ok(new ResponseDTO<LabelResponseDTO> { Success = true, Message = "Label created.", Data = label });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new ResponseDTO<string> { Success = false, Message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLabels()
        {
            var labels = await _labelBusiness.GetAllLabelsAsync(GetUserId());
            return Ok(new ResponseDTO<IEnumerable<LabelResponseDTO>> { Success = true, Message = "Labels fetched.", Data = labels });
        }

        [HttpDelete("{labelId}")]
        public async Task<IActionResult> DeleteLabel(int labelId)
        {
            try
            {
                await _labelBusiness.DeleteLabelAsync(labelId, GetUserId());
                return Ok(new ResponseDTO<string> { Success = true, Message = "Label deleted." });
            }
            catch (LabelNotFoundException ex)
            {
                return NotFound(new ResponseDTO<string> { Success = false, Message = ex.Message });
            }
        }
    }
}
