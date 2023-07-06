using System.Diagnostics;
using System.Drawing;

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

            Assert.AreEqual(7026, unspokenParasiteItem_IdIndexed.Id);
            Assert.AreEqual(" The Unspoken Parasite", unspokenParasiteItem_IdIndexed.Name);
            Assert.AreEqual("<mainText><stats><ornnBonus> 550</ornnBonus> Health<br><ornnBonus> 40</ornnBonus> Armor<br><ornnBonus> 40</ornnBonus> Magic Resist<br><ornnBonus> 25</ornnBonus> Ability Haste</stats><br><li><passive>Voidborn Resilience:</passive> For each second in champion combat gain a stack granting <scaleArmor>Armor</scaleArmor> and <scaleMR>Magic Resist</scaleMR>, up to 8 stacks max. At max stacks become empowered, instantly draining enemies around you for magic damage, healing yourself, and increasing your bonus resist until end of combat.<br><br><rarityMythic>Mythic Passive:</rarityMythic> Grants all other <rarityLegendary>Legendary</rarityLegendary> items <attention>  Armor and  Magic Resist</attention>.</mainText><br>", unspokenParasiteItem_IdIndexed.Description);
            Assert.IsFalse(unspokenParasiteItem_IdIndexed.Active);
            Assert.IsFalse(unspokenParasiteItem_IdIndexed.InStore);
            Assert.IsTrue(unspokenParasiteItem_IdIndexed.CraftableFromItemIds.Contains(6665));
            Assert.IsFalse(unspokenParasiteItem_IdIndexed.CraftedToItemIds.Any());
            Assert.IsTrue(unspokenParasiteItem_IdIndexed.Categories.Any());
            Assert.IsTrue(unspokenParasiteItem_IdIndexed.Categories.Contains(ItemCategory.AbilityHaste));
            Assert.AreEqual(1, unspokenParasiteItem_IdIndexed.MaxStacks);
            Assert.AreEqual(string.Empty, unspokenParasiteItem_IdIndexed.RequiredChampion);
            Assert.AreEqual("Ornn", unspokenParasiteItem_IdIndexed.RequiredAlly);
            Assert.AreEqual(string.Empty, unspokenParasiteItem_IdIndexed.RequiredBuffCurrencyName);
            Assert.AreEqual(0, unspokenParasiteItem_IdIndexed.RequiredBuffCurrencyCost);
            Assert.AreEqual(0, unspokenParasiteItem_IdIndexed.SpecialRecipeItemId);
            Assert.IsFalse(unspokenParasiteItem_IdIndexed.IsEnchantment);
            Assert.AreEqual(0, unspokenParasiteItem_IdIndexed.Price);
            Assert.AreEqual(3200, unspokenParasiteItem_IdIndexed.PriceTotal);
            
            if (OperatingSystem.IsWindows())
            {
                Stream iconDataStream = await unspokenParasiteItem_IdIndexed.GetAssetStreamAsync();
                Image icon = Image.FromStream(iconDataStream);
            }
            
            Assert.AreEqual(7026, unspokenParasiteItem_NameIndexed.Id);
            Assert.AreEqual(" The Unspoken Parasite", unspokenParasiteItem_NameIndexed.Name);
            Assert.AreEqual("<mainText><stats><ornnBonus> 550</ornnBonus> Health<br><ornnBonus> 40</ornnBonus> Armor<br><ornnBonus> 40</ornnBonus> Magic Resist<br><ornnBonus> 25</ornnBonus> Ability Haste</stats><br><li><passive>Voidborn Resilience:</passive> For each second in champion combat gain a stack granting <scaleArmor>Armor</scaleArmor> and <scaleMR>Magic Resist</scaleMR>, up to 8 stacks max. At max stacks become empowered, instantly draining enemies around you for magic damage, healing yourself, and increasing your bonus resist until end of combat.<br><br><rarityMythic>Mythic Passive:</rarityMythic> Grants all other <rarityLegendary>Legendary</rarityLegendary> items <attention>  Armor and  Magic Resist</attention>.</mainText><br>", unspokenParasiteItem_NameIndexed.Description);
            Assert.IsFalse(unspokenParasiteItem_NameIndexed.Active);
            Assert.IsFalse(unspokenParasiteItem_NameIndexed.InStore);
            Assert.IsTrue(unspokenParasiteItem_NameIndexed.CraftableFromItemIds.Contains(6665));
            Assert.IsFalse(unspokenParasiteItem_NameIndexed.CraftedToItemIds.Any());
            Assert.IsTrue(unspokenParasiteItem_NameIndexed.Categories.Any());
            Assert.IsTrue(unspokenParasiteItem_NameIndexed.Categories.Contains(ItemCategory.AbilityHaste));
            Assert.AreEqual(1, unspokenParasiteItem_NameIndexed.MaxStacks);
            Assert.AreEqual(string.Empty, unspokenParasiteItem_NameIndexed.RequiredChampion);
            Assert.AreEqual("Ornn", unspokenParasiteItem_NameIndexed.RequiredAlly);
            Assert.AreEqual(string.Empty, unspokenParasiteItem_NameIndexed.RequiredBuffCurrencyName);
            Assert.AreEqual(0, unspokenParasiteItem_NameIndexed.RequiredBuffCurrencyCost);
            Assert.AreEqual(0, unspokenParasiteItem_NameIndexed.SpecialRecipeItemId);
            Assert.IsFalse(unspokenParasiteItem_NameIndexed.IsEnchantment);
            Assert.AreEqual(0, unspokenParasiteItem_NameIndexed.Price);
            Assert.AreEqual(3200, unspokenParasiteItem_NameIndexed.PriceTotal);
        }

        [TestMethod]
        public async Task SummonerIconsRequestTest()
        {
            CommunityDragon dragonEn = new CommunityDragon(VersionAlias.Latest, LeagueLocales.English);
            Assert.IsNotNull(dragonEn);
            SummonerIconsCollection icons = await dragonEn.GetSummonerIconsAsync();
            Assert.IsNotNull(icons);
            Assert.IsTrue(icons.Any());

            SummonerIcon elderwoodOrnnIcon_IdIndexed = icons[4846];
            SummonerIcon elderwoodOrnnIcon_TitleIndexed = icons["Elderwood Ornn Icon"];

            Assert.IsNotNull(elderwoodOrnnIcon_IdIndexed);
            Assert.IsNotNull(elderwoodOrnnIcon_TitleIndexed);

            Assert.AreEqual(4846, elderwoodOrnnIcon_IdIndexed.Id);
            Assert.AreEqual("Elderwood Ornn Icon", elderwoodOrnnIcon_IdIndexed.Title);
            Assert.AreEqual(2020, elderwoodOrnnIcon_IdIndexed.YearReleased);
            Assert.IsFalse(elderwoodOrnnIcon_IdIndexed.IsLegacy);
            Assert.IsTrue(elderwoodOrnnIcon_IdIndexed.Descriptions.Any());
            Assert.AreEqual(SummonerIconRegion.Riot, elderwoodOrnnIcon_IdIndexed.Descriptions[0].Region);
            Assert.AreEqual("This icon was acquired from the Event Pass Token Shop during the 2020 Battle Queens event.", elderwoodOrnnIcon_IdIndexed.Descriptions[0].Description);
            Assert.IsTrue(elderwoodOrnnIcon_IdIndexed.Rarities.Any());
            Assert.AreEqual(SummonerIconRarityValue.Epic, elderwoodOrnnIcon_IdIndexed.Rarities[0].Rarity);
            Assert.AreEqual(SummonerIconRegion.Riot, elderwoodOrnnIcon_IdIndexed.Rarities[0].Region);
            Assert.IsFalse(elderwoodOrnnIcon_IdIndexed.DisabledRegions.Any());
            Assert.IsTrue(string.IsNullOrWhiteSpace(elderwoodOrnnIcon_IdIndexed.EsportsTeam));
            Assert.IsTrue(string.IsNullOrWhiteSpace(elderwoodOrnnIcon_IdIndexed.EsportsEvent));
            Assert.AreEqual(SummonerIconEsportsRegion.None, elderwoodOrnnIcon_IdIndexed.EsportsRegion);

            if (OperatingSystem.IsWindows())
            {
                Stream iconDataStream = await elderwoodOrnnIcon_IdIndexed.GetAssetStreamAsync();
                Image icon = Image.FromStream(iconDataStream);
            }
        }

        [TestMethod]
        public async Task SummonerIconSetsRequestTest()
        {
            CommunityDragon dragonEn = new CommunityDragon(VersionAlias.Latest, LeagueLocales.English);
            Assert.IsNotNull(dragonEn);
            SummonerIconSetCollection iconSets = await dragonEn.GetSummonerIconSetsAsync();

            SummonerIconSet elderwoodIconSet_IdIndexed = iconSets[112];
            SummonerIconSet elderwoodIconSet_TitleIndexed = iconSets["Elderwood"];

            Assert.IsNotNull(elderwoodIconSet_IdIndexed);
            Assert.IsNotNull(elderwoodIconSet_TitleIndexed);

            Assert.AreEqual(112, elderwoodIconSet_IdIndexed.Id);
            Assert.IsFalse(elderwoodIconSet_IdIndexed.IsHidden);
            Assert.AreEqual("Elderwood", elderwoodIconSet_IdIndexed.DisplayName);
            Assert.AreEqual(string.Empty, elderwoodIconSet_IdIndexed.Description);
            Assert.IsTrue(elderwoodIconSet_IdIndexed.IconIds.Contains(4846));
        }

        [TestMethod]
        public async Task LeagueChallengesTest()
        {
            int challengeId = 402406;
            CommunityDragon dragonEn = new CommunityDragon(VersionAlias.Latest, LeagueLocales.English);
            Assert.IsNotNull(dragonEn);
            LeagueChallengesCollection challenges = await dragonEn.GetLeagueChallengesAsync();
            LeagueChallenge challenge = challenges[challengeId];
            Assert.IsNotNull(challenge);
            Assert.AreEqual("Multi-Weapon Master", challenge.Name);
            Assert.AreEqual("Win with each of different mythic items", challenge.Description);
            Assert.AreEqual("Win with <em>different mythic items</em>", challenge.DescriptionShort);
            Assert.IsFalse(challenge.IsLeaderboard);
            Assert.IsFalse(challenge.IsReverseDirection);
            Assert.IsTrue(challenge.QueueIds.Any());
            Assert.IsTrue(challenge.QueueIds.Contains(400));
            Assert.IsFalse(challenge.Seasons.Any());
            Assert.AreEqual(LeagueChallengeSource.EOGD, challenge.Source);
            Assert.AreEqual(DateTime.UnixEpoch, challenge.EndTimestamp);
            Assert.IsNotNull(challenge.Tags);
            Assert.AreEqual(402400, challenge.Tags.Parent);
            Assert.AreEqual("$[?(@.epicness == 'EPICNESS_MYTHIC' && 'Items/ItemGroups/OrnnItems' nin @.groups)].id", challenge.Tags.ItemQuery);
            Assert.IsNotNull(challenge.ChallengeIcons);
            Assert.IsTrue(challenge.ChallengeIcons.Any());
            Assert.IsTrue(challenge.ChallengeIcons.ContainsKey(LeagueChallengeRank.Challenger));
            LeagueChallengeIcon icon = challenge.ChallengeIcons[LeagueChallengeRank.Challenger];
            Assert.IsNotNull(icon);
            Assert.AreEqual(dragonEn.ClientAssetsUri + "challenges/config/402406/tokens/challenger.png",icon.GetAssetUri());
            Assert.IsTrue(challenge.Thresholds.Any());
            Assert.IsTrue(challenge.Thresholds.ContainsKey(LeagueChallengeRank.Master));
            Assert.IsFalse(challenge.Thresholds.ContainsKey(LeagueChallengeRank.Challenger));
            LeagueChallengeThreshold threshold = challenge.Thresholds[LeagueChallengeRank.Master];
            Assert.IsNotNull(threshold);
            Assert.AreEqual(23.0, threshold.Value, 0.01);

            if (OperatingSystem.IsWindows())
            {
                Image img = Image.FromStream(await challenges[challengeId].ChallengeIcons[LeagueChallengeRank.Challenger].GetAssetStreamAsync());
            }
        }
    }
}