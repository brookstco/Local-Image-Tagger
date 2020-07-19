using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace LocalImageTagger
{
    /// <summary>
    /// Converts a full path of an image to its bitmap
    /// </summary>
    [ValueConversion(typeof(string), typeof(BitmapImage))] //Makes this findable from bindings
    public class PathToImageConverter : IValueConverter
    {
        public static PathToImageConverter instance = new PathToImageConverter();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Get the full path if not null
            if(value == null)
            {
                return null;
            }
            var path = (string)value;
            return new BitmapImage(new Uri(path));
        }

        //Not implemented
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
