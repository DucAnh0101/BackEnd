using Microsoft.AspNetCore.Mvc;
using Services.Implements;
using DataAccessLayer.DTOs.request;
using DataAccessLayer.DTOs.response;

namespace CustomStore.Controllers
{
        [ApiController]
        [Route("api/gamma")]
        public class GammaController : ControllerBase
        {
            private readonly IGammaService _service;
            public GammaController(IGammaService service) => _service = service;

            [HttpGet]
            public async Task<ActionResult<List<GammaDeviceResponse>>> GetAll()
            {
                return await _service.GetAllAsync();
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<GammaDeviceResponse>> Get(int id)
            {
                var result = await _service.GetByIdAsync(id);
                if (result == null) return NotFound();
                return result;
            }

            [HttpPost]
            public async Task<IActionResult> Create([FromBody] GammaDeviceRequest request)
            {
                await _service.CreateAsync(request);
                return Ok();
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> Update(int id, [FromBody] GammaDeviceRequest request)
            {
                var updated = await _service.UpdateAsync(id, request);
                if (!updated) return NotFound();
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                var deleted = await _service.DeleteAsync(id);
                if (!deleted) return NotFound();
                return NoContent();
            }
        }

    }

