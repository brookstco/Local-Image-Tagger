using System;
using System.Collections.Generic;
using System.Text;

namespace LocalImageTagger.Files
{
    public static class FileTypeHelper
    {
        /// <summary>
        /// Returns the <see cref="FileTypeCategory"></see> based on a given file's extension/>
        /// </summary>
        /// <param name="name">The full path, file name, or extension as a string.</param>
        /// <returns>Returns the approopriate <see cref="FileTypeCategory"/></returns>
        public static FileTypeCategory DetermineFileTypeCategory(string name)
        {

            if (name.EndsWith("JPG", StringComparison.OrdinalIgnoreCase) || name.EndsWith("JPEG", StringComparison.OrdinalIgnoreCase)
                || name.EndsWith("PNG", StringComparison.OrdinalIgnoreCase)
                || name.EndsWith("BMP", StringComparison.OrdinalIgnoreCase)
                || name.EndsWith("TIFF", StringComparison.OrdinalIgnoreCase))
            {
                return FileTypeCategory.Image;
            }
            else if (name.EndsWith("MP4", StringComparison.OrdinalIgnoreCase))
            {
                return FileTypeCategory.Video;
            }
            else
            {
                return FileTypeCategory.Unknown;
            }
        }

        public static FileTypeCategory DetermineFileTypeCategory(Uri uri)
        {
            //uri.AbsoluteUri is another option, but can't handle relative uris. 
            //Since this just looks at the ext that shouldn't matter at all though.
            //I don't even think I need this overload, but writing this down just in case something breaks if I do use it.
            return DetermineFileTypeCategory(uri.OriginalString);
        }

    }
}
