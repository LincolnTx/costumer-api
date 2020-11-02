using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using costumer.api.Infra.Data.Confuguration;
using costumer.api.Models;
using Microsoft.EntityFrameworkCore;

namespace costumer.api.Infra.Data.Repositories.Phone
{
    public class PhoneRepository : Repository<Phones>, IPhoneRepository
    {
        public PhoneRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public bool DeletePhonesForCustomer(string customerId)
        {
            try
            {
                _dbSet.RemoveRange(_dbSet.Where(phones => phones.CustomerId == customerId));
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<List<Phones>> FindPhonesByUserId(string customerId)
        {
           return  await _dbSet.Where(phone => phone.CustomerId == customerId).ToListAsync();
        }
    }
}