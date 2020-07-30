using System.IO;

namespace LocalImageTagger.Files
{
    /// <summary>
    /// Information about taggable items
    /// </summary>
    public class FileItem
    {
        /// <summary>
        /// The Database ID for the file.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The category of the file based on its type.
        /// </summary>
        public FileTypeCategory Type { get { return FileTypeHelper.DetermineFileTypeCategory(FullPath); } }

        /// <summary>
        /// The absolute path to the file.
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// The filename of the item.
        /// </summary>
        public string Name { get { return PathHelper.GetFileName(FullPath); } }

        /// <summary>
        /// The file extension of the item.
        /// </summary>
        public string Extension { get { return PathHelper.GetExtension(FullPath); }  }


    }
}
