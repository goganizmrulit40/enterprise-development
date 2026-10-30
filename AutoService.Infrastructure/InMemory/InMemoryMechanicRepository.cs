using AutoService.Domain.Data;
using AutoService.Domain.Interfaces;
using AutoService.Domain.Models;

namespace AutoService.Infrastructure.InMemory;

public class InMemoryMechanicRepository : IMechanicRepository
{
    public Task<IEnumerable<Mechanic>> GetAllAsync() => Task.FromResult(DataSeed.Mechanics.AsEnumerable());

    public Task<Mechanic?> GetByIdAsync(Guid id) => Task.FromResult(DataSeed.Mechanics.FirstOrDefault(m => m.Id == id));

    public Task AddAsync(Mechanic mechanic)
    {
        DataSeed.Mechanics.Add(mechanic);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Mechanic mechanic) => Task.CompletedTask;

    public Task DeleteAsync(Mechanic mechanic)
    {
        DataSeed.Mechanics.Remove(mechanic);
        return Task.CompletedTask;
    }
}