﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace craftersmine.League.CommunityDragon
{
    internal class AssetConverter<T> : JsonConverter where T : IAsset
    {
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value is T icon)
            {
                writer.WriteValue(icon.RawPath);
            }
            
            throw new JsonWriterException("Invalid type " + value?.GetType().FullName + ", expected " +
                                          typeof(LeagueChallengeIcon).FullName);
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                if (reader.Value is string path)
                {
                    T asset = (T)Activator.CreateInstance(typeof(T), path);
                    return asset;
                }
            }
            if (reader.TokenType == JsonToken.Null)
                return null;

            throw new JsonReaderException("Unexpected value \"" + reader.Value + "\" of " + reader.Path +
                                          ", expected string");
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(LeagueChallengeIcon);
        }
    }
}
