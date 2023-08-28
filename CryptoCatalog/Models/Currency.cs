using System.Collections.Generic;

namespace CryptoCatalog.Models
{
    public record Currency(
         string Rank,
         string Symbol,
         string Name,
         string PriceUsd
    );

    public record CurrencyResponse(
        IReadOnlyList<Currency> data
    );
}
