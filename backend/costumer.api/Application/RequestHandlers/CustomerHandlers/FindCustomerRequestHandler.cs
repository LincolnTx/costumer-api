using System.Collections.Generic;
using System.Threading.Tasks;
using costumer.api.Application.Exceptions;
using costumer.api.Application.RequestHandlers.CustumerHandlerContracts;
using costumer.api.Infra.Data.Repositories.Customer;
using costumer.api.Infra.Data.Repositories.Phone;
using costumer.api.Infra.SeedWork;
using costumer.api.Models;
using costumer.api.v1.Responses;

namespace costumer.api.Application.RequestHandlers.CustomerHandlers
{
    public class FindCustomerRequestHandler: RequestHandler, IFindCustomerRequestHandler
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IPhoneRepository _phoneRepository;
        
        public FindCustomerRequestHandler(ExceptionNotificationHandler notifications, IUnitOfWork uow,
            ICustomerRepository customerRepository, IPhoneRepository phoneRepository) : base(notifications, uow)
        {
            _customerRepository = customerRepository;
            _phoneRepository = phoneRepository;
        }

        public async Task<List<CustomersResponse>> ListCustomers()
        {
            var customersResponses = new List<CustomersResponse>();
            var customers =  await  _customerRepository.ListCustomers();

            if (customers.Count <= 0)
            {
               await _notifications.PublishException(new ExceptionNotification("013",
                    "Não temos nenhum cliente cadastro no momento"));
               return null;
            }

            foreach (var customer in customers)
            {
                var phones = await _phoneRepository.FindPhonesByUserId(customer.Id);
                
                var customerResponse = new CustomersResponse(customer.Name, customer.Email, customer.CpfCnpj, customer.CompanyName, 
                    customer.ZipCode, customer.Stage, customer.Type, SanitizePhones(phones));
                
                customersResponses.Add(customerResponse);
            };

            return customersResponses;
        }

        public async Task<CustomersResponse> FindCustomerByEmail(string email)
        {
            var customer = await _customerRepository.FindCustomerByEmail(email);
            
            if (customer == null)
            {
                await _notifications.PublishException(new ExceptionNotification("014",
                    "Não foi possível encontrar esse cliente"));
                return null;
            }

            var phones = await _phoneRepository.FindPhonesByUserId(customer.Id);
            
            var customerResponse = new CustomersResponse(customer.Name, customer.Email, customer.CpfCnpj, customer.CompanyName, 
                customer.ZipCode, customer.Stage, customer.Type, SanitizePhones(phones));
            
            return customerResponse;
        }

        private List<string> SanitizePhones(List<Phones> phones)
        {
            var sanitizePhoneNumbers = new List<string>();
            
            phones.ForEach(phone => sanitizePhoneNumbers.Add(phone.PhoneNumber));

            return sanitizePhoneNumbers;
        }
    }
}