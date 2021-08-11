using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NLA.CustomerAPI.Domains;
using NLA.CustomerAPI.Repositories.Data;
using NLA.CustomerAPI.Repositories.Interfaces;

namespace NLA.CustomerAPI.Repositories
{
    public class CustomerRepository: ICustomerRepository
    {
        private readonly CustomerDbContext _dbContext;
        private readonly DbSet<Customer> _dbSet;

        public CustomerRepository(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<Customer>();
            
        }

        public async Task<List<Customer>> GetAllCustomers(CancellationToken cancellationToken = default)
        {
            // TODO: this is bad we need pagination here
            return await _dbSet
               .ToListAsync(cancellationToken);
        }

        public async Task<Customer> RegisterCutomer(Customer customer,CancellationToken cancellationToken = default)
        {
            _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync();

            return customer;
        }

    }
}
