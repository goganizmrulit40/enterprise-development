using AutoService.Domain.Models;

namespace AutoService.Tests;

/// <summary>
/// Класс, хранящий юнит-тесты
/// </summary>
public class AutoServiceTests(AutoServiceFixture fixture, ITestOutputHelper output)
    : IClassFixture<AutoServiceFixture>
{
    private const string DiagnosticsWorkName = "Диагностика ходовой";

    /// <summary>
    /// Тест 1: механики по виду работ
    /// </summary>
    [Fact]
    public void GetMechanicsByWorkCategory()
    {
        var work = fixture.Works.First(w => w.Name == DiagnosticsWorkName);

        var result = fixture.Mechanics
            .Where(m => m.Specialization.ToString() == work.Category)
            .OrderBy(m => m.FullName)
            .ToList();

        foreach (var m in result)
            output.WriteLine($"{m.FullName} — {m.Specialization}");

        Assert.NotEmpty(result);
        Assert.All(result, m => Assert.Equal(work.Category, m.Specialization.ToString()));
    }

    /// <summary>
    /// Тест 2: клиенты указанного механика, упорядоченные по ФИО
    /// </summary>
    [Fact]
    public void GetClientsByMechanic()
    {
        var mechanic = fixture.Mechanics.First(m => m.Specialization == Specialization.Engine);

        var clientIds = fixture.Orders
            .Where(o => o.MechanicId == mechanic.Id)
            .Select(o => o.ClientId)
            .Distinct()
            .ToList();

        var clients = fixture.Clients
            .Where(c => clientIds.Contains(c.Id))
            .OrderBy(c => c.FullName)
            .ToList();

        output.WriteLine($"Механик: {mechanic.FullName}");
        foreach (var c in clients)
            output.WriteLine($"{c.FullName} — {c.Phone}");

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
        var monthAgo = new DateTime(2026, 10, 12, 23, 5, 10, DateTimeKind.Local).AddDays(-30);

        var grouped = fixture.Orders
            .Where(o => o.AcceptedAt >= monthAgo)
            .GroupBy(o => o.ClientId)
            .Select(g => new { ClientId = g.Key, Count = g.Count() })
            .Where(x => x.Count > 1)
            .ToList();

        foreach (var g in grouped)
        {
            var client = fixture.Clients.First(c => c.Id == g.ClientId);
            output.WriteLine($"{client.FullName}: {g.Count} обращения");
        }

        Assert.NotEmpty(grouped);
    }

    /// <summary>
    /// Тест 4: суммарная стоимость работ для выбранного заказа
    /// </summary>
    [Fact]
    public void GetOrderTotalCost()
    {
        var order = fixture.Orders.First(o => o.Works.Count > 1);

        var total = order.Works.Sum(w => w.Price);
        var car = fixture.Cars.First(c => c.Id == order.CarId);

        output.WriteLine($"Авто: {car.Brand} {car.Model} ({car.LicensePlate})");
        foreach (var w in order.Works)
            output.WriteLine($"  {w.Name}: {w.Price} р.");
        output.WriteLine($"Итого: {total} р.");

        Assert.Equal(order.TotalCost, total);
        Assert.True(total > 0);
    }

    /// <summary>
    /// Тест 5: топ 5 наиболее частых видов работ
    /// </summary>
    [Fact]
    public void GetTop5Works()
    {
        var top = fixture.Orders
            .SelectMany(o => o.Works)
            .GroupBy(w => w.Name)
            .Select(g => new { Name = g.Key, Count = g.Count() })
            .OrderByDescending(x => x.Count)
            .ThenBy(x => x.Name)
            .Take(5)
            .ToList();

        foreach (var t in top)
            output.WriteLine($"{t.Name}: {t.Count}");

        Assert.True(top.Count > 0);
        Assert.True(top.Count <= 5);
    }
}