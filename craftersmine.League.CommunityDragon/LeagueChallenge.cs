using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using craftersmine.League.CommunityDragon;
using Newtonsoft.Json;

namespace craftersmine.League.CommunityDragon
{
    public class LeagueChallenge
    {
        [JsonProperty("name")]
        public string Name { get; private set; }
        [JsonProperty("description")]
        public string Description { get; private set; }
        [JsonProperty("descriptionShort")]
        public string DescriptionShort { get; private set; }
        [JsonProperty("leaderboard")]
        public bool IsLeaderboard { get; private set; }
        [JsonProperty("reverseDirection")]
        public bool IsReverseDirection { get; private set; }
        [JsonProperty("queueIds")]
        public int[] QueueIds { get; private set; }
        [JsonProperty("seasons")]
        public int[] Seasons { get; private set; }
        [JsonProperty("source")]
        public LeagueChallengeSource Source { get; private set; }
        [JsonProperty("tags")]
        public LeagueChallengeTags Tags { get; private set; }
        [JsonProperty("levelToIconPath")]
        public ReadOnlyDictionary<LeagueChallengeRank, LeagueChallengeIcon> ChallengeIcons { get; private set; }
        [JsonProperty("thresholds")]
        public ReadOnlyDictionary<LeagueChallengeRank, LeagueChallengeThreshold> Thresholds { get; private set; }
        [JsonProperty("endTimestamp"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime EndTimestamp { get; private set; }
    }

    public class LeagueChallengeTags
    {
        [JsonProperty("isCapstone"), JsonConverter(typeof(JsonStringBooleanConverter))]
        public bool IsCapstone { get; private set; }
        [JsonProperty("isCategory")]
        public bool IsCategory { get; private set; }
        [JsonProperty("seasonal")]
        public bool Seasonal { get; private set; }
        [JsonProperty("parent")]
        public int Parent { get; private set; }
        [JsonProperty("priority")]
        public float Priority { get; private set; }
        [JsonProperty("season")]
        public int Season { get; private set; }
        [JsonProperty("championQuery")]
        public string ChampionQuery { get; private set; }
        [JsonProperty("itemQuery")]
        public string ItemQuery { get; private set; }
        [JsonProperty("valueMapping")]
        public ChallengeValueMapping ValueMapping { get; private set; }
    }

    [JsonConverter(typeof(ChallengeIconConverter))]
    public class LeagueChallengeIcon : IAsset
    {
        internal const string PathRoot = "/lol-game-data/assets/ASSETS/Challenges/Config/";

        internal CommunityDragon ClientInstance { get; set; }
        internal string RawPath { get; set; }

        internal LeagueChallengeIcon(string path)
        {
            RawPath = path;
        }

        public async Task<Stream> GetAssetStreamAsync()
        {
            return await ClientInstance.GetAssetStream(GetAssetUri());
        }

        public string GetAssetUri()
        {
            return ClientInstance.ClientAssetsUri + "challenges/config/" + RawPath.Replace(PathRoot, "").ToLower();
        }
    }

    public class LeagueChallengeThreshold
    {
        [JsonProperty("value")]
        public float Value { get; private set; }
        [JsonProperty("rewardGroupId")]
        public Guid RewardGroupId { get; private set; }
        [JsonProperty("rewards")]
        public LeagueChallengeReward[] Rewards { get; private set; }
    }

    public class LeagueChallengeReward
    {
        [JsonProperty("category")]
        public ChallengeCategory Category { get; private set; }
        [JsonProperty("id")]
        public Guid Id { get; private set; }
        [JsonProperty("quantity")]
        public int Quantity { get; private set; }
    }
}
