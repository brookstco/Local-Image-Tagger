using System.Windows.Media;

namespace LocalImageTagger.ViewModels
{
    public class BaseTabViewModel : BaseViewModel
    {
        /// <summary>
        /// The name of the tab.
        /// </summary>
        public string TabName { get; set; }

        /// <summary>
        /// The number of the tab.
        /// </summary>
        public int TabNumber { get; set; }

        /// <summary>
        /// Whether the tab is pinned or not.
        /// Pinned tabs always appear first
        /// </summary>
        public bool IsPinned { get; set; }

        /// <summary>
        /// The Icon for the tag as an <see cref="ImageSource"/>.
        /// </summary>
        public ImageSource TabIcon { get; set; }

    }
}
