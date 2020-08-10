
namespace LocalImageTagger
{
    /// <summary>
    /// Item that is used as the header for a tab.
    /// Modified for the code by Leif Simon Goodwin at https://www.codeproject.com/Articles/5266461/A-WPF-Tab-Header-Control-with-Scroll-Buttons-Movea in the WpfTabControlLibrary
    /// </summary>
    class TabHeaderItem
    {
        /// <summary>
        /// The label of the tab header.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The ID of the tab header.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The Text that is displayed in the tab header
        /// </summary>
        public string HeaderText
        {
            get
            {
                return Label;// + " : " + ID;
            }
        }
    }
}
