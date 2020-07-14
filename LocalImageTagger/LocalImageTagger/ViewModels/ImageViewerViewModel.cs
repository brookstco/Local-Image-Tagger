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

        /// <summary>
        /// Swaps between NN and Normal rendering modes
        /// </summary>
        public ICommand SwapRenderingMode { get; set; }

        #endregion

        #region Properties

        /// <summary>
        /// The Bitmap image form of the image.
        /// </summary>
        public BitmapImage Image { get; set; }

        /// <summary>
        /// The current Stretch property for the image
        /// </summary>
        public Stretch ImageStretch { get; set; }

        /// <summary>
        /// The current rendering mode for the image.
        /// </summary>
        public BitmapScalingMode RenderingBitmapScalingMode { get; set; }

        /// <summary>
        /// The content shown in the rendering swap button. Changes depending on the current rendering mode
        /// </summary>
        public string ButtonRenderContent { get; set; }

        /// <summary>
        /// The content shown in the rendering swap button tooltip. Changes depending on the current rendering mode
        /// </summary>
        public string ButtonRenderToolTip { get; set; }

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
            SwapRenderingMode = new RelayCommand(swapRenderingMode);

            //TODO: Temporary image. This should be passed in instead when this is opened
            Image = new BitmapImage(new Uri(Path.Join("C:", "Users", "Colin", "Pictures", "untitled.png")));

            //Default Settings
            ImageStretch = Stretch.Uniform;
            RenderingBitmapScalingMode = BitmapScalingMode.NearestNeighbor; //So that it is linear once immediately swapped
            swapRenderingMode();
        }

        #region Methods

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

        #region Rendering Methods

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

        /// <summary>
        /// Swap out the rendering mode and button details between NN and Linear
        /// </summary>
        public void swapRenderingMode()
        {
            //Deaults to Unspecified(default) with the else
            //Otherwise, it checks the current, and changes everything to the other
            if(RenderingBitmapScalingMode == BitmapScalingMode.Unspecified)
            {
                ButtonRenderContent = "Render Linear";
                ButtonRenderToolTip = "Changes the image to render Linear (smooth) instead of the current Nearest Neighbor (pixel-perfect)";
                setRenderingModeNN();
            }
            else //if (RenderingBitmapScalingMode == BitmapScalingMode.NearestNeighbor) //If there are more options, don't have this be the default
            {
                ButtonRenderContent = "Render with NN";
                ButtonRenderToolTip = "Changes the image to render with Nearest Neighbor (pixel-perfect) instead of the current Linear (smooth)";
                setRenderingModeDefault();
            }
        }

        #endregion

        #endregion
    }
}
