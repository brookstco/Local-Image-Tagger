using Dapper;
using LocalImageTagger.Files;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        /// Returns a list of FileItems based on the given DB FileIDs.
        /// If no FileIds are in the IEnumerable<int>, returns everything. 
        /// If there is no IEnumerable<int> or there is an error, return null.
        /// </summary>
        /// <param name="ids">A list of integer FileIds to return the file data for.</param>
        /// <returns>returns a List of FileItems or null on failure.</returns>
        public static List<FileItem> LoadFilesByID(IEnumerable<int> ids)
        {
            if (ids == null) //There is no IEnumerable<int>
            {
                return null;
            }
            else if (!ids.Any()) //The IEnumerable<int> is empty
            {
                return LoadAllFiles();
            }

            //The IEnumerable<int> exists and has values, so proceed as normal.

            //Defined early to allow a null return at the end.
            List<FileItem> output = null;

            try
            {
                //Closing is automatic with a using and will happen even on an error.
                using (var cn = new SQLiteConnection(LoadConnectionString()))
                {
                    cn.Open();

                    string sqlGetFilesByID = "SELECT * FROM Files WHERE ID IN @IDs";
                    //The IDs are converted into a string for the sql parameter
                    string IdString = string.Join(", ", ids);

                    //TODO: A query with no results should still return an empty list, not null or something else. Confirm this is the case.

                    //Queries using Dapper, subs in the string as the parameter and returns the results as a list
                    output = cn.Query<FileItem>(sqlGetFilesByID, new { IDs = IdString}).ToList();
                }
            }
            catch (SqliteException ex)
            {
                DatabaseError.DatabaseErrorUnknownMessage(ex);
                return null;
            }
            catch (Exception ex)
            {
                DatabaseError.OtherErrorMessage(ex);
                return null;
            }

            return output;
        }


        /// <summary>
        /// Returns all files in a List of FileItems.
        /// </summary>
        /// <returns>Reeturns a List of FileItems or null on failure.</returns>
        public static List<FileItem> LoadAllFiles()
        {
            List<FileItem> output = null;

            try
            {
                //Closing is automatic with a using and will happen even on an error.
                using (var cn = new SQLiteConnection(LoadConnectionString()))
                {
                    cn.Open();

                    string sqlGetFilesByID = "SELECT * FROM Files";

                    //TODO: A query with no results should still return an empty list, not null or something else. Confirm this is the case.

                    //Queries using Dapper, subs in the string as the parameter and returns the results as a list
                    output = cn.Query<FileItem>(sqlGetFilesByID).ToList();
                }
            }
            catch (SqliteException ex)
            {
                DatabaseError.DatabaseErrorUnknownMessage(ex);
                return null;
            }
            catch (Exception ex)
            {
                DatabaseError.OtherErrorMessage(ex);
                return null;
            }

            return output;
        }

        /// <summary>
        /// Adds <see cref="NewFile"/>s to the database. The files are passed in in any IEnumerable, and can have any number.
        /// Due to the nature of SQLITE, passing them all in and using 1 transaction is vastly more efficient that calling this func many times.
        /// </summary>
        /// <param name="files">List of 1 or more <see cref="NewFile"/> files.</param>
        /// <returns>The <see cref="int"/> amount of modified records or -1 if there was an error.</returns>
        public static int AddNewFiles(IEnumerable<NewFile> files)
        {
            //Used code from https://www.codeproject.com/Articles/853842/Csharp-Avoiding-Performance-Issues-with-Inserts-in 
            //and https://stackoverflow.com/questions/9006604/improve-performance-of-sqlite-bulk-inserts-using-dapper-orm to ensure that SQLITE will insert efficiently

            var results = new List<int>();

            try { 
                //Closing is automatic with a using and will happen even on an error.
                using (var cn = new SQLiteConnection(LoadConnectionString()))
                {
                    //Opening is not implicit
                    cn.Open();

                    //Transatctions always happen in SQLite and doing a transaction per insert is terribly slow
                    using (var transaction = cn.BeginTransaction())
                    {
                        //Commmands with parameters prevent sql injection, and prevent the overhead in SQLite when doing a batch in one transaction
                        using (var cmd = cn.CreateCommand())
                        {
                            //Switching from @path to ? as a test, since the params weren't working
                            //string sqlInsertFile = @"INSERT INTO Files (FullPath) VALUES (@Path);";

                            cmd.CommandText = "INSERT OR IGNORE INTO Files (FullPath) VALUES (?);"; //sqlInsertFile;

                            SQLiteParameter param = new SQLiteParameter();
                            cmd.Parameters.Add(param); //"@Path"

                            //Insert each file in the list
                            foreach (var file in files)
                            {
                                //cmd.Parameters["@Path"].Value = file.FullPath;
                                param.Value = file.FullPath;
                                results.Add(cmd.ExecuteNonQuery());
                            }
                        }
                        //Finishes and commits the transaction
                        transaction.Commit();
                    }
                }
                return results.Sum();
            }
            catch(SqliteException ex){
                DatabaseError.DatabaseErrorUnknownMessage(ex);
                return -1;
            }
            catch(Exception ex)
            {
                DatabaseError.OtherErrorMessage(ex);
                return -1;
            }
        }




    }
}
