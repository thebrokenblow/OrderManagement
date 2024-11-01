using MediatR;
using OrderManagement.Domain;

namespace OrderManagement.Application.Orders.Commands.CreateOrder;

public class CreateOrderCommand : IRequest<int>
{
    public required string CustomerName { get; init; }
    public required decimal TotalAmount { get; init; }
    public required CurrencyOrder Currency { get; init; }
    public required int Priority { get; init; }
}