using System;
using System.Windows.Input;
using CryptoCatalog.Models;

namespace CryptoCatalog.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase currentPageViewModel;
        private CurrencyDetailsViewModel currencyDetailsViewModel;
        private CurrenciesListViewModel currenciesListViewModel;

        public ViewModelBase CurrentPageViewModel
        {
            get { return currentPageViewModel; }
            set
            {
                currentPageViewModel = value;
                OnPropertyChanged("CurrentPageViewModel");
            }
        }
        public ICommand OpenList { get; }

        public MainWindowViewModel(CurrencyDetailsViewModel currencyDetailsViewModel, CurrenciesListViewModel currenciesListViewModel)
        {          
            this.currencyDetailsViewModel = currencyDetailsViewModel;
            this.currenciesListViewModel = currenciesListViewModel;
            CurrentPageViewModel = currenciesListViewModel;
            currenciesListViewModel.CustomEvent += OnNavigateDetails;
            OpenList = new CommandImplementation(_ => { CurrentPageViewModel = currenciesListViewModel; });
        }

        private void OnNavigateDetails(object? sender, EventArgs e)
        {          
            currencyDetailsViewModel.Currency = currenciesListViewModel.SelectedCurrency;
            CurrentPageViewModel = currencyDetailsViewModel;
        }
    }
}
