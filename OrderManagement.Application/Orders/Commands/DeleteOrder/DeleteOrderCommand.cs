using MediatR;

namespace OrderManagement.Application.Orders.Commands.DeleteOrder;

public class DeleteOrderCommand : IRequest
{
    public required int Id { get; set; }
}