using costumer.api.Models;
using System.Threading.Tasks;

namespace costumer.api.Infra.Data.Repositories.User
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity> FindUserByEmail(string email);
    }
}
