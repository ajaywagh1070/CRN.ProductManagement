using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace CRN.ProductManagement.Tests;

public class ItemApiTests :
    IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public ItemApiTests(
        WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Items_Without_JWT_Should_Return_Unauthorized()
    {
        var response =
            await _client.GetAsync(
                "/api/v1/Items");

        Assert.Equal(
            HttpStatusCode.Unauthorized,
            response.StatusCode);
    }
}