using costumer.api.Application.Exceptions;
using costumer.api.Infra.SeedWork;
using costumer.api.v1.Contracts;
using System.Threading.Tasks;

namespace costumer.api.Application.RequestHandlers
{
    public abstract class RequestHandler
    {
        protected readonly ExceptionNotificationHandler _notifications;
        private readonly IUnitOfWork _uow;

        public RequestHandler(ExceptionNotificationHandler notifications, IUnitOfWork uow)
        {
            _notifications = notifications;
            _uow = uow;
        }

        protected void NotifyValidationErrors(Request message)
        {
            foreach (var error in message.GetValidationResult().Errors)
            {
                _notifications.PublishException(new ExceptionNotification("001", error.ErrorMessage, error.PropertyName));
            }
        }

        public async Task<bool> Commit()
        {
            if (_notifications.HasNotifications()) return false;
            if (await _uow.Commit()) return true;

            await _notifications.PublishException(new ExceptionNotification("002", "We had a problem during saving your data."));

            return false;
        }
    }
}
