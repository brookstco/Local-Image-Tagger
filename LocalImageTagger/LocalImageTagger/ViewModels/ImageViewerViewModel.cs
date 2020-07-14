using System.Windows.Input;

namespace LocalImageTagger.ViewModels
{
    class ImageViewerViewModel : BaseViewModel
    {
        /// <summary>
        /// The viewmodel to display the appropraite file type
        /// </summary>
        public BaseViewModel SelectedDisplayType { get; set; }

        public ICommand SwapSize { get; set; }

        public ImageViewerViewModel()
        {
            SelectedDisplayType = new ImageDisplayViewModel();
            SwapSize = new RelayCommand(((ImageDisplayViewModel)SelectedDisplayType).swapSize);
        }


    }
}
