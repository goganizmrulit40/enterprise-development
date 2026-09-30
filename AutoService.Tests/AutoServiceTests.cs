using AutoService.Domain.Data;
using AutoService.Domain.Models;
using Xunit;

namespace AutoService.Tests;

/// <summary>
/// Класс, хранящий юнит-тесты
/// </summary>
public class AutoServiceTests
{
    private readonly ITestOutputHelper  _output;
    private readonly List<Client>       _clients;
    private readonly List<Car>          _cars;
    private readonly List<Mechanic>     _mechanics;
    private readonly List<WorkType>     _works;
    private readonly List<Order>        _orders;

    /// <summary>
    /// Конструктор класса
    /// </summary>  
    public AutoServiceTests(ITestOutputHelper output)
    {
        _output = output;
        (_clients, _cars, _mechanics, _works, _orders) = DataSeed.Create();
    }
}