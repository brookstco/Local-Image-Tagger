using System.Windows;

namespace LocalImageTagger
{
    public static class CloseHelper
    {
        /// <summary>
        /// Closes a window. 
        /// Permits MVVM style window closing, but isn't pure MVVM, since the VM will see the view while the view is passed in. An interface could be used, but is excessive in this project.
        /// </summary>
        /// <param name="window"></param>
        public static void CloseWindow(Window window)
        {
            if (window != null)
            {
                window.Close();
            }
        }

    }
}
