using Microsoft.WindowsAPICodePack.Dialogs;
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
        public ICommand ChooseDirectory { get; set; }

        #endregion


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
