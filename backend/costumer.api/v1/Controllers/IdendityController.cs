using System.Threading.Tasks;
using costumer.api.Application.Exceptions;
using costumer.api.Application.Identity;
using costumer.api.v1.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace costumer.api.v1.Controllers
{
    public class IdendityController : BaseController
    {
        private readonly IIdentityService _identityService;

        public IdendityController(ExceptionNotificationHandler notifications,
            IIdentityService identityService) : base (notifications)
        {
            _identityService = identityService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest login)
        {
            var loginResponse = await _identityService.LoginUser(login);

            return Response(200, loginResponse);
        }

    }
}
