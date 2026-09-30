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

    /// <summary>
    /// Тест 1: механики по виду работ
    /// </summary> 
    [Fact]
    public void GetMechanicsByWorkCategory()
    {
        var work = _works.First(w => w.Name == "Ремонт ГБЦ");

        var result = _mechanics
            .Where(m => m.Specialization.ToString() == work.Category)
            .OrderBy(m => m.FullName)
            .ToList();

        foreach (var m in result)
            _output.WriteLine($"{m.FullName} — {m.Specialization}");

        Assert.NotEmpty(result);
        Assert.All(result, m => Assert.Equal(work.Category, m.Specialization.ToString()));
    }
}