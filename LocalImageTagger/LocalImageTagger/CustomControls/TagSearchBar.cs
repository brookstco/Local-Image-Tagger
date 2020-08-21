using System.Windows.Controls;

namespace LocalImageTagger.UserControls
{
    class TagSearchBar : TextBox
    {
        //TODO: Make a custom text box for searching either single or multi-strings of tags. Tags should be autocompleted by a drop-down of options. 
        //A list of bothe the strings (that is displayed to the user) as well as a list of the tagIDs should be accessible
        //A list of all non-identified tags (no ids/ not in ddatabase) should also be availible.  (such as for adding new aliases)
        //Suggested tags should prioritize 1: categories, 2: tags (based on count), 3: aliases
        //Display the tag type (cat, tag, alias) and the count for the tags
        //Option to have only 1 tag or many (if one, prevents spaces)

        //Processes the special characters into commands for the list

        #region Properties

        /// <summary>
        /// Determines whether the tag search bar accepts only 1 (true) or many (false) tags.
        /// </summary>
        public bool isSingleTag { get; set; } = false;

        #endregion

    }
}
