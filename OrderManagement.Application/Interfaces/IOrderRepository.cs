using OrderManagement.Domain;

namespace OrderManagement.Application.Interfaces;

public interface IOrderRepository
{
    Task<int> AddAsync(Order order, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    Task UpdateStatusOrderAsync(int id, StatusOrder status, CancellationToken cancellationToken = default);
    Task UpdateStatusAllOrderAsync(StatusOrder status);
}