using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace GSMA.MobileConnect.Json.Converters
{
    public class SupportedVersionsConverter : JsonConverter
    {
        /// <inheritdoc/>
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Discovery.SupportedVersions));
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

                if (obj == null)
                {
                    continue;
                }

                foreach (var kvp in obj)
                {
                    dict.Add(kvp.Key, (string)kvp.Value);
                }
            }

            return new Discovery.SupportedVersions(dict);
        }

        /// <inheritdoc/>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var versions = value as Discovery.SupportedVersions;
            var dict = versions?.InitialValues;

            if (dict == null || dict.Count == 0)
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
