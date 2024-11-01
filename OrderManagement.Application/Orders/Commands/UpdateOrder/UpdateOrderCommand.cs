using MediatR;
using OrderManagement.Domain;

namespace OrderManagement.Application.Orders.Commands.UpdateOrder;

public class UpdateOrderCommand : IRequest
{
    public required string CustomerName { get; set; }
    public required DateOnly OrderDate { get; set; }
    public required decimal TotalAmount { get; set; }
    public required CurrencyOrder Currency { get; set; }
    public required StatusOrder Status { get; set; }
    public required int Priority { get; set; }
    public required decimal TotalAmountInBaseCurrency { get; set; }
}