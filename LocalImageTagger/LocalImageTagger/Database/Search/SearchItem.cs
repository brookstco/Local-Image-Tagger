using System;
using System.Collections.Generic;
using System.Text;

namespace LocalImageTagger.Database.Search
{
    /// <summary>
    /// A search item with the associated Ids for searching
    /// </summary>
    public class SearchItem
    {

        #region Properties

        /// <summary>
        /// The type of search this item is.
        /// </summary>
        public SearchOperation SearchType { get; private set; }

        //Split this into multiple inherited classes?

        /// <summary>
        /// The ID of the tag/file for this operation.
        /// </summary>
        public int ID { get; private set; } = -1;

        /// <summary>
        /// String Fullpath to a directory.
        /// Used for <see cref="SearchOperation.DirectoryExclusive"/> and <see cref="SearchOperation.DirectoryInclusive"/> only.
        /// </summary>
        public string FullPath { get; private set; } = null;

        /// <summary>
        /// List of additional searchItems.
        /// Used for <see cref="SearchOperation.OR"/> only.
        /// </summary>
        public List<SearchItem> SearchItems { get; private set; } = null;

        #endregion


        //It will only ever need 1. Should I confirm that the correct type was added here?
        public SearchItem(SearchOperation searchType, int id)
        {
            SearchType = searchType;
            ID = id;
        }
        public SearchItem(SearchOperation searchType, string fullPath)
        {
            SearchType = searchType;
            FullPath = fullPath;
        }
        public SearchItem(SearchOperation searchType, List<SearchItem> searchItems)
        {
            SearchType = searchType;
            SearchItems = searchItems;
        }

    }
}
