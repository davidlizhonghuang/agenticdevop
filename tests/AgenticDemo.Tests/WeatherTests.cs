using Xunit;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;

namespace AgenticDemo.Tests;

public class WeatherTests:IClassFixture<WebApplicationFactory<Program>>
{
  private readonly HttpClient _client;
    public WeatherTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }
    [Fact]
    public async Task GetWeatherForecast_ReturnsSuccessStatusCode()
    {
        // Arrange
        var request = "/weatherforecast";

        // Act
        var response = await _client.GetAsync("/weatherforecast");

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299
        Assert.Equal("application/json; charset=utf-8",
            response.Content.Headers.ContentType?.ToString());
    }
}


 