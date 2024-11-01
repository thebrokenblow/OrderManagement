using Hangfire;
using MediatR;
using OrderManagement.Application.Common.Repositories.Interfaces;
using OrderManagement.Application.Common.Services.Interfaces;
using OrderManagement.Domain;

namespace OrderManagement.Application.Orders.Commands.UpdateStatusOrderBackground;

public class UpdateStatusOrderBackgroundCommandHandler : IRequestHandler<UpdateStatusOrderBackgroundCommand>
{
    private readonly IOrderRepository _repository;
    private readonly ICurrencyConversion _currencyConversion;
    private readonly IFileRepository _fileRepository;

    public UpdateStatusOrderBackgroundCommandHandler(
        IOrderRepository repository, 
        ICurrencyConversion currencyConversion,
        IFileRepository fileRepository)
    {
        _repository = repository;
        _currencyConversion = currencyConversion;
        _fileRepository = fileRepository;
    }

    public async Task Handle(UpdateStatusOrderBackgroundCommand request, CancellationToken cancellationToken)
    {
        RecurringJob.AddOrUpdate(
            "ChangeStatusOrderInProcess", 
            () =>  ChangeStatus(cancellationToken),
            "*/5 * * * *");
        
        await ChangeStatus(cancellationToken);
    }

    public async Task ChangeStatus(CancellationToken cancellationToken)
    {
        var orders = await _repository.GetOrdersAsync(cancellationToken);
        
        foreach (var order in orders.Where(order => order.Status == StatusOrder.Pending))
        {
            if (order.Currency == CurrencyOrder.USD)
            {
                await _repository.UpdateStatusAsync(order, StatusOrder.Completed, cancellationToken);
                continue;
            }
            
            var responseCurrencyConversion = await _currencyConversion.GetCurrencyConversionAsync(
                order.Currency, 
                cancellationToken);
            
            var valueCurrency = responseCurrencyConversion.ConversionRates[CurrencyOrder.USD.ToString()]; 
            await _repository.UpdateStatusAsync(order, StatusOrder.Processing, cancellationToken);

            var totalAmountBaseCurrency = order.TotalAmount * valueCurrency;
            
            await _repository.UpdateTotalAmountBaseCurrencyAsync(order, totalAmountBaseCurrency, cancellationToken);
            await _repository.UpdateStatusAsync(order, StatusOrder.Completed, cancellationToken);

            await _fileRepository.WriteAsync(order.ToString(), cancellationToken);
        }
    }
}