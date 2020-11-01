using costumer.api.v1.Contracts;
using System.Threading.Tasks;

namespace costumer.api.Application.Identity
{
    public interface IIdentityService
    {
        Task<bool> LoginUser(LoginRequest login);
    }
}
