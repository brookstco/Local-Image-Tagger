﻿
using LocalImageTagger.Files;
using System.Collections.ObjectModel;
using System.Linq;

namespace LocalImageTagger.ViewModels
{
    public class SearchTabViewModel : BaseTabViewModel
    {

        //TODO: Observable colections don't work with LINQ. Should I swap them out for something like a list?  - No fix or use both.
        //TODO: Pass in default search and whether it should immediately search with the ctor, so that links can open new tabs with prefilled values

        #region Properties

        /// <summary>
        /// All of the FileItems returned by the search.
        /// </summary>
        public ObservableCollection<FileItem> FileItems { get; set; } = new ObservableCollection<FileItem>();

        /// <summary>
        /// The files items for the current page.
        /// </summary>
        public ObservableCollection<FileItem> CurrentPageFileItems 
        {
            get;

            //Cuts the appropriate section for the total items.
            //CurrentPageNumber - 1 since it needs to be the starting index
            //Take will not break if the number is greater than the amount in the collection
            //Skip and take are LINQ which break with OBservable collections
            //{
            //return FileItems.Skip((CurrentPageNumber - 1) * Properties.Settings.Default.ThumbnailsPerPage).Take(Properties.Settings.Default.ThumbnailsPerPage);
            //}
        }

        /// <summary>
        /// The number of the page currently being looked at.
        /// </summary>
        public int CurrentPageNumber { get; set; } = 1;

        /// <summary>
        /// The total number of pages for the search result.
        /// </summary>
        public int TotalPages 
        { 
            get
            {
                //Divides the total items but the items per page to get the total number of pages
                //Sets the pages to 1 if the collection has 0 items
                //Assumes that ThumbnailsPerPage > 0. This can break otherwise
                return (int)(((FileItems.Count - 1) / Properties.Settings.Default.ThumbnailsPerPage) + 1);
            } 
        }

        #endregion

        public SearchTabViewModel(string startingSearch = "", bool searchImmediately = false)
        {
            if (startingSearch == "")
            {
                TabName = "New Search";
            }
            else
            {
                TabName = startingSearch;
            }


            if (searchImmediately)
            {
                //TODO: Search immediately if true
            }

        }

    }
}
