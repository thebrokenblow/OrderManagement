using MediatR;
using OrderManagement.Application.Common.Repositories.Interfaces;
using OrderManagement.Domain;

namespace OrderManagement.Application.Orders.Queries.GetOrderRange;

public class GetProductRangeQueryHandler : IRequestHandler<GetProductRangeQuery, List<Order>>
{
    private readonly IOrderRepository _repository;

    public GetProductRangeQueryHandler(IOrderRepository repository) =>
        _repository = repository;
        
    public async Task<List<Order>> Handle(GetProductRangeQuery request, CancellationToken cancellationToken) =>
        await _repository.GetRangeAsync(request.CountSkip, request.CountTake, cancellationToken);
}