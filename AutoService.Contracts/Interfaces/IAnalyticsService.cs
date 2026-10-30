namespace AutoService.Contracts.Interfaces;

/// <summary>
/// Сервис для аналитических запросов.
/// </summary>
public interface IAnalyticsService
{
    public Task<IEnumerable<object>> GetMechanicsByWorkAsync(string workName);
    public Task<IEnumerable<object>> GetClientsByMechanicAsync(Guid mechanicId);
    public Task<IEnumerable<object>> GetRepeatClientsAsync();
    public Task<decimal> GetOrderTotalCostAsync(Guid orderId);
    public Task<IEnumerable<object>> GetTop5WorksAsync();
}