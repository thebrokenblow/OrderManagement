using MediatR;
using OrderManagement.Domain;

namespace OrderManagement.Application.Orders.Queries.GetOrderRange;

public class GetProductRangeQuery : IRequest<List<Order>>
{
    public int CountSkip { get; set; }
    public int CountTake { get; set; }
}