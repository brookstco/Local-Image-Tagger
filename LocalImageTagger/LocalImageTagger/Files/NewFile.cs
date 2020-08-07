using System;
using System.Collections.Generic;
using System.Text;

namespace LocalImageTagger.Files
{
    /// <summary>
    /// A new file that isn't in the system yet
    /// </summary>
    public class NewFile
    {

        #region Properties

        /// <summary>
        /// The category of the file based on its type.
        /// </summary>
        public FileTypeCategory Type { get { return FileTypeHelper.DetermineFileTypeCategory(FullPath); } }

        /// <summary>
        /// The absolute path to the file.
        /// </summary>
        public string FullPath { get; set; }

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
        public string FileName { get { return PathHelper.GetFileName(FullPath); } }

        /// <summary>
        /// The file extension of the item.
        /// </summary>
        public string Extension { get { return PathHelper.GetExtension(FullPath); } }

        #endregion


        #region Constructor

        /// <summary>
        /// New Files can be given either a Full path or a Uri.
        /// </summary>
        /// <param name="fullPath">The string fullpath to the file</param>
        public NewFile(string fullPath)
        {
            FullPath = fullPath;
        }

        /// <summary>
        /// New Files can be given either a Full path or a Uri.
        /// </summary>
        /// <param name="uri">The Uri to the file. This will be converted to the original string and saved as the FullPath. The Uri can still be gotten, but it will be recreated.</param>
        public NewFile(Uri uri)
        {
            FullPath = uri.OriginalString;
        }

        #endregion

    }
}
