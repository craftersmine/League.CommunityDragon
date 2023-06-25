using System.Globalization;

namespace craftersmine.League.CommunityDragon
{
    public class CommunityDragon
    {
        private const string BaseUriFormat = "https://raw.communitydragon.org/{0}/plugins/rcp-be-lol-game-data/global/{1}/v1/";
        private const string ClientAssetsUriFormat =
            "https://raw.communitydragon.org/{0}/plugins/rcp-be-lol-game-data/global/default/assets/"; 

        private HttpClient _httpClient;

        public Uri MetadataUri { get; }
        public Uri ClientAssetsUri { get; }

        public CommunityDragon(Version gameVersion, CultureInfo locale)
        {
            _httpClient = new HttpClient();

            string localeStr;
            if (Equals(locale, CultureInfo.InvariantCulture))
                localeStr = "default";
            else localeStr = locale.Name.ToLower().Replace("-", "_");
            string gameVer = gameVersion.Major + "." + gameVersion.Minor;
            MetadataUri = new Uri(string.Format(BaseUriFormat, gameVer, localeStr));
            ClientAssetsUri = new Uri(string.Format(ClientAssetsUriFormat, gameVer));
        }
    }
}