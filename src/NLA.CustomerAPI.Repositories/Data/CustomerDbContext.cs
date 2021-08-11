using Microsoft.EntityFrameworkCore;
using NLA.CustomerAPI.Domains;

namespace NLA.CustomerAPI.Repositories.Data
{
    public class CustomerDbContext: DbContext
    {
        public CustomerDbContext():base() { }
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options):base(options) {  }
        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerDbContext).Assembly);
        }
    }
}
