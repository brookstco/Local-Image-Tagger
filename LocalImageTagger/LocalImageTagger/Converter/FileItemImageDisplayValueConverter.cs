using LocalImageTagger.Files;
using System;
using System.Globalization;
using System.Windows.Media.Imaging;

namespace LocalImageTagger.Converter
{
    /// <summary>
    /// Returns a BitmapImage for the given FileItem
    /// </summary>
    class FileItemImageDisplayValueConverter : BaseValueConverter<FileItemImageDisplayValueConverter>
    {
        /// <summary>
        /// Converts from a FileItem to a BitmapImage for display
        /// </summary>
        /// <param name="value">A FileItem object</param>
        /// <returns></returns>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Value is an FileItem Object
            FileItem File = (FileItem)value;

            //Changes depending on the file type of the item
            switch (File.Type)
            {
                case FileTypeCategory.Image:
                    return new BitmapImage(File.Uri);
                default:
                    //IDEA: https://stackoverflow.com/questions/347614/storing-wpf-image-resources suggests storing the image resource seperately and referencing it to reduce mem use. This is only useful if I allow adding of files besides imgs, so a problem for future me.
                    //UNTESTED
                    return new BitmapImage(new Uri("/Images/Files/unknownFiles.png", UriKind.Relative));
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
