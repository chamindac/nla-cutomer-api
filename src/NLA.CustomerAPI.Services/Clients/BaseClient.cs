using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace NLA.CustomerAPI.Services.Clients
{
    // Implementation of ClientBase class
    public abstract class ClientBase
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ClientBase> _logger;

        public ClientBase(HttpClient httpClient, ILogger<ClientBase> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves the all data
        /// </summary>
        /// <typeparam name="S">Return type</typeparam>
        /// <param name="url"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<S> Get<S>(string url, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url, cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }

            string content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<S>(content, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
        }

        /// <summary>
        /// Insert new data
        /// </summary>
        /// <typeparam name="T">Input type</typeparam>
        /// <typeparam name="S">Return Type</typeparam>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<S> Post<T,S>(string url, T data, CancellationToken cancellationToken = default)
        {
            var stringContent = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(url, stringContent, cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }

            string content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<S>(content, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
        }

        /// <summary>
        /// Update the exsting data
        /// </summary>
        /// <typeparam name="T">Input type</typeparam>
        /// <typeparam name="S">Return Type</typeparam>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<S> Put<T,S>(string url, T data, CancellationToken cancellationToken = default)
        {
            var stringContent = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PutAsync(url, stringContent, cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }

            string content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<S>(content, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
        }

        /// <summary>
        /// Delete the exsisting data
        /// </summary>
        /// <param name="url"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<S> Delete<S>(string url, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync(url, cancellationToken);
            string content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<S>(content, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
        }
    }
}
