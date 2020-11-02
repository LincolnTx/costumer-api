using System.Threading.Tasks;
using costumer.api.Application.Exceptions;
using costumer.api.Application.RequestHandlers.CustumerHandlerContracts;
using costumer.api.v1.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace costumer.api.v1.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly ICreateCustumerRequestHandler _createCustumer;

        public CustomerController(ExceptionNotificationHandler notifications,
            ICreateCustumerRequestHandler createCustomer) : base(notifications)
        {
            _createCustumer = createCustomer;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomerAsync([FromBody] CreateCustomerRequest requestCustomer)
        {
            var createCustomerResponse = await _createCustumer.Handle(requestCustomer);

            return Response(200, createCustomerResponse);
        }
    }
}
