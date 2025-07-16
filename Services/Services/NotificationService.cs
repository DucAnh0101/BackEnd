using BusinessObject;
using BusiniessObject.Models;
using DataAccessLayer.DTOs.request;
using DataAccessLayer.DTOs.response;
using Services.Implements;

namespace Services.Services
{
    public class NotificationService : INotificationServices
    {
        private readonly MyDbContext _dbContext;
        public NotificationService(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteNotification(int id)
        {
            var n = _dbContext.Notifications.FirstOrDefault(o => o.Id == id);
            if (n == null) throw new Exception($"No notification found!");

            _dbContext.Notifications.Remove(n);
            _dbContext.SaveChanges();
        }

        public List<Notification> GetAllNotification()
        {
            var n = _dbContext.Notifications.ToList();
            if (n == null) throw new Exception($"No notification found!");
            return n;
        }

        public NotificationRes GetNotification(int id)
        {
            var n = _dbContext.Notifications.FirstOrDefault(o => o.Id == id);
            if (n == null) throw new Exception($"No notification found!");
            return new NotificationRes
            {
                Content = n.Content,
                RequiredDate = n.RequiredDate,
            };
        }

        public NotificationRes UpdateNotification(NotificationReq notification, int id)
        {
            var n = _dbContext.Notifications.FirstOrDefault(o => o.Id == id);
            if (n == null) throw new Exception($"No notification found!");

            n.Content = notification.Content;
            n.RequiredDate = notification.RequiredDate;

            _dbContext.SaveChanges();
            return new NotificationRes
            {
                Content = notification.Content,
                RequiredDate = notification.RequiredDate,
            };
        }
    }
}
