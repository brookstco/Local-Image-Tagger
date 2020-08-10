using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace LocalImageTagger.Views
{
    /// <summary>
    /// Opens up dialog windows
    /// </summary>
    public static class DialogHelper
    {
        //Helpers are split up to make accessing easier even though there is a lot of repitition, it's not complex or hard to change.

        /// <summary>
        /// Opens a New File Dialog at the center of the owner if provided.
        /// </summary>
        /// <param name="owner">Optional. The owner of the dialog, so that it'll be centered.</param>
        public static void OpenNewFileDialog(Window owner = null)
        {
            NewFileWindow dialog = new NewFileWindow();
            if (owner != null) 
            {
                dialog.Owner = owner;
            }
            dialog.Show();
        }

        /// <summary>
        /// Opens a New Tag Dialog at the center of the owner if provided.
        /// </summary>
        /// <param name="owner">Optional. The owner of the dialog, so that it'll be centered.</param>
        public static void OpenNewTagDialog(Window owner = null)
        {
            NewTagWindow dialog = new NewTagWindow();
            if (owner != null)
            {
                dialog.Owner = owner;
            }
            dialog.Show();
        }

        /// <summary>
        /// Opens a New Category Dialog at the center of the owner, if provided.
        /// </summary>
        /// <param name="owner">Optional. The owner of the dialog, so that it'll be centered.</param>
        public static void OpenNewCategoryDialog(Window owner = null)
        {
            NewCategoryWindow dialog = new NewCategoryWindow();
            if (owner != null)
            {
                dialog.Owner = owner;
            }
            dialog.Show();
        }

    }
}
