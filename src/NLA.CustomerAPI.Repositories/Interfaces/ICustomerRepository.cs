using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NLA.CustomerAPI.Domains;
using NLA.CustomerAPI.Repositories.Data;

namespace NLA.CustomerAPI.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllCustomers(CancellationToken cancellationToken = default);
        Task<Customer> RegisterCutomer(Customer customer, CancellationToken cancellationToken = default);
    }
}
