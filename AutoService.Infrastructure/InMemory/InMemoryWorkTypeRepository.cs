using AutoService.Domain.Data;
using AutoService.Domain.Interfaces;
using AutoService.Domain.Models;

namespace AutoService.Infrastructure.InMemory;

public class InMemoryWorkTypeRepository : IWorkTypeRepository
{
    public Task<IEnumerable<WorkType>> GetAllAsync() => Task.FromResult(DataSeed.Works.AsEnumerable());

    public Task<WorkType?> GetByIdAsync(Guid id) => Task.FromResult(DataSeed.Works.FirstOrDefault(w => w.Id == id));

    public Task AddAsync(WorkType workType)
    {
        DataSeed.Works.Add(workType);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(WorkType workType) => Task.CompletedTask;

    public Task DeleteAsync(WorkType workType)
    {
        DataSeed.Works.Remove(workType);
        return Task.CompletedTask;
    }
}