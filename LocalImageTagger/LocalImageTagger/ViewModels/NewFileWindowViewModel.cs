using LocalImageTagger.Database;
using LocalImageTagger.Files;
using PropertyChanged;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Forms;

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
        /// Opens a dialog to select new File(s) to import to the program. Clears previous selections
        /// </summary>
        public RelayCommand AddMoreFilesCommand { get; private set; }

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

        /// <summary>
        /// String for the button.
        /// </summary>
        public string ButtonTextReplaceFiles { get { return FilesSelected ? "Replace New Files" : "Add New Files"; } }

        /// <summary>
        /// String for the button.
        /// </summary>
        public string ButtonTextAddMoreFiles { get { return "Add More New Files"; } }

        /// <summary>
        /// The user-selected files in NewFile form in a observable collection so that the UI updates.
        /// </summary>
        public ObservableCollection<NewFile> Files { get; private set; }

        /// <summary>
        /// Returns true if Files has 1 or more files in it and false if it is empty.
        /// </summary>
        public bool FilesSelected { get; private set; } // originally this, but wouldn't update UI. { get { return Files.Any(); } }

        #endregion

        #region constructor

        public NewFileWindowViewModel()
        {
            AddNewFilesCommand = new RelayCommand(addNewFiles);
            AddMoreFilesCommand = new RelayCommand(addMoreFiles);
            Close = new RelayCommand<Window>(CloseHelper.CloseWindow);
            SaveAndClose = new RelayCommand<Window>(saveAndClose);

            Files = new ObservableCollection<NewFile>();

            //Listen for changes to update the UI
            Files.CollectionChanged += OnCollectionChanged;
        }

        #endregion

        #region Methods

        //Overrules Fody, so needs to supress the unneeded warning.
        [SuppressPropertyChangedWarnings]
        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            //Simply having the notify property go seems to be broken due to using Fody Weaver.
            //Removing Fody weaver and manually fixing this all would improve efficiency in a few places probably.
            //PropertyChanged(new PropertyChangedEventArgs(nameof(FilesSelected)));
            FilesSelected = Files.Any();
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
        private void addMoreFiles()
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
        private void addFilesToDB()
        {
            //This will return error codes, but right now it has its own popups, so nothing needed afaik
            //It needs an IEnumerable, so observable collection is all good
            SQLiteDataAccess.AddNewFiles(Files);
        }

        /// <summary>
        /// Saves the Files to the DB then closes the window.
        /// </summary>
        /// <param name="window">The window doing the closing.</param>
        private void saveAndClose(Window window)
        {
            addFilesToDB();
            CloseHelper.CloseWindow(window);
        }

        #endregion

    }
}
