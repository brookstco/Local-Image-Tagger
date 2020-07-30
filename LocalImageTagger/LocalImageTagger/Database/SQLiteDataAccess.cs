using LocalImageTagger.Files;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocalImageTagger.Database
{
    public class SQLiteDataAccess
    {
        //NOTE: SQLite writes are atomic and limited by transation, but each transaction can have many writes or reads. Bundle things together to improve performance

        /// <summary>
        /// Loads the connection string to the SQLite database
        /// </summary>
        /// <returns></returns>
        private static string LoadConnectionString()
        {
            return "ERROR";
        }

        /// <summary>
        /// Returns a list of FileItems based on the given IDs from the DB.
        /// </summary>
        /// <returns>A List of FileItems.</returns>
        public static List<FileItem> LoadFiles()
        {
            return null;
        }

        /// <summary>
        /// Adds a new File to the DB.
        /// </summary>
        /// <param name="Uri">The full path to the file.</param>
        public static void AddFile(string Uri)
        {

        }

    }
}
