using LocalImageTagger.Database;
using LocalImageTagger.Files;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Input;

namespace LocalImageTagger.ViewModels
{
    class NewFileWindowViewModel : BaseViewModel
    {

        #region Commands

        /// <summary>
        /// Opends a dialog to select new File(s) to import to the program. Clears previous selections
        /// </summary>
        public RelayCommand AddNewFilesCommand { get; private set; }

        /// <summary>
        /// Opends a dialog to select new File(s) to import to the program. Clears previous selections
        /// </summary>
        public RelayCommand AddMoreFilesCommand { get; private set; }

        #endregion

        #region Properties

        /// <summary>
        /// String for the button.
        /// </summary>
        public string ButtonTextAddNewFiles { get { return "Add New Files"; } }

        /// <summary>
        /// String for the button.
        /// </summary>
        public string ButtonTextReplaceFiles { get { return "Replace New Files"; } }

        /// <summary>
        /// String for the button.
        /// </summary>
        public string ButtonTextAddMoreFiles { get { return "Add More New Files"; } }

        /// <summary>
        /// The user-selected files in NewFile form in a list
        /// </summary>
        public List<NewFile> Files { get; private set; } = new List<NewFile>();

        #endregion


        public NewFileWindowViewModel()
        {
            AddNewFilesCommand = new RelayCommand(addNewFiles);
            AddMoreFilesCommand = new RelayCommand(addNewFiles);

        }

        //Open the dialog and add new files, but delete the old ones first.
        private void addNewFiles()
        {
            var fileDialog = selectFiles();

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                //Empty the list first, but only on successfully pressing okay.
                Files.Clear();

                //Turn the results into usable NewFiles and add them to the list
                foreach (string file in fileDialog.FileNames)
                {
                    Files.Add(new NewFile(file));
                }

            }
        }

        //Open the dialog and add new files to the list.
        private void addMorewFiles()
        {
            var fileDialog = selectFiles();

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                //Turn the results into usable NewFiles and add them to the list
                foreach (string file in fileDialog.FileNames)
                {
                    Files.Add(new NewFile(file));
                }

            }
        }

        //Select 1 or more files, then add them each to the database
        private OpenFileDialog selectFiles()
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                InitialDirectory = "c:\\",
                Filter = "Image files (*.png;*.jpeg;*.bmp;*.tiff)|*.png;*.jpeg;*.bmp;*.tiff|All Files (*.*)|*.*", //Video files (*.mp4)|*.mp4|
                RestoreDirectory = true,
                Multiselect = true,
                Title = "Select File(s) to import"
            };

            return fileDialog;
        }

        //Adds the list of files to the database
        private void AddFilesToDB()
        {
            //This will return error codes, but right now it has its own popups, so nothing needed afaik
            SQLiteDataAccess.AddNewFiles(Files);
        }


    }
}
