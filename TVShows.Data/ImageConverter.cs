﻿using System;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace TVShows.Data
{
    public class StringToImageConverter : IValueConverter
    {
        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is Class_tvshow)
            {
                var record = (Class_tvshow)value;
                if (string.IsNullOrEmpty(record.Link_image))
                    return new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"MiniImages\NotAvailable.jpg", UriKind.Relative));
                return new BitmapImage(new Uri(record.Link_image, UriKind.Relative));
            }
            else
            {
                string imagename = value as string;
                if (string.IsNullOrEmpty(imagename))
                    imagename = AppDomain.CurrentDomain.BaseDirectory + @"MiniImages\NotAvailable.jpg";

                return AppDomain.CurrentDomain.BaseDirectory + @"MiniImages\" + imagename;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
