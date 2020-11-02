using costumer.api.Infra.Data.Confuguration;
using costumer.api.Infra.Data.Repositories.Customer;
using costumer.api.Models;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace costumer.api.Infra.Data.Repositories.Costumer
{
    public class CustomerRepository : Repository<CustomerEntity>, ICustomerRespository
    {
        public CustomerRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }

        public async Task<CustomerEntity> FindCustomerByCpfCnpj(string cpfCnpj)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(customer => customer.CpfCnpj == cpfCnpj);
        }
        
        public async Task<CustomerEntity> FindCustomerByEmail(string email)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(customer => customer.Email == email);
        }
    }
}
