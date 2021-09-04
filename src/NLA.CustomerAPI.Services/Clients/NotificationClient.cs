using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using NLA.CustomerAPI.Domains;

namespace NLA.CustomerAPI.Services.Clients
{
    public class NotificationApiClient : ClientBase, INotificationApiClient
    {
        public const string RegisterCustomerEmailRootUrl = "api/Notification/customerregistration";
        public NotificationApiClient(HttpClient httpClient, ILogger<NotificationApiClient> logger) : base(httpClient, logger)
        {
        }
        
        public async Task<bool> SendCustomerRegistrationEmail(Customer registerCustomer, CancellationToken cancellationToken = default)
        {
            return await Post<Customer, bool>($"{RegisterCustomerEmailRootUrl}", registerCustomer, cancellationToken);
        }
    }
}