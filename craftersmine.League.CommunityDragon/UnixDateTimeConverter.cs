using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Resources;
using System.Text;

namespace craftersmine.League.CommunityDragon
{
    internal class UnixDateTimeConverter : JsonConverter
    {
        private readonly bool useSeconds;

        public UnixDateTimeConverter() : this(false) { }

        public UnixDateTimeConverter(bool useSeconds)
        {
            this.useSeconds = useSeconds;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            long val;
            if (value is DateTime)
            {
                if (!useSeconds)
                    val = ((DateTime) value).ToUnixTimeMilliseconds();
                else
                    val = ((DateTime) value).ToUnixTimeSeconds();
            }
            else
            {
                throw new Exception("Expected DateTime value, got " + value.GetType().Name);
            }
            writer.WriteValue(val);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return new DateTime(1970, 1, 1);

            long val = 0;

            if (reader.TokenType != JsonToken.Integer)
            {
                if (reader.TokenType == JsonToken.String)
                {
                    if (reader.Value != null) val = long.Parse(reader.Value.ToString());
                }
                else
                    throw new Exception("Expected integer value, got " + reader.TokenType);
            }

            long ticks;
            if (val == 0)
                ticks = (long) (reader.Value ?? 0);
            else ticks = val;

            if (!useSeconds)
                return ticks.FromUnixTimeMilliseconds();
            else return ticks.FromUnixTimeSeconds();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(int);
        }
    }
}
