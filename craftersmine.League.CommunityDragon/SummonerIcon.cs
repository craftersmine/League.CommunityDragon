using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace craftersmine.League.CommunityDragon
{
    public class SummonerIcon : IAsset
    {
        internal CommunityDragon ClientInstance { get; set; }

        [JsonProperty("id")]
        public int Id { get; private set; }
        [JsonProperty("yearReleased")]
        public int YearReleased { get; private set; }
        [JsonProperty("isLegacy")]
        public bool IsLegacy { get; private set; }
        [JsonProperty("title")]
        public string Title { get; private set; }
        [JsonProperty("esportsTeam")]
        public string EsportsTeam { get; private set; }
        [JsonProperty("esportsEvent")]
        public string EsportsEvent { get; private set; }
        [JsonProperty("esportsRegion")]
        public SummonerIconEsportsRegion EsportsRegion { get; private set; }
        [JsonProperty("descriptions")]
        public SummonerIconDescription[] Descriptions { get; private set; }
        [JsonProperty("rarities")]
        public SummonerIconRarity[] Rarities { get; private set; }
        [JsonProperty("disabledRegions")]
        public SummonerIconRegion[] DisabledRegions { get; private set; }

        [JsonProperty("imagePath")]
        public string RawPath { get; private set; }

        public async Task<Stream> GetAssetStreamAsync()
        {
            return await ClientInstance.GetAssetStream(GetAssetUri());
        }

        public string GetAssetUri()
        {
            return ClientInstance.MetadataUri + "profile-icons/" + Path.GetFileName(ImagePath);
        }
    }

    public class SummonerIconDescription
    {
        [JsonProperty("region")]
        public SummonerIconRegion Region { get; private set; }
        [JsonProperty("description")]
        public string Description { get; private set; }
    }

    public class SummonerIconRarity
    {
        [JsonProperty("region")]
        public SummonerIconRegion Region { get; private set; }
        [JsonProperty("rarity")]
        public SummonerIconRarityValue Rarity { get; private set; }
    }
}
