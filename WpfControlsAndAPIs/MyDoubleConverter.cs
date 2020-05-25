using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfControlsAndAPIs
{
    // System.Windows.Data.IValueConverter; 
    public class MyDoubleConverter : IValueConverter
    {
        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            double number = (double)value;
            return (int)number;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // You won't worry about "two-way" bindings here, so just return the value.
            return value;
        }
    }
}
