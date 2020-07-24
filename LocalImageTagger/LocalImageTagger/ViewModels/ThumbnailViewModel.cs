using System;
using System.Collections.Generic;
using System.Text;

namespace LocalImageTagger.ViewModels
{
    /// <summary>
    /// A thumbnail displays an image of the fileItem and is cliackable to interact with it
    /// </summary>
    class ThumbnailViewModel : BaseViewModel
    {
        /// <summary>
        /// The <see cref="FileItem" that is displayed in the fileItem/>
        /// </summary>
        FileItem file;

        //TODO: Colored border?
        //TODO: Click actions - Make the entire thumbnail a button instead? Will need to differentiate clicks and double clicks
        //Click to tag, double click to view


        public ThumbnailViewModel(FileItem fileItem)
        {
            file = fileItem;
        }

    }
}
