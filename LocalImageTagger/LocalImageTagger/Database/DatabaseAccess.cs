using LocalImageTagger.Tags;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Text;

namespace LocalImageTagger
{
    class DatabaseAccess
    {
        const int nameLength = 100;
        const int uriLength = 2000;
        //+ others for the tags

        #region Searching 

        /// <summary>
        /// Returns a list of all of the tags (and their counts) that begin with the letters that are currently being typed, restricted by category. 
        /// Updated on each keyboard change in the search bar.
        /// </summary>
        /// <param name="search"></param>
        /// <param name="categoryID">The ID of the category the tag belongs to</param>
        public void suggestTags(string search, int categoryID)
        {
            //If the tag category is null, it is a category, and should be given as an option. Otherwise, restrict by the provided category

            //Returns a list (LINQ, probably) suitable for a dropdown of all of the tags
            //prioritize categories first (and make it clear that they're categories
            //Then order by the count
        }

        //TODO: Once a tag is selected from this list (or they type in a complete match and press space), add its id into the List. Caategories must be followed by a tag, and only the following tag gets added.

        /// <summary>
        /// When an alias has been entered, it is replaced by its attached normal tags if they aren't already in the search
        /// Only happens when the option is selected to "Replace aliases in seach bar"
        /// </summary>
        /// <param name=""></param>
        public string convertAlias(int alias, ref List<int> searchIDs)
        {
            //replaces the alias ID in the list with its associated normal tags
            //Returns the string version of the normal tags for the caller to plug into the search properly
            return "ERROR";
        }

        /// <summary>
        /// Adds the children tags to the end of the current search if they aren't already in the search
        /// </summary>
        /// <param name="parent"></param>
        public void addChildren(int parent, List<int> searchIDs)
        {

        }

        /// <summary>
        /// Adds missing tags from aliases and parents.
        /// </summary>
        /// <param name="search"></param>
        public List<int> preprocessTags(List<int> searchIDs)
        {
            //loop through each tag
            //if normal tag:
            //  addChildren(current, searchList);
            //if alias:
            //  if !replaceAliases
            //      convertAlias(current, searchList
            return searchIDs;
        }

        /// <summary>
        /// The actual search for tags. Calls the final preprocessing to account for aliases and parents, and returns a list of the files
        /// </summary>
        /// <param name="searchIDs"></param>
        public void searchDatabaseByTags(List<int> searchIDs)
        {
            searchIDs = preprocessTags(searchIDs);
            //search DB using the list of IDs. Directly search the tagmap table, and use the file IDS to find the data in the file table. Return a sortable list of results
        }

        #endregion

        #region Add into database

        /// <summary>
        /// Adds a new tag into the database
        /// </summary>
        /// <param name="name">The name of the new tag</param>
        /// <param name="categoryID">The category that this tag belongs to</param>
        /// <param name="aliases">The alias IDs already in a comma seperated string</param>
        /// <param name="parents">The parent IDs already in a comma seperated string</param>
        /// <param name="children">The children IDs already in a comma seperated string</param>
        /// <param name="description">The desciption of the tag.</param>
        public void addTag(string name, int categoryID, string aliases, string parents, string children, string description)
        {
            var tagType = TagType.Standard;
            //Add current date
            //check that all the fields are good
            //add new tag to DB
        }

        //TODO: Updaters for each value for all tables should be made for editing entries.

        public void addAlias(string name, string aliases)
        {
            var tagType = TagType.Alias;
            //add into tag database as an alias
        }

        /// <summary>
        /// Adds a new category into the tag database
        /// </summary>
        /// <param name="name">The name of the new category</param>
        /// <param name="description">The desciption of the category</param>
        public void addCategory(string name, string description)
        {
            //After ensuring it will actually fit, add it to the DB
            if (stringSizeFitsUnicode(name, nameLength))
            {
                var tagType = TagType.Category;
                //Add into database as new category type tag
            }
            else
            {
                //TODO: Custom exception with handleing, or just deal with this elsewhere
                throw new System.Exception();
            }
        }

        /// <summary>
        /// Adds a new file into the database
        /// </summary>
        /// <param name="uri">The URI of the new file</param>
        public void addFile(string uri)
        {
            //After ensuring it will actually fit, add it to the DB
            if (stringSizeFitsUnicode(uri, uriLength))
            {
                //Add into database as new File
            }
            else
            {
                //TODO: Custom exception with handleing, or just deal with this elsewhere
                throw new System.Exception();
            }
        }

        #endregion

        #region Tagmap

        /// <summary>
        /// Adds tags to an image
        /// </summary>
        /// <param name="fileID"></param>
        /// <param name="tagList"></param>
        public void tagImage(int fileID, List<int> tagList)
        {
            //figure out which tags are already associated with the image
            //add each tag paired with the fileID into the tagmap that aren't ready added --- addTagMap
            //remove all tagmaps that are from tags that used to be attached, but aren't anymore

        }

        /// <summary>
        /// Adds a tag-file tagmap into the tagmap table
        /// </summary>
        /// <param name="fileID"></param>
        /// <param name="tagID"></param>
        public void addTagMap(int fileID, int tagID)
        {
            //add into DB
        }

        /// <summary>
        /// Removes a tag-file tagmap from the tagmap table
        /// </summary>
        /// <param name="fileID"></param>
        /// <param name="tagID"></param>
        public void removeTagMap(int fileID, int tagID)
        {
            //remove the entry that matches
        }

        #endregion

        #region Helpers
        /// <summary>
        /// Returns whether the byte size of the string is less than the wanted size.
        /// Uses Unicode encoding
        /// </summary>
        /// <param name="entry">The string to be measured</param>
        /// <param name="size">The maximum size in bytes</param>
        /// <returns></returns>
        public bool stringSizeFitsUnicode(string entry, int size)
        {
            //Comparision returns a bool value for the byte count of the string
            return (Encoding.Unicode.GetByteCount(entry) <= size);
        }

        /// <summary>
        /// Converts the strings that store the IDs of alias, parents, and children into a list of ints
        /// </summary>
        /// <param name="IDString"></param>
        /// <returns></returns>
        public List<int> convertToIDList(string IDString)
        {
            //SQL STRING_SPLIT
            return null;
        }
        #endregion
    }
}
