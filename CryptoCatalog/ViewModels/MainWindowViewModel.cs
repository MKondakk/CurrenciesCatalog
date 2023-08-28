using System.Windows.Controls;
using System.Windows.Input;
using CryptoCatalog.Pages;

namespace CryptoCatalog.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private Page currentPage = new CurrenciesList();

        public Page CurrentPage
        {
            get { return currentPage; }
            set
            {
                currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }

        public ICommand OpenDetails { get; }

        public MainWindowViewModel()
        {
            OpenDetails = new CommandImplementation(_ => { CurrentPage = new CurrencyDetails(); });
        }
    }
}
