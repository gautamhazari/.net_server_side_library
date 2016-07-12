using GSMA.MobileConnect.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Utils
{
    /// <summary>
    /// Helper methods for dealing with scope and scope values
    /// </summary>
    public static class Scope
    {
        /// <summary>
        /// Returns a scope that is ensured to contain the defaultScope and has any duplication of values removed
        /// </summary>
        /// <param name="scope">Scope to coerce</param>
        /// <param name="defaultScope">Required default scope</param>
        /// <returns>Scope containing default scope values and no duplicated values</returns>
        public static string CoerceOpenIdScope(string scope, string defaultScope = Constants.Scope.OPENID)
        {
            var split = (scope ?? "").Split().ToList();
            var splitDefault = defaultScope.Split().ToList();

            for (int i = 0; i < splitDefault.Count; i++)
            {
                if (split.FirstOrDefault(x => x.Equals(splitDefault[i], StringComparison.OrdinalIgnoreCase)) == null)
                {
                    split.Insert(i, splitDefault[i]);
                }
            }

            return string.Join(" ", split.Distinct()).Trim();
        }
    }
}
