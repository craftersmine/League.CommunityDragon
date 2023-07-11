using System.Collections.ObjectModel;
using Newtonsoft.Json;

using System.Globalization;
using System.Net;
using Newtonsoft.Json.Linq;

namespace craftersmine.League.CommunityDragon
{
    public class CommunityDragon
    {
        internal const string MetadataUriFormat = "https://raw.communitydragon.org/{0}/plugins/rcp-be-lol-game-data/global/{1}/v1/";
        internal const string ClientAssetsUriFormat =
            "https://raw.communitydragon.org/{0}/plugins/rcp-be-lol-game-data/global/default/assets/";

        internal const string GameAssetsUriFormat = "https://raw.communitydragon.org/{0}/game/assets/";

        private HttpClient _httpClient;

        public Uri MetadataUri { get; }
        public Uri ClientAssetsUri { get; }
        public Uri GameAssetsUri { get; }

        public CommunityDragon(VersionAlias version, CultureInfo locale)
        {
            _httpClient = new HttpClient();

            string localeStr;
            if (Equals(locale, CultureInfo.InvariantCulture))
                localeStr = "default";
            else localeStr = locale.Name.ToLower().Replace("-", "_");
            string gameVer = "latest";
            switch (version)
            {
                case VersionAlias.Latest:
                    gameVer = "latest";
                    break;
                case VersionAlias.PBE:
                    gameVer = "pbe";
                    break;
            }
            MetadataUri = new Uri(string.Format(MetadataUriFormat, gameVer, localeStr));
            ClientAssetsUri = new Uri(string.Format(ClientAssetsUriFormat, gameVer));
            GameAssetsUri = new Uri(string.Format(GameAssetsUriFormat, gameVer));
        }

        public CommunityDragon(Version gameVersion, CultureInfo locale)
        {
            _httpClient = new HttpClient();

            string localeStr;
            if (Equals(locale, CultureInfo.InvariantCulture))
                localeStr = "default";
            else localeStr = locale.Name.ToLower().Replace("-", "_");
            string gameVer = gameVersion.Major + "." + gameVersion.Minor;
            MetadataUri = new Uri(string.Format(MetadataUriFormat, gameVer, localeStr));
            ClientAssetsUri = new Uri(string.Format(ClientAssetsUriFormat, gameVer));
            GameAssetsUri = new Uri(string.Format(GameAssetsUriFormat, gameVer));
        }

        public async Task<ItemsCollection> GetItemsAsync()
        {
            ItemsCollection items = new ItemsCollection(await GetAsync<Item[]>(MetadataUri + "items.json", null));
            foreach (Item item in items)
                item.ClientInstance = this;

            return items;
        }

        public async Task<SummonerIconsCollection> GetSummonerIconsAsync()
        {
            SummonerIconsCollection icons =
                new SummonerIconsCollection(await GetAsync<SummonerIcon[]>(MetadataUri + "summoner-icons.json", null));
            foreach (SummonerIcon icon in icons)
                icon.ClientInstance = this;

            return icons;
        }

        public async Task<SummonerIconSetCollection> GetSummonerIconSetsAsync()
        {
            SummonerIconSetCollection iconSets =
                new SummonerIconSetCollection(
                    await GetAsync<SummonerIconSet[]>(MetadataUri + "summoner-icon-sets.json", null));
            return iconSets;
        }

        public async Task<LeagueChallengesCollection> GetLeagueChallengesAsync()
        {
            JObject obj = await GetAsync<JObject>(MetadataUri + "challenges.json", null);
            Dictionary<int, LeagueChallenge>
                challenges = obj["challenges"].ToObject<Dictionary<int, LeagueChallenge>>();
            foreach (LeagueChallenge challenge in challenges.Values)
            {
                foreach (LeagueChallengeIcon icon in challenge.ChallengeIcons.Values)
                    icon.ClientInstance = this;
            }
            return new LeagueChallengesCollection(challenges);
        }

        #region Internals

        internal async Task<Stream> GetAssetStream(string assetPath)
        {
            var response = await _httpClient.GetAsync(assetPath, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();

            var stream = await response.Content.ReadAsStreamAsync();
            MemoryStream memStream = new MemoryStream();

            if (response.Content.Headers.ContentLength is null)
                throw new ArgumentOutOfRangeException(nameof(response),
                    "Response content stream length is not present in response!");

            await stream.CopyToAsync(memStream);
            //stream.SetLength(response.Content.Headers.ContentLength.Value);
            return memStream;
        }

        internal async Task<T?> GetAsync<T>(string address, IDictionary<string, object>? queryParams)
        {
            List<string> queryParamsList = new List<string>();
            if (!(queryParams is null) && queryParams.Any())
            {
                foreach (var kvp in queryParams)
                {
                    queryParamsList.Add(string.Join("=", kvp.Key, kvp.Value));
                }

                string queryParamsString = string.Join("&", queryParamsList);
                queryParamsString = Uri.EscapeDataString(queryParamsString);
                address = string.Join("?", address, queryParamsString);
            }

            var response = await _httpClient.GetAsync(address);

            response.EnsureSuccessStatusCode();

            var responseStr = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode) return JsonConvert.DeserializeObject<T>(responseStr);

            if (string.IsNullOrWhiteSpace(responseStr))
                throw new CommunityDragonRequestException(response.StatusCode);

            throw new CommunityDragonRequestException(HttpStatusCode.BadRequest, "Unknown error has occurred when requesting CommunityDragon!");

        }

        #endregion
    }
}