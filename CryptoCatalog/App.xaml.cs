using CryptoCatalog.Models;
using CryptoCatalog.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

using System.Windows;

namespace CryptoCatalog
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs startupEventArgs)
        {
            base.OnStartup(startupEventArgs);
            ServiceCollection services = new ServiceCollection();
            services.AddScoped<MainWindow>();

            services.AddScoped<MainWindowViewModel>();
            services.AddScoped<CurrenciesListViewModel>();
            services.AddScoped<CurrencyDetailsViewModel>();

            ServiceProvider serviceProvider = services.BuildServiceProvider();
            MainWindow mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
