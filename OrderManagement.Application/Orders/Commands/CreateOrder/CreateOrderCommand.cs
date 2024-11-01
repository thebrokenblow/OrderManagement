using MediatR;
using OrderManagement.Domain;

namespace OrderManagement.Application.Orders.Commands.CreateOrder;

public class CreateOrderCommand : IRequest<int>
{
    public required string CustomerName { get; set; }
    public required decimal TotalAmount { get; set; }
    public required CurrencyOrder Currency { get; set; }
    public required int Priority { get; set; }
}