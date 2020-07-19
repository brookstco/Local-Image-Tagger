using System;
using System.Windows.Input;

namespace LocalImageTagger.ViewModels
{
    class FirstTimePopUpViewModel : BaseViewModel
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

        public bool CheckboxChecked { get; set; } = true;

        //
        //These cannot be databound for some reason. Couldn't find any info online about it, so they are here for if I figure it out
        public Uri HyperlinkWiki { get; private set; } = new Uri("https://github.com/brookstco/Local-Image-Tagger");
        public Uri HyperlinkReport { get; private set; } = new Uri("https://github.com/brookstco/Local-Image-Tagger/issues");

        //public Naviga

        //public HyperlinkCommand<Uri> HyperlinkRequest { get; private set; }

        #endregion
        public FirstTimePopUpViewModel()
        {
            //HyperlinkRequest = new HyperlinkCommand.Hyperlink_RequestNavigate();
            //Set the window size when opening
            WindowWidth = 300;
            WindowHeight = 400;
        }

        /// <summary>
        /// Sets the status of the pop-up window opening or not iun the user settings
        /// </summary>
        /// <param name="value"></param>
        private void setPopUpSetting()
        {
            //TODO: SETTINGS NOT IMPLEMENTED
            //setting = checkboxChecked
        }


    }
}
