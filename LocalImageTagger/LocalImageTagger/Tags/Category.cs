using System;
using System.Collections.Generic;
using System.Text;

namespace LocalImageTagger.Tags
{
    public class Category
    {
        #region Properties

        /// <summary>
        /// The Category name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The database ID of this tag.
        /// Null if not in database
        /// </summary>
        public int? ID { get; private set; }

        /// <summary>
        /// The display color for tags in this category
        /// Null if undefined
        /// </summary>
        public string Color { get; private set; }

        /// <summary>
        /// The display priority for tags in this category
        /// Null if undefined
        /// </summary>
        public int? Priority { get; private set; }

        #endregion


        public Category(string name, int? id = null, string color = null, int? priority = null )
        {
            Name = name;
            ID = id;
            Color = color;
            Priority = priority;
        }
    }
}
