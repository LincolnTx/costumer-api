using costumer.api.Infra.Data.Confuguration;
using costumer.api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace costumer.api.Infra.Data.Repositories.User
{
    public class UserRepository : Repository<UserEntity> ,IUserRepository
    {
        public UserRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }
        public async Task<UserEntity> FindUserByEmail(string email)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(user => user.Email == email);
        }
    }
}
