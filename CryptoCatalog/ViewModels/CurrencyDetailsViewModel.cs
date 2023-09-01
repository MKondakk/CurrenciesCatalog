using CryptoCatalog.Models;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Json;



namespace CryptoCatalog.ViewModels
{
    /// <summary>
    /// Currency Details Page ViewModel
    /// </summary>
    public class CurrencyDetailsViewModel : ViewModelBase
    {
        private Currency _currency;

        public Currency Currency
        {
            get => _currency;
            set
            {
                _currency = value;
                FetchMarkets(Currency.id);
                OnPropertyChanged(nameof(Currency));
            }
        }
        public ObservableCollection<Market> Markets { get; set; }
        public CurrencyDetailsViewModel()
        {
            Markets = new ObservableCollection<Market>();
        }
        private async void FetchMarkets(string currencyId)
        {
            Markets.Clear();
            var client = new HttpClient()
            {
                BaseAddress = new Uri("https://api.coincap.io")
            };

            var response = await client.GetAsync($"v2/assets/{currencyId}/markets?limit=7");
            var result = await response.Content.ReadFromJsonAsync<MarketResponse>();

            if (result == null) { return; }


            foreach (var market in result.data)
            {
                Markets.Add(market);
            }
        }
    }
}
