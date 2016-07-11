using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Json.Converters
{
    /// <summary>
    /// Converts an ISO8601-2004 YYYY-MM-DD format to a DateTime
    /// </summary>
    public class IsoDateConverter : JsonConverter
    {
        /// <inheritdoc/>
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(DateTime) || objectType == typeof(DateTime?));
        }

        /// <inheritdoc/>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null || string.IsNullOrEmpty(reader.Value.ToString()))
            {
                return objectType == typeof(DateTime?) ? null : (DateTime?)DateTime.MinValue;
            }

            var isoFormat = reader.Value.ToString();
            isoFormat = isoFormat.Replace("0000-", "9999-");
            return DateTime.Parse(isoFormat);
        }

        /// <inheritdoc/>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var nullableDate = value as DateTime?;

            if (nullableDate == null)
            {
                writer.WriteNull();
                return;
            }

            var date = nullableDate.Value;
            var year = date.Year == 9999 ? "0000" : date.Year.ToString();
            writer.WriteValue($"{year}-{date.Month.ToString("D2")}-{date.Day.ToString("D2")}");
        }
    }
}
