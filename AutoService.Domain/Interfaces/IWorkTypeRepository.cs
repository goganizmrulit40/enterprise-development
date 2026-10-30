using AutoService.Domain.Models;

namespace AutoService.Domain.Interfaces;

public interface IWorkTypeRepository
{
    public Task<IEnumerable<WorkType>> GetAllAsync();
    public Task<WorkType?> GetByIdAsync(Guid id);
    public Task AddAsync(WorkType workType);
    public Task UpdateAsync(WorkType workType);
    public Task DeleteAsync(WorkType workType);
}