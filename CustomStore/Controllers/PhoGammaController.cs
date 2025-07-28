using Microsoft.AspNetCore.Mvc;
using Services.Implements;
using DataAccessLayer.DTOs.request;
using DataAccessLayer.DTOs.response;

namespace CustomStore.Controllers
{
    [ApiController]
    [Route("api/phogamma")]
    public class PhoGammaController : ControllerBase
    {
        private readonly IPhoGammaService _service;
        public PhoGammaController(IPhoGammaService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => Ok(await _service.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PhoGammaDeviceRequest request) => Ok(await _service.CreateAsync(request));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PhoGammaDeviceRequest request) => Ok(await _service.UpdateAsync(id, request));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _service.DeleteAsync(id));
    }
}
