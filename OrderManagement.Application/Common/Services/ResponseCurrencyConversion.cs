using System.Text.Json.Serialization;

namespace OrderManagement.Application.Common.Services;

public class ResponseCurrencyConversion
{
    [JsonPropertyName("conversion_rates")]
    public required Dictionary<string, decimal> ConversionRates { get; init; }
}