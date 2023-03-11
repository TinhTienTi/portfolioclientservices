using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace PortfolioServices.Bo.ApiServices;

public class PingApiService<T> : IPingApiService<T>
{
    private readonly IConfiguration configuration;
    private readonly HttpClient client = new();

    public PingApiService(IConfiguration configuration)
    {
        this.configuration = configuration;
        client.BaseAddress = new Uri(configuration["Api:Uri"]);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<T> GetAsync(string apiPath)
    {
        T result = (dynamic)null;
        HttpResponseMessage response = await client.GetAsync(apiPath);
        if (response.IsSuccessStatusCode)
        {
            result = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync()); ;
        }
        return result;
    }

}
