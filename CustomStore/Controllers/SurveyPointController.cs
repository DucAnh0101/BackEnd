using DataAccessLayer.DTOs.request;
using Microsoft.AspNetCore.Mvc;
using Services.Implements;

namespace CustomStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SurveyPointController : ControllerBase
    {
        private readonly ISurveyPointServices _surveyPointServices;

        public SurveyPointController(ISurveyPointServices surveyPointServices)
        {
            _surveyPointServices = surveyPointServices;
        }

        [HttpPost]
        [Route("add-surveypoint")]
        public async Task<IActionResult> CreateSurveyPoint(SurveyPointReq req)
        {
            try
            {
                var sp = _surveyPointServices.CreateSurveyPonit(req);
                return Ok("Create Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllSurveyPonitByUId(int id)
        {
            try
            {
                var sp = _surveyPointServices.GetSurveyPointByUId(id);
                return Ok(sp);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSurveypoint(int id)
        {
            try
            {
                _surveyPointServices.DeleteSurveyPoint(id); `
                return Ok("Delete survey ponit successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
