﻿using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Windows.Input;

namespace LocalImageTagger.ViewModels
{
    class NewFileLocationWindowViewModel : BaseViewModel
    {

        #region Commands
        /// <summary>
        /// Opends a dialog to select a directory
        /// </summary>
        public RelayCommand ChooseDirectory { get; set; }

        #endregion


        #region Properties

        /// <summary>
        /// The current width of the window. Used for perserving window adjustments.
        /// </summary>
        public double WindowWidth { get; set; }

        /// <summary>
        /// The current height of the window. Used for perserving window adjustments.
        /// </summary>
        public double WindowHeight { get; set; }

        /// <summary>
        /// The directory that was chosen to be added
        /// </summary>
        public string ChosenDirectory { get; set; }

        /// <summary>
        /// The status of the checkbox. True=checked
        /// </summary>
        public bool CheckboxChecked { get; set; }

        #endregion



        public NewFileLocationWindowViewModel()
        {
            ChooseDirectory = new RelayCommand(SelectDirectory);

            //Set the window size when opening
            WindowWidth = 400;
            WindowHeight = 300;

        }

        private void SelectDirectory()
        {
            //TODO: Use settings to remember the last used location. Do this for at least adding new images
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "C:\\Users";
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                ChosenDirectory = dialog.FileName;
            }
        }
    }
}
