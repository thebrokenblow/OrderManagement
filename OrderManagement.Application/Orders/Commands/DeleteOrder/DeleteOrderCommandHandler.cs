using MediatR;
using OrderManagement.Application.Common.Repositories.Interfaces;

namespace OrderManagement.Application.Orders.Commands.DeleteOrder;

public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
{
    private readonly IOrderRepository _repository;
    
    public DeleteOrderCommandHandler(IOrderRepository repository) =>
        _repository = repository;

    public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken) =>
        await _repository.DeleteAsync(request.Id, cancellationToken);
}