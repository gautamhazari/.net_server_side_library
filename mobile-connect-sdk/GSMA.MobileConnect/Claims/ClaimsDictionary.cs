using GSMA.MobileConnect.Utils;
using System.Collections.Generic;
using System.Collections;

namespace GSMA.MobileConnect.Claims
{
    /// <summary>
    /// JSON Serializable class to store configured claims values for use with mobile connect methods
    /// </summary>
    public class ClaimsDictionary : IDictionary<string, ClaimsValue>
    {
        private readonly Dictionary<string, ClaimsValue> _internalDict = new Dictionary<string, ClaimsValue>();

        /// <summary>
        /// Get or set claim value at specified key
        /// </summary>
        /// <param name="key">Claim key</param>
        /// <returns>Claims value or null if no claim found for key</returns>
        public ClaimsValue this[string key]
        {
            get
            {
                if(_internalDict.ContainsKey(key))
                {
                    return _internalDict[key];
                }

                return null;
            }
            set
            {
                _internalDict[key] = value;
            }
        }

        /// <summary>
        /// Add a voluntary claim with the specified key
        /// </summary>
        /// <param name="key">Claim key</param>
        public void Add(string key)
        {
            Add(key, null);
        }

        /// <summary>
        /// Add a claim value with the specified key
        /// </summary>
        /// <param name="key">Claim key</param>
        /// <param name="value">Claim value</param>
        public void Add(string key, ClaimsValue value)
        {
            Validate.RejectNullOrEmpty(key, "key");

            this[key] = value;
        }

        /// <summary>
        /// Add a required claim with the specified key
        /// </summary>
        /// <param name="key">Claim key</param>
        public void AddRequired(string key)
        {
            Add(key, ClaimsValue.Required());
        }

        /// <summary>
        /// Add a claim with the specified key and value. When claims are sent to a method that accepts them the response will only contain the claim if the values match.
        /// </summary>
        /// <param name="key">Claim key</param>
        /// <param name="required">Is claim essential</param>
        /// <param name="value">Claim value</param>
        public void AddWithValue(string key, bool required, object value)
        {
            Add(key, ClaimsValue.WithValue(required, value));
        }

        /// <summary>
        /// Add a claim with the specified key and values. When claims are sent to a method that accepts them the response will only contain the claim if the value is in the values list.
        /// </summary>
        /// <param name="key">Claim key</param>
        /// <param name="required">Is claim essential</param>
        /// <param name="values">Claim values</param>
        public void AddWithValues(string key, bool required, params object[] values)
        {
            Add(key, ClaimsValue.WithValues(required, values));
        }

        #region IDictionary Implementation

        /// <inheritdoc/>
        public ICollection<string> Keys
        {
            get { return _internalDict.Keys; }
        }

        /// <inheritdoc/>
        public ICollection<ClaimsValue> Values
        {
            get { return _internalDict.Values; }
        }

        /// <inheritdoc/>
        public int Count
        {
            get { return _internalDict.Count; }
        }

        /// <inheritdoc/>
        public bool IsReadOnly
        {
            get { return false; }
        }

        /// <inheritdoc/>
        public bool Remove(string key)
        {
            return _internalDict.Remove(key);
        }

        /// <inheritdoc/>
        public void Clear()
        {
            _internalDict.Clear();
        }

        /// <inheritdoc/>
        public bool ContainsKey(string key)
        {
            return _internalDict.ContainsKey(key);
        }

        /// <inheritdoc/>
        public bool TryGetValue(string key, out ClaimsValue value)
        {
            return _internalDict.TryGetValue(key, out value);
        }

        /// <inheritdoc/>
        public void Add(KeyValuePair<string, ClaimsValue> item)
        {
            Add(item.Key, item.Value);
        }

        /// <inheritdoc/>
        public bool Contains(KeyValuePair<string, ClaimsValue> item)
        {
            return ((ICollection<KeyValuePair<string, ClaimsValue>>)_internalDict).Contains(item);
        }

        /// <inheritdoc/>
        public void CopyTo(KeyValuePair<string, ClaimsValue>[] array, int arrayIndex)
        {
            ((ICollection<KeyValuePair<string, ClaimsValue>>)_internalDict).CopyTo(array, arrayIndex);
        }

        /// <inheritdoc/>
        public bool Remove(KeyValuePair<string, ClaimsValue> item)
        {
            return ((ICollection<KeyValuePair<string, ClaimsValue>>)_internalDict).Remove(item);
        }

        /// <inheritdoc/>
        public IEnumerator<KeyValuePair<string, ClaimsValue>> GetEnumerator()
        {
            return _internalDict.GetEnumerator();
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_internalDict).GetEnumerator();
        } 

        #endregion
    }
}
