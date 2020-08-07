
using System;
using System.Windows;

namespace LocalImageTagger.Database
{
    public static class DatabaseError
    {
        /// <summary>
        /// Displays a Error message box with general information for the user.
        /// </summary>
        /// <param name="ex">The exception. </param>
        public static void DatabaseErrorUnknownMessage(Exception ex)
        {
            MessageBox.Show($"The error [ {ex.Message} ] occured with the database. Ensure that the database exists at ./Database and is named TagDatabase.db then retry the operation.", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// Displays a Error message box with the error code.
        /// </summary>
        /// <param name="ex">The exception. </param>
        public static void OtherErrorMessage(Exception ex)
        {
            MessageBox.Show($"An error occured during database access and is not a database error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
