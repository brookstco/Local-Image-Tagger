using Dapper;
using LocalImageTagger.Files;
using LocalImageTagger.Tags;
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

        #region Connection

        /// <summary>
        /// Returns the saved connection string for the SQLite database
        /// </summary>
        private static string LoadConnectionString()
        {
            return Properties.Settings.Default.DatabaseConnectionString;
        }

        #endregion

        #region Generic Functions
        //For reducing repitition with the common formats

        /// <summary>
        /// Performs an INSERT command into the SQLite DB using Dapper given the SQL command and a preforms parameter object. Returns the number of affected rows or -1 on an error.
        /// </summary>
        /// <param name="sql">The sql command string.</param>
        /// <param name="parameters"> The parameters in "new { param1 = val1, param2 = val2...}" form.</param>
        /// <returns></returns>
        private static int insertSQL(string sql, object parameters)
        {
            int affectedRows = 0;
            try
            {
                //Closing is automatic with a using and will happen even on an error.
                using (var cn = new SQLiteConnection(LoadConnectionString()))
                {
                    //Opening is not implicit
                    cn.Open();

                    affectedRows = cn.Execute(sql, parameters);
                }
            }
            catch (SqliteException ex)
            {
                DatabaseError.DatabaseErrorUnknownMessage(ex);
                return -1;
            }
            catch (Exception ex)
            {
                DatabaseError.OtherErrorMessage(ex);
                return -1;
            }
            return affectedRows;
        }


        #endregion

        #region Files

        #region Get Files

        /// <summary>
        /// Returns a list of FileItems based on the given DB FileIDs.
        /// If no FileIds are in the IEnumerable<int>, returns everything. 
        /// If there is no IEnumerable<int> or there is an error, return null.
        /// </summary>
        /// <param name="ids">A list of integer FileIds to return the file data for.</param>
        /// <returns>returns a List of FileItems or null on failure.</returns>
        public static List<FileItem> GetFilesByID(IEnumerable<int> ids)
        {
            if (ids == null) //There is no IEnumerable<int>
            {
                return null;
            }
            else if (!ids.Any()) //The IEnumerable<int> is empty
            {
                return GetAllFiles();
            }

            //The IEnumerable<int> exists and has values, so proceed as normal.

            //Defined early to allow a null return at the end.
            List<FileItem> output = null;

            string sql = "SELECT * FROM Files WHERE ID IN @IDs";
            //The IDs are converted into a string for the sql parameter
            string IdString = string.Join(", ", ids);

            try
            {
                //Closing is automatic with a using and will happen even on an error.
                using (var cn = new SQLiteConnection(LoadConnectionString()))
                {
                    cn.Open();

                    //TODO: A query with no results should still return an empty list, not null or something else. Confirm this is the case.

                    //Queries using Dapper, subs in the string as the parameter and returns the results as a list
                    output = cn.Query<FileItem>(sql, new { IDs = IdString}).ToList();
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
        public static List<FileItem> GetAllFiles()
        {
            List<FileItem> output = null;

            string sql = "SELECT * FROM Files";

            try
            {
                //Closing is automatic with a using and will happen even on an error.
                using (var cn = new SQLiteConnection(LoadConnectionString()))
                {
                    cn.Open();

                    //TODO: A query with no results should still return an empty list, not null or something else. Confirm this is the case.

                    //Queries using Dapper, subs in the string as the parameter and returns the results as a list
                    output = cn.Query<FileItem>(sql).ToList();
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

        #endregion

        #region Add Files

        /// <summary>
        /// Adds <see cref="NewFile"/>s to the database. The files are passed in in any IEnumerable, and can have any number.
        /// Due to the nature of SQLITE, passing them all in and using 1 transaction is vastly more efficient that calling this func many times.
        /// </summary>
        /// <param name="files">List of 1 or more <see cref="NewFile"/> files.</param>
        /// <returns>The <see cref="int"/> amount of modified records or -1 if there was an error.</returns>
        public static int AddNewFiles(IEnumerable<NewFile> files)
        {
            // Used code from https://www.codeproject.com/Articles/853842/Csharp-Avoiding-Performance-Issues-with-Inserts-in and referenced https://stackoverflow.com/questions/9006604/improve-performance-of-sqlite-bulk-inserts-using-dapper-orm
            // to ensure that SQLITE will insert efficiently. (See license in WpfTabControlLibrary)

            var results = new List<int>();
            string sql = "INSERT OR IGNORE INTO Files (FullPath) VALUES (?);";

            try { 
                //Closing is automatic with a using and will happen even on an error.
                using (var cn = new SQLiteConnection(LoadConnectionString()))
                {
                    //Opening is not implicit
                    cn.Open();

                    //Transactions always happen in SQLite and doing a transaction per insert is terribly slow
                    using var transaction = cn.BeginTransaction();
                    using (var cmd = cn.CreateCommand()) //Commmands with parameters prevent sql injection, and prevent the overhead in SQLite when doing a batch in one transaction
                    {
                        cmd.CommandText = sql;

                        SQLiteParameter param = new SQLiteParameter();
                        //An Add adds into the first ?. I think addwithvalue isn't supported in sqllite? Either way, we want the value to be changed each time
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

        #endregion

        #region Edit Files

        #endregion

        #region Remove Files

        #endregion


        #endregion


        #region Tags

        #region Load Tags
        #endregion

        #region Add Tags

        public static void AddNewTag(FullTag tag)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Edit Tags

        #endregion

        #region Remove Tags

        #endregion

        #endregion


        #region Categories

        #region Get Categories

        /// <summary>
        /// Returns a category with the given ID from the database
        /// </summary>
        /// <param name="id">The DB ID for the category.</param>
        /// <returns>A <see cref="Category"/> of the ID or null if there was no result.</returns>
        public static Category GetCategoryByID(int id)
        {
            Category output = null;
            string sql = "SELECT Name, ID, Color, Priority FROM Categories WHERE ID = @CategoryID";
            try
            {
                //Closing is automatic with a using and will happen even on an error.
                using (var cn = new SQLiteConnection(LoadConnectionString()))
                {
                    cn.Open();

                    //Queries using Dapper. Returns as a Category. Returns null if there is no result.
                    //TODO: Confirm result of QuerySingleOrDefault is null.
                    output = cn.QuerySingleOrDefault<Category>(sql, new { CategoryID = id });
                    //Returns int64 like all sqlite things. Gets casted inside of category class ctor
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


        #endregion

        #region Add Categories

        public static int AddNewCategory(Category cat)
        {
            string sql = "INSERT INTO Categories (Name, Color, Priority) Values (@Name, @Color, @Priority);";
            int affectedRows = 0;
            try
            {
                //Closing is automatic with a using and will happen even on an error.
                using (var cn = new SQLiteConnection(LoadConnectionString()))
                {
                    //Opening is not implicit
                    cn.Open();

                    affectedRows = cn.Execute(sql, new { Name = cat.Name, Color = cat.Color, Priority = cat.Priority });
                }
            }
            catch (SqliteException ex)
            {
                DatabaseError.DatabaseErrorUnknownMessage(ex);
                return -1;
            }
            catch (Exception ex)
            {
                DatabaseError.OtherErrorMessage(ex);
                return -1;
            }
            return affectedRows;
        }

        #endregion

        #region Edit Categories

        #endregion

        #region Remove Categories

        #endregion

        #endregion
    }
}
