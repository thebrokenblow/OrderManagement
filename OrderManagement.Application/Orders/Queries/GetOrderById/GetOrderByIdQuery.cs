using MediatR;
using OrderManagement.Domain;

namespace OrderManagement.Application.Orders.Queries.GetOrderById;

public class GetOrderByIdQuery : IRequest<Order>
{
    public int Id { get; set; }
}