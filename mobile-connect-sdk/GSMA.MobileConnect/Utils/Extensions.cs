using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
