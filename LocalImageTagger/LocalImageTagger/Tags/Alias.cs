using System.Collections.Generic;

namespace LocalImageTagger.Tags
{
    /// <summary>
    /// Aliases are a special class of tag that are replaced by other tags during searching.
    /// </summary>
    class Alias
    {
        #region Properties

        /// <summary>
        /// The name of the alias.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The database ID of this alias.
        /// </summary>
        public int? ID { get; private set; }

        /// <summary>
        /// A list of tagIDs for the children of this alias
        /// </summary>
        public List<int> Children { get; private set; }

        public TagType Type
        {
            get
            {
                return TagType.Alias;
            }
        }

        #endregion

        public Alias(string name, int? id = null, List<int> children)
        {
            Name = name;
            ID = id;
            Children = children;
        }

        public Alias(string name, long id, List<int> children)
        {
            Name = name;
            ID = (int)id;
            Children = children;
        }

    }
}
