using AutoService.Domain.Data;
using AutoService.Domain.Interfaces;
using AutoService.Domain.Models;

namespace AutoService.Infrastructure.InMemory;

/// <summary>
/// Реализация репозитория механиков в памяти.
/// </summary>
public class InMemoryMechanicRepository : IMechanicRepository
{
    /// <summary>
    /// Получить список всех механиков.
    /// </summary>
    public Task<IEnumerable<Mechanic>> GetAllAsync() => Task.FromResult(DataSeed.Mechanics.AsEnumerable());

    /// <summary>
    /// Получить механика по идентификатору.
    /// </summary>
    public Task<Mechanic?> GetByIdAsync(Guid id) => Task.FromResult(DataSeed.Mechanics.FirstOrDefault(m => m.Id == id));

    /// <summary>
    /// Добавить механика.
    /// </summary>
    public Task AddAsync(Mechanic mechanic)
    {
        DataSeed.Mechanics.Add(mechanic);
        return Task.CompletedTask;
    }

    /// <summary>
    /// Обновить данные механика.
    /// </summary>
    public Task UpdateAsync(Mechanic mechanic) => Task.CompletedTask;

    /// <summary>
    /// Удалить механика.
    /// </summary>
    public Task DeleteAsync(Mechanic mechanic)
    {
        DataSeed.Mechanics.Remove(mechanic);
        return Task.CompletedTask;
    }
}