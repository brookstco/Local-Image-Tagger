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

        #endregion

        public Tag(string name, int id, int count)
        {
            Name = name;
            ID = id;
            Count = count;
        }

    }
}
