using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace LocalImageTagger
{
    /// <summary>
    /// Returns the appropriate display item for the given item
    /// </summary>
    class ItemToDisplayConverter
    {
        //TODO: This is the same as ItemToImageConverter. Fix this or delete
        public static ItemToDisplayConverter instance = new ItemToDisplayConverter();
        /// <summary>
        /// Currently only displays the image if valid, and an unknown otherwise. IT is actually an ItemToImageConverter right now
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
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
            if(item.Type == FileCategoryType.Image)
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
