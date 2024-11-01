using MediatR;
using OrderManagement.Application.Interfaces;
using OrderManagement.Domain;

namespace OrderManagement.Application.Orders.Commands.CreateOrder;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
{
    private readonly IOrderRepository _repository;

    public CreateOrderCommandHandler(IOrderRepository repository) =>
        _repository = repository;
    
    public Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Order
        {
            CustomerName = request.CustomerName,
            OrderDate = DateOnly.FromDateTime(DateTime.UtcNow),
            TotalAmount = request.TotalAmount,
            Currency = request.Currency,
            Status = StatusOrder.Pending,
            Priority = request.Priority,
            TotalAmountInBaseCurrency = null,
        };

        if (request.Currency == CurrencyOrder.USD)
        {
            order.TotalAmountInBaseCurrency = request.TotalAmount;
        }
        
        return _repository.AddAsync(order, cancellationToken);
    }
}