using System.Net.Http.Json;

namespace Passwordless.Api.IntegrationTests;

public class BasicTests : IClassFixture<TestWebApplicationFactory<Program>>
{
    protected readonly TestWebApplicationFactory<Program> _factory;
    protected readonly HttpClient _client;

    public BasicTests(TestWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = factory.CreateClient();

        _client.DefaultRequestHeaders.Add("Accept", "application/json");
        _client.DefaultRequestHeaders.Add("ApiSecret", _factory.ApiSecret);
    }

    public Task<HttpResponseMessage> PostAsync(string url, object payload)
    {
        return _client.PostAsJsonAsync(url, payload);
    }
}