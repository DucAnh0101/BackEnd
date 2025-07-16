using DataAccessLayer.DTOs.request;
using Microsoft.AspNetCore.Mvc;
using Services.Implements;

namespace CustomStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationController : Controller
    {
        private readonly INotificationServices _notificationServices;
        public NotificationController(INotificationServices notificationServices)
        {
            _notificationServices = notificationServices;
        }

        [HttpGet("GetAllNotification")]
        public IActionResult GetAllNoti()
        {
            try
            {
                var noti = _notificationServices.GetAllNotification();
                return Ok(noti);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetAllNotiById(int id)
        {
            try
            {
                var noti = _notificationServices.GetNotification(id);
                return Ok(noti);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-notification")]
        public IActionResult UpdateNotification(int id, NotificationReq req)
        {
            try
            {
                var noti = _notificationServices.UpdateNotification(req, id);
                return Ok(noti);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            try
            {
                _notificationServices.DeleteNotification(id);
                return Ok("Delete notificaion successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
