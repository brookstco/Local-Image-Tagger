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
        //TODO: Full screen and sidebar close (and probably some zoom/pan controls) should be always on screen, but fade out when the window isn't interacted with.
        //TODO: Fullscreen needs a keyboard escape (like esc)


        /// <summary>
        /// Bool for whether the sidebar with tags is open (true) or not (false)
        /// </summary>
        //private bool sideBarOpen = true;

        #region Properties

        /// <summary>
        /// The minimum width that the windows can be adjusted to.
        /// </summary>
        public double WindowMinimumWidth { get; set; } = 100;

        /// <summary>
        /// The minimum height that the windows can be adjusted to.
        /// </summary>
        public double WindowMinimumHeight { get; set; } = 100;

        /// <summary>
        /// The current width of the window. Used for perserving window adjustments.
        /// </summary>
        public double WindowWidth { get; set; }

        /// <summary>
        /// The current height of the window. Used for perserving window adjustments.
        /// </summary>
        public double WindowHeight { get; set; }

        /// <summary>
        /// The position of the window's left side.
        /// </summary>
        public double WindowLeft { get; set; }

        /// <summary>
        /// The position of the window's top side.
        /// </summary>
        public double WindowTop { get; set; }

        /// <summary>
        /// Window Style used for full screening the app
        /// </summary>
        public WindowStyle WindowStyle { get; set; }

        /// <summary>
        /// Window State used for full screening the app
        /// </summary>
        public WindowState WindowState { get; set; }

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
        /// Controls the column of the sidebar button, so that space isn't unnecesarily reserved
        /// </summary>
        public string ButtonSidebarColumn { get; private set; }

        /// <summary>
        /// Controls the H alignment of the sidebar button, so it is on the correct side
        /// </summary>
        public HorizontalAlignment ButtonSidebarHorizontalAlignment { get; private set; }

        /// <summary>
        /// Bool for whether the sidebar with tags is open (true) or not (false).
        /// </summary>
        public bool SidebarVisible { get; private set; }

        #endregion

        #region Commands

        /// <summary>
        /// Toggles fullscreen
        /// </summary>
        public ICommand ToggleFullscreen { get; private set; }

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
            OpenCloseSidebar = new RelayCommand(toggleSideBar);
            ToggleFullscreen = new RelayCommand(toggleFullscreen);

            //TODO: Temporary image. This should be passed in instead when this is opened
            Image = new BitmapImage(new Uri(Path.Join("C:", "Users", "Colin", "Pictures", "untitled.png")));

            //Default Settings
            ImageStretch = Stretch.Uniform;

            //Set up the non-binded settings. These should update on close, but not actively
            RenderingBitmapScalingMode = Properties.Settings.Default.ImageViewerRenderingMode;
            setRenderingButtonText();

            SidebarVisible = true;
            SidebarVisible = Properties.Settings.Default.ImageViewerSideMenuVisibile;
            setSidebarVisibility();

            WindowHeight = Properties.Settings.Default.ImageViewerHeight;
            WindowWidth = Properties.Settings.Default.ImageViewerWidth;

            WindowLeft = Properties.Settings.Default.ImageViewerLeft;
            WindowTop = Properties.Settings.Default.ImageViewerTop;

            //Use revert to set not fullscreen at the start
            revertFullscreen();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Toggles fullscreen for this window
        /// </summary>
        public void toggleFullscreen()
        {
            //If maximized
            if (WindowStyle == WindowStyle.None)
            {
                revertFullscreen();
            }
            else
            {
                makeFullscreen();
            }
        }

        private void makeFullscreen()
        {
            WindowStyle = WindowStyle.None;
            WindowState = WindowState.Maximized;
        }
        private void revertFullscreen()
        {
            WindowStyle = WindowStyle.SingleBorderWindow;
            WindowState = WindowState.Normal;

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

        #region Rendering Methods

        /// <summary>
        /// Set the rendering mode of the image to NearestNeighbor for Pixel Art
        /// </summary>
        /// <param name="mode">BitmapScalingMode enum</param>
        private void setRenderingModeNN()
        {
            RenderingBitmapScalingMode = BitmapScalingMode.NearestNeighbor;
        }

        /// <summary>
        /// Set the rendering mode of the image to Default
        /// </summary>
        /// <param name="mode">BitmapScalingMode enum</param>
        private void setRenderingModeDefault()
        {
            RenderingBitmapScalingMode = BitmapScalingMode.Unspecified;
        }

        /// <summary>
        /// Set the rendering mode of the image to high Quality
        /// </summary>
        /// <param name="mode">BitmapScalingMode enum</param>
        private void setRenderingModeHQ()
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
                setRenderingModeNN();
            }
            else //if (RenderingBitmapScalingMode == BitmapScalingMode.NearestNeighbor) //If there are more options, don't have this be the default
            {
                setRenderingModeDefault();
            }
            setRenderingButtonText();
        }

        /// <summary>
        /// Sets the buttons to have text appropratie for the current rendering mode
        /// </summary>
        private void setRenderingButtonText()
        {
            if (RenderingBitmapScalingMode == BitmapScalingMode.NearestNeighbor)
            {
                ButtonRenderContent = "Render Linear";
                ButtonRenderToolTip = "Changes the image to render Linear (smooth) instead of the current Nearest Neighbor (pixel-perfect)";
            }
            else //if (RenderingBitmapScalingMode == BitmapScalingMode.NearestNeighbor) //If there are more options, don't have this be the default
            {
                ButtonRenderContent = "Render with NN";
                ButtonRenderToolTip = "Changes the image to render with Nearest Neighbor (pixel-perfect) instead of the current Linear (smooth)";
            }

        }

        #endregion


        /// <summary>
        /// Toggle the sidebar in or out
        /// </summary>
        public void toggleSideBar()
        {
            SidebarVisible = !SidebarVisible;
            setSidebarVisibility();
        }

        private void setSidebarVisibility()
        {
            //The content inside matches the if statement (open controls first, then closed)
            if (SidebarVisible)
            {
                ButtonSidebarDirection = "1";
                ButtonSidebarColumn = "0";
                ButtonSidebarHorizontalAlignment = HorizontalAlignment.Right;
            }
            else
            {
                ButtonSidebarDirection = "-1";
                ButtonSidebarColumn = "1";
                ButtonSidebarHorizontalAlignment = HorizontalAlignment.Left;
            }

        }

        #endregion

        /// <summary>
        /// Updates the settings files with the variables used locally
        /// </summary>
        private void updateSettings()
        {
            Properties.Settings.Default.ImageViewerRenderingMode = RenderingBitmapScalingMode;
            Properties.Settings.Default.ImageViewerSideMenuVisibile = SidebarVisible;
            Properties.Settings.Default.ImageViewerWidth = WindowWidth;
            Properties.Settings.Default.ImageViewerHeight = WindowHeight;
            Properties.Settings.Default.ImageViewerLeft = WindowLeft;
            Properties.Settings.Default.ImageViewerTop = WindowTop;

            //Must manually save if not binding
            Properties.Settings.Default.Save();
        }

    }
}
