using Microsoft.AspNetCore.Mvc;

namespace CustomStore.Controllers
{
    [ApiController]
    [Route("F&Q")]
    public class F_QController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
