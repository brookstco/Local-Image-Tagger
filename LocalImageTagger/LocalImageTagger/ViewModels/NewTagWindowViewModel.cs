
using LocalImageTagger.Database;
using LocalImageTagger.Tags;
using System.Windows;

namespace LocalImageTagger.ViewModels
{
    class NewTagWindowViewModel : BaseViewModel
    {
        #region Commands

        /// <summary>
        /// Closes the window (using MVVM).
        /// </summary>
        public RelayCommand<Window> Close { get; private set; }

        /// <summary>
        /// Saves the Files to the DB then closes the window.
        /// </summary>
        public RelayCommand<Window> SaveAndClose { get; private set; }

        #endregion


        #region Properties

        //TODO: my tags don't support being empty, which isn't great. Figure that one out. Maybe blank fields as defaults, and it just checks if the entered info is valid before adding? Or have each as a field and build the tag at the end.
        //Partially fixed, but double check sometime

        public Tag NewTag { get; private set; } //= new FullTag();

        #endregion

        public NewTagWindowViewModel()
        {
            Close = new RelayCommand<Window>(CloseHelper.CloseWindow);
            SaveAndClose = new RelayCommand<Window>(saveAndClose);
        }

        #region Methods


        /// <summary>
        /// Saves the Files to the DB then closes the window.
        /// </summary>
        /// <param name="window">The window doing the closing.</param>
        private void saveAndClose(Window window)
        {
            SQLiteDataAccess.AddNewTag(NewTag);
            CloseHelper.CloseWindow(window);
        }

        #endregion
    }
}
