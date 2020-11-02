using System.Collections.Generic;
using costumer.api.Models;
using System.Threading.Tasks;

namespace costumer.api.Infra.Data.Repositories.Customer
{
    public interface ICustomerRepository : IRepository<CustomerEntity>
    {
        Task<CustomerEntity> FindCustomerByCpfCnpj(string cpf);
        Task<CustomerEntity> FindCustomerByEmail(string email);
        Task<CustomerEntity> FindCustomerById(string id);
        CustomerEntity DeleteCustomer(CustomerEntity customer);
        Task<List<CustomerEntity>> ListCustomers();

        Task<bool> UpdateCustomer(string id, string cpfCnpj = null, string companyName = null, string zipCode = null,
            int? stage = null);
    }
}
