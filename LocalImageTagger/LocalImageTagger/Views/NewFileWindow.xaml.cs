using LocalImageTagger.ViewModels;
using System.Windows;

namespace LocalImageTagger.Views
{
    /// <summary>
    /// Interaction logic for NewFileWindow.xaml
    /// </summary>
    public partial class NewFileWindow : Window
    {
        public NewFileWindow()
        {
            InitializeComponent();
            DataContext = new NewFileWindowViewModel();
        }
    }
}
