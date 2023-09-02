using System.Collections.Generic;

namespace CryptoCatalog.Models
{
    public record SearchCurrencyAssets(
 IReadOnlyList<SearchCurrencyEdge> edges
    );

    public record SearchCurrencyData(
 SearchCurrencyAssets assets
    );

    public record SearchCurrencyEdge(
 SearchCurrency node
    );

    public record SearchCurrency(
 string id,
 string name,
 string symbol
    );

    public record SearchCurrencyResponse(
 SearchCurrencyData data
    );
}
