using AutoService.Domain.Data;
using AutoService.Domain.Interfaces;
using AutoService.Domain.Models;

namespace AutoService.Infrastructure.InMemory;

/// <summary>
/// Реализация репозитория автомобилей в памяти.
/// </summary>
public class InMemoryCarRepository : ICarRepository
{
    /// <summary>
    /// Получить список всех автомобилей.
    /// </summary>
    public Task<IEnumerable<Car>> GetAllAsync() => Task.FromResult(DataSeed.Cars.AsEnumerable());

    /// <summary>
    /// Получить автомобиль по идентификатору.
    /// </summary>
    public Task<Car?> GetByIdAsync(Guid id) => Task.FromResult(DataSeed.Cars.FirstOrDefault(c => c.Id == id));

    /// <summary>
    /// Добавить автомобиль.
    /// </summary>
    public Task AddAsync(Car car)
    {
        DataSeed.Cars.Add(car);
        return Task.CompletedTask;
    }

    /// <summary>
    /// Обновить данные автомобиля.
    /// </summary>
    public Task UpdateAsync(Car car) => Task.CompletedTask;

    /// <summary>
    /// Удалить автомобиль.
    /// </summary>
    public Task DeleteAsync(Car car)
    {
        DataSeed.Cars.Remove(car);
        return Task.CompletedTask;
    }
}