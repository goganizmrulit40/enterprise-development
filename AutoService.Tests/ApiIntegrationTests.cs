using System.Net.Http.Json;
using AutoService.Domain.Models;
using Microsoft.AspNetCore.Mvc.Testing;

namespace AutoService.Tests;

public class ApiIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public ApiIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    /// <summary>
    /// Тест: проверка получения списка машин через API.
    /// </summary>
    [Fact]
    public async Task GetAllCars_ReturnsSuccessAndData()
    {
        var response = await _client.GetAsync("/api/cars", TestContext.Current.CancellationToken);

        response.EnsureSuccessStatusCode();
        var cars = await response.Content.ReadFromJsonAsync<List<Car>>(TestContext.Current.CancellationToken);

        Assert.NotNull(cars);
        Assert.NotEmpty(cars);
    }

    /// <summary>
    /// Тест: проверка аналитического запроса (топ-5 работ).
    /// </summary>
    [Fact]
    public async Task GetTop5Works_ReturnsSuccess()
    {
        var response = await _client.GetAsync("/api/reports/top-5-works", TestContext.Current.CancellationToken);

        response.EnsureSuccessStatusCode();
    }
}