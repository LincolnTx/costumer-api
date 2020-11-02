using System.Threading.Tasks;
using costumer.api.v1.Contracts;

namespace costumer.api.Application.RequestHandlers.CustumerHandlerContracts
{
    public interface IUpdateCustomerRequestHandler
    {
        Task<bool> Handle(string id ,UpdateCustomerRequest requestUpdate);
    }
}