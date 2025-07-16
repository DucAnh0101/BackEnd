using BusiniessObject.Models;
using DataAccessLayer.DTOs.request;
using DataAccessLayer.DTOs.response;

namespace Services.Implements
{
    public interface INotificationServices
    {
        List<Notification> GetAllNotification();
        NotificationRes GetNotification(int id);
        NotificationRes UpdateNotification(NotificationReq notification, int id);
        void DeleteNotification(int id);
    }
}
