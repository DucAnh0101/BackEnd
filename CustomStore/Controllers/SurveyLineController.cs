using DataAccessLayer.DTOs.request;
using Microsoft.AspNetCore.Mvc;
using Services.Implements;

namespace CustomStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SurveyLineController : ControllerBase
    {
        private readonly ISurveyLineServices services;
        public SurveyLineController(ISurveyLineServices services)
        {
            this.services = services;
        }

        [HttpPost("add_surveyline")]
        public async Task<IActionResult> CreateSurveyLine(SurveyLineReq req, int id)
        {
            try
            {
                var s = services.CreateSurveyLine(req, id);
                return Ok(s);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update_surveyline/{id}")]
        public async Task<IActionResult> UpdateSurvryLine(SurveyLineReq req, [FromRoute] int id)
        {
            try
            {
                var s = services.UpdateSurveyLine(req, id);
                return Ok(s);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSurveyLine([FromRoute] int id)
        {
            try
            {
                services.DeleteSurveyLine(id);
                return Ok("Survey line delete successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getbyslineid/{id}")]
        public async Task<IActionResult> GetSurLineById([FromRoute] int id)
        {
            try
            {
                var s = services.GetSurveyLineResById(id);
                return Ok(s);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get_slineid/{id}")]
        public async Task<IActionResult> GetSurLinesById([FromRoute] int id)
        {
            try
            {
                var s = services.GetSurveyLineResByPrjId(id);
                return Ok(s);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
