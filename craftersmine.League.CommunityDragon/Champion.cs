using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace craftersmine.League.CommunityDragon
{
    public class Champion
    {
        internal CommunityDragon ClientInstance { get; set; }

        private ChampionSummary? _summary;

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

        public async Task<ChampionSummary?> GetSummary()
        {
            if (_summary is null)
                _summary = await ClientInstance.GetAsync<ChampionSummary>(ClientInstance.MetadataUri + "champions/" + Id +
                                                                    ".json", null);

            _summary.BanVoiceOver.ClientInstance = ClientInstance;
            _summary.ChooseVoiceOver.ClientInstance = ClientInstance;
            _summary.StingerSfx.ClientInstance = ClientInstance;
            if (_summary.Skins is not null && _summary.Skins.Any())
            {
                foreach (ChampionSkin skin in _summary.Skins)
                {
                    if (skin.ChromaImage is not null)
                        skin.ChromaImage.ClientInstance = ClientInstance;
                    if (skin.SplashVideo is not null)
                        skin.SplashVideo.ClientInstance = ClientInstance;
                    if (skin.CollectionSplashVideo is not null)
                        skin.CollectionSplashVideo.ClientInstance = ClientInstance;
                    skin.LoadingScreenPortrait.ClientInstance = ClientInstance;
                    skin.Splash.ClientInstance = ClientInstance;
                    skin.UncenteredSplash.ClientInstance = ClientInstance;
                    skin.Tile.ClientInstance = ClientInstance;
                    if (skin.Chromas is not null && skin.Chromas.Any())
                    {
                        foreach (ChampionChroma chroma in skin.Chromas)
                            chroma.ChromaImage.ClientInstance = ClientInstance;
                    }
                }
            }
            if (_summary.BanVoiceOver is not null)
                _summary.BanVoiceOver.ClientInstance = ClientInstance;
            if (_summary.BanVoiceOver is not null)
                _summary.BanVoiceOver.ClientInstance = ClientInstance;
            if (_summary.BanVoiceOver is not null)
                _summary.BanVoiceOver.ClientInstance = ClientInstance;

            return _summary;
        }
    }

    [JsonConverter(typeof(AssetConverter<ChampionPortraitIcon>))]
    public class ChampionPortraitIcon : IAsset
    {
        internal CommunityDragon ClientInstance { get; set; }
        public ChampionPortraitIcon(string path) { }

        public string RawPath { get; internal set; }

        public async Task<Stream> GetAssetStreamAsync()
        {
            return await ClientInstance.GetAssetStream(GetAssetUri());
        }

        public string GetAssetUri()
        {
            return ClientInstance.MetadataUri + "champion-icons/" + Path.GetFileName(RawPath).ToLower();
        }
    }

    public class ChampionSummary
    {
        [JsonProperty("title")]
        public string Title { get; private set; }
        [JsonProperty("shortBio")]
        public string ShortBiography { get; private set; }
        [JsonProperty("tacticalInfo")]
        public ChampionTacticalInfo TacticalInfo { get; private set; }
        [JsonProperty("playstyleInfo")]
        public ChampionPlaystyleInfo Playstyle { get; private set; }
        [JsonProperty("stingerSfxPath")]
        public ChampionSfxAsset StingerSfx { get; private set; }
        [JsonProperty("chooseVoPath")]
        public ChampionChooseVoiceOverAsset ChooseVoiceOver { get; private set; }
        [JsonProperty("banVoPath")]
        public ChampionBanVoiceOverAsset BanVoiceOver { get; private set; }
        [JsonProperty("roles")]
        public ChampionRole[] Roles { get; private set; }
        [JsonProperty("skins")]
        public ChampionSkin[] Skins { get; private set; }
        [JsonProperty("passive")]
        public ChampionAbility Passive { get; private set; }
        [JsonProperty("spells")]
        public ChampionSpell[] Spells { get; private set; }
    }

    public class ChampionPlaystyleInfo
    {
        [JsonProperty("damage")]
        public int Damage { get; private set; }
        [JsonProperty("durability")]
        public int Durability { get; private set; }
        [JsonProperty("crowdControl")]
        public int CrowdControl { get; private set; }
        [JsonProperty("mobility")]
        public int Mobility { get; private set; }
        [JsonProperty("utility")]
        public int Utility { get; private set; }
    }

    public class ChampionTacticalInfo
    {
        [JsonProperty("style")]
        public int Style { get; private set; }
        [JsonProperty("difficulty")]
        public int Difficulty { get; private set; }
        [JsonProperty("damageType")]
        public ChampionDamageType DamageType { get; private set; }
    }

    [JsonConverter(typeof(AssetConverter<ChampionSfxAsset>))]
    public class ChampionSfxAsset : IAsset
    {
        internal CommunityDragon ClientInstance { get; set; }
        internal ChampionSfxAsset(string path) { }

        public string RawPath { get; internal set; }

        public async Task<Stream> GetAssetStreamAsync()
        {
            return await ClientInstance.GetAssetStream(GetAssetUri());
        }

        public string GetAssetUri()
        {
            return ClientInstance.ClientAssetsUri + "champion-sfx-audios/" + Path.GetFileName(RawPath).ToLower();
        }
    }

    [JsonConverter(typeof(AssetConverter<ChampionChooseVoiceOverAsset>))]
    public class ChampionChooseVoiceOverAsset : IAsset
    {
        internal CommunityDragon ClientInstance { get; set; }
        internal ChampionChooseVoiceOverAsset(string path) { }

        public string RawPath { get; internal set; }

        public async Task<Stream> GetAssetStreamAsync()
        {
            return await ClientInstance.GetAssetStream(GetAssetUri());
        }

        public string GetAssetUri()
        {
            return ClientInstance.ClientAssetsUri + "champion-choose-vo/" + Path.GetFileName(RawPath).ToLower();
        }
    }

    [JsonConverter(typeof(AssetConverter<ChampionBanVoiceOverAsset>))]
    public class ChampionBanVoiceOverAsset : IAsset
    {
        internal CommunityDragon ClientInstance { get; set; }
        internal ChampionBanVoiceOverAsset(string path) { }

        public string RawPath { get; internal set; }

        public async Task<Stream> GetAssetStreamAsync()
        {
            return await ClientInstance.GetAssetStream(GetAssetUri());
        }

        public string GetAssetUri()
        {
            return ClientInstance.ClientAssetsUri + "champion-ban-vo/" + Path.GetFileName(RawPath).ToLower();
        }
    }

    public class ChampionSkin
    {
        [JsonProperty("id")]
        public int Id { get; private set; }
        [JsonProperty("isBase")]
        public bool IsBaseSkin { get; private set; }
        [JsonProperty("name")]
        public string Name { get; private set; }
        [JsonProperty("splashPath")]
        public ChampionSplashAsset Splash { get; private set; }
        [JsonProperty("uncenteredSplashPath")]
        public ChampionSplashAsset UncenteredSplash { get; private set; }
        [JsonProperty("tilePath")]
        public ChampionTileAsset Tile { get; private set; }
        [JsonProperty("loadScreenPath")]
        public ChampionClientGameAsset LoadingScreenPortrait { get; private set; }
        [JsonProperty("skinType")]
        public string SkinType { get; private set; } // TODO: determine what is this
        [JsonProperty("rarity")]
        public ChampionSkinRarity Rarity { get; private set; }
        [JsonProperty("isLegacy")]
        public bool IsLegacy { get; private set; }
        [JsonProperty("splashVideoPath")]
        public ChampionClientGameAsset? SplashVideo { get; private set; }
        [JsonProperty("collectionSplashVideoPath")]
        public ChampionClientGameAsset? CollectionSplashVideo { get; private set; }
        [JsonProperty("featuresText")]
        public string? FeaturesText { get; private set; }
        [JsonProperty("chromaPath")]
        public ChampionChromaAsset? ChromaImage { get; private set; }
        [JsonProperty("chromas")]
        public ChampionChroma[] Chromas { get; private set; }
        // TODO: Add emblems
        [JsonProperty("regionRarityId")]
        public int RegionRarityId { get; private set; }
        // TODO: Add rarity gem path
        [JsonProperty("skinLines")]
        public ChampionSkinline[] Skinlines { get; private set; }
        [JsonProperty("description")]
        public string Description { get; private set; }
    }

    [JsonConverter(typeof(AssetConverter<ChampionSplashAsset>))]
    public class ChampionSplashAsset : IAsset
    {
        private const string ChampionSplashPath = "/lol-game-data/assets/v1/champion-splashes/";
        internal CommunityDragon ClientInstance { get; set; }
        internal ChampionSplashAsset(string path) { }

        public string RawPath { get; internal set; }

        public async Task<Stream> GetAssetStreamAsync()
        {
            return await ClientInstance.GetAssetStream(GetAssetUri());
        }

        public string GetAssetUri()
        {
            return ClientInstance.ClientAssetsUri + "champion-splashes/" + RawPath.Replace(ChampionSplashPath, "").ToLower();
        }
    }

    [JsonConverter(typeof(AssetConverter<ChampionTileAsset>))]
    public class ChampionTileAsset : IAsset
    {
        internal CommunityDragon ClientInstance { get; set; }
        internal ChampionTileAsset(string path) { }

        public string RawPath { get; internal set; }

        public async Task<Stream> GetAssetStreamAsync()
        {
            return await ClientInstance.GetAssetStream(GetAssetUri());
        }

        public string GetAssetUri()
        {
            return ClientInstance.ClientAssetsUri + "champion-tiles/" + Path.GetFileName(RawPath).ToLower();
        }
    }

    [JsonConverter(typeof(AssetConverter<ChampionClientGameAsset>))]
    public class ChampionClientGameAsset : IAsset
    {
        private const string LoadingScreenPathRoot = "/lol-game-data/assets/ASSETS/Characters/";

        internal CommunityDragon ClientInstance { get; set; }
        internal ChampionClientGameAsset(string path) { }

        public string RawPath { get; internal set; }

        public async Task<Stream> GetAssetStreamAsync()
        {
            return await ClientInstance.GetAssetStream(GetAssetUri());
        }

        public string GetAssetUri()
        {
            return ClientInstance.ClientAssetsUri + RawPath.Replace(LoadingScreenPathRoot, "").ToLower();
        }
    }

    //[JsonConverter(typeof(AssetConverter<ChampionSplashVideoAsset>))]
    //public class ChampionSplashVideoAsset : IAsset
    //{
    //    private const string LoadingScreenPathRoot = "/lol-game-data/assets/ASSETS/Characters/";

    //    internal CommunityDragon ClientInstance { get; set; }
    //    internal ChampionSplashVideoAsset(string path) { }

    //    public string RawPath { get; internal set; }

    //    public async Task<Stream> GetAssetStreamAsync()
    //    {
    //        return await ClientInstance.GetAssetStream(GetAssetUri());
    //    }

    //    public string GetAssetUri()
    //    {
    //        return ClientInstance.ClientAssetsUri + RawPath.Replace(LoadingScreenPathRoot, "").ToLower();
    //    }
    //}

    [JsonConverter(typeof(AssetConverter<ChampionChromaAsset>))]
    public class ChampionChromaAsset : IAsset
    {
        private const string ChampionSplashPath = "/lol-game-data/assets/v1/champion-chroma-images/";
        internal CommunityDragon ClientInstance { get; set; }
        internal ChampionChromaAsset(string path) { }

        public string RawPath { get; internal set; }

        public async Task<Stream> GetAssetStreamAsync()
        {
            return await ClientInstance.GetAssetStream(GetAssetUri());
        }

        public string GetAssetUri()
        {
            return ClientInstance.ClientAssetsUri + "champion-chroma-images/" + RawPath.Replace(ChampionSplashPath, "").ToLower();
        }
    }

    public class ChampionChroma
    {
        [JsonProperty("id")]
        public int Id { get; private set; }
        [JsonProperty("name")]
        public string Name { get; private set; }
        [JsonProperty("chromaPath")]
        public ChampionChromaAsset ChromaImage { get; private set; }
        [JsonProperty("colors"), JsonConverter(typeof(ColorConverter))]
        public Color[] Colors { get; private set; }
        [JsonProperty("descriptions")]
        public ChampionChromaDescription Description { get; private set; }
        [JsonProperty("rarities")]
        public ChampionChromaRarities Rarities { get; private set; }
    }

    public class ChampionChromaDescription
    {
        [JsonProperty("region")]
        public AssetRegion Region { get; private set; }
        [JsonProperty("description")]
        public string Description { get; private set; }
    }

    public class ChampionChromaRarities
    {
        [JsonProperty("region")]
        public AssetRegion Region { get; private set; }
        [JsonProperty("rarity")]
        public int Rarity { get; private set; }
    }

    public class ChampionSkinline
    {
        [JsonProperty("id")]
        public int Id { get; private set; }
    }

    public class ChampionAbility
    {
        [JsonProperty("name")]
        public string Name { get; private set; }
        [JsonProperty("abilityIconPath")]
        public ChampionClientGameAsset AbilityIcon { get; private set; }
        // TODO: add ability video paths
        [JsonProperty("description")]
        public string Description { get; private set; }
    }

    public class ChampionSpell : ChampionAbility
    {
        [JsonProperty("spellKey")]
        public string SpellKey { get; private set; }
        [JsonProperty("cost")]
        public string Cost { get; private set; }
        [JsonProperty("cooldown")]
        public string Cooldown { get; private set; }
        [JsonProperty("dynamicDescription")]
        public string DynamicDescription { get; private set; }
        [JsonProperty("range")]
        public float[] Ranges { get; private set; }
        [JsonProperty("costCoefficients")]
        public float[] CostCoefficients { get; private set; }
        [JsonProperty("cooldownCoefficients")]
        public float[] CooldownCoefficients { get; private set; }
        [JsonProperty("coefficients")]
        public ChampionSpellCoefficients Coefficients { get; private set; }
        [JsonProperty("effectAmmounts")]
        public ChampionSpellEffectAmounts EffectAmounts { get; private set; }
        [JsonProperty("ammo")]
        public ChampionSpellAmmoInfo AmmoInfo { get; private set; }
        [JsonProperty("maxLevel")]
        public int MaxLevel { get; private set; }
    }

    //[JsonConverter(typeof(AssetConverter<ChampionVideoAsset>))]
    //public class ChampionVideoAsset : IAsset
    //{
    //    private const string ChampionSplashPath = "/lol-game-data/assets/ASSETS/Characters/";
    //    internal CommunityDragon ClientInstance { get; set; }
    //    internal ChampionVideoAsset(string path) { }

    //    public string RawPath { get; internal set; }

    //    public async Task<Stream> GetAssetStreamAsync()
    //    {
    //        return await ClientInstance.GetAssetStream(GetAssetUri());
    //    }

    //    public string GetAssetUri()
    //    {
    //        return ClientInstance.GameAssetsUri + "characters/" + RawPath.Replace(ChampionSplashPath, "").ToLower();
    //    }
    //}

    public class ChampionSpellCoefficients
    {
        [JsonProperty("coefficient1")]
        public float CoefficientOne { get; private set; }
        [JsonProperty("coefficient2")]
        public float CoefficientTwo { get; private set; }
    }

    public class ChampionSpellEffectAmounts
    {
        [JsonProperty("Effect1Amonunt")]
        public float Effect1Amount { get; private set; }
        [JsonProperty("Effect2Amonunt")]
        public float Effect2Amount { get; private set; }
        [JsonProperty("Effect3Amonunt")]
        public float Effect3Amount { get; private set; }
        [JsonProperty("Effect4Amonunt")]
        public float Effect4Amount { get; private set; }
        [JsonProperty("Effect5Amonunt")]
        public float Effect5Amount { get; private set; }
        [JsonProperty("Effect6Amonunt")]
        public float Effect6Amount { get; private set; }
        [JsonProperty("Effect7Amonunt")]
        public float Effect7Amount { get; private set; }
        [JsonProperty("Effect8Amonunt")]
        public float Effect8Amount { get; private set; }
        [JsonProperty("Effect9Amonunt")]
        public float Effect9Amount { get; private set; }
        [JsonProperty("Effect10Amonunt")]
        public float Effect10Amount { get; private set; }
    }

    public class ChampionSpellAmmoInfo
    {
        [JsonProperty("ammoRechargeTime")]
        public float[] AmmoRechargeTime { get; private set; }
        [JsonProperty("maxAmmo")]
        public float[] MaxAmmo { get; private set; }
    }
}
