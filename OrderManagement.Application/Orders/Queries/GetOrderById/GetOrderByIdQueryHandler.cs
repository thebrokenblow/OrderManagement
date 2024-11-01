using MediatR;
using OrderManagement.Application.Common.Repositories.Interfaces;
using OrderManagement.Domain;

namespace OrderManagement.Application.Orders.Queries.GetOrderById;

public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Order>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrderByIdQueryHandler(IOrderRepository repository) =>
        _orderRepository = repository;
    
    public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken) =>
        await _orderRepository.GetByIdAsync(request.Id, cancellationToken);
}