using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace craftersmine.League.CommunityDragon
{
    internal class UnixTimeSpanConverter : JsonConverter
    {
        private bool useSeconds = false;

        public UnixTimeSpanConverter() : this(false) {}

        public UnixTimeSpanConverter(bool useSeconds)
        {
            this.useSeconds = useSeconds;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is TimeSpan ts)
            {
                writer.WriteValue((long)ts.TotalMilliseconds);
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return new TimeSpan(0, 0, 0, 0, 0);

            if (reader.Value != null)
            {
                if (reader.TokenType != JsonToken.Integer && reader.TokenType != JsonToken.Float)
                    throw new Exception("Expected integer or float value, got " + reader.TokenType);
                if (reader.TokenType == JsonToken.Integer)
                {
                    long msTs = (long) reader.Value;
                    if (useSeconds)
                        return TimeSpan.FromSeconds(msTs);
                    else
                        return TimeSpan.FromMilliseconds(msTs);
                }
                else
                {
                    if (useSeconds)
                        return TimeSpan.FromSeconds((double) reader.Value);
                    else
                        return TimeSpan.FromMilliseconds((double) reader.Value);
                }
            }

            return new TimeSpan(0, 0, 0, 0, 0);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(TimeSpan);
        }
    }
}
