using LocalImageTagger.ViewModels;
using System.Windows;

namespace LocalImageTagger.Views
{
    /// <summary>
    /// Interaction logic for VideoViewer.xaml
    /// </summary>
    public partial class VideoViewer : Window
    {
        public VideoViewer()
        {
            InitializeComponent();
            DataContext = new VideoViewerViewModel();
        }
    }
}
