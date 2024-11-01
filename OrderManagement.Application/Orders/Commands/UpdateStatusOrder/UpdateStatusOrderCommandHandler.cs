using MediatR;
using OrderManagement.Application.Interfaces;

namespace OrderManagement.Application.Orders.Commands.UpdateStatusOrder;

public class UpdateStatusOrderCommandHandler : IRequestHandler<UpdateStatusOrderCommand>
{
    private readonly IOrderRepository _repository;

    public UpdateStatusOrderCommandHandler(IOrderRepository repository) =>
        _repository = repository;
    
    public async Task Handle(UpdateStatusOrderCommand request, CancellationToken cancellationToken) =>
        await _repository.UpdateStatusByIdAsync(request.Id, request.Status, cancellationToken);
}