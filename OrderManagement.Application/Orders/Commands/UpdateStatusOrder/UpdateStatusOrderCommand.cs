using MediatR;
using OrderManagement.Domain;

namespace OrderManagement.Application.Orders.Commands.UpdateStatusOrder;

public class UpdateStatusOrderCommand : IRequest
{
    public int Id { get; init; }
    public StatusOrder Status { get; init; }
}