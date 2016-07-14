using Newtonsoft.Json;

namespace GSMA.MobileConnect.Claims
{
    public class ClaimsValue
    {
        [JsonProperty("essential", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool Essential { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public object Value { get; set; }

        [JsonProperty("values", NullValueHandling = NullValueHandling.Ignore)]
        public object[] Values { get; set; }

        [JsonConstructor]
        private ClaimsValue() { }

        public static ClaimsValue Required()
        {
            return new ClaimsValue { Essential = true };
        }

        public static ClaimsValue WithValue(bool required, object value)
        {
            return new ClaimsValue { Essential = required, Value = value };
        }

        public static ClaimsValue WithValues(bool required, params object[] values)
        {
            return new ClaimsValue { Essential = required, Values = values };
        }
    }
}
