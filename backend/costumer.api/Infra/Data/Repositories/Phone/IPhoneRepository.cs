using costumer.api.Models;

namespace costumer.api.Infra.Data.Repositories.Phone
{
    public interface IPhoneRepository : IRepository<Phones>
    {
        public bool DeletePhonesForCustomer(string customerId);
    }
}