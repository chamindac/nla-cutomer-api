using System.Threading;
using System.Threading.Tasks;
using NLA.CustomerAPI.Domains;

namespace NLA.CustomerAPI.Services.Clients
{
    public interface INotificationApiClient
    {
        Task<bool> SendCustomerRegistrationEmail(Customer registerCustomer, CancellationToken cancellationToken = default);
    }
}
