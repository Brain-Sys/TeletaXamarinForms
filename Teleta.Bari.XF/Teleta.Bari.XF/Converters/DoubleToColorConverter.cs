using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Teleta.Bari.XF.Converters
{
    public class DoubleToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double v = (double)value;

            if (v < 20)
            {
                return Color.Green;
            }
            else if (v >= 20 && v <= 80)
            {
                return Color.Orange;
            }

            return Color.BlueViolet;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}