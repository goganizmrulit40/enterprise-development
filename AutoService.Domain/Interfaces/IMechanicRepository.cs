using AutoService.Domain.Models;

namespace AutoService.Domain.Interfaces;

public interface IMechanicRepository
{
    public Task<IEnumerable<Mechanic>> GetAllAsync();
    public Task<Mechanic?> GetByIdAsync(Guid id);
    public Task AddAsync(Mechanic mechanic);
    public Task UpdateAsync(Mechanic mechanic);
    public Task DeleteAsync(Mechanic mechanic);
}