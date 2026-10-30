using AutoService.Domain.Data;
using AutoService.Domain.Interfaces;
using AutoService.Domain.Models;

namespace AutoService.Infrastructure.InMemory;

/// <summary>
/// Реализация репозитория видов работ в памяти.
/// </summary>
public class InMemoryWorkTypeRepository : IWorkTypeRepository
{
    /// <summary>
    /// Получить список всех видов работ.
    /// </summary>
    public Task<IEnumerable<WorkType>> GetAllAsync() => Task.FromResult(DataSeed.Works.AsEnumerable());

    /// <summary>
    /// Получить вид работ по идентификатору.
    /// </summary>
    public Task<WorkType?> GetByIdAsync(Guid id) => Task.FromResult(DataSeed.Works.FirstOrDefault(w => w.Id == id));

    /// <summary>
    /// Добавить вид работ.
    /// </summary>
    public Task AddAsync(WorkType workType)
    {
        DataSeed.Works.Add(workType);
        return Task.CompletedTask;
    }

    /// <summary>
    /// Обновить данные вида работ.
    /// </summary>
    public Task UpdateAsync(WorkType workType) => Task.CompletedTask;

    /// <summary>
    /// Удалить вид работ.
    /// </summary>
    public Task DeleteAsync(WorkType workType)
    {
        DataSeed.Works.Remove(workType);
        return Task.CompletedTask;
    }
}