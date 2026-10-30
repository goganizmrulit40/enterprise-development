using AutoService.Domain.Data;
using AutoService.Domain.Interfaces;
using AutoService.Domain.Models;

namespace AutoService.Infrastructure.InMemory;

public class InMemoryClientRepository : IClientRepository
{
    public Task<IEnumerable<Client>> GetAllAsync() => Task.FromResult(DataSeed.Clients.AsEnumerable());

    public Task<Client?> GetByIdAsync(Guid id) => Task.FromResult(DataSeed.Clients.FirstOrDefault(c => c.Id == id));

    public Task AddAsync(Client client)
    {
        DataSeed.Clients.Add(client);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Client client) => Task.CompletedTask;

    public Task DeleteAsync(Client client)
    {
        DataSeed.Clients.Remove(client);
        return Task.CompletedTask;
    }
}