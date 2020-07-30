namespace LocalImageTagger
{
    /// <summary>
    /// The category of file. Determines how it is displayed and behaves.
    /// </summary>
    public enum FileTypeCategory
    {
        /// <summary>
        /// The enum was created erroneously.
        /// </summary>
        Unknown,
        /// <summary>
        /// Image thumbnails will be shown, and the full image can be opened
        /// </summary>
        Image,
        /// <summary>
        /// Video. Thumbnail is an early frame. Can be played, and have certain frames bookmarked.
        /// </summary>
        Video,
        /// <summary>
        /// Sound files. No icon, but can be played.
        /// </summary>
        Audio,
        /// <summary>
        /// Folder themselves can be tagged. The file can be opened in the OS explorer, or the contents opened in the tagger.
        /// </summary>
        Directory,
        /// <summary>
        /// Files that can be run. These will show their icon and can be directly run.
        /// </summary>
        Application,
        /// <summary>
        /// Any other type of file. These can only be opened in other programs and have no display.
        /// </summary>
        Other
    }

}
