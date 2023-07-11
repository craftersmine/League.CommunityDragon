using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Newtonsoft.Json;

namespace craftersmine.League.CommunityDragon
{
    internal class ColorConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value is Color color)
                writer.WriteValue("#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2"));
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String && reader.Value is string colorValue)
                return Color.FromArgb(Convert.ToInt32(colorValue.Replace("#", "")));
            else return Color.White;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Color);
        }
    }
}
