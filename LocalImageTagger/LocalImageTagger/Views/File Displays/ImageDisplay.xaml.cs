using LocalImageTagger.ViewModels;
using System.Windows.Controls;

namespace LocalImageTagger.Views
{
    /// <summary>
    /// Interaction logic for ImageDIsplay.xaml
    /// </summary>
    public partial class ImageDisplay : UserControl
    {
        public ImageDisplay()
        {
            InitializeComponent();
            DataContext = new ImageDisplayViewModel();
        }
    }
}
