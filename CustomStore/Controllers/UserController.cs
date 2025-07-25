using DataAccessLayer.DTOs.request;
using Microsoft.AspNetCore.Mvc;
using Services.Implements;

namespace CustomStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet("list-user")]
        public async Task<IActionResult> GetListUser()
        {
            try
            {
                var u = _userServices.GetAllUser();
                return Ok(u);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var u = _userServices.GetUserById(id);
                return Ok(u);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("update-user")]
        public async Task<IActionResult> UpdateUserInfo([FromBody] UserUpdateReq req, int id)
        {
            try
            {
                var u = _userServices.UpdateUserInfo(req, id);
                return Ok(u);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("delete-user")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                _userServices.DeleteUser(id);
                return Ok("User has been deleted!");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPut("update-password")]
        public async Task<IActionResult> UpdatePass(int id, string oldpass, string newpass, string confirmpass)
        {
            try
            {
                _userServices.UpdatePassword(id, oldpass, newpass, confirmpass);
                return Ok("Your password has been updated!");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
