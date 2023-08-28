using System.Collections.Generic;

namespace CryptoCatalog.Models
{
    public record Currency(
 string rank,
 string symbol,
 string name,
 string priceUsd
);

    public record CurrencyResponse(
 IReadOnlyList<Currency> data
 );
}
