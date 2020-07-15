using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;

namespace LocalImageTagger.ViewModels
{
    class NewCategoryWindowViewModel : BaseViewModel
    {
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

        public NewCategoryWindowViewModel()
        {

        }

    }
}
