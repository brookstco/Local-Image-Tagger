using System;

namespace LocalImageTagger.Files
{
    /// <summary>
    /// Information about taggable items
    /// </summary>
    public class FileItem
    {
        #region Properties


        //Should this be Nullable (int?) for the case where a file gets made that isn't in the DB?
        /// <summary>
        /// The Database ID for the file.
        /// </summary>
        public int ID { get; private set; }

        //TODO: Would saving this improve perforamce at the cost of space, or is performance negligible for the space benefit?

        /// <summary>
        /// The category of the file based on its type.
        /// </summary>
        public FileTypeCategory Type { get { return FileTypeHelper.DetermineFileTypeCategory(FullPath); } }

        /// <summary>
        /// The absolute path to the file.
        /// </summary>
        public string FullPath { get; private set; }

        /// <summary>
        /// The Uri for the file.
        /// </summary>
        public Uri Uri 
        { 
            get
            {
                return new Uri(FullPath);
            } 
        }

        /// <summary>
        /// The filename of the item.
        /// </summary>
        public string Name { get { return PathHelper.GetFileName(FullPath); } }

        /// <summary>
        /// The file extension of the item.
        /// </summary>
        public string Extension { get { return PathHelper.GetExtension(FullPath); }  }

        #endregion


        #region Constructor

        /// <summary>
        /// FileItems must have both a path and an ID, since the program won't work with any file whose data hasn't been imported
        /// </summary>
        /// <param name="fullPath">The string fullpath to the file</param>
        /// <param name="id">The Database ID for the file</param>
        public FileItem(string fullPath, int id)
        {
            FullPath = fullPath;
            ID = id;
        }

        /// <summary>
        /// FileItems must have both a path and an ID, since the program won't work with any file whose data hasn't been imported
        /// </summary>
        /// <param name="uri">The Uri to the file. This will be converted to the original string and saved as the FullPath. The Uri can still be gotten, but it will be recreated.</param>
        /// <param name="id">The Database ID for the file</param>
        public FileItem(Uri uri, int id)
        {
            FullPath = uri.OriginalString;
            ID = id;
        }

        #endregion

    }
}
