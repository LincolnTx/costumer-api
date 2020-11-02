using System.Collections.Generic;
using System.Threading.Tasks;
using costumer.api.Models;
using costumer.api.v1.Responses;

namespace costumer.api.Application.RequestHandlers.CustumerHandlerContracts
{
    public interface IFindCustomerRequestHandler
    {
        Task<List<CustomersResponse>> ListCustomers();

        Task<CustomersResponse> FindCustomerByEmail(string email);

    }
}