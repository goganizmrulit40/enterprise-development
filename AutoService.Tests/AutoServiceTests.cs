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
        var work = _works.First(w => w.Name == "Диагностика ходовой");

        var result = _mechanics
            .Where(m => m.Specialization.ToString() == work.Category)
            .OrderBy(m => m.FullName)
            .ToList();

        foreach (var m in result)
            _output.WriteLine($"{m.FullName} — {m.Specialization}");

        Assert.NotEmpty(result);
        Assert.All(result, m => Assert.Equal(work.Category, m.Specialization.ToString()));
    }

    /// <summary>
    /// Тест 2: клиенты указанного механика, упорядоченные по ФИО
    /// </summary>
    [Fact]
    public void GetClientsByMechanic()
    {
        var mechanic = _mechanics.First(m => m.Specialization == Specialization.Engine);

        var clientIds = _orders
            .Where(o => o.MechanicId == mechanic.Id)
            .Select(o => o.ClientId)
            .Distinct()
            .ToList();

        var clients = _clients
            .Where(c => clientIds.Contains(c.Id))
            .OrderBy(c => c.FullName)
            .ToList();

        _output.WriteLine($"Механик: {mechanic.FullName}");
        foreach (var c in clients)
            _output.WriteLine($"{c.FullName} — {c.Phone}");

        Assert.NotEmpty(clients);

        var sorted = clients.OrderBy(c => c.FullName).ToList();
        Assert.Equal(sorted, clients);
    }

    /// <summary>
    /// Тест 3: кол-во клиентов с повторным обращением за последний месяц
    /// </summary>
    [Fact]
    public void GetRepeatClientsLastMonth()
    {
        var monthAgo = DateTime.UtcNow.AddDays(-30);

        var grouped = _orders
            .Where(o => o.AcceptedAt >= monthAgo)
            .GroupBy(o => o.ClientId)
            .Select(g => new { ClientId = g.Key, Count = g.Count() })
            .Where(x => x.Count > 1)
            .ToList();

        foreach (var g in grouped)
        {
            var client = _clients.First(c => c.Id == g.ClientId);
            _output.WriteLine($"{client.FullName}: {g.Count} обращения");
        }

        Assert.NotEmpty(grouped);
    }

    /// <summary>
    /// Тест 4: суммарная стоимость работ для выбранного заказа
    /// </summary>
    [Fact]
    public void GetOrderTotalCost()
    {
        var order = _orders.First(o => o.Works.Count > 1);

        var total = order.Works.Sum(w => w.Price);
        var car = _cars.First(c => c.Id == order.CarId);

        _output.WriteLine($"Авто: {car.Brand} {car.Model} ({car.LicensePlate})");
        foreach (var w in order.Works)
            _output.WriteLine($"  {w.Name}: {w.Price} р.");
        _output.WriteLine($"Итого: {total} р.");

        Assert.Equal(order.TotalCost, total);
        Assert.True(total > 0);
    }
}