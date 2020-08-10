using LocalImageTagger.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace LocalImageTagger.ViewModels
{
    class MainWindowViewModel
    {

        #region Properties

        //#region Window information
        ///// <summary>
        ///// The minimum width that the windows can be adjusted to.
        ///// </summary>
        //public double WindowMinimumWidth { get; set; } = 400;

        ///// <summary>
        ///// The minimum height that the windows can be adjusted to.
        ///// </summary>
        //public double WindowMinimumHeight { get; set; } = 300;

        ///// <summary>
        ///// The current width of the window. Used for perserving window adjustments.
        ///// </summary>
        //public double WindowWidth { get; set; } = 1000;

        ///// <summary>
        ///// The current height of the window. Used for perserving window adjustments.
        ///// </summary>
        //public double WindowHeight { get; set; } = 600;

        //#endregion

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

        #region Commands

        /// <summary>
        /// Adds a new tab.
        /// </summary>
        public RelayCommand AddTabCommand { get; private set; }

        /// <summary>
        /// Removes a specific tab.
        /// </summary>
        public RelayCommand<BaseTabViewModel> RemoveTabCommand { get; private set; }

        /// <summary>
        /// Opens a new <see cref="NewFileWindow"/> with this as the owner
        /// </summary>
        public RelayCommand<Window> OpenNewFileDialogCommand { get; private set; }

        /// <summary>
        /// Opens a new <see cref="NewTagWindow"/> with this as the owner
        /// </summary>
        public RelayCommand<Window> OpenNewTagDialogCommand { get; private set; }

        /// <summary>
        /// Opens a new <see cref="NewCategoryWindow"/> with this as the owner
        /// </summary>
        public RelayCommand<Window> OpenNewCatDialogCommand { get; private set; }

        #endregion


        #region Constructor

        public MainWindowViewModel()
        {
            TabCollection = new ObservableCollection<BaseTabViewModel>();

            //TODO: The default needs to be loaded from settings. So the distribution should be a blank search tab
            //Default with a single search tab open
            TabCollection.Add(new SearchTabViewModel());

            //Set the original selected tab to the first one there
            SelectedTab = TabCollection.FirstOrDefault();

            AddTabCommand = new RelayCommand(addNewSearchTab);
            RemoveTabCommand = new RelayCommand<BaseTabViewModel>(closeTab);
            OpenNewFileDialogCommand = new RelayCommand<Window>(DialogHelper.OpenNewFileDialog);
            OpenNewTagDialogCommand = new RelayCommand<Window>(DialogHelper.OpenNewTagDialog);
            OpenNewCatDialogCommand = new RelayCommand<Window>(DialogHelper.OpenNewCategoryDialog);
        }

        #endregion


        #region Medthods

        /// <summary>
        /// Closes the selected tab by removing it from the tab list.
        /// </summary>
        /// <param name="tab">The tab to remove.</param>
        private void closeTab(BaseTabViewModel tab)
        {
            TabCollection.Remove(tab);
        }

        /// <summary>
        /// Adds a new <see cref="SearchTabViewModel"/> to the tab list.
        /// </summary>
        private void addNewSearchTab()
        {
            TabCollection.Add(new SearchTabViewModel());
        }

        private void confirmAndClose()
        {

            //TODO: When closing, prompt about closing, and have a checkbox for not having that warning anymore

            //Have the popup be ok or cancel. On okay, exit. Nothing otherwise.

        }

        #endregion
    }
}
