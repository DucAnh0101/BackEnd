using DataAccessLayer.DTOs;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Implements;

namespace CustomStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JWTController : ControllerBase
    {
        private readonly IAuthServices _authServices;
        public JWTController(IAuthServices authServices)
        {
            _authServices = authServices;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login(LoginRequest model, [FromServices] JwtTokenGenerator tokenGen)
        {
            if (model.Username == "admin" && model.Password == "123")
            {
                var token = tokenGen.GenerateToken("1", "Admin");
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPassReq reset)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _authServices.ResetPasswordAsync(reset);
                return Ok(new { message = "Mật khẩu mới đã được gửi tới email của bạn." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

    }
}
