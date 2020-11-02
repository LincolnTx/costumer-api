using costumer.api.Application.Exceptions;
using costumer.api.Infra.Data.Repositories.User;
using costumer.api.v1.Contracts;
using System.Threading.Tasks;
using costumer.api.Application.RequestHandlers;

namespace costumer.api.Application.Identity
{
    public class IdentityService : RequestHandler, IIdentityService
    {
        private readonly IUserRepository _userRepository;

        public IdentityService(IUserRepository userRepository, ExceptionNotificationHandler exceptionHandler) : base(exceptionHandler)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> LoginUser(LoginRequest login)
        {
            if (!login.IsValid())
            {
                NotifyValidationErrors(login);
                return false;
            }
            var user = await _userRepository.FindUserByEmail(login.Email);

            if( user == null ||  !string.Equals(user.Password, login.Password))
            {
                await _notifications.PublishException(new ExceptionNotification("002", "Usuário ou senha incorretos!", null));
                return false;
            }

            return true;
        }
    }
}
