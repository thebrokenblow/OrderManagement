using MediatR;
using OrderManagement.Domain;

namespace OrderManagement.Application.Orders.Commands.UpdateStatusOrder;

public class UpdateStatusOrderCommand : IRequest
{
    public int Id { get; set; }
    public StatusOrder Status { get; set; }
}