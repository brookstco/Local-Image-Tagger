
namespace LocalImageTagger.ViewModels
{
    class NewTagWindowViewModel : BaseViewModel
    {
        #region Properties

        /// <summary>
        /// The current width of the window. Used for perserving window adjustments.
        /// </summary>
        public double WindowWidth { get; set; }

        /// <summary>
        /// The current height of the window. Used for perserving window adjustments.
        /// </summary>
        public double WindowHeight { get; set; }

        #endregion

        public NewTagWindowViewModel()
        {
            //Set the window size when opening
            WindowWidth = 400;
            WindowHeight = 300;
        }
    }
}
