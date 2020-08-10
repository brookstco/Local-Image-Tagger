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
        /// This will be -1 if there is no associated database Id
        /// </summary>
        public int ID { get; private set; }
        #endregion

        /// <summary>
        /// If this category is the default category.
        /// </summary>
        public bool DefaultCategory { get; private set; }

        public Category(string name, int id = -1, bool defaultCat = false)
        {
            Name = name;
            ID = id;
            DefaultCategory = defaultCat;
        }
    }
}
