using AutoService.Domain.Data;
using AutoService.Domain.Interfaces;
using AutoService.Domain.Models;

namespace AutoService.Infrastructure.InMemory;

public class InMemoryOrderRepository : IOrderRepository
{
    public Task<IEnumerable<Order>> GetAllAsync() => Task.FromResult(DataSeed.Orders.AsEnumerable());

    public Task<Order?> GetByIdAsync(Guid id) => Task.FromResult(DataSeed.Orders.FirstOrDefault(o => o.Id == id));

    public Task AddAsync(Order order)
    {
        DataSeed.Orders.Add(order);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Order order) => Task.CompletedTask;

    public Task DeleteAsync(Order order)
    {
        DataSeed.Orders.Remove(order);
        return Task.CompletedTask;
    }
}