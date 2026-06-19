using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;

namespace CRN.ProductManagement.Tests;

public class AuthorizedProductApiTests :
    IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public AuthorizedProductApiTests(
        WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetProducts_With_Valid_JWT_Should_Return_OK()
    {
        var loginRequest = new
        {
            UserName = "admin",
            Password = "admin123"
        };

        var loginResponse =
            await _client.PostAsJsonAsync(
                "/api/Auth/login",
                loginRequest);

        loginResponse.EnsureSuccessStatusCode();

        var json =
            await loginResponse.Content.ReadAsStringAsync();

        using var document =
            JsonDocument.Parse(json);

        var token =
            document.RootElement
                    .GetProperty("accessToken")
                    .GetString();

        _client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue(
                "Bearer",
                token);

        var response =
            await _client.GetAsync(
                "/api/v1/Products");

        Assert.Equal(
            HttpStatusCode.OK,
            response.StatusCode);
    }
}