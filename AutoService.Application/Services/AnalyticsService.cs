using AutoService.Contracts.Interfaces;
using AutoService.Domain.Data;

namespace AutoService.Application.Services;

/// <summary>
/// Сервис для выполнения аналитических запросов.
/// </summary>
public class AnalyticsService : IAnalyticsService
{
    /// <summary>
    /// 1. Получить механиков, специализирующихся на выбранном виде работ.
    /// </summary>
    /// <param name="workName">Название работы (например, "Диагностика ходовой").</param>
    public Task<IEnumerable<object>> GetMechanicsByWorkAsync(string workName)
    {
        var work = DataSeed.Works.FirstOrDefault(w => w.Name == workName);
        if (work == null) throw new Exception("Работа не найдена");

        var mechanics = DataSeed.Mechanics
            .Where(m => m.Specialization.ToString() == work.Category)
            .ToList();

        return Task.FromResult<IEnumerable<object>>(mechanics);
    }

    /// <summary>
    /// 2. Получить клиентов указанного механика, упорядоченных по ФИО.
    /// </summary>
    /// <param name="mechanicId">Идентификатор механика.</param>
    public Task<IEnumerable<object>> GetClientsByMechanicAsync(Guid mechanicId)
    {
        var mechanic = DataSeed.Mechanics.FirstOrDefault(m => m.Id == mechanicId);
        if (mechanic == null) throw new Exception("Механик не найден");

        var clients = DataSeed.Clients
            .Where(c => DataSeed.Orders.Any(o => o.ClientId == c.Id && o.MechanicId == mechanic.Id))
            .OrderBy(c => c.FullName)
            .ToList();

        return Task.FromResult<IEnumerable<object>>(clients);
    }

    /// <summary>
    /// 3. Получить клиентов с повторными обращениями за последний месяц.
    /// </summary>
    public Task<IEnumerable<object>> GetRepeatClientsAsync()
    {
        var monthAgo = new DateTime(2026, 10, 12, 0, 0, 0, DateTimeKind.Utc).AddDays(-30);

        var clients = DataSeed.Orders
            .Where(o => o.AcceptedAt >= monthAgo)
            .GroupBy(o => o.ClientId)
            .Where(g => g.Count() > 1)
            .Select(g => DataSeed.Clients.First(c => c.Id == g.Key))
            .ToList();

        return Task.FromResult<IEnumerable<object>>(clients);
    }

    /// <summary>
    /// 4. Подсчитать суммарную стоимость работ для выбранного заказа.
    /// </summary>
    /// <param name="orderId">Идентификатор заказа.</param>
    public Task<decimal> GetOrderTotalCostAsync(Guid orderId)
    {
        var order = DataSeed.Orders.FirstOrDefault(o => o.Id == orderId);
        if (order == null) throw new Exception("Заказ не найден");

        var total = order.Works.Sum(w => w.Price);
        return Task.FromResult(total);
    }

    /// <summary>
    /// 5. Получить топ 5 наиболее частых видов работ.
    /// </summary>
    public Task<IEnumerable<object>> GetTop5WorksAsync()
    {
        var top = DataSeed.Orders
            .SelectMany(o => o.Works)
            .GroupBy(w => w.Name)
            .Select(g => new { Name = g.Key, Count = g.Count() })
            .OrderByDescending(x => x.Count)
            .ThenBy(x => x.Name)
            .Take(5)
            .ToList();

        return Task.FromResult<IEnumerable<object>>(top);
    }
}