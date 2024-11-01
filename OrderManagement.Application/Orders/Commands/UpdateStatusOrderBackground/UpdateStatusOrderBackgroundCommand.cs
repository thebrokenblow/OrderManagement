using MediatR;
using OrderManagement.Domain;

namespace OrderManagement.Application.Orders.Commands.UpdateStatusOrderBackground;

public class UpdateStatusOrderBackgroundCommand : IRequest
{
    public StatusOrder Status { get; set; }
}