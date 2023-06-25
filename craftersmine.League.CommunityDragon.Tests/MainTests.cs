using System.Diagnostics;

namespace craftersmine.League.CommunityDragon.Tests
{
    [TestClass]
    public class MainTests
    {
        public const string BaseUriFormat =
            "https://raw.communitydragon.org/{0}/plugins/rcp-be-lol-game-data/global/{1}/v1/";
        private const string AssetsUriFormat =
            "https://raw.communitydragon.org/{0}/plugins/rcp-be-lol-game-data/global/default/assets/"; 

        [TestMethod]
        public void InitializationTests()
        {
            CommunityDragon dragonEn = new CommunityDragon(new Version(13, 12), LeagueLocales.English);
            Assert.IsNotNull(dragonEn);
            Assert.IsTrue(dragonEn.MetadataUri.ToString() == string.Format(BaseUriFormat, "13.12", "default"));
            Assert.IsTrue(dragonEn.ClientAssetsUri.ToString() == string.Format(AssetsUriFormat, "13.12"));
            Debug.WriteLine("Dragon Metadata EN-13.12: " + dragonEn.MetadataUri);
            Debug.WriteLine("Dragon Assets EN-13.12: " + dragonEn.ClientAssetsUri);
            CommunityDragon dragonRu = new CommunityDragon(new Version(13, 12), LeagueLocales.Russian);
            Assert.IsNotNull(dragonRu);
            Assert.IsTrue(dragonRu.MetadataUri.ToString() == string.Format(BaseUriFormat, "13.12", "ru_ru"));
            Assert.IsTrue(dragonRu.ClientAssetsUri.ToString() == string.Format(AssetsUriFormat, "13.12"));
            Debug.WriteLine("Dragon Metadata RU-13.12: " + dragonRu.MetadataUri);
            Debug.WriteLine("Dragon Assets RU-13.12: " + dragonEn.ClientAssetsUri);

        }
    }
}