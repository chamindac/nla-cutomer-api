using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NLA.CustomerAPI.Domains;

namespace NLA.CustomerAPI.Services
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllCustomers(CancellationToken cancellationToken = default);
        Task<Customer> RegisterCustomer(Customer customer, CancellationToken cancellationToken = default);
    }
}