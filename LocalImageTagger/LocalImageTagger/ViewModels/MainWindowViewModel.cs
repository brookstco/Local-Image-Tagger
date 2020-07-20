using System;
using System.Collections.Generic;
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
        public double WindowWidth { get; set; }

        /// <summary>
        /// The current height of the window. Used for perserving window adjustments.
        /// </summary>
        public double WindowHeight { get; set; }

        #endregion

        #region Tabs

        public ObservableCollection<MyTabClass> ItemCollection { get; set; }
        public MyTabClass SelectedTab { get; set; }
        (...)
        void CloseTabCommandAction(MyTabClass tab)
        {
            ItemCollection.Remove(tab);
        }
        void AddTabCommandAction()
        {
            ItemCollection.Add(New MyTabClass());
        }

        #endregion


        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindowViewModel()
        {
            //Set the window size when opening
            WindowWidth = 1000;
            WindowHeight = 600;
        }
    }
}
