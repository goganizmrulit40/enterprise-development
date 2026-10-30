using AutoService.Domain.Data;
using AutoService.Domain.Interfaces;
using AutoService.Domain.Models;

namespace AutoService.Infrastructure.InMemory;

/// <summary>
/// Реализация репозитория клиентов в памяти.
/// </summary>
public class InMemoryClientRepository : IClientRepository
{
    /// <summary>
    /// Получить список всех клиентов.
    /// </summary>
    public Task<IEnumerable<Client>> GetAllAsync() => Task.FromResult(DataSeed.Clients.AsEnumerable());

    /// <summary>
    /// Получить клиента по идентификатору.
    /// </summary>
    public Task<Client?> GetByIdAsync(Guid id) => Task.FromResult(DataSeed.Clients.FirstOrDefault(c => c.Id == id));

    /// <summary>
    /// Добавить клиента.
    /// </summary>
    public Task AddAsync(Client client)
    {
        DataSeed.Clients.Add(client);
        return Task.CompletedTask;
    }

    /// <summary>
    /// Обновить данные клиента.
    /// </summary>
    public Task UpdateAsync(Client client) => Task.CompletedTask;

    /// <summary>
    /// Удалить клиента.
    /// </summary>
    public Task DeleteAsync(Client client)
    {
        DataSeed.Clients.Remove(client);
        return Task.CompletedTask;
    }
}