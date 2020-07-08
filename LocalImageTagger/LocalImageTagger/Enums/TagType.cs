namespace LocalImageTagger
{
    /// <summary>
    /// The type  of tag. Changes how the "TagAssociations" field is used.
    /// </summary>
    public enum TagType : short
    {
        /// <summary>
        /// The enum was created erroneously.
        /// </summary>
        Unknown,
        /// <summary>
        /// Normal tag behavior. The "TagAssociations" field contains the tag's parents.
        /// </summary>
        Standard,
        /// <summary>
        /// The tag is an Alias. The "TagAssociations" field contains all of the standard tags that this alias is for.
        /// </summary>
        Alias
    }
}
