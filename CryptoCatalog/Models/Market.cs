using System.Collections.Generic;

namespace CryptoCatalog.Models
{
    public record Market(
        string exchangeId,
        double volumeUsd24Hr,
        double priceUsd,
        double volumePercent
    );

    public record MarketResponse(
        IReadOnlyList<Market> data
    );
}

