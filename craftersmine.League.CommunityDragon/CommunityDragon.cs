using Newtonsoft.Json;

using System.Globalization;
using System.Net;

namespace craftersmine.League.CommunityDragon
{
    public class CommunityDragon
    {
        internal const string MetadataUriFormat = "https://raw.communitydragon.org/{0}/plugins/rcp-be-lol-game-data/global/{1}/v1/";
        internal const string ClientAssetsUriFormat =
            "https://raw.communitydragon.org/{0}/plugins/rcp-be-lol-game-data/global/default/assets/"; 

        private HttpClient _httpClient;

        public Uri MetadataUri { get; }
        public Uri ClientAssetsUri { get; }

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
        }

        public async Task<ItemsCollection> GetItemsAsync()
        {
            ItemsCollection items = new ItemsCollection(await GetAsync<Item[]>(MetadataUri + "items.json", null));
            foreach (Item item in items)
                item.ClientInstance = this;

            return items;
        }

        public async Task<SummonerIconsCollection> GetSummonerIcons()
        {
            SummonerIconsCollection icons =
                new SummonerIconsCollection(await GetAsync<SummonerIcon[]>(MetadataUri + "summoner-icons.json", null));
            foreach (SummonerIcon icon in icons)
                icon.ClientInstance = this;

            return icons;
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