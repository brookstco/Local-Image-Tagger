using Dapper;
using LocalImageTagger.Files;
using Microsoft.Data.Sqlite;
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
            using (IDbConnection cn = new SQLiteConnection(LoadConnectionString()))
            {
                //Returns an enumerabe
                var output = cn.Query<FileItem>("select * from Files", new DynamicParameters());
                return output.ToList();
            }
        }

        /// <summary>
        /// Adds <see cref="NewFile"/>s to the database. The files are passed in in any IEnumerable, and can have any number.
        /// Due to the nature of SQLITE, passing them all in and using 1 transaction is vastly more efficient that calling this func many times.
        /// </summary>
        /// <param name="files">List of 1 or more <see cref="NewFile"/> files.</param>
        /// <returns>The <see cref="int"/> amount of modified records.</returns>
        public static int AddNewFiles(IEnumerable<NewFile> files)
        {
            //Used code from https://www.codeproject.com/Articles/853842/Csharp-Avoiding-Performance-Issues-with-Inserts-in to ensure that SQLITE will insert efficiently

            var results = new List<int>();
            string sqlInsertFile = @"INSERT INTO Files (FullPath) VALUES (@Path);";

            using (var cn = new SQLiteConnection(LoadConnectionString()))
            {
                //OPening shoiuld be implicit in the using
                //cn.Open();
                //Transatctions always happen in SQLite and doing a transaction per insert is terribly slow
                using (var transaction = cn.BeginTransaction())
                {
                    using (var cmd = cn.CreateCommand())
                    {
                        cmd.CommandText = sqlInsertFile;
                        cmd.Parameters.AddWithValue("@Path", SqliteType.Text);

                        //Insert each file in the list
                        foreach (var file in files)
                        {
                            cmd.Parameters["@Path"] = file.FullPath;
                            results.Add(cmd.ExecuteNonQuery());
                        }
                    }
                    //Finishes and commits the transaction
                    transaction.Commit();
                }
            }
            return results.Sum();
        }

    }
}
