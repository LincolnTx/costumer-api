using costumer.api.Application.Exceptions;
using costumer.api.v1.Contracts;

namespace costumer.api.Application.RequestHandlers
{
    public abstract class RequestHandler
    {
        protected readonly ExceptionNotificationHandler _notifications;

        public RequestHandler(ExceptionNotificationHandler notifications)
        {
            _notifications = notifications;
        }

        protected void NotifyValidationErrors(Request message)
        {
            foreach (var error in message.GetValidationResult().Errors)
            {
                _notifications.PublishException(new ExceptionNotification("001", error.ErrorMessage, error.PropertyName));
            }
        }
    }
}
