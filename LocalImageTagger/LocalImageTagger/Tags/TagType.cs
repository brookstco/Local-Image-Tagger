namespace LocalImageTagger.Tags
{
    /// <summary>
    /// The type  of tag. Used to distinguish normal tags from aliases
    /// </summary>
    public enum TagType
    {
        /// <summary>
        /// The enum was created erroneously.
        /// </summary>
        Unknown,
        /// <summary>
        /// Normal tag behavior. The "Children" field contains the standard tags that are children of this tag
        /// </summary>
        Standard,
        /// <summary>
        /// The tag is an Alias. The "Children" field contains all of the standard tags that this alias is for.
        /// </summary>
        Alias,
        /// <summary>
        /// The tag is a category. It will behave completely differently
        /// This enum should not be used.
        /// </summary>
        Category
    }
}
