using Newtonsoft.Json;

namespace GSMA.MobileConnect.Claims
{
    /// <summary>
    /// Class representing a single claim to be requested
    /// </summary>
    public class ClaimsValue
    {
        /// <summary>
        /// If the claim is essential
        /// </summary>
        [JsonProperty("essential", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool Essential { get; set; }

        /// <summary>
        /// The expected value of the claim, if set
        /// </summary>
        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public object Value { get; set; }

        /// <summary>
        /// The expected values array of the claim, if set
        /// </summary>
        [JsonProperty("values", NullValueHandling = NullValueHandling.Ignore)]
        public object[] Values { get; set; }

        [JsonConstructor]
        private ClaimsValue() { }

        /// <summary>
        /// Creates a new ClaimsValue with Essential set to true
        /// </summary>
        /// <returns>A new ClaimsValue instance</returns>
        public static ClaimsValue Required()
        {
            return new ClaimsValue { Essential = true };
        }

        /// <summary>
        /// Creates a new ClaimsValue with Value set as specified
        /// </summary>
        /// <param name="required">If the claim is essential</param>
        /// <param name="value">The expected value of the claim</param>
        /// <returns>A new ClaimsValue instance</returns>
        public static ClaimsValue WithValue(bool required, object value)
        {
            return new ClaimsValue { Essential = required, Value = value };
        }

        /// <summary>
        /// Creates a new ClaimsValue with Values set as specified
        /// </summary>
        /// <param name="required">If the claim is essential</param>
        /// <param name="values">The expected values array</param>
        /// <returns>A new ClaimsValue instance</returns>
        public static ClaimsValue WithValues(bool required, params object[] values)
        {
            return new ClaimsValue { Essential = required, Values = values };
        }
    }
}
