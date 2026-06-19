using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;

namespace CRN.ProductManagement.Tests;

public class AuthApiTests :
    IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public AuthApiTests(
        WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Login_Should_Return_Token()
    {
        var request = new
        {
            UserName = "admin",
            Password = "admin123"
        };

        var response =
            await _client.PostAsJsonAsync(
                "/api/Auth/login",
                request);

        Assert.Equal(
            HttpStatusCode.OK,
            response.StatusCode);
    }
}