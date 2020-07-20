using System;
using System.Collections.Generic;
using System.Text;

namespace LocalImageTagger
{
    /// <summary>
    /// Holds the locations and metadata about a directory that the tagged files are inside of
    /// </summary>
    class FileLocation
    {
        /// <summary>
        /// The directory's uri
        /// </summary>
        private string uri;

        /// <summary>
        /// Only the contents of this folder (False) or inclusing all subdirectories too(true)
        /// </summary>
        private bool subdirectoriesIncluded;

    }
}
