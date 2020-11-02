using System.Threading.Tasks;
using costumer.api.Application.Exceptions;
using costumer.api.Application.RequestHandlers.CustumerHandlerContracts;
using costumer.api.Infra.Data.Repositories.Customer;
using costumer.api.Infra.SeedWork;
using costumer.api.v1.Contracts;

namespace costumer.api.Application.RequestHandlers.CustomerHandlers
{
    public class UpdateCustomerRequestHandler : RequestHandler, IUpdateCustomerRequestHandler
    {
        private readonly ICustomerRepository _customerRepository;
        
        public UpdateCustomerRequestHandler(ExceptionNotificationHandler notifications, IUnitOfWork uow,
            ICustomerRepository customerRepository) : base(notifications, uow)
        {
            _customerRepository = customerRepository;
        }

        public async Task<bool> Handle(string id, UpdateCustomerRequest requestUpdate)
        {
            var customer = await _customerRepository.FindCustomerById(id);

            if (customer == null)
            {
                await _notifications.PublishException(new ExceptionNotification("015",
                    "Usuário não econtrado para alteações"));
                return false;
            }

            var updateSuccessful = await _customerRepository.UpdateCustomer(id, requestUpdate.CpfCnpj, requestUpdate.CompanyName, requestUpdate.ZipCode,
                requestUpdate.Stage);

            if (updateSuccessful && await Commit())
            {
                return true;
            }
            await _notifications.PublishException(new ExceptionNotification("016",
                "Erro na atualizazação"));
            return false;
        }
    }
}