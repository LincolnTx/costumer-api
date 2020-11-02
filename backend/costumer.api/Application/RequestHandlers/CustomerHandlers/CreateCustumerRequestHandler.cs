using costumer.api.Application.Exceptions;
using costumer.api.Application.RequestHandlers.CustumerHandlerContracts;
using costumer.api.Infra.Data.Repositories.Customer;
using costumer.api.Infra.SeedWork;
using costumer.api.Models;
using costumer.api.v1.Contracts;
using costumer.api.v1.Responses;
using System.Threading.Tasks;

namespace costumer.api.Application.RequestHandlers.CustomerHandlers
{
    public class CreateCustumerRequestHandler : RequestHandler, ICreateCustumerRequestHandler
    {
        private readonly ICustomerRespository _customerRespository;

        public CreateCustumerRequestHandler(ExceptionNotificationHandler notifications, IUnitOfWork uow,
            ICustomerRespository customerRespository) : base(notifications, uow)
        {
            _customerRespository = customerRespository;
        }

        public async Task<CreateCustomerResponse> Handle(CreateCustomerRequest requestCustomer)
        {
            if (! requestCustomer.IsValid())
            {
                NotifyValidationErrors(requestCustomer);
                return null;
            }

            if (! await IsCustomerAbleToPersist(requestCustomer.CpfCnpj, requestCustomer.Email))
            {
                return null;
            }
            
            var customerType = GetCustomerType(requestCustomer.CpfCnpj);
            var customer = new CustomerEntity(requestCustomer.Name, requestCustomer.Email, requestCustomer.CpfCnpj, requestCustomer.CompanyName, 
                requestCustomer.ZipCode, requestCustomer.Stage, requestCustomer.Phones, customerType);

            _customerRespository.Add(customer);

            if(! await Commit())
            {
                await _notifications.PublishException(new ExceptionNotification("003", "Erro ao cadastrar cliente"));
                return null;
            }

            var customerStage = StageEnumeration.FromId(customer.Stage).Name;
            var customerTypeName = CustomerTypeEnumeration.FromId(customer.Type).Name;

            return new CreateCustomerResponse(customer.Name, customer.Email, customer.CpfCnpj, customerTypeName, customerStage);
        }

        private int GetCustomerType(string cpfCnpj)
        {
            if (cpfCnpj.Length == 14)
            {
                return CustomerTypeEnumeration.LegalEntity.Id;
            }

            return CustomerTypeEnumeration.Person.Id;
        }

        private async Task<bool> IsCustomerAbleToPersist(string cpfCnpj, string email)
        {
            var emailVerification = await _customerRespository.FindCustomerByEmail(email);

            if (emailVerification != null)
            {
                await _notifications.PublishException(new ExceptionNotification("010",
                    "Email informado já esta sendo utilizado", "email"));
                
                return false;
            }

            var cpfCnpjVerification = await _customerRespository.FindCustomerByCpfCnpj(cpfCnpj);
            
            if (cpfCnpjVerification != null)
            {
                await _notifications.PublishException(new ExceptionNotification("011",
                    "Cpf/Cnpj informado já esta sendo utilizado", "cpfCnpj"));
                
                return false;
            }

            return true;
        }
    }
}
