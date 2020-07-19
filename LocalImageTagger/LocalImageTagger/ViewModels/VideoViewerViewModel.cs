using System;
using System.Collections.Generic;
using System.Text;

namespace LocalImageTagger.ViewModels
{
    class VideoViewerViewModel : BaseViewModel
    {
        #region Properties

        /// <summary>
        /// The minimum width that the windows can be adjusted to.
        /// </summary>
        public double WindowMinimumWidth { get; set; } = 200;

        /// <summary>
        /// The minimum height that the windows can be adjusted to.
        /// </summary>
        public double WindowMinimumHeight { get; set; } = 200;

        /// <summary>
        /// The current width of the window. Used for perserving window adjustments.
        /// </summary>
        public double WindowWidth { get; set; }

        /// <summary>
        /// The current height of the window. Used for perserving window adjustments.
        /// </summary>
        public double WindowHeight { get; set; }

        #endregion

        public VideoViewerViewModel()
        {
            //Set the window size when opening
            WindowWidth = 800;
            WindowHeight = 450;
        }
    }
}
