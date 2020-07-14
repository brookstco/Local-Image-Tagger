using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace LocalImageTagger.ViewModels
{
    class ImageViewerViewModel : BaseViewModel
    {

        /// <summary>
        /// Bool for whether the sidebar with tags is open (true) or not (false)
        /// </summary>
        private bool sideBarOpen = true;

        #region Commands

        /// <summary>
        /// Command to swap the stretch property for the window
        /// </summary>
        public ICommand SwapSize { get; private set; }

        /// <summary>
        /// Command to set the rendering mode to NearestNeighbor
        /// </summary>
        public ICommand SetRenderingModeNearestNeighbor { get; private set; }

        /// <summary>
        /// Command to set the rendering mode to High Quality
        /// </summary>
        public ICommand SetRenderingModeHighQuality { get; private set; }

        /// <summary>
        /// Command to set the rendering mode to Normal
        /// </summary>
        public ICommand SetRenderingModeNormal { get; private set; }

        /// <summary>
        /// Swaps between NN and Normal rendering modes
        /// </summary>
        public ICommand SwapRenderingMode { get; private set; }

        /// <summary>
        /// Swaps whether the sidebar is open or closed
        /// </summary>
        public ICommand OpenCloseSidebar { get; private set; }

        #endregion

        #region Properties

        /// <summary>
        /// The Bitmap image form of the image.
        /// </summary>
        public BitmapImage Image { get; private set; }

        /// <summary>
        /// The current Stretch property for the image
        /// </summary>
        public Stretch ImageStretch { get; private set; }

        /// <summary>
        /// The current rendering mode for the image.
        /// </summary>
        public BitmapScalingMode RenderingBitmapScalingMode { get; private set; }

        /// <summary>
        /// The content shown in the rendering swap button. Changes depending on the current rendering mode
        /// </summary>
        public string ButtonRenderContent { get; private set; }

        /// <summary>
        /// The content shown in the rendering swap button tooltip. Changes depending on the current rendering mode
        /// </summary>
        public string ButtonRenderToolTip { get; private set; }

        /// <summary>
        /// The direction of the button. Default left = 1, right = -1
        /// </summary>
        public string ButtonSidebarDirection { get; private set; }

        /// <summary>
        /// Controls the visibility of the sidebar elements to make a custom expander
        /// </summary>
        public Visibility SidebarVisibility { get; private set; }

        #endregion

        #region Constructor

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
            OpenCloseSidebar = new RelayCommand(swapSideBar);

            //TODO: Temporary image. This should be passed in instead when this is opened
            Image = new BitmapImage(new Uri(Path.Join("C:", "Users", "Colin", "Pictures", "untitled.png")));

            //Default Settings
            ImageStretch = Stretch.Uniform;
            //Rendering and sidebar start opposite, so that the swap functions can set things up properly. 
            //TODO: Probably should split stuuff into more functions.
            RenderingBitmapScalingMode = BitmapScalingMode.NearestNeighbor;
            swapRenderingMode();
            sideBarOpen = false;
            swapSideBar();
        }

        #endregion

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

        /// <summary>
        /// Opens or closes the sidebar
        /// </summary>

        #endregion

        public void swapSideBar()
        {
            //Do the swap first
            sideBarOpen = !sideBarOpen;
            //The content inside matches the if statement (open controls first, then closed)
            if (sideBarOpen)
            {
                ButtonSidebarDirection = "1";
                SidebarVisibility = Visibility.Visible;
            }
            else
            {
                ButtonSidebarDirection = "-1";
                SidebarVisibility = Visibility.Collapsed;
            }
        }

        #endregion
    }
}
