using OrderManagement.Domain;

namespace OrderManagement.Application.Common.Services.Interfaces;

public interface ICurrencyConversion
{
    Task<ResponseCurrencyConversion> GetCurrencyConversionAsync(CurrencyOrder currencyOrder,
        CancellationToken cancellationToken);
}