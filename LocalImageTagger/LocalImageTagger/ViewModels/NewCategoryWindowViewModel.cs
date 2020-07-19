using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;

namespace LocalImageTagger.ViewModels
{
    class NewCategoryWindowViewModel : BaseViewModel
    {
        #region Properties

        /// <summary>
        /// The minimum width that the windows can be adjusted to.
        /// </summary>
        public double WindowMinimumWidth { get; set; } = 200;

        /// <summary>
        /// The minimum height that the windows can be adjusted to.
        /// </summary>
        public double WindowMinimumHeight { get; set; } = 200;

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

        //TODO: Make the getter just directly return the value from the settings or wherever ti is stored.
        /// <summary>
        /// The current default category that will get repalced if this becomes the default
        /// </summary>
        public string CurrentDefaultCategory { get; } = "ERROR";

        #endregion

        public NewCategoryWindowViewModel()
        {
            //Set the window size when opening
            WindowWidth = 400;
            WindowHeight = 300;
        }

    }
}
