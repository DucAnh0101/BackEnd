using DataAccessLayer.DTOs.request;
using Microsoft.AspNetCore.Mvc;
using Services.Implements;

namespace CustomStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceServices _deviceService;

        public DeviceController(IDeviceServices deviceService)
        {
            _deviceService = deviceService;
        }

        // --------- GammaCalibration ---------
        [HttpPost("gamma")]
        public async Task<IActionResult> AddGamma([FromBody] GammaReq req) => Ok(await _deviceService.AddGammaDataAsync(req));

        [HttpGet("gamma/{id}")]
        public async Task<IActionResult> GetGammaById(int id)
        {
            var result = await _deviceService.GetGammaByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPut("gamma/{id}")]
        public async Task<IActionResult> UpdateGamma(int id, [FromBody] GammaReq req) => Ok(await _deviceService.UpdateGammaAsync(id, req));

        [HttpDelete("gamma/{id}")]
        public async Task<IActionResult> DeleteGamma(int id) => Ok(await _deviceService.DeleteGammaAsync(id));

        // --------- PhoGammaInfo ---------
        [HttpPost("phogamma")]
        public async Task<IActionResult> AddPhoGamma([FromBody] PhoGammaReq req) => Ok(await _deviceService.AddPhoGammaDataAsync(req));

        [HttpGet("phogamma/{id}")]
        public async Task<IActionResult> GetPhoGammaById(int id)
        {
            var result = await _deviceService.GetPhoGammaByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPut("phogamma/{id}")]
        public async Task<IActionResult> UpdatePhoGamma(int id, [FromBody] PhoGammaReq req) => Ok(await _deviceService.UpdatePhoGammaAsync(id, req));

        [HttpDelete("phogamma/{id}")]
        public async Task<IActionResult> DeletePhoGamma(int id) => Ok(await _deviceService.DeletePhoGammaAsync(id));

        // --------- XRFInfo ---------
        [HttpPost("xrf")]
        public async Task<IActionResult> AddXrf([FromBody] XrfReq req) => Ok(await _deviceService.AddXrfDataAsync(req));

        [HttpGet("xrf/{id}")]
        public async Task<IActionResult> GetXrfById(int id)
        {
            var result = await _deviceService.GetXrfByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPut("xrf/{id}")]
        public async Task<IActionResult> UpdateXrf(int id, [FromBody] XrfReq req) => Ok(await _deviceService.UpdateXrfAsync(id, req));

        [HttpDelete("xrf/{id}")]
        public async Task<IActionResult> DeleteXrf(int id) => Ok(await _deviceService.DeleteXrfAsync(id));

        // --------- MeasuringDevice ---------
        [HttpPost("measuring")]
        public async Task<IActionResult> AddMeasuringDevice([FromBody] MeasuringDeviceReq req) => Ok(await _deviceService.AddMeasuringDeviceAsync(req));

        [HttpGet("measuring/{id}")]
        public async Task<IActionResult> GetMeasuringDeviceById(int id)
        {
            var result = await _deviceService.GetMeasuringDeviceByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPut("measuring/{id}")]
        public async Task<IActionResult> UpdateMeasuringDevice(int id, [FromBody] MeasuringDeviceReq req) => Ok(await _deviceService.UpdateMeasuringDeviceAsync(id, req));

        [HttpDelete("measuring/{id}")]
        public async Task<IActionResult> DeleteMeasuringDevice(int id) => Ok(await _deviceService.DeleteMeasuringDeviceAsync(id));

        // --------- DeviceType ---------
        [HttpPost("devicetype")]
        public async Task<IActionResult> AddDeviceType([FromBody] DeviceTypeReq req) => Ok(await _deviceService.AddDeviceTypeAsync(req));

        [HttpGet("devicetype/{id}")]
        public async Task<IActionResult> GetDeviceTypeById(int id)
        {
            var result = await _deviceService.GetDeviceTypeByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPut("devicetype/{id}")]
        public async Task<IActionResult> UpdateDeviceType(int id, [FromBody] DeviceTypeReq req) => Ok(await _deviceService.UpdateDeviceTypeAsync(id, req));

        [HttpDelete("devicetype/{id}")]
        public async Task<IActionResult> DeleteDeviceType(int id) => Ok(await _deviceService.DeleteDeviceTypeAsync(id));
    }
}
