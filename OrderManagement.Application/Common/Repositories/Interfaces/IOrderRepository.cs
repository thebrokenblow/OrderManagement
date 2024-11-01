using OrderManagement.Domain;

namespace OrderManagement.Application.Common.Repositories.Interfaces;

public interface IOrderRepository
{
    Task<Order> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<List<Order>> GetRangeAsync(int countSkip, int countTake, CancellationToken cancellationToken = default);
    Task<int> AddAsync(Order order, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    Task UpdateAsync(Order updatedOrder, CancellationToken cancellationToken = default);
    Task UpdateStatusByIdAsync(int id, StatusOrder status, CancellationToken cancellationToken = default);
    Task UpdateStatusAsync(Order order, StatusOrder status, CancellationToken cancellationToken = default);
    Task<List<Order>> GetOrdersAsync(CancellationToken cancellationToken = default);
    Task UpdateTotalAmountBaseCurrencyAsync(Order order, decimal totalAmountBaseCurrency, CancellationToken cancellationToken = default);
}