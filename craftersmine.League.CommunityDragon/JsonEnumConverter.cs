using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace craftersmine.League.CommunityDragon
{
    internal class JsonEnumConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value is Enum && value.GetType().GetCustomAttribute(typeof(JsonEnumAttribute)) is not null)
                writer.WriteValue(((Enum)value).GetJsonEnumValue());
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            if (objectType is Enum && objectType.GetCustomAttribute(typeof(JsonEnumAttribute)) is not null && reader.TokenType == JsonToken.String && reader.Value is not null)
                return reader.Value.ToString()!.ParseJsonEnumValue(objectType);

            throw new JsonReaderException("Unable to convert " + reader.Value + " of type " + reader.TokenType +
                                          " to " + objectType.FullName);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Enum) && objectType.GetCustomAttribute(typeof(JsonEnumAttribute)) is not null;
        }
    }
}
