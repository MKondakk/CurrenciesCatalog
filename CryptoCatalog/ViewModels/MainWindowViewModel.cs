using System;
using System.Windows.Input;
using CryptoCatalog.Models;
using MaterialDesignThemes.Wpf;

namespace CryptoCatalog.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase currentPageViewModel;
        private CurrencyDetailsViewModel currencyDetailsViewModel;
        private CurrenciesListViewModel currenciesListViewModel;
        private bool _isChecked;
        public bool IsChecked

        {
            get { return _isChecked; }
            set
            {
                _isChecked = value;
                OnPropertyChanged(nameof(IsChecked));
            }
        }
       public ViewModelBase CurrentPageViewModel
            {
                get { return currentPageViewModel; }
                set
                {
                    currentPageViewModel = value;
                    OnPropertyChanged("CurrentPageViewModel");
                }
            }
        public ICommand DarkModeCommand { get; }
        public ICommand OpenList { get; }


        public MainWindowViewModel(CurrencyDetailsViewModel currencyDetailsViewModel, CurrenciesListViewModel currenciesListViewModel)
        {          
            this.currencyDetailsViewModel = currencyDetailsViewModel;
            this.currenciesListViewModel = currenciesListViewModel;
            CurrentPageViewModel = currenciesListViewModel;
            currenciesListViewModel.CustomEvent += OnNavigateDetails;
            OpenList = new CommandImplementation(_ => { CurrentPageViewModel = currenciesListViewModel; });
            DarkModeCommand = new ViewModelCommand(ExecuteDarkModeCommand);
        }

        private void OnNavigateDetails(object? sender, EventArgs e)
        {          
            currencyDetailsViewModel.Currency = currenciesListViewModel.SelectedCurrency;
            CurrentPageViewModel = currencyDetailsViewModel;
        }
        private void ExecuteDarkModeCommand()
        {
            PaletteHelper palette = new PaletteHelper();
            ITheme theme = palette.GetTheme();

            if (IsChecked)
            {
                theme.SetBaseTheme(Theme.Dark);
            }
            else
            {
                theme.SetBaseTheme(Theme.Light);
            }
            palette.SetTheme(theme);
        }
    }
}
