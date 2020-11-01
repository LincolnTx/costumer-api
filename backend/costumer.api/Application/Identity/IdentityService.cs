using costumer.api.Application.Exceptions;
using costumer.api.Infra.Data.Repositories.User;
using costumer.api.v1.Contracts;
using System.Threading.Tasks;

namespace costumer.api.Application.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly IUserRepository _userRepository;
        private readonly ExceptionNotificationHandler _exceptionHandler;

        public IdentityService(IUserRepository userRepository, ExceptionNotificationHandler exceptionHandler)
        {
            _userRepository = userRepository;
            _exceptionHandler = exceptionHandler;
        }

        public async Task<bool> LoginUser(LoginRequest login)
        {
            var user = await _userRepository.FindUserByEmail(login.Email);

            if( user == null ||  !string.Equals(user.Password, login.Password))
            {
               await _exceptionHandler.PublishException(new ExceptionNotification("002", "Usuário ou senha incorretos!", null));
                return false;
            }

            return true;
        }
    }
}
