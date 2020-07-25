using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;

namespace LocalImageTagger.Converter
{
    class BoolToThumbnailMarginValueConverter : BaseValueConverter<BoolToThumbnailMarginValueConverter>
    {
        /// <summary>
        /// Converts from a Bool to a Thickness for a thumbnail border
        /// </summary>
        /// <param name="value">A bool</param>
        /// <returns>A <see cref="Thickness"/></returns>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Thickness is a struct that takes 4 doubles. All 4 should be the same for an even margin.
            if (((bool)value) == true)
            {
                //If true, set the settings as the even margin size
                var margin = Properties.Settings.Default.ThumbnailMarginSize;
                return new Thickness(margin, margin, margin, margin);

            }
            else
            {
                return new Thickness(0.0, 0.0, 0.0, 0.0);
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
