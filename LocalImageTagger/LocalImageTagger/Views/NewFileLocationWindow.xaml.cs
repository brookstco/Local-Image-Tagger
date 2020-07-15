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
            DataContext = new NewFileLocationWindowViewModel();
        }

    }
}
