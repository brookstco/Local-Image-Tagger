
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

        #region Constructor

        /// <summary>
        /// Category holds the DB and Display information for the category.
        /// For new instantiation, only the name is a required field
        /// </summary>
        public Category(string name, int? id = null, string color = null, int? priority = null)
        {
            Name = name;
            ID = id;
            Color = color;
            Priority = priority;
        }

        /// <summary>
        /// Category holds the DB and Display information for the category.
        /// SQLite DB outputs int64
        /// </summary>
        public Category(string name, long id, string color, long priority)
        {
            Name = name;
            //Casts int64 from sqlite selects into the proper int form. Won't even have problems with overflow for priority (small) and 2 billion is probably enough categories or files for a single user.
            ID = (int)id;
            Color = color;
            //Casts int64 from sqlite selects into the proper int form. Won't even have problems with overflow for priority (small) and 2 billion is probably enough categories or files for a single user.
            Priority = (int)priority;
        }

        #endregion
    }
}
