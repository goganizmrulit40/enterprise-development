using AutoService.Domain.Models;

namespace AutoService.Domain.Interfaces;

public interface IOrderRepository
{
    public Task<IEnumerable<Order>> GetAllAsync();
    public Task<Order?> GetByIdAsync(Guid id);
    public Task AddAsync(Order order);
    public Task UpdateAsync(Order order);
    public Task DeleteAsync(Order order);
}