using costumer.api.Infra.Data.Confuguration;
using costumer.api.Infra.SeedWork;
using System.Threading.Tasks;

namespace costumer.api.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<bool> Commit()
        {
            return await _applicationDbContext.SaveEntitiesAsync();
        }

        public void Dispose()
        {
            _applicationDbContext.Dispose();
        }
    }
}
