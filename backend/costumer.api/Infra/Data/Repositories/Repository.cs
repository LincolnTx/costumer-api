using costumer.api.Infra.Data.Confuguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace costumer.api.Infra.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext _applicationDbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _dbSet = applicationDbContext.Set<TEntity>();
        }

        public void Add(TEntity obj)
        {
            _applicationDbContext.Add(obj);
        }

        public async Task Commit()
        {
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
