using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain;
using OrderManagement.Application.Interfaces;
using OrderManagement.Application.Common.Exceptions;

namespace OrderManagement.Persistence.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly OrderManagementDbContext _context;
    public OrderRepository(OrderManagementDbContext context) =>
        _context = context;
    
    public async Task<Order> GetByIdAsync(int id, CancellationToken cancellationToken) => 
        await _context.Orders.SingleOrDefaultAsync(order => order.Id == id, cancellationToken: cancellationToken) ??
                                                            throw new NotFoundException(nameof(Order), id);
    public async Task<int> AddAsync(Order order, CancellationToken cancellationToken)
    {
        await _context.AddAsync(order, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        
        return order.Id;    
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var order = await GetByIdAsync(id, cancellationToken);

        _context.Remove(order);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateStatusByIdAsync(int id, StatusOrder status, CancellationToken cancellationToken)
    {
        var order = await GetByIdAsync(id, cancellationToken);
        
        order.Status = status;
        await _context.SaveChangesAsync(cancellationToken);
    }

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