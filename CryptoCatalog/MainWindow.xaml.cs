using CryptoCatalog.ViewModels;
using System.Windows;

namespace CryptoCatalog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainWindowViewModel mainWindowViewModel)    
        {
            InitializeComponent();
            DataContext = mainWindowViewModel;
        }
    }
}
