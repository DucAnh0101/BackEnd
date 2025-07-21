using DataAccessLayer.DTOs.request;
using DataAccessLayer.DTOs.response;
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
        public async Task<IActionResult> CreateSurveyPoint(SurveyPointReq req, int id)
        {
            try
            {
                var sp = _surveyPointServices.CreateSurveyPonit(req, id);
                return Ok(sp.Id);
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
                _surveyPointServices.DeleteSurveyPoint(id);
                return Ok("Delete survey ponit successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add-hydrology/{id}")]
        public async Task<IActionResult> AddHydrology([FromBody] HydrologyDto hydrology, int id)
        {
            try
            {
                var hydro = _surveyPointServices.CreateHydrology(hydrology, id);
                return Ok(hydro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-hydro/{id}")]
        public async Task<IActionResult> UpdateHydrology([FromBody] HydrologyDto hydrology, int id)
        {
            try
            {
                _surveyPointServices.UpdateHydrology(hydrology, id);
                return Ok("Update hydrology successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add-location/{id}")]
        public async Task<IActionResult> AddLocation([FromBody] LocationDesDto location, int id)
        {
            try
            {
                var hydro = _surveyPointServices.CreateLocation(location, id);
                return Ok(location);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-location/{id}")]
        public async Task<IActionResult> UpdateLocation([FromBody] LocationDesDto location, int id)
        {
            try
            {
                _surveyPointServices.UpdateLocation(location, id);
                return Ok("Update hydrology successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add-vegetation/{id}")]
        public async Task<IActionResult> AddVegetation([FromBody] VegetationCoverDto vegetation, int id)
        {
            try
            {
                var hydro = _surveyPointServices.CreateVegetationCover(vegetation, id);
                return Ok(vegetation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-vegetation/{id}")]
        public async Task<IActionResult> UpdateVegetation([FromBody] VegetationCoverDto vegetation, int id)
        {
            try
            {
                _surveyPointServices.UpdateVegetationCover(vegetation, id);
                return Ok("Update hydrology successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
