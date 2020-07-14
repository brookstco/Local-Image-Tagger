using LocalImageTagger.ViewModels;
using System.Windows.Controls;

namespace LocalImageTagger.Views
{
    /// <summary>
    /// Interaction logic for VideoDisplay.xaml
    /// </summary>
    public partial class VideoDisplay : UserControl
    {
        public VideoDisplay()
        {
            InitializeComponent();

            DataContext = new VideoDisplayViewModel();
        }
    }
}
