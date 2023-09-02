using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CryptoCatalog.Models;

namespace CryptoCatalog.ViewModels
{
    /// <summary>
    /// Currencies List Page ViewModel
    /// </summary>
    public class CurrenciesListViewModel : ViewModelBase
    {
        public event EventHandler<Currency> NavigateDetails;

        public ObservableCollection<Currency> Currencies { get; set; }

        public ICommand OpenDetails { get; }

        public CurrenciesListViewModel()
        {
            OpenDetails = new CommandImplementation(o =>
            {
                if (o is Currency selectedCurrency)
                {
                    NavigateDetails?.Invoke(this, selectedCurrency);
                }
            });

            Currencies = new ObservableCollection<Currency>();

            FetchCurrencies();
        }

        async private Task FetchCurrencies()
        {
            var client = new HttpClient() { BaseAddress = new Uri("https://api.coincap.io") };

            try
            {
                var response = await client.GetAsync("v2/assets?limit=15");

                var result = await response.Content.ReadFromJsonAsync<CurrencyResponse>();

                if (result == null) { return; }

                foreach (var item in result.data)
                {
                    Currencies.Add(item);
                }

            }
            catch
            {
                MessageBox.Show("Error loading");
            }
        }
    }
}
