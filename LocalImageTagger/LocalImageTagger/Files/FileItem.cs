using System;
using System.Collections.Generic;
using LocalImageTagger.Tags;

namespace LocalImageTagger.Files
{
    /// <summary>
    /// Information about taggable items
    /// </summary>
    public class FileItem : NewFile
    {
        #region Properties

        /// <summary>
        /// The Database ID for the file.
        /// </summary>
        public int ID { get; private set; }

        /// <summary>
        /// The tags for this FileItem.
        /// </summary>
        public List<Tag> Tags { get; set; }

        #endregion


        #region Constructor

        /// <summary>
        /// FileItems must have both a path and an ID, since the program won't work with any file whose data hasn't been imported.
        /// Tags can be loaded in for faster access, but are optional
        /// </summary>
        /// <param name="fullPath">The string fullpath to the file.</param>
        /// <param name="id">The Database ID for the file.</param>
        public FileItem(string fullPath, int id, List<Tag> tags = null) : base(fullPath)
        {
            ID = id;
            Tags = tags;
        }

        /// <summary>
        /// FileItems must have both a path and an ID, since the program won't work with any file whose data hasn't been imported.
        /// </summary>
        /// <param name="uri">The Uri to the file. This will be converted to the original string and saved as the FullPath. The Uri can still be gotten, but it will be recreated.</param>
        /// <param name="id">The Database ID for the file.</param>
        /// <param name="tags">Optional <see cref="List{Tag}"/> for the tags associated with this File.</param>
        public FileItem(Uri uri, int id, List<Tag> tags = null) : base(uri)
        {
            ID = id;
            Tags = tags;
        }

        #endregion

    }
}
