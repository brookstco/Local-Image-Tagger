using System;
using System.Collections.Generic;
using System.Text;

namespace LocalImageTagger.Tags
{
    /// <summary>
    /// A tag with the extra details needed for searching with it.
    /// </summary>
    public class SearchTag : Tag
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


}
