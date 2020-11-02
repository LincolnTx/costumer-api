using System.Threading.Tasks;
using costumer.api.v1.Responses;

namespace costumer.api.Application.RequestHandlers.CustumerHandlerContracts
{
    public interface IDeleteCustomerRequestHandler
    {
        Task<DeleteCustomerResponse> Handle(string id);
    }
}