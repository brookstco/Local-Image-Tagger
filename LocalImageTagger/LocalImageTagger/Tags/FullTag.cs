using System;
using System.Collections.Generic;
using System.Text;

namespace LocalImageTagger.Tags
{
    /// <summary>
    /// A tag with all of its information.
    /// </summary>
    public class FullTag : SearchTag
    {

        #region Properties

        /// <summary>
        /// The text description of the tag shown in the tag dictionary.
        /// </summary>
        public string Description { get; private set; }

        #endregion

        public FullTag(string name, int id, int count, List<int> children, string desc) : base(name, id, count, children)
        {
            Description = desc;
        }

    }
}
