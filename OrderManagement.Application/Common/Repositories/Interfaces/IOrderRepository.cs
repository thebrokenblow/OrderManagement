using OrderManagement.Domain;

namespace OrderManagement.Application.Interfaces;

public interface IOrderRepository
{
    Task<int> AddAsync(Order order, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    Task UpdateStatusByIdAsync(int id, StatusOrder status, CancellationToken cancellationToken = default);
    Task UpdateStatusAsync(Order order, StatusOrder status, CancellationToken cancellationToken = default);
    Task<List<Order>> GetOrdersAsync(CancellationToken cancellationToken = default);
    Task UpdateTotalAmountBaseCurrencyAsync(Order order, decimal totalAmountBaseCurrency, CancellationToken cancellationToken = default);
}