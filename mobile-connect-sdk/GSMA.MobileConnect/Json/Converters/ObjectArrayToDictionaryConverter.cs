using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Json.Converters
{
    /// <summary>
    /// Flattens an array of objects to a dictionary of string, string. Should only be used when the objects are simple key/value objects with different keys
    /// </summary>
    public class ObjectArrayToDictionaryConverter : JsonConverter
    {
        /// <inheritdoc/>
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Dictionary<string, string>));
        }

        /// <inheritdoc/>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var dict = new Dictionary<string, string>();
            JArray array = null;

            try
            {
                array = JArray.Load(reader);
            }
            catch (JsonReaderException)
            {
                return null;
            }

            foreach (var item in array)
            {
                var obj = item as JObject;

                if(obj == null)
                {
                    continue;
                }

                foreach (var kvp in obj)
                {
                    dict.Add(kvp.Key, (string)kvp.Value);
                }
            }

            return dict;
        }

        /// <inheritdoc/>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var dict = value as Dictionary<string, string>;
            if(dict == null)
            {
                return;
            }

            JArray array = new JArray();
            foreach (var kvp in dict)
            {
                var obj = new JObject();
                obj.Add(kvp.Key, kvp.Value);
                array.Add(obj);
            }

            array.WriteTo(writer);
        }
    }
}
