using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Windows.Input;

namespace LocalImageTagger.ViewModels
{
    class NewFileLocationWindowViewModel : BaseViewModel
    {
        public string ChosenDirectory { get; set; }

        public ICommand ChooseDirectory { get; set; }

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
                //MessageBox.Show("You selected: " + dialog.FileName);
                ChosenDirectory = dialog.FileName;
            }
        }
    }
}
