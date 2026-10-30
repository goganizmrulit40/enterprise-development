using AutoService.Domain.Models;

namespace AutoService.Domain.Interfaces;

public interface IClientRepository
{
    public Task<IEnumerable<Client>> GetAllAsync();
    public Task<Client?> GetByIdAsync(Guid id);
    public Task AddAsync(Client client);
    public Task UpdateAsync(Client client);
    public Task DeleteAsync(Client client);
}