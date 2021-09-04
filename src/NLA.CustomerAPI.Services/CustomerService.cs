using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NLA.CustomerAPI.Domains;
using NLA.CustomerAPI.Services.Clients;
using NLA.CustomerAPI.Repositories.Interfaces;

namespace NLA.CustomerAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly INotificationApiClient _notificationApiClient;
        // TODO: Implementa validators
        //private readonly IValidator<Customer> _customerValidator;

        public CustomerService(ICustomerRepository customerRepository
            ,INotificationApiClient notificationApiClient
            //,IValidator<Customer> customerValidator
            )
        {
            _customerRepository = customerRepository;
            _notificationApiClient = notificationApiClient;
            //_customerValidator = customerValidator;
        }

        public async Task<List<Customer>> GetAllCustomers(CancellationToken cancellationToken = default)
        {
            List<Customer> customers = await _customerRepository
                .GetAllCustomers(cancellationToken);

           return customers;
        }

        public async Task<Customer> RegisterCustomer(Customer customer, CancellationToken cancellationToken = default)
        {
            var registeredCustomer = await _customerRepository.RegisterCutomer(customer);

            //TODO: Call notification - Send message to Q
            await _notificationApiClient.SendCustomerRegistrationEmail(registeredCustomer, cancellationToken);

            return registeredCustomer;
        }
    }
}
