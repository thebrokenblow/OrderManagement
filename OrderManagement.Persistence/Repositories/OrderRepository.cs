using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain;
using OrderManagement.Application.Common.Exceptions;
using OrderManagement.Application.Common.Repositories.Interfaces;

namespace OrderManagement.Persistence.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly OrderManagementDbContext _context;
    public OrderRepository(OrderManagementDbContext context) =>
        _context = context;

    public async Task<List<Order>> GetRangeAsync(int countSkip, int countTake, CancellationToken cancellationToken) =>
        await _context.Orders
            .Skip(countSkip)
            .Take(countTake)
            .ToListAsync(cancellationToken);

    public async Task<Order> GetByIdAsync(int id, CancellationToken cancellationToken) => 
        await _context.Orders.SingleOrDefaultAsync(order => order.Id == id, cancellationToken: cancellationToken) ??
                                                            throw new NotFoundException(nameof(Order), id);
    public async Task<int> AddAsync(Order order, CancellationToken cancellationToken)
    {
        await _context.AddAsync(order, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        
        return order.Id;    
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken) =>
        await _context.Orders
            .Where(order => order.Id == id)
            .ExecuteDeleteAsync(cancellationToken);
    
    public async Task UpdateAsync(Order updatedOrder, CancellationToken cancellationToken = default) =>
        await _context.Orders.Where(order => order.Id == updatedOrder.Id)
            .ExecuteUpdateAsync(s => s
                    .SetProperty(order => order.CustomerName, updatedOrder.CustomerName)
                    .SetProperty(order => order.OrderDate, updatedOrder.OrderDate)
                    .SetProperty(order => order.TotalAmount, updatedOrder.TotalAmount)
                    .SetProperty(order => order.Currency, updatedOrder.Currency)
                    .SetProperty(order => order.Status, updatedOrder.Status)
                    .SetProperty(order => order.Priority, updatedOrder.Priority)
                    .SetProperty(order => order.TotalAmountInBaseCurrency, updatedOrder.TotalAmountInBaseCurrency), 
                cancellationToken);

    public async Task UpdateStatusByIdAsync(int id, StatusOrder status, CancellationToken cancellationToken) =>
        await _context.Orders
            .Where(order => order.Id == id)
            .ExecuteUpdateAsync(s => s
                    .SetProperty(order => order.Status, status),
                cancellationToken);

    public async Task UpdateStatusAsync(Order order, StatusOrder status, CancellationToken cancellationToken = default)
    {
        order.Status = status;
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<Order>> GetOrdersAsync(CancellationToken cancellationToken) =>
        await _context.Orders.ToListAsync(cancellationToken);

    public async Task UpdateTotalAmountBaseCurrencyAsync(Order order, decimal totalAmountBaseCurrency,
        CancellationToken cancellationToken = default)
    {
        order.TotalAmountInBaseCurrency = totalAmountBaseCurrency;
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<Order>> GetOrdersAsync() => 
        await _context.Orders.ToListAsync();
}