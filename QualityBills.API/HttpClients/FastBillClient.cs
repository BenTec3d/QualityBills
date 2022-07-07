using Marvin.StreamExtensions;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using QualityBills.API.Customers;
using QualityBills.API.Settings;
using System.Net.Http.Headers;
using System.Text;

namespace QualityBills.API.HttpClients
{
    public class FastBillClient
    {
        private readonly HttpClient _httpClient;
        private readonly FastBillApiSettings _apiSettings;

        public FastBillClient(HttpClient httpClient, IOptions<FastBillApiSettings> apiSettings)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _apiSettings = apiSettings.Value ?? throw new ArgumentNullException(nameof(apiSettings));

            _httpClient.Timeout = new TimeSpan(0, 0, 30);
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));

            if (!string.IsNullOrEmpty(_apiSettings.Email) && !string.IsNullOrEmpty(_apiSettings.Key))
            {
                var authenticationString = $"{_apiSettings.Email}:{_apiSettings.Key}";
                var base64EncodedAuthenticationString = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(authenticationString));
                _httpClient.DefaultRequestHeaders.Add("Authorization", $"Basic {base64EncodedAuthenticationString}");
            }
        }

        private class JsonPayload
        {
            public JsonPayload(string service)
            {
                Service = service;
            }

            public string Service { get; set; }
            public List<string> Filter { get; set; } = new();
        }

        private class Request
        {
            public string Service { get; set; }
            public List<string> Filter { get; set; } = new();
        }

        private class Response
        {
            public List<FastBillCustomerDto> Customers { get; set; }
        }

        private class Root
        {
            public Request Request { get; set; }
            public Response Response { get; set; }
        }

        public async Task<IEnumerable<FastBillCustomerDto>> GetCustomersAsync(CancellationToken cancellationToken)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, _apiSettings.Url);

            JsonPayload payload = new JsonPayload("customer.get");
            string json = JsonConvert.SerializeObject(payload);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
            {
                var stream = await response.Content.ReadAsStreamAsync();
                response.EnsureSuccessStatusCode();
                var deserializedResonse = stream.ReadAndDeserializeFromJson<Root>();
                return deserializedResonse.Response.Customers;
            }
        }
    }
}
