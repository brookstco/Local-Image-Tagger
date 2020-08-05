using Dapper;
using LocalImageTagger.Files;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace LocalImageTagger.Database
{
    public class SQLiteDataAccess
    {
        //NOTE: SQLite writes are atomic and limited by transation, but each transaction can have many writes or reads. Bundle things together to improve performance

        /// <summary>
        /// Returns the saved connection string for the SQLite database
        /// </summary>
        private static string LoadConnectionString()
        {
            return Properties.Settings.Default.DatabaseConnectionString;
        }

        /// <summary>
        /// Returns a list of FileItems based on the given IDs from the DB.
        /// </summary>
        /// <returns>A List of FileItems.</returns>
        public static List<FileItem> LoadFiles()
        {
            //The using will ensure that the DB is closed, even on a crash
            using (IDbConnection db = new SQLiteConnection(LoadConnectionString()))
            {
                //Returns an enumerabe
                var output = db.Query<FileItem>("select * from Files", new DynamicParameters());
                return output.ToList();
            }
        }

        /// <summary>
        /// Adds a new File to the DB.
        /// </summary>
        /// <param name="Uri">The full path to the file.</param>
        public static void AddFiles(string Uri)
        {
            using (IDbConnection db = new SQLiteConnection(LoadConnectionString()))
            {
                db.Execute("insert into Files (URI) values (Uri) ", new { Uri });
            }

        }

    }
}
