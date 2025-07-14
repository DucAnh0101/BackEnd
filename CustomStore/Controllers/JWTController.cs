using BussiniessObject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace CustomStore.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class JWTController : ControllerBase
    {
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

    }
}
