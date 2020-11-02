using System;
using System.Threading.Tasks;

namespace costumer.api.Infra.SeedWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}
