using AutoService.Domain.Data;
using AutoService.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoService.Api.Controllers;

/// <summary>
/// Контроллер для управления заказами.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    /// <summary>
    /// Получить список всех заказов.
    /// </summary>
    [HttpGet]
    public ActionResult<IEnumerable<Order>> GetAll()
    {
        return Ok(DataSeed.Orders);
    }

    /// <summary>
    /// Получить заказ по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор заказа.</param>
    [HttpGet("{id}")]
    public ActionResult<Order> GetById(Guid id)
    {
        var order = DataSeed.Orders.FirstOrDefault(o => o.Id == id);
        if (order == null) return NotFound();
        return Ok(order);
    }

    /// <summary>
    /// Добавить новый заказ.
    /// </summary>
    /// <param name="newOrder">Данные нового заказа.</param>
    [HttpPost]
    public ActionResult<Order> Create([FromBody] Order newOrder)
    {
        DataSeed.Orders.Add(newOrder);
        return CreatedAtAction(nameof(GetById), new { id = newOrder.Id }, newOrder);
    }

    /// <summary>
    /// Обновить данные заказа.
    /// </summary>
    /// <param name="id">Идентификатор заказа.</param>
    /// <param name="updatedOrder">Новые данные заказа.</param>
    [HttpPut("{id}")]
    public IActionResult Update(Guid id, [FromBody] Order updatedOrder)
    {
        var order = DataSeed.Orders.FirstOrDefault(o => o.Id == id);
        if (order == null) return NotFound();

        order.CarId = updatedOrder.CarId;
        order.ClientId = updatedOrder.ClientId;
        order.MechanicId = updatedOrder.MechanicId;
        order.Works = updatedOrder.Works;
        order.AcceptedAt = updatedOrder.AcceptedAt;
        order.IssuedAt = updatedOrder.IssuedAt;

        return NoContent();
    }

    /// <summary>
    /// Удалить заказ по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор заказа.</param>
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var order = DataSeed.Orders.FirstOrDefault(o => o.Id == id);
        if (order == null) return NotFound();

        DataSeed.Orders.Remove(order);
        return NoContent();
    }
}