using costumer.api.Models;
using System.Threading.Tasks;

namespace costumer.api.Infra.Data.Repositories.Customer
{
    public interface ICustomerRespository : IRepository<CustomerEntity>
    {
        Task<CustomerEntity> FindCustomerByCpfCnpj(string cpf);
        Task<CustomerEntity> FindCustomerByEmail(string email);
    }
}
