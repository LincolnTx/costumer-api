using System.Threading.Tasks;
using costumer.api.Application.Exceptions;
using costumer.api.Application.RequestHandlers.CustumerHandlerContracts;
using costumer.api.v1.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace costumer.api.v1.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly ICreateCustumerRequestHandler _createCustomer;
        private readonly IDeleteCustomerRequestHandler _deleteCustomer;

        public CustomerController(ExceptionNotificationHandler notifications,
            ICreateCustumerRequestHandler createCustomer, IDeleteCustomerRequestHandler deleteCustomer) : base(notifications)
        {
            _createCustomer = createCustomer;
            _deleteCustomer = deleteCustomer;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomerAsync([FromBody] CreateCustomerRequest requestCustomer)
        {
            var createCustomerResponse = await _createCustomer.Handle(requestCustomer);

            return Response(200, createCustomerResponse);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCustomerAsync(string id)
        {
            var deletedCustomer = await _deleteCustomer.Handle(id);

            return Response(200, deletedCustomer);
        }
    }
}
