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
                SetProperty(ref _isChecked, value);
                ToggleTheme(value);
            }
        }
        public ViewModelBase CurrentPageViewModel
        {
            get { return currentPageViewModel; }
            set
            {
                SetProperty(ref currentPageViewModel, value);
            }
        }

        public ICommand OpenList { get; }

        public MainWindowViewModel(CurrencyDetailsViewModel currencyDetailsViewModel, CurrenciesListViewModel currenciesListViewModel)
        {
            this.currencyDetailsViewModel = currencyDetailsViewModel;
            this.currenciesListViewModel = currenciesListViewModel;

            CurrentPageViewModel = currenciesListViewModel;
            IsChecked = true;
            OpenList = new CommandImplementation(_ => { CurrentPageViewModel = currenciesListViewModel; });

            currenciesListViewModel.NavigateDetails += OnNavigateDetails;
        }

        private void OnNavigateDetails(object? sender, Currency currency)
        {
            currencyDetailsViewModel.Currency = currency;
            CurrentPageViewModel = currencyDetailsViewModel;
        }

        private void ToggleTheme(bool isDark)
        {
            var paletteHelper = new PaletteHelper();
            ITheme theme = paletteHelper.GetTheme();
            IBaseTheme baseTheme = isDark ? new MaterialDesignDarkTheme() : new MaterialDesignLightTheme();
            theme.SetBaseTheme(baseTheme);
            paletteHelper.SetTheme(theme);
        }
    }
}
