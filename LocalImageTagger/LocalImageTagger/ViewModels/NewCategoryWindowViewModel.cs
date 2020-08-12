using LocalImageTagger.Database;
using LocalImageTagger.Properties;
using System.Windows;

namespace LocalImageTagger.ViewModels
{
    class NewCategoryWindowViewModel : BaseViewModel
    {
        //Locals

        private bool checkboxDefault = false;

        private static string defaultColor = "#000000";
        private static int defaultPriority = 5;

        #region Properties

        /// <summary>
        /// The user-entered name of the new category
        /// </summary>
        public string NameText { get; set; }

        /// <summary>
        /// The user-entered Color of the new category
        /// </summary>
        public string ColorText { get; set; } = defaultColor;

        /// <summary>
        /// The user-entered Priority of the new category
        /// </summary>
        public int PriorityText { get; set; } = defaultPriority;


        /// <summary>
        /// Controls the visibility of the Warning for setting a new default
        /// </summary>
        public Visibility WarningVisibility { get; set; } = Visibility.Collapsed;

        /// <summary>
        /// The status of the checkbox. True=checked
        /// </summary>
        public bool CheckboxChecked
        {
            get
            {
                return checkboxDefault;
            }
            set
            {
                checkboxDefault = value;
                //Also updates the warning visibility whenever this changes.
                if (CheckboxChecked)
                {
                    WarningVisibility = Visibility.Visible;
                }
                else
                {
                    WarningVisibility = Visibility.Collapsed;
                }
            }
        }

        /// <summary>
        /// The current default category.
        /// This will be replaced if a new one is selected
        /// </summary>
        public string CurrentDefaultCategory
        {
            get
            {
                var cat = SQLiteDataAccess.GetCategoryByID(Settings.Default.DefaultCategoryID);
                if (cat == null)
                {
                    return "ERROR";
                }
                else
                {
                    return cat.Name;
                }
            }
        }

        #endregion

        #region Commands

        /// <summary>
        /// Closes the window (using MVVM).
        /// </summary>
        public RelayCommand<Window> Close { get; private set; }

        /// <summary>
        /// Saves the Category to the DB then closes the window.
        /// </summary>
        public RelayCommand<Window> SaveAndClose { get; private set; }


        #endregion

        public NewCategoryWindowViewModel()
        {
            Close = new RelayCommand<Window>(CloseHelper.CloseWindow);
            SaveAndClose = new RelayCommand<Window>(saveAndClose);

        }

        #region Methods

        /// <summary>
        /// Saves the Category to the DB then closes the window.
        /// </summary>
        /// <param name="window">The window doing the closing.</param>
        private void saveAndClose(Window window)
        {
            
            CloseHelper.CloseWindow(window);
        }

        #endregion

    }
}
