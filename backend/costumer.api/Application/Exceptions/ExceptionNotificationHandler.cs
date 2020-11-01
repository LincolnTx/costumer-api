using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace costumer.api.Application.Exceptions
{
    public class ExceptionNotificationHandler : IDisposable
    {
        private List<ExceptionNotification> _notifications;

        public  ExceptionNotificationHandler()
        {
            _notifications = new List<ExceptionNotification>();
        }

        public Task PublishException(ExceptionNotification notification)
        {
            _notifications.Add(notification);

            return Task.CompletedTask;
        }

        public List<ExceptionNotification> GetNotifications()
        {
            return _notifications;
        }

        public bool HasNotifications()
        {
            return GetNotifications().Any();
        }

        public void Dispose()
        {
            _notifications = new List<ExceptionNotification>();
        }
    }
}
