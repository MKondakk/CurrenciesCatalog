using System.Collections.Generic;

namespace CryptoCatalog.Models
{
    public record Currency(
         string id,       
         string rank,
         string symbol,
         string name,
         string supply,
         string maxSupply,
         string marketCapUsd,
         string volumeUsd24Hr,
         double priceUsd,
         string changePercent24Hr,
         string vwap24Hr
    );

    public record CurrencyResponse(
        IReadOnlyList<Currency> data
    );
}
