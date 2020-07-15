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
        public string ChosenDirectory { get; set; }

        /// <summary>
        /// The status of the checkbox. True=checked
        /// </summary>
        public bool CheckboxChecked {get; set;}


        public NewFileLocationWindowViewModel()
        {
            ChooseDirectory = new RelayCommand(SelectDirectory);

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
