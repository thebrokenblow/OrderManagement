using System.Text.Json;
using OrderManagement.Application.Common.Services.Interfaces;
using OrderManagement.Domain;

namespace OrderManagement.Application.Common.Services;

public class CurrencyConversion : ICurrencyConversion
{
    private readonly HttpClient _httpClient = new();
    private const string ApiKey = "5a84aaf63c6ac3aef7a5a3b3";
    private const string HttpPath = $"https://v6.exchangerate-api.com/v6/{ApiKey}/latest/";
    
    public async Task<ResponseCurrencyConversion> GetCurrencyConversionAsync(CurrencyOrder currencyOrder, CancellationToken cancellationToken)
    {
        using var httpResponse = await _httpClient.GetAsync(
            $"{HttpPath}/{currencyOrder.ToString()}", 
            cancellationToken);

        httpResponse.EnsureSuccessStatusCode();
        
        var responseContent = await httpResponse.Content.ReadAsStringAsync(cancellationToken);
        var exchangeRateApiResponse = JsonSerializer.Deserialize<ResponseCurrencyConversion>(responseContent) ?? 
                                      throw new Exception();

        return exchangeRateApiResponse;
    }
}