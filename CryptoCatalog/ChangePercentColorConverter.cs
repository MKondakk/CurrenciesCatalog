using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;


namespace CryptoCatalog
{
   public class ChangePercentColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double changePercent)
            {
                if (changePercent < 0)
                    return Brushes.Coral;
                else if (changePercent > 0)
                    return Brushes.MediumSpringGreen;
            }
            return Brushes.White; 
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
