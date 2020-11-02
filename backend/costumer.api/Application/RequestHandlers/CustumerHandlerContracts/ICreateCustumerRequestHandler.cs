using costumer.api.v1.Contracts;
using costumer.api.v1.Responses;
using System.Threading.Tasks;

namespace costumer.api.Application.RequestHandlers.CustumerHandlerContracts
{
    public interface ICreateCustumerRequestHandler
    {
        Task<CreateCustomerResponse> Handle(CreateCustomerRequest requestCustomer);
    }
}
