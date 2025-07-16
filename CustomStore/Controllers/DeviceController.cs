using DataAccessLayer.DTOs.request;
using Microsoft.AspNetCore.Mvc;
using Services.Implements;
namespace CustomStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceService _deviceService;

        public DeviceController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        // ✅ GET: api/device/by-type/1
        [HttpGet("by-type/{typeId}")]
        public async Task<IActionResult> GetByType(int typeId)
        {
            var devices = await _deviceService.GetByTypeAsync(typeId);
            return Ok(devices);
        }

        // ✅ POST: api/device
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DeviceReq request)
        {
            var result = await _deviceService.CreateAsync(request);
            return Ok(new { message = "Thiết bị đã được thêm thành công!", deviceId = result.Id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DeviceReq request)
        {
            var result = await _deviceService.UpdateAsync(id, request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _deviceService.DeleteAsync(id);
            if (!success)
                return NotFound(new { message = "Không tìm thấy thiết bị." });

            return Ok(new { message = "Xoá thiết bị thành công." });
        }

    }
}
