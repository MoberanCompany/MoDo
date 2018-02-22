using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Modo.Helper
{
    public class BooleanToEnableConverter : IValueConverter
    {
        public BooleanToEnableConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is bool && (bool)value)
            {
                return true;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return ! (bool)value;
        }
    }
}
