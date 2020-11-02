using System;
using System.Linq;
using costumer.api.Infra.Data.Confuguration;
using costumer.api.Models;

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
    }
}