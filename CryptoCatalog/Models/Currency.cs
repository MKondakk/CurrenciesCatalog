using System.Collections.Generic;

namespace CryptoCatalog.Models
{
    public record BaseCurrency(
         string id,
         string symbol,
         string name
    );

    public record Currency(
         string id,
         string rank,
         string symbol,
         string name,
         string supply,
         string maxSupply,
         string marketCapUsd,
         double volumeUsd24Hr,
         double priceUsd,
         double changePercent24Hr,
         string vwap24Hr
    ) : BaseCurrency(id, symbol, name);

    public record CurrencyResponse(
        IReadOnlyList<Currency> data
    );
}
