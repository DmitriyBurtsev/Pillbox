using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Pillbox.Services
{
    public class DatetimeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
			if (value is DateTime dateTime)
			{
                if (dateTime == null)
				{
					return string.Empty;
				}
				if (parameter is string pattern)
				{
					return dateTime.ToString("dd:mm:yyyy");
				}
				else
				{
					return dateTime.ToString();
				}
			}
			else if (value is TimeSpan timeSpan)
			{
				if (timeSpan == null)
				{
					return string.Empty;
				}

                if (parameter is string)
				{
					return new DateTime(timeSpan.Ticks).ToString("HH:mm");
				}
				else
				{
					return new DateTime(timeSpan.Ticks).ToString();
                }
			}
			return string.Empty;
		}

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
			return value;
		}
	}
}
