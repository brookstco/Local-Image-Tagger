using LocalImageTagger.ViewModels;
using System.Windows;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Windows.Input;

namespace LocalImageTagger.Views
{
    /// <summary>
    /// Interaction logic for NewDirectoryWindow.xaml
    /// </summary>
    public partial class NewFileLocationWindow : Window
    {
        public NewFileLocationWindow()
        {
            InitializeComponent();
            //This addition is only really useful once I support more than just images, since I support adding multiple files at once.
            //TODO: I can use this same view for both add and edit. Pass in viewmodel to allow for either? Also needs more of the data to be bound anyway, but def for this.
            DataContext = new NewFileLocationWindowViewModel();
        }

    }
}
