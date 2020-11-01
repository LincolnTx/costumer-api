using costumer.api.Models;
using System.Threading.Tasks;

namespace costumer.api.Infra.Data.Repositories.Customer
{
    interface ICustomerRespository : IRepository<CustomerEntity>
    {
        Task<CustomerEntity> FindCustomerByCpf(string cpf);
    }
}
