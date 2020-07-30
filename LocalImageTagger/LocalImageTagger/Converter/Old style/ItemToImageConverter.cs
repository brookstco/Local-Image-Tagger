using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace LocalImageTagger
{
    /// <summary>
    /// Returns the appropriate display item for the given item
    /// </summary>
    [ValueConversion(typeof(string), typeof(BitmapImage))] //Makes this findable from bindings
    class ItemToImageConverter
    {
        public static ItemToDisplayConverter instance = new ItemToDisplayConverter();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //If there is no given object
            if (value == null)
            {
                return null;
            }
            //else
            var item = (FileItem)value;

            //Returns 
            if(item.Type == FileTypeCategory.Image)
            {
                return new BitmapImage(new Uri(item.FullPath));
            }
            else
            {
                return new BitmapImage(new Uri("Images/unknownFile.png"));
            }
        }

        //Not implemented
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
