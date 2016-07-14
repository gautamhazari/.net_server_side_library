using System.Collections.Generic;
using System.Diagnostics;

namespace GSMA.MobileConnect.Utils
{
    /// <summary>
    /// Class to store a simple key value pair, useful for http headers and cookies
    /// </summary>
    [DebuggerDisplay("{Key}-{Value}")]
    public class BasicKeyValuePair
    {
        private readonly KeyValuePair<string, string> _internalKvPair;

        /// <summary>
        /// The Key of the KeyValue Pair (Readonly)
        /// </summary>
        public string Key
        {
            get { return _internalKvPair.Key; }
        }

        /// <summary>
        /// The Value of the KeyValue Pair (Readonly)
        /// </summary>
        public string Value
        {
            get { return _internalKvPair.Value; }
        }

        /// <summary>
        /// Constructs a new instance of KeyValuePair
        /// </summary>
        /// <param name="key">The Key of the KeyValue Pair</param>
        /// <param name="value">The Value of the KeyValue Pair</param>
        public BasicKeyValuePair(string key, string value)
        {
            this._internalKvPair = new KeyValuePair<string, string>(key, value);
        }
    }
}
