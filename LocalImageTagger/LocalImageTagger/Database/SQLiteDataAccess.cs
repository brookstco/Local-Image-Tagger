using Dapper;
using LocalImageTagger.Files;
using LocalImageTagger.Tags;
using Microsoft.Data.Sqlite;
using System;
using System.Collections;
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
        //For reducing repitition with the common formats. Try catches are still repeated, but its only a few now. I could reduce them more, but it complicated function calls and added inefficiency.

        /// <summary>
        /// Performs an INSERT command into the SQLite DB using Dapper given the SQL command and a preformed parameter object. 
        /// Returns the number of affected rows or -1 on an error.
        /// </summary>
        /// <param name="sql">The sql command <see cref="string"/>.</param>
        /// <param name="paramObj"> The parameters in "new { param1 = val1, param2 = val2...}" form or in a class with identical field names as the params in the sql.</param>
        /// <returns></returns>
        private static int insertSQL(string sql, object paramObj)
        {
            int affectedRows = 0;
            try
            {
                //Closing is automatic with a using and will happen even on an error.
                using (var cn = new SQLiteConnection(LoadConnectionString()))
                {
                    //Opening is not implicit
                    cn.Open();

                    affectedRows = cn.Execute(sql, paramObj);
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

        /// <summary>
        /// Performs one or many INSERT commands into the SQLite DB using Dapper with an efficient transaction given the SQL command and a list of preformed parameter objects.
        /// Returns the number of affected rows or -1 on an error.
        /// </summary>
        /// <param name="sql">The sql command <see cref="string"/>.</param>
        /// <param name="paramObjList"> An <see cref="IEnumerable"/> of parameters in "new { param1 = val1, param2 = val2...}" form or in a class with identical field names as the params in the sql.</param>
        /// <returns></returns>
        private static int insertManySQL(string sql, IEnumerable paramObjList)
        {
            int affectedRows = 0;
            try
            {
                //Closing is automatic with a using and will happen even on an error.
                using (var cn = new SQLiteConnection(LoadConnectionString()))
                {
                    //Opening is not implicit
                    cn.Open();
                    using (var transaction = cn.BeginTransaction())
                    {
                        affectedRows = cn.Execute(sql, paramObjList, transaction);

                        transaction.Commit();
                    }

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
            //Cannot use ? as param if passing in classes with multiple properties in potentially random order.
            string sql = "INSERT OR IGNORE INTO Files (FullPath) VALUES (@FullPath);";
            return insertManySQL(sql, files);
        }

        #endregion

        #region Edit Files

        //TODO: Edit file paths if the file is missing

        #endregion

        #region Remove Files

        //Delete function for the file. Should also delete all associated tagmaps. Currently foreign keys - Do they auto delete? is there a warning? Are foreign keys really needed here?

        #endregion


        #endregion

        #region Tags

        #region Load Tags

        //TODO: Load tag by id

        //TODO: Get tagid by name (return null if no tag)  ---  Must exactly match

        //TODO: Get possible tagIDs by the start of a name  --returns a list of all tags that begin (or include?) the string

        //TODO: Get AliasId by name (return null if no alias)

        //TODO: Get possible aliasIDs by the start of a name  --returns a list of all aliases that begin (or include?) the string

        #endregion

        #region Add Tags

        public static void AddNewTag(Tag tag)
        {
            //TODO: Add tag info - get tagid
            //Check if the aliases exists, if null, add new alias with this tagid
            //if the alias exists, append this id to the alias id list.
            //Append this id to the child id list for any parents.
            throw new NotImplementedException();
        }

        //TODO: Add many tags for load in through file support. Make a transaction and return a list of ids in the same order as the passed in tag instances

        #endregion

        #region Edit Tags

        //TODO: Lets you edit all tag fields. USES THE SAME VIEW but different viewmodels AS ADD NEW TAG.
        //Keep a copy of the old and new, compare, and only update changed fields.
        //Will have to search through everything since its not denormalised. IS extra space requirements worth? How slow will this be?

        #endregion

        #region Remove Tags

        //TODO: Remove a tag and all of its associated tagmaps, parent's child ids, and alias ids. Also delete any aliases that only have this as a child.

        #endregion

        #endregion

        #region Categories

        //TODO: Make each category have its own tag table? This would increase speed on searches (Right now, needs to check on every tag if it is the right cat.). Reduces the space needed for category fields on tags, but need disambiguation in the tagmaps.

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

        //TODO: Get catid by name

        //TODO: Get possible cats by the start of a name  --returns a list of all cats that begin (or include?) the string

        #endregion

        #region Add Categories

        /// <summary>
        /// Add a new category into the database
        /// </summary>
        /// <param name="cat"> The category to add. Only requires the name field to be filled. </param>
        /// <returns>An integer of the rows affected or -1 on an error.</returns>
        public static int AddNewCategory(Category cat)
        {
            string sql = "INSERT INTO Categories (Name, Color, Priority) Values (@Name, @Color, @Priority);";
            //Since Category has the same dfield names as the sql, we can just directly pass the object instead of new { Name = cat.Name, Color = cat.Color, Priority = cat.Priority }.
            return insertSQL(sql, cat);
        }

        #endregion

        #region Edit Categories

        //TODO: Lets you edit all tag fields. USES THE SAME VIEW but different viewmodels AS ADD NEW TAG.
        //Keep a copy of the old and new, compare, and only update changed fields.
        //If the changes would affect a tag field, change all associated tags too.


        //TODO: Merge category action? Since deleting a category is big and deletes tags, maybe a merge to hellp a transition? Not an immediate goal though.

        #endregion

        #region Remove Categories

        //TODO: Deletes the category and all associated tags. Loop through the tags first, so that all of their associations are properly removed.

        #endregion

        #endregion

        #region TagMaps

        #region Load TagMaps

        //TODO: Load tagmaps by fileID and return the tagIDs

        //TODO: Load tagmaps by tagID and return the FileIds


        //TODO: More complex searches proper searching. Maybe have its own region?
        //https://vtidter.blogspot.com/2014/02/database-schema-for-tags.html
        /*"Toxi" solution
image
Toxi came up with a three-table structure. Via the table “tagmap” the bookmarks and the tags are n-to-m related. Each tag can be used together with different bookmarks and vice versa. This DB-schema is also used by wordpress.
The queries are quite the same as in the “scuttle” solution.
Intersection (AND)
Query for “bookmark+webservice+semweb”
SELECT b.*
FROM tagmap bt, bookmark b, tag t
WHERE bt.tag_id = t.tag_id
AND (t.name IN ('bookmark', 'webservice', 'semweb'))
AND b.id = bt.bookmark_id
GROUP BY b.id
HAVING COUNT( b.id )=3
Union (OR)
Query for “bookmark|webservice|semweb”
SELECT b.*
FROM tagmap bt, bookmark b, tag t
WHERE bt.tag_id = t.tag_id
AND (t.name IN ('bookmark', 'webservice', 'semweb'))
AND b.id = bt.bookmark_id
GROUP BY b.id
Minus (Exclusion)
Query for “bookmark+webservice-semweb”, that is: bookmark AND webservice AND NOT semweb.

SELECT b. *
FROM bookmark b, tagmap bt, tag t
WHERE b.id = bt.bookmark_id
AND bt.tag_id = t.tag_id
AND (t.name IN ('Programming', 'Algorithms'))
AND b.id NOT IN (SELECT b.id FROM bookmark b, tagmap bt, tag t WHERE b.id = bt.bookmark_id AND bt.tag_id = t.tag_id AND t.name = 'Python')
GROUP BY b.id
HAVING COUNT( b.id ) =2
Leaving out the HAVING COUNT leads to the Query for “bookmark|webservice-semweb”.
Credits go to Rhomboid for helping me out with this query.
Conclusion
The advantages of this solution:
You can save extra information on each tag (description, tag hierarchy, …)
This is the most normalized solution (that is, if you go for 3NF: take this one :-)
Disadvantages:
When altering or deleting bookmarks you can end up with tag-orphans.
If you want to have more complicated queries like (bookmarks OR bookmark) AND (webservice or WS) AND NOT (semweb or semanticweb) the queries tend to become very complicated. In these cases I suggest the following query/computation process:
Run a query for each tag appearing in your “tag-query”: SELECT b.id FROM tagmap bt, bookmark b, tag t WHERE bt.tag_id = t.tag_id AND b.id = bt.bookmark_id AND t.name = "semweb"
Put each id-set from the result into an array (that is: in your favourite coding language). You could cache this arrays if you want..
Constrain the arrays with union or intersection or whatever.
In this way, you can also do queries like (del.icio.us|delicious)+(semweb|semantic_web)-search. This type of queries (that is: the brackets) cannot be done by using the denormalized “MySQLicious solution”.
This is the most flexible data structure and I guess it should scale pretty good (that is: if you do some caching).


        */
        #endregion

        #region Add TagMaps

        //TODO: Add many tagmaps based on a list of tagid and fileids

        #endregion

        //Tagmaps can't be edited. Just delete and add a new one.

        #region Remove Tags

        //TODO: Remove a tagmap based on fileid and tagid.

        //TODO: Remove all tagmaps based on fileID or tagID.

        #endregion

        #endregion



        //TODO: Preprocess tags
        //When searching, break the tags up, and get the file ids for each, and put the ids in a new list. This makes it easier for the other functions

        //TODO: Searching autocomplete. After 3(or user-chosen) number of letters typed, search the database for all of the possible choices. Prioritize categories then tags then aliases. Once in a category, only tags
        //Show in order of the count for tags. Show what type (cat, tag, alias) and the count for the tags.

    }
}
