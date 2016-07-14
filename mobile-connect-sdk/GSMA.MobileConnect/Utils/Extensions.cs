using System;
using System.Collections.Generic;
using System.Linq;

namespace GSMA.MobileConnect.Utils
{
    /// <summary>
    /// Helpful extension methods that have no other logical place
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Checks for the IEnumerable to contain all the values specified in the values string after being separated using the separators
        /// </summary>
        /// <param name="enumerable">IEnumerable with available values</param>
        /// <param name="values">Values required as a delimited string</param>
        /// <param name="separators">Delimiters for values string, if not supplied the string will be split on whitespace characters</param>
        /// <param name="stringComparison">One of the enumeration values that specifies the rules of comparison</param>
        /// <returns>True if all tokens in the values string are present in the enumerable</returns>
        public static bool ContainsAllValues(this IEnumerable<string> enumerable, string values, StringComparison stringComparison, params char[] separators)
        {
            var splitValues = values.Split(separators, StringSplitOptions.RemoveEmptyEntries).ToList();
            return enumerable.ContainsAllValues(splitValues, stringComparison);
        }

        /// <summary>
        /// Checks for the IEnumerable to contain all values in the value list
        /// </summary>
        /// <param name="enumerable">IEnumerable with available values</param>
        /// <param name="values">Values required</param>
        /// <param name="stringComparison">One of the enumeration values that specifies the rules of comparison</param>
        /// <returns>True if all strings in the values list are present in the enumerable</returns>
        public static bool ContainsAllValues(this IEnumerable<string> enumerable, List<string> values, StringComparison stringComparison)
        {
            foreach (var item in enumerable)
            {
                var found = values.FindIndex(x => string.Equals(x, item, stringComparison));
                if (found < 0)
                {
                    continue;
                }

                values.RemoveAt(found);

                if (values.Count == 0)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Remove a specified value from a delimited string if found
        /// </summary>
        /// <param name="value">Delimited string to remove value from</param>
        /// <param name="toRemove">Value to remove</param>
        /// <param name="stringComparison">One of the enumeration values that specifies the rules of comparison</param>
        /// <param name="separator">Seperator to split and join values on, if null will split on whitespace and join using the space character</param>
        /// <returns>String with instance of toRemove removed</returns>
        public static string RemoveFromDelimitedString(this string value, string toRemove, StringComparison stringComparison, char? separator = null)
        {
            if(value.IndexOf(toRemove, stringComparison) < 0)
            {
                return value;
            }

            var separators = separator == null ? null : new char[] { separator.Value };
            var split = value.Split(separators, StringSplitOptions.RemoveEmptyEntries).ToList();

            split.RemoveAll(x => x.Equals(toRemove, stringComparison));

            var delimiter = new string(separator ?? ' ', 1);
            return string.Join(delimiter, split);
        }
    }
}
