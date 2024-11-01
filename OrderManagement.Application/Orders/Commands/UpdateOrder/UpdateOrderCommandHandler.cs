using MediatR;
using OrderManagement.Application.Common.Repositories.Interfaces;
using OrderManagement.Domain;

namespace OrderManagement.Application.Orders.Commands.UpdateOrder;

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
{
    private readonly IOrderRepository _repository;
    
    public UpdateOrderCommandHandler(IOrderRepository repository) => 
        _repository = repository;
    
    public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Order
        {
            CustomerName = request.CustomerName,
            OrderDate = request.OrderDate,
            TotalAmount = request.TotalAmount,
            Currency = request.Currency,
            Status = request.Status,
            Priority = request.Priority,
            TotalAmountInBaseCurrency = request.TotalAmountInBaseCurrency
        };
        
        await _repository.UpdateAsync(order, cancellationToken);
    }
}