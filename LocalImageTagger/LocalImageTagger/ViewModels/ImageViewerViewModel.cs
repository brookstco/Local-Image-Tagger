using System;
using System.IO;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace LocalImageTagger.ViewModels
{
    class ImageViewerViewModel : BaseViewModel
    {
        /// <summary>
        /// The viewmodel to display the appropraite file type
        /// </summary>
        //public BaseViewModel SelectedDisplayType { get; set; }

        #region Commands

        /// <summary>
        /// Command to swap the stretch property for the window
        /// </summary>
        public ICommand SwapSize { get; set; }

        /// <summary>
        /// Command to set the rendering mode to NearestNeighbor
        /// </summary>
        public ICommand SetRenderingModeNearestNeighbor { get; set; }

        /// <summary>
        /// Command to set the rendering mode to High Quality
        /// </summary>
        public ICommand SetRenderingModeHighQuality { get; set; }

        /// <summary>
        /// Command to set the rendering mode to Normal
        /// </summary>
        public ICommand SetRenderingModeNormal { get; set; }

        #endregion

        #region Properties

        /// <summary>
        /// The current Stretch property for the image
        /// </summary>
        public Stretch ImageStretch { get; set; }

        /// <summary>
        /// The Bitmap image form of the image.
        /// </summary>
        public BitmapImage Image { get; set; }

        /// <summary>
        /// The current rendering mode for the image.
        /// </summary>
        public BitmapScalingMode RenderingBitmapScalingMode { get; set; }

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public ImageViewerViewModel()
        {
            //SelectedDisplayType = new ImageDisplayViewModel();
            SwapSize = new RelayCommand(swapSize);
            SetRenderingModeNearestNeighbor = new RelayCommand(setRenderingModeNN);
            SetRenderingModeHighQuality = new RelayCommand(setRenderingModeHQ);
            SetRenderingModeNormal = new RelayCommand(setRenderingModeDefault);

            //TODO: Temporary image. This should be passed in instead when this is opened
            Image = new BitmapImage(new Uri(Path.Join("C:", "Users", "Colin", "Pictures", "untitled.png")));

            //Default Settings
            ImageStretch = Stretch.Uniform;
            RenderingBitmapScalingMode = BitmapScalingMode.Unspecified;
        }

        /// <summary>
        /// Swaps the image's stretch property between Uniform and None
        /// </summary>
        public void swapSize()
        {
            if (ImageStretch == 0)
            {
                ImageStretch = Stretch.Uniform; //Uniform
            }
            else
            {
                ImageStretch = Stretch.None; //None
            }
        }

        /// <summary>
        /// Set the rendering mode of the image to NearestNeighbor for Pixel Art
        /// </summary>
        /// <param name="mode">BitmapScalingMode enum</param>
        public void setRenderingModeNN()
        {
            RenderingBitmapScalingMode = BitmapScalingMode.NearestNeighbor;
        }
        /// <summary>
        /// Set the rendering mode of the image to Default
        /// </summary>
        /// <param name="mode">BitmapScalingMode enum</param>
        public void setRenderingModeDefault()
        {
            RenderingBitmapScalingMode = BitmapScalingMode.Unspecified;
        }
        /// <summary>
        /// Set the rendering mode of the image to high Quality
        /// </summary>
        /// <param name="mode">BitmapScalingMode enum</param>
        public void setRenderingModeHQ()
        {
            RenderingBitmapScalingMode = BitmapScalingMode.HighQuality;
        }
    }
}
