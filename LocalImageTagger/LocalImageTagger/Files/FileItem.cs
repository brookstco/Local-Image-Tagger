namespace LocalImageTagger
{
    /// <summary>
    /// Information about taggable items
    /// </summary>
    public class FileItem
    {
        /// <summary>
        /// The category of the file
        /// </summary>
        public FileCategoryType Type { get; set; }

        /// <summary>
        /// The absolute path to the file
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// The name of the item
        /// </summary>
        public string Name { get { return getFileFolderName(FullPath)}; }

        /// <summary>
        /// Database ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Returns the name from a full path
        /// </summary>
        /// <param name="path">The Full Path</param>
        /// <returns></returns>
        public static string getFileFolderName (string path)
        {
            //Return an empty string if the path is empty
            if (string.IsNullOrEmpty(path))
            {
                return string.Empty;
            }

            //Make all slashes backslashes
            var normalizedPath = path.Replace('/', '\\');

            //Find the last \ of the path
            var lastIndex = normalizedPath.LastIndexOf('\\');
            //If one was not found
            if(lastIndex <= 0)
            {
                return path;
            }

            //Return what is after the last index
            return path.Substring(lastIndex + 1);
        }
    }
}
