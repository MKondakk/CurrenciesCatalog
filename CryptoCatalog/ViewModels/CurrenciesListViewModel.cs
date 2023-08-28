using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Json;
using CryptoCatalog.Models;

namespace CryptoCatalog.ViewModels
{
    /// <summary>
    /// Currencies List Page ViewModel
    /// </summary>
    internal class CurrenciesListViewModel
    {

        public ObservableCollection<Currency> Currencies { get; set; }

        public CurrenciesListViewModel()
        {
            Currencies = new ObservableCollection<Currency>();

            // TODO: move from ctor
            FetchCurrencies();
        }

        private async void FetchCurrencies()
        {
            var client = new HttpClient(

            )
            { BaseAddress = new Uri("https://api.coincap.io") };

            var response = await client.GetFromJsonAsync<CurrencyResponse>("v2/assets?limit=10");

            if (response == null) { return; }

            foreach (var item in response.data)
            {
                Currencies.Add(item);
            }
        }

    }
}
