using costumer.api.Infra.Data.Confuguration;
using costumer.api.Infra.Data.Repositories.Customer;
using costumer.api.Models;
using System;
using System.Threading.Tasks;

namespace costumer.api.Infra.Data.Repositories.Costumer
{
    public class CustomerRepository : Repository<CustomerEntity>, ICustomerRespository
    {
        public CustomerRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }

        public Task<CustomerEntity> FindCustomerByCpf(string cpf)
        {
            throw new NotImplementedException();
        }
    }
}
