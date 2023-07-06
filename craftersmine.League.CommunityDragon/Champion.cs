using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace craftersmine.League.CommunityDragon
{
    public class Champion
    {
        internal CommunityDragon ClientInstance { get; set; }

        [JsonProperty("id")]
        public int Id { get; private set; }
        [JsonProperty("name")]
        public string Name { get; private set; }
        [JsonProperty("alias")]
        public string Alias { get; private set; }
        [JsonProperty("squarePortraitPath")]
        public ChampionPortraitIcon PortraitIcon { get; private set; }
        [JsonProperty("roles")]
        public ChampionRole[] Roles { get; private set; }
    }

    [JsonConverter(typeof(AssetConverter<ChampionPortraitIcon>))]
    public class ChampionPortraitIcon : IAsset
    {
        internal CommunityDragon ClientInstance { get; set; }
        internal ChampionPortraitIcon(string path) { }

        public string RawPath { get; internal set; }

        public async Task<Stream> GetAssetStreamAsync()
        {
            throw new NotImplementedException();
        }

        public string GetAssetUri()
        {
            throw new NotImplementedException();
        }
    }
}
