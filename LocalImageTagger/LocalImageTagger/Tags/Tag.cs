using System.Collections.Generic;

namespace LocalImageTagger.Tags
{
    //There are 3 forms of tag in order to save space when details are unneeded. All 3 are below, since they are related

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

    /// <summary>
    /// A tag with the extra details needed for searching with it.
    /// </summary>
    class SearchTag : Tag
    {

        #region Properties

        /// <summary>
        /// A list of tagIDs for the children of this tag.
        /// </summary>
        public List<int> Children { get; private set; }



        #endregion

        public SearchTag(string name, int id, int count, List<int> children) : base(name, id, count)
        {
            Children = children;
        }

    }

    /// <summary>
    /// A tag with all of its information.
    /// </summary>
    class FullTag : SearchTag
    {

        #region Properties

        /// <summary>
        /// The text description of the tag shown in the tag dictionary.
        /// </summary>
        public string Description { get; private set; }

        #endregion

        public FullTag(string name, int id, int count, List<int> children,  string desc) : base(name, id, count, children)
        {
            Description = desc;
        }

    }

}
