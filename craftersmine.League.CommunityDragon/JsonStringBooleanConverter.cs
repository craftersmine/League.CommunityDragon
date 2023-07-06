using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace craftersmine.League.CommunityDragon
{
    internal class JsonStringBooleanConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value is bool v)
            {
                if (v) writer.WriteValue("Y");
                else writer.WriteValue("N");
            }

            throw new JsonWriterException("Invalid type " + value?.GetType().FullName + ", expected " +
                                          typeof(bool).FullName);
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                if (reader.Value is string s)
                {
                    switch (s)
                    {
                        case "Y":
                            return true;
                        case "N":
                            return false;
                    }
                }
            }
            throw new JsonReaderException("Unexpected value \"" + reader.Value + "\" of " + reader.Path +
                                          ", expected \"Y\" or \"N\"");
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(bool);
        }
    }
}
