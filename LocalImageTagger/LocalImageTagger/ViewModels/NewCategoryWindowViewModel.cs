using LocalImageTagger.Database;
using LocalImageTagger.Properties;
using System.Windows;

namespace LocalImageTagger.ViewModels
{
    class NewCategoryWindowViewModel : BaseViewModel
    {
        #region Properties

        /// <summary>
        /// The current width of the window. Used for perserving window adjustments.
        /// </summary>
        public double WindowWidth { get; set; }

        /// <summary>
        /// The current height of the window. Used for perserving window adjustments.
        /// </summary>
        public double WindowHeight { get; set; }

        private bool checkboxDefault = false;

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

        public NewCategoryWindowViewModel()
        {
            //Set the window size when opening
            WindowWidth = 400;
            WindowHeight = 300;
        }

    }
}
