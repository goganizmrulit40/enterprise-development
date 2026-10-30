using AutoService.Domain.Data;
using AutoService.Domain.Interfaces;
using AutoService.Domain.Models;

namespace AutoService.Infrastructure.InMemory;

public class InMemoryCarRepository : ICarRepository
{
    public Task<IEnumerable<Car>> GetAllAsync() => Task.FromResult(DataSeed.Cars.AsEnumerable());

    public Task<Car?> GetByIdAsync(Guid id) => Task.FromResult(DataSeed.Cars.FirstOrDefault(c => c.Id == id));

    public Task AddAsync(Car car)
    {
        DataSeed.Cars.Add(car);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Car car) => Task.CompletedTask;
    public Task DeleteAsync(Car car)
    {
        DataSeed.Cars.Remove(car);
        return Task.CompletedTask;
    }
}