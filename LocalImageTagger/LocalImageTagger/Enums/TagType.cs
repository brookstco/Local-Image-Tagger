namespace LocalImageTagger
{
    /// <summary>
    /// The type  of tag. Changes how the "Alias" field is used.
    /// </summary>
    public enum TagType : byte
    {
        /// <summary>
        /// The enum was created erroneously.
        /// </summary>
        Unknown,
        /// <summary>
        /// Normal tag behavior. The "Alias" field contains all of the aliases for this tag
        /// </summary>
        Standard,
        /// <summary>
        /// The tag is an Alias. The "Alias" field contains all of the standard tags that this alias is for.
        /// </summary>
        Alias,
        /// <summary>
        /// The tag is a category. It will behave completely differently
        /// </summary>
        Category
    }
}
