using CryptoCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                OnPropertyChanged(nameof(Currency));
            }
        }

    }
}
