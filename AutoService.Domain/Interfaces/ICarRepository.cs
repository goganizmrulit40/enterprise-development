using AutoService.Domain.Models;

namespace AutoService.Domain.Interfaces;

public interface ICarRepository
{
    public Task<IEnumerable<Car>> GetAllAsync();
    public Task<Car?> GetByIdAsync(Guid id);
    public Task AddAsync(Car car);
    public Task UpdateAsync(Car car);
    public Task DeleteAsync(Car car);
}