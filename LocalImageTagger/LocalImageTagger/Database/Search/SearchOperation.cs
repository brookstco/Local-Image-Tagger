
namespace LocalImageTagger.Database
{
    public enum SearchOperation
    {
        /// <summary>
        /// The standard search type. Works as an AND with multiple search terms, or as a direct search with only this item.
        /// </summary>
        Standard = 0,
        /// <summary>
        /// Same function as standard
        /// </summary>
        AND = 0,
        /// <summary>
        /// Requires the result to match one or more of the included search items
        /// Requires a list of additional search coperations inside of it to be or-ed
        /// </summary>
        OR = 1,
        /// <summary>
        /// The standard search type, but must be excluded. Works as an NAND with multiple search terms, or as a direct search with only this item.
        /// </summary>
        Excluded = 2,
        /// <summary>
        /// Same function as Excluded
        /// </summary>
        NOT = 2,
        /// <summary>
        /// Overwrites defaults with the included searchOperations.
        /// </summary>
        Optional = 3,
        /// <summary>
        /// Same function as standard, but has a fileID and finds the file instead.
        /// </summary>
        File = 4,
        /// <summary>
        /// Same function as standard, but include an exact directory instead.
        /// Requires a string fullPath
        /// </summary>
        DirectoryExclusive = 5,
        /// <summary>
        /// Same function as standard, but include a directory (and all of its subdirectories) instead.
        /// Requires a string fullPath
        /// </summary>
        DirectoryInclusive = 6,

    }
}
