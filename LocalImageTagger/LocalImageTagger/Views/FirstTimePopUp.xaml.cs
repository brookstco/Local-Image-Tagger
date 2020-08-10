using System.Windows;
using LocalImageTagger.ViewModels;

namespace LocalImageTagger
{
    public partial class FirstTimePopUp : Window
    {
        public FirstTimePopUp()
        {
            InitializeComponent();
            DataContext = new FirstTimePopUpViewModel();
        }
    }
}
