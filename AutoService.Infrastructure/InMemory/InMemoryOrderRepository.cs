using AutoService.Domain.Data;
using AutoService.Domain.Interfaces;
using AutoService.Domain.Models;

namespace AutoService.Infrastructure.InMemory;

/// <summary>
/// Реализация репозитория заказов в памяти.
/// </summary>
public class InMemoryOrderRepository : IOrderRepository
{
    /// <summary>
    /// Получить список всех заказов.
    /// </summary>
    public Task<IEnumerable<Order>> GetAllAsync() => Task.FromResult(DataSeed.Orders.AsEnumerable());

    /// <summary>
    /// Получить заказ по идентификатору.
    /// </summary>
    public Task<Order?> GetByIdAsync(Guid id) => Task.FromResult(DataSeed.Orders.FirstOrDefault(o => o.Id == id));

    /// <summary>
    /// Добавить заказ.
    /// </summary>
    public Task AddAsync(Order order)
    {
        DataSeed.Orders.Add(order);
        return Task.CompletedTask;
    }

    /// <summary>
    /// Обновить данные заказа.
    /// </summary>
    public Task UpdateAsync(Order order) => Task.CompletedTask;

    /// <summary>
    /// Удалить заказ.
    /// </summary>
    public Task DeleteAsync(Order order)
    {
        DataSeed.Orders.Remove(order);
        return Task.CompletedTask;
    }
}