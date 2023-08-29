using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Input;
using CryptoCatalog.Models;

namespace CryptoCatalog.ViewModels
{
    /// <summary>
    /// Currencies List Page ViewModel
    /// </summary>
    public class CurrenciesListViewModel : ViewModelBase
    {
        public event EventHandler CustomEvent;

        private Currency selectedCurrency;

        public Currency SelectedCurrency
        {
            get { return selectedCurrency; }
            set
            {
                selectedCurrency = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Currency> Currencies { get; set; }
        public ICommand OpenDetails { get; }

        public CurrenciesListViewModel()
        {
            OpenDetails = new CommandImplementation(selectedCurrency =>
            {
                if (selectedCurrency is Currency)
                {
                    SelectedCurrency = (Currency)selectedCurrency;
                }
                CustomEvent?.Invoke(this, EventArgs.Empty);
            });
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
