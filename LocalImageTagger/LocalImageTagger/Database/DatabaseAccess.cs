using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Text;

namespace LocalImageTagger
{
    class DatabaseAccess
    {
        const int nameLength = 100;
        const int uriLength = 2000;
        //others for the tags

        /// <summary>
        /// Returns a list of all of the tags (and their counts) that begin with the letters that are currently being typed. Updated on each keyboard change in the search bar.
        /// </summary>
        /// <param name="search"></param>
        public void suggestTags(string search)
        {
            //Returns a list suitable for a dropdown of all of the tags
        }

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
        public void searchDatabase(List<int> searchIDs)
        {
            searchIDs = preprocessTags(searchIDs);
            //search DB using the list of IDs. Directly search the tagmap table, and use the file IDS to find the data in the file table. Return a sortable list of results
        }

        /// <summary>
        /// Adds a new tag into the database
        /// </summary>
        /// <param name="name">The name of the new tag</param>
        /// <param name="categoryID">The category that this tag belongs to</param>
        /// <param name="tagType">The Closest value ot a tinyint, which is what this is stored as</param>
        /// <param name="aliases">The alias IDs already in a comma seperated string</param>
        /// <param name="parents">The parent IDs already in a comma seperated string</param>
        /// <param name="children">The children IDs already in a comma seperated string</param>
        /// <param name="description">The desciption of the tag.</param>
        public void addTag(string name, int categoryID, byte tagType, string aliases, string parents, string children, string description)
        {
            //Add current date
            //check that all the fields are good
            //add new tag to DB
        }

        //TODO: Updaters for each value for all tables should be made for editing entries.

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

        /// <summary>
        /// Adds a new category into the database
        /// </summary>
        /// <param name="name">The name of the new category</param>
        public void addCategory(string name)
        {
            //After ensuring it will actually fit, add it to the DB
            if (stringSizeFitsUnicode(name, nameLength))
            {
                //Add into database as new category
            }
            else
            {
                //TODO: Custom exception with handleing, or just deal with this elsewhere
                throw new System.Exception();
            }
        }

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
    }
}
