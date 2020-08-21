using LocalImageTagger.ViewModels;
using System.Windows;

namespace LocalImageTagger.Views
{
    /// <summary>
    /// Interaction logic for NewCategoryWindow.xaml
    /// </summary>
    public partial class NewCategoryWindow : Window
    {
        public NewCategoryWindow()
        {
            InitializeComponent();
            //TODO: I can use this same view for both add and edit. Pass in viewmodel to allow for either? Also needs more of the data to be bound anyway, but def for this.
            DataContext = new NewCategoryWindowViewModel();
        }
    }
}
