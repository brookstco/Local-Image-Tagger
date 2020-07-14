using System;
using System.IO;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace LocalImageTagger.ViewModels
{
    class ImageViewerViewModel : BaseViewModel
    {
        /// <summary>
        /// The viewmodel to display the appropraite file type
        /// </summary>
        //public BaseViewModel SelectedDisplayType { get; set; }

        /// <summary>
        /// Command to swap the stretch property for the window
        /// </summary>
        public ICommand SwapSize { get; set; }

        /// <summary>
        /// The current Stretch property for the image
        /// Set as an enum: 0 = None, 2 = Uniform
        /// </summary>
        public int ImageStretch { get; set; }

        //TODO:  May be better to use a converter to allow zoom
        /// <summary>
        /// The Bitmap image form of the image.
        /// </summary>
        public BitmapImage Image { get; set; }


        /// <summary>
        /// Constructor
        /// </summary>
        public ImageViewerViewModel()
        {
            //SelectedDisplayType = new ImageDisplayViewModel();
            SwapSize = new RelayCommand(swapSize);
            Image = new BitmapImage(new Uri(Path.Join("C:", "Users", "Colin", "Pictures", "untitled.png")));
            ImageStretch = 0;
        }

        /// <summary>
        /// Swaps the image's stretch property between Uniform and None
        /// </summary>
        public void swapSize()
        {
            if (ImageStretch == 0)
            {
                ImageStretch = 2; //Uniform
            }
            else
            {
                ImageStretch = 0; //None
            }
        }

    }
}
