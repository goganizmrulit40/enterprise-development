using AutoService.Domain.Data;
using Microsoft.AspNetCore.Mvc;

namespace AutoService.Api.Controllers;

/// <summary>
/// Контроллер для аналитических запросов.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ReportsController : ControllerBase
{
    /// <summary>
    /// 1. Получить механиков, специализирующихся на выбранном виде работ.
    /// </summary>
    /// <param name="workName">Название работы (например, "Диагностика ходовой").</param>
    [HttpGet("mechanics-by-work")]
    public IActionResult GetMechanicsByWork([FromQuery] string workName)
    {
        var work = DataSeed.Works.FirstOrDefault(w => w.Name == workName);
        if (work == null) return NotFound("Работа не найдена");

        var mechanics = DataSeed.Mechanics
            .Where(m => m.Specialization.ToString() == work.Category)
            .ToList();

        return Ok(mechanics);
    }

    /// <summary>
    /// 2. Получить клиентов указанного механика, упорядоченных по ФИО.
    /// </summary>
    /// <param name="mechanicId">Идентификатор механика.</param>
    [HttpGet("clients-by-mechanic/{mechanicId}")]
    public IActionResult GetClientsByMechanic(Guid mechanicId)
    {
        var mechanic = DataSeed.Mechanics.FirstOrDefault(m => m.Id == mechanicId);
        if (mechanic == null) return NotFound("Механик не найден");

        var clients = DataSeed.Clients
            .Where(c => DataSeed.Orders.Any(o => o.ClientId == c.Id && o.MechanicId == mechanic.Id))
            .OrderBy(c => c.FullName)
            .ToList();

        return Ok(clients);
    }

    /// <summary>
    /// 3. Получить клиентов с повторными обращениями за последний месяц.
    /// </summary>
    [HttpGet("repeat-clients")]
    public IActionResult GetRepeatClients()
    {
        var monthAgo = new DateTime(2026, 10, 12, 0, 0, 0, DateTimeKind.Utc).AddDays(-30);

        var grouped = DataSeed.Orders
            .Where(o => o.AcceptedAt >= monthAgo)
            .GroupBy(o => o.ClientId)
            .Where(g => g.Count() > 1)
            .Select(g => DataSeed.Clients.First(c => c.Id == g.Key))
            .ToList();

        return Ok(grouped);
    }

    /// <summary>
    /// 4. Подсчитать суммарную стоимость работ для выбранного заказа.
    /// </summary>
    /// <param name="orderId">Идентификатор заказа.</param>
    [HttpGet("order-total/{orderId}")]
    public IActionResult GetOrderTotalCost(Guid orderId)
    {
        var order = DataSeed.Orders.FirstOrDefault(o => o.Id == orderId);
        if (order == null) return NotFound("Заказ не найден");

        var total = order.Works.Sum(w => w.Price);
        return Ok(new { OrderId = order.Id, TotalCost = total });
    }

    /// <summary>
    /// 5. Получить топ 5 наиболее частых видов работ.
    /// </summary>
    [HttpGet("top-5-works")]
    public IActionResult GetTop5Works()
    {
        var top = DataSeed.Orders
            .SelectMany(o => o.Works)
            .GroupBy(w => w.Name)
            .Select(g => new { Name = g.Key, Count = g.Count() })
            .OrderByDescending(x => x.Count)
            .ThenBy(x => x.Name)
            .Take(5)
            .ToList();

        return Ok(top);
    }
}