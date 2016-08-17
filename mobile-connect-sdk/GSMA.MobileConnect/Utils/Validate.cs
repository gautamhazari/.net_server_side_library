using GSMA.MobileConnect.Exceptions;
using System.Runtime.CompilerServices;

namespace GSMA.MobileConnect.Utils
{
    internal static class Validate
    {
        /// <summary>
        /// Throws an ArgumentNullException if the passed parameter is null
        /// </summary>
        /// <param name="obj">Parameter to check for null</param>
        /// <param name="name">Name of the parameter for the exception message</param>
        /// <param name="caller">Calling method</param>
        /// <exception cref="MobileConnectInvalidArgumentException">If obj is null</exception>
        internal static void RejectNull(object obj, string name, [CallerMemberName]string caller = null)
        {
            if(obj == null)
            {
                throw new MobileConnectInvalidArgumentException(name, caller);
            }
        }

        /// <summary>
        /// Throws an ArgumentException if the passed parameter is empty or ArgumentNullException if null
        /// </summary>
        /// <param name="input">Parameter to check for null or empty</param>
        /// <param name="name">Name of the parameter for the exception message</param>
        /// /// <param name="caller">Calling method</param>
        /// <exception cref="MobileConnectInvalidArgumentException">If input is null or empty</exception>
        internal static void RejectNullOrEmpty(string input, string name, [CallerMemberName]string caller = null)
        {
            RejectNull(input, name, caller);

            if (input == string.Empty)
            {
                throw new MobileConnectInvalidArgumentException(name, caller);
            }
        }        
    }
}
