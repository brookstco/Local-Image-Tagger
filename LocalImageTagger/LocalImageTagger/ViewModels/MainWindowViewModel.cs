using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LocalImageTagger.ViewModels
{
    class MainWindowViewModel
    {

        #region Properties

        #region Window information
        /// <summary>
        /// The minimum width that the windows can be adjusted to.
        /// </summary>
        public double WindowMinimumWidth { get; set; } = 400;

        /// <summary>
        /// The minimum height that the windows can be adjusted to.
        /// </summary>
        public double WindowMinimumHeight { get; set; } = 300;

        /// <summary>
        /// The current width of the window. Used for perserving window adjustments.
        /// </summary>
        public double WindowWidth { get; set; } = 1000;

        /// <summary>
        /// The current height of the window. Used for perserving window adjustments.
        /// </summary>
        public double WindowHeight { get; set; } = 600;

        #endregion

        #region Tabs

        /// <summary>
        /// All of the current tabs in a collection that will be updated in the UI.
        /// </summary>
        public ObservableCollection<BaseTabViewModel> TabCollection { get; set; }

        /// <summary>
        /// The currently selected tab.
        /// </summary>
        public BaseTabViewModel SelectedTab { get; set; }


        #endregion

        #endregion

        #region Constructor

        public MainWindowViewModel()
        {
        }

        #endregion


        #region Medthods

        /// <summary>
        /// Closes the selected tab by removing it from the tab list.
        /// </summary>
        /// <param name="tab"></param>
        void CloseTabCommandAction(BaseTabViewModel tab)
        {
            TabCollection.Remove(tab);
        }

        /// <summary>
        /// Adds a new tab to the tab list.
        /// Specifically adds a new <see cref="SearchTabViewModel"/>.
        /// </summary>
        void AddTabCommandAction()
        {
            TabCollection.Add(new SearchTabViewModel());
        }

        #endregion
    }
}
