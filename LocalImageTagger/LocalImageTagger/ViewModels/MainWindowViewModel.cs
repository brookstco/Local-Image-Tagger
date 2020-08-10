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
        /// Removes a tab with int ID.
        /// </summary>
        public RelayCommand<int> RemoveTabCommand { get; private set; }

        /// <summary>
        /// Opens a new <see cref="NewFileWindow"/> with this as the owner
        /// </summary>
        public RelayCommand<Window> OpenNewFileDialog { get; private set; }

        /// <summary>
        /// Opens a new <see cref="NewTagWindow"/> with this as the owner
        /// </summary>
        public RelayCommand<Window> OpenNewTagDialog { get; private set; }

        /// <summary>
        /// Opens a new <see cref="NewCategoryWindow"/> with this as the owner
        /// </summary>
        public RelayCommand<Window> OpenNewCatDialog { get; private set; }

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

            AddTabCommand = new RelayCommand(AddNewSearchTab);

            OpenNewFileDialog = new RelayCommand<Window>(DialogHelper.OpenNewFileDialog);
            OpenNewTagDialog = new RelayCommand<Window>(DialogHelper.OpenNewTagDialog);
            OpenNewCatDialog = new RelayCommand<Window>(DialogHelper.OpenNewCategoryDialog);
        }

        #endregion


        #region Medthods

        /// <summary>
        /// Closes the selected tab by removing it from the tab list.
        /// </summary>
        /// <param name="tab">The tab to remove.</param>
        public void CloseTab(BaseTabViewModel tab)
        {
            TabCollection.Remove(tab);
        }

        /// <summary>
        /// Adds a new <see cref="SearchTabViewModel"/> to the tab list.
        /// </summary>
        public void AddNewSearchTab()
        {
            TabCollection.Add(new SearchTabViewModel());
        }


        #endregion
    }
}
