using System;
using System.IO;
using System.Linq;

namespace LocalImageTagger.Files
{
    //Taken and modified from https://www.rudyhuyn.com/blog/2017/04/18/be-careful-with-path-getextension/ to deal with the problems with the path functions with other OSes

    /// <summary>
    /// Implements extension functions to replace the path version that throw exceptions on illegal characters that are not illegal on other platforms
    /// </summary>
    public static class PathHelper
    {
        // The standard seperators for file paths.
        static readonly char[] filePathSeparators = { '/', '\\', ':' };

        // The standard seperators for uris.
        static readonly char[] uriSeparators = { '/' };

        #region GetExtension

        /// <summary>
        /// Returns the Extension part of a path string or uri
        /// Equivalent of Path.GetExtension but doesn't throw an exception when the string contains an invalid character (" < > | etc...)
        /// </summary>
        /// <param name="path"> The String Path for a filePath </param>
        /// <returns>The extension including the period "." or null or string.empty </returns>
        public static string GetExtension(this string path)
        {
            return GetExtensionInternal(path, filePathSeparators);
        }
        /// <summary>
        /// Returns the Extension part of a path string or uri
        /// Equivalent of Path.GetExtension but doesn't throw an exception when the string contains an invalid character (" < > | etc...)
        /// </summary>
        public static string GetExtension(this Uri uri)
        {
            return GetExtensionInternal(uri.LocalPath, uriSeparators);
        }
        /// <summary>
        /// Returns the Extension part of a path string or uri
        /// Equivalent of Path.GetExtension but doesn't throw an exception when the string contains an invalid character (" < > | etc...)
        /// </summary>
        public static string GetExtension(this string path, char[] separators)
        {
            if (separators != null && separators.Contains('.'))
            {
                throw new ArgumentException("separators can't contain '.'");
            }

            return GetExtensionInternal(path, separators);
        }

        //Goes back from the end of the name to find the . and returns everything after that
        private static string GetExtensionInternal(this string path, char[] separators)
        {
            if (path == null)
                return null;

            var length = path.Length;
            for (var i = length - 1; i >= 0; --i)
            {
                var ch = path[i];
                if (ch == '.')
                {
                    return i != length - 1 ? path.Substring(i, length - i) : string.Empty;
                }
                else if (separators != null && separators.Contains(ch))
                {
                    break;
                }
            }
            return string.Empty;
        }

        #endregion

        #region GetFileName

        /// <summary>
        /// Returns the Filename part of a path string or uri
        /// Equivalent of Path.GetFilename but doesn't throw an exception when the string contains an invalid character (" < > | etc...)
        /// </summary>
        /// <param name="path"> The String Path for a filePath </param>
        /// <returns>The Filename including the extension or null or string.empty </returns>
        public static string GetFileName(this string path)
        {
            return GetFileNameInternal(path, filePathSeparators);
        }

        /// <summary>
        /// Returns the Filename part of a path string or uri
        /// Equivalent of Path.GetFilename but doesn't throw an exception when the string contains an invalid character (" < > | etc...)
        /// </summary>
        public static string GetFileName(this Uri uri)
        {
            return GetFileNameInternal(uri.LocalPath, uriSeparators);
        }

        /// <summary>
        /// Returns the Filename part of a path string or uri
        /// Equivalent of Path.GetFilename but doesn't throw an exception when the string contains an invalid character (" < > | etc...)
        /// </summary>
        public static string GetFileName(this string path, char[] separators)
        {
            if (separators != null && separators.Contains('.'))
            {
                throw new ArgumentException("separators can't contain '.'");
            }

            return GetFileNameInternal(path, separators);
        }

        //Goes backwards until it finds a seperator character and returns what comes after it
        private static string GetFileNameInternal(string path, char[] separators)
        {
            if (path != null)
            {

                var length = path.Length;
                for (int i = length - 1; i >= 0; --i)
                {
                    var ch = path[i];
                    if (separators.Contains(ch))
                        return path.Substring(i + 1, length - i - 1);
                }
            }
            return path;
        }

        #endregion


        public static string RemoveInvalidChars(string filename, char? replacedLetter = null)
        {
            if (filename == null)
                return null;

            var invalidChars = Path.GetInvalidFileNameChars();

            if (replacedLetter == null)
            {
                return new string(filename
                    .Where(x => !invalidChars.Contains(x))
                    .ToArray());
            }
            else
            {
                return new string(filename
                    .Select(x => invalidChars.Contains(x) ? replacedLetter.Value : x)
                    .ToArray());
            }
        }
    }
}

