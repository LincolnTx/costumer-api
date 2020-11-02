using costumer.api.Infra.Data.Confuguration;
using costumer.api.Infra.Data.Repositories.Customer;
using costumer.api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using costumer.api.v1.Contracts;
using Microsoft.EntityFrameworkCore;

namespace costumer.api.Infra.Data.Repositories.Costumer
{
    public class CustomerRepository : Repository<CustomerEntity>, ICustomerRepository
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

        public async Task<CustomerEntity> FindCustomerById(string id)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(customer => customer.Id == id);
        }

        public CustomerEntity DeleteCustomer(CustomerEntity customer)
        {
            return _dbSet.Remove(customer).Entity;
        }

        public async Task<List<CustomerEntity>> ListCustomers()
        {
            return await _dbSet.ToListAsync();
        }
        
        public async Task<bool> UpdateCustomer(string id, string cpfCnpj = null, string companyName = null, string zipCode = null, int? stage = null)
        {
           var customer = await _dbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

           var success = customer.UpdateCustomerInfo(cpfCnpj, companyName, zipCode, stage);
           _dbSet.Update(customer);

           return success;
        }
    }
}
