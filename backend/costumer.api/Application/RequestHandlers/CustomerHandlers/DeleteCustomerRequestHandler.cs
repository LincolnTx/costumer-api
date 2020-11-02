using System.Threading.Tasks;
using costumer.api.Application.Exceptions;
using costumer.api.Application.RequestHandlers.CustumerHandlerContracts;
using costumer.api.Infra.Data.Repositories.Customer;
using costumer.api.Infra.Data.Repositories.Phone;
using costumer.api.Infra.SeedWork;
using costumer.api.v1.Responses;

namespace costumer.api.Application.RequestHandlers.CustomerHandlers
{
    public class DeleteCustomerRequestHandler : RequestHandler, IDeleteCustomerRequestHandler
    {
        private  readonly ICustomerRepository _customerRepository;
        private  readonly IPhoneRepository _phoneRepository;
        public DeleteCustomerRequestHandler(ExceptionNotificationHandler notifications, IUnitOfWork uow,
            ICustomerRepository customerRepository, IPhoneRepository phoneRepository) : base(notifications, uow)
        {
            _customerRepository = customerRepository;
            _phoneRepository = phoneRepository;
        }

        public async Task<DeleteCustomerResponse> Handle(string id)
        {
            var customer = await _customerRepository.FindCustomerById(id);
            
            if (customer == null)
            {
                await _notifications.PublishException(new ExceptionNotification("012", "Id informado não foi encontrado",
                    "customerId"));
                return null;
            }

            if (!_phoneRepository.DeletePhonesForCustomer(customer.Id))
            {
                await _notifications.PublishException(new ExceptionNotification("013", "Erro ao remover cliente"));
                return null;
            }
            var deletedCustomer = _customerRepository.DeleteCustomer(customer);

            if (!await Commit())
            {
                await _notifications.PublishException(new ExceptionNotification("013", "Erro ao remover cliente"));
                return null;
            }

            var customerType = CustomerTypeEnumeration.FromId(deletedCustomer.Type).Name;
            return  new DeleteCustomerResponse(deletedCustomer.Name, deletedCustomer.Email, deletedCustomer.CpfCnpj, customerType);
        }
    }
}