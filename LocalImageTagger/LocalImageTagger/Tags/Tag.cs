using System.Collections.Generic;

namespace LocalImageTagger.Tags
{
    /// <summary>
    /// A tag with the details that will be needed when viewing it.
    /// </summary>
    public class Tag
    {

        #region Properties

        /// <summary>
        /// The name of the tag.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The database ID of this tag.
        /// </summary>
        public int ID { get; private set; }

        /// <summary>
        /// The number of files tagged with this tag.
        /// </summary>
        public int Count { get; private set; }

        public TagType Type
        {
            get
            {
                return TagType.Standard;
            }
        }

        /// <summary>
        /// A list of tagIDs for the children of this tag.
        /// </summary>
        public List<int> Children { get; private set; }

        /// <summary>
        /// The text description of the tag shown in the tag dictionary.
        /// </summary>
        public string Description { get; private set; }

        #endregion


        public Tag(string name, int id, int count = 0, List<int> children = null, string desc = null)
        {
            Name = name;
            ID = id;
            Count = count;
            Children = children;
            Description = desc;
        }



    }
}
