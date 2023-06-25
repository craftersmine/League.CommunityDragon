using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;

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

        [TestMethod]
        public async Task ItemsRequestTests()
        {
            CommunityDragon dragonEn = new CommunityDragon(new Version(13, 12), LeagueLocales.English);
            Assert.IsNotNull(dragonEn);
            ItemsCollection items = await dragonEn.GetItemsAsync();
            Assert.IsNotNull(items);
            Assert.IsTrue(items.Any());
            Item unspokenParasiteItem_IdIndexed = items[7026];
            Item unspokenParasiteItem_NameIndexed = items[7026];

            Assert.IsNotNull(unspokenParasiteItem_IdIndexed);
            Assert.IsNotNull(unspokenParasiteItem_NameIndexed);

            Assert.AreEqual(unspokenParasiteItem_IdIndexed.Id, 7026);
            Assert.AreEqual(unspokenParasiteItem_IdIndexed.Name, " The Unspoken Parasite");
            Assert.AreEqual(unspokenParasiteItem_IdIndexed.Description, "<mainText><stats><ornnBonus> 550</ornnBonus> Health<br><ornnBonus> 40</ornnBonus> Armor<br><ornnBonus> 40</ornnBonus> Magic Resist<br><ornnBonus> 25</ornnBonus> Ability Haste</stats><br><li><passive>Voidborn Resilience:</passive> For each second in champion combat gain a stack granting <scaleArmor>Armor</scaleArmor> and <scaleMR>Magic Resist</scaleMR>, up to 8 stacks max. At max stacks become empowered, instantly draining enemies around you for magic damage, healing yourself, and increasing your bonus resist until end of combat.<br><br><rarityMythic>Mythic Passive:</rarityMythic> Grants all other <rarityLegendary>Legendary</rarityLegendary> items <attention>  Armor and  Magic Resist</attention>.</mainText><br>");
            Assert.IsFalse(unspokenParasiteItem_IdIndexed.Active);
            Assert.IsFalse(unspokenParasiteItem_IdIndexed.InStore);
            Assert.IsTrue(unspokenParasiteItem_IdIndexed.CraftableFromItemIds.Contains(6665));
            Assert.IsFalse(unspokenParasiteItem_IdIndexed.CraftedToItemIds.Any());
            Assert.IsTrue(unspokenParasiteItem_IdIndexed.Categories.Any());
            Assert.IsTrue(unspokenParasiteItem_IdIndexed.Categories.Contains(ItemCategory.AbilityHaste));
            Assert.AreEqual(unspokenParasiteItem_IdIndexed.MaxStacks, 1);
            Assert.AreEqual(unspokenParasiteItem_IdIndexed.RequiredChampion, string.Empty);
            Assert.AreEqual(unspokenParasiteItem_IdIndexed.RequiredAlly, "Ornn");
            Assert.AreEqual(unspokenParasiteItem_IdIndexed.RequiredBuffCurrencyName, string.Empty);
            Assert.AreEqual(unspokenParasiteItem_IdIndexed.RequiredBuffCurrencyCost, 0);
            Assert.AreEqual(unspokenParasiteItem_IdIndexed.SpecialRecipeItemId, 0);
            Assert.IsFalse(unspokenParasiteItem_IdIndexed.IsEnchantment);
            Assert.AreEqual(unspokenParasiteItem_IdIndexed.Price, 0);
            Assert.AreEqual(unspokenParasiteItem_IdIndexed.PriceTotal, 3200);
            
            if (OperatingSystem.IsWindows())
            {
                Stream iconDataStream = await unspokenParasiteItem_IdIndexed.GetAssetStreamAsync();
                Image icon = Image.FromStream(iconDataStream);
            }
            
            Assert.AreEqual(unspokenParasiteItem_NameIndexed.Id, 7026);
            Assert.AreEqual(unspokenParasiteItem_NameIndexed.Name, " The Unspoken Parasite");
            Assert.AreEqual(unspokenParasiteItem_NameIndexed.Description, "<mainText><stats><ornnBonus> 550</ornnBonus> Health<br><ornnBonus> 40</ornnBonus> Armor<br><ornnBonus> 40</ornnBonus> Magic Resist<br><ornnBonus> 25</ornnBonus> Ability Haste</stats><br><li><passive>Voidborn Resilience:</passive> For each second in champion combat gain a stack granting <scaleArmor>Armor</scaleArmor> and <scaleMR>Magic Resist</scaleMR>, up to 8 stacks max. At max stacks become empowered, instantly draining enemies around you for magic damage, healing yourself, and increasing your bonus resist until end of combat.<br><br><rarityMythic>Mythic Passive:</rarityMythic> Grants all other <rarityLegendary>Legendary</rarityLegendary> items <attention>  Armor and  Magic Resist</attention>.</mainText><br>");
            Assert.IsFalse(unspokenParasiteItem_NameIndexed.Active);
            Assert.IsFalse(unspokenParasiteItem_NameIndexed.InStore);
            Assert.IsTrue(unspokenParasiteItem_NameIndexed.CraftableFromItemIds.Contains(6665));
            Assert.IsFalse(unspokenParasiteItem_NameIndexed.CraftedToItemIds.Any());
            Assert.IsTrue(unspokenParasiteItem_NameIndexed.Categories.Any());
            Assert.IsTrue(unspokenParasiteItem_NameIndexed.Categories.Contains(ItemCategory.AbilityHaste));
            Assert.AreEqual(unspokenParasiteItem_NameIndexed.MaxStacks, 1);
            Assert.AreEqual(unspokenParasiteItem_NameIndexed.RequiredChampion, string.Empty);
            Assert.AreEqual(unspokenParasiteItem_NameIndexed.RequiredAlly, "Ornn");
            Assert.AreEqual(unspokenParasiteItem_NameIndexed.RequiredBuffCurrencyName, string.Empty);
            Assert.AreEqual(unspokenParasiteItem_NameIndexed.RequiredBuffCurrencyCost, 0);
            Assert.AreEqual(unspokenParasiteItem_NameIndexed.SpecialRecipeItemId, 0);
            Assert.IsFalse(unspokenParasiteItem_NameIndexed.IsEnchantment);
            Assert.AreEqual(unspokenParasiteItem_NameIndexed.Price, 0);
            Assert.AreEqual(unspokenParasiteItem_NameIndexed.PriceTotal, 3200);
        }

        [TestMethod]
        public async Task SummonerIconsRequestTest()
        {
            CommunityDragon dragonEn = new CommunityDragon(VersionAlias.Latest, LeagueLocales.English);
            Assert.IsNotNull(dragonEn);
            SummonerIconsCollection icons = await dragonEn.GetSummonerIcons();
            Assert.IsNotNull(icons);
            Assert.IsTrue(icons.Any());

            SummonerIcon elderwoodOrnnIcon_IdIndexed = icons[4846];
            SummonerIcon elderwoodOrnnIcon_TitleIndexed = icons["Elderwood Ornn Icon"];

            Assert.IsNotNull(elderwoodOrnnIcon_IdIndexed);
            Assert.IsNotNull(elderwoodOrnnIcon_TitleIndexed);

            Assert.AreEqual(elderwoodOrnnIcon_IdIndexed.Id, 4846);
            Assert.AreEqual(elderwoodOrnnIcon_IdIndexed.Title, "Elderwood Ornn Icon");
            Assert.AreEqual(elderwoodOrnnIcon_IdIndexed.YearReleased, 2020);
            Assert.IsFalse(elderwoodOrnnIcon_IdIndexed.IsLegacy);
            Assert.IsTrue(elderwoodOrnnIcon_IdIndexed.Descriptions.Any());
            Assert.AreEqual(elderwoodOrnnIcon_IdIndexed.Descriptions[0].Region, SummonerIconRegion.Riot);
            Assert.AreEqual(elderwoodOrnnIcon_IdIndexed.Descriptions[0].Description, "This icon was acquired from the Event Pass Token Shop during the 2020 Battle Queens event.");
            Assert.IsTrue(elderwoodOrnnIcon_IdIndexed.Rarities.Any());
            Assert.AreEqual(elderwoodOrnnIcon_IdIndexed.Rarities[0].Rarity, SummonerIconRarityValue.Epic);
            Assert.AreEqual(elderwoodOrnnIcon_IdIndexed.Rarities[0].Region, SummonerIconRegion.Riot);
            Assert.IsFalse(elderwoodOrnnIcon_IdIndexed.DisabledRegions.Any());
            Assert.IsTrue(string.IsNullOrWhiteSpace(elderwoodOrnnIcon_IdIndexed.EsportsTeam));
            Assert.IsTrue(string.IsNullOrWhiteSpace(elderwoodOrnnIcon_IdIndexed.EsportsEvent));
            Assert.AreEqual(elderwoodOrnnIcon_IdIndexed.EsportsRegion, SummonerIconEsportsRegion.None);

            if (OperatingSystem.IsWindows())
            {
                Stream iconDataStream = await elderwoodOrnnIcon_IdIndexed.GetAssetStreamAsync();
                Image icon = Image.FromStream(iconDataStream);
            }
        }
    }
}