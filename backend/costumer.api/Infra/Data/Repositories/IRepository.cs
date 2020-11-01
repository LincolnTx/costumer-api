using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace costumer.api.Infra.Data.Repositories
{
    interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
    }
}
