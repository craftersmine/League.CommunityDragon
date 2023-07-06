using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace craftersmine.League.CommunityDragon
{
    public enum VersionAlias
    {
        Latest,
        PBE
    }
    
    [JsonEnum, JsonConverter(typeof(JsonEnumConverter))]
    public enum ItemCategory
    {
        [JsonEnumValue("Damage")]
        Damage,
        [JsonEnumValue("Active")]
        Active,
        [JsonEnumValue("CooldownReduction")]
        CooldownReduction,
        [JsonEnumValue("ArmorPenetration")]
        ArmorPenetration,
        [JsonEnumValue("AbilityHaste")]
        AbilityHaste,
        [JsonEnumValue("Health")]
        Health,
        [JsonEnumValue("SpellBlock")]
        SpellBlock,
        [JsonEnumValue("Armor")]
        Armor,
        [JsonEnumValue("MagicResist")]
        MagicResist,
        [JsonEnumValue("Boots")]
        Boots,
        [JsonEnumValue("ManaRegen")]
        ManaRegen,
        [JsonEnumValue("HealthRegen")]
        HealthRegen,
        [JsonEnumValue("CriticalStrike")]
        CriticalStrike,
        [JsonEnumValue("SpellDamage")]
        SpellDamage,
        [JsonEnumValue("Mana")]
        Mana,
        [JsonEnumValue("LifeSteal")]
        LifeSteal,
        [JsonEnumValue("SpellVamp")]
        SpellVamp,
        [JsonEnumValue("Jungle")]
        Jungle,
        [JsonEnumValue("Lane")]
        Lane,
        [JsonEnumValue("AttackSpeed")]
        AttackSpeed,
        [JsonEnumValue("OnHit")]
        OnHit,
        [JsonEnumValue("Trinket")]
        Trinket,
        [JsonEnumValue("Consumable")]
        Consumable,
        [JsonEnumValue("Stealth")]
        Stealth,
        [JsonEnumValue("Vision")]
        Vision,
        [JsonEnumValue("NonbootsMovement")]
        NonBootsMovement,
        [JsonEnumValue("Tenacity")]
        Tenacity,
        [JsonEnumValue("MagicPenetration")]
        MagicPenetration,
        [JsonEnumValue("Aura")]
        Aura,
        [JsonEnumValue("Slow")]
        Slow,
        [JsonEnumValue("GoldPer")]
        GoldPer
    }

    [JsonEnum, JsonConverter(typeof(JsonEnumConverter))]
    public enum SummonerIconRegion
    {
        [JsonEnumValue("")]
        None,
        [JsonEnumValue("riot")]
        Riot,
        [JsonEnumValue("NA")]
        NorthAmerica,
        [JsonEnumValue("EUW")]
        EuropeWest,
        [JsonEnumValue("EUNE")]
        EuropeNordicEast,
        [JsonEnumValue("RU")]
        Russia,
        [JsonEnumValue("KR")]
        Korea,
        [JsonEnumValue("BR")]
        Brazil,
        [JsonEnumValue("TR")]
        Turkey,
        [JsonEnumValue("OC1", "OCE")]
        Oceania,
        [JsonEnumValue("LA1", "LAN")]
        LatinAmericaNorth,
        [JsonEnumValue("LA2", "LAS")]
        LatinAmericaSouth,
        [JsonEnumValue("JP")]
        Japan,
        [JsonEnumValue("TENCENT", "tencent")]
        Tencent,
        [JsonEnumValue("TEST")]
        Test,
        [JsonEnumValue("SEA", "GPL")]
        Garena,
        [JsonEnumValue("GARENA2")]
        Garena2,
        [JsonEnumValue("GARENA3")]
        Garena3,
        [JsonEnumValue("SG")]
        Singapore,
        [JsonEnumValue("PH")]
        Philippines,
        [JsonEnumValue("TW")]
        Taiwan,
        [JsonEnumValue("TH")]
        Thailand,
        [JsonEnumValue("VN")]
        Vietnam,
        [JsonEnumValue("ID")]
        Indonesian,
    }

    [JsonEnum, JsonConverter(typeof(JsonEnumConverter))]
    public enum SummonerIconEsportsRegion
    {
        [JsonEnumValue("")]
        None,
        [JsonEnumValue("NA")]
        NorthAmerica,
        [JsonEnumValue("EU")]
        Europe,
        [JsonEnumValue("RU")]
        Russia,
        [JsonEnumValue("CIS")]
        CIS,
        [JsonEnumValue("CH")]
        China,
        [JsonEnumValue("LAN/LAS")]
        LatinAmerica,
        [JsonEnumValue("LA1", "LAN")]
        LatinAmericaNorth,
        [JsonEnumValue("LA2", "LAS")]
        LatinAmericaSouth,
        [JsonEnumValue("SEA", "GPL")]
        Garena,
        [JsonEnumValue("KR")]
        Korea,
        [JsonEnumValue("BR")]
        Brazil,
        [JsonEnumValue("TR")]
        Turkey,
        [JsonEnumValue("OC1", "OCE")]
        Oceania,
        [JsonEnumValue("JP")]
        Japan,
        [JsonEnumValue("VN")]
        Vietnam,
        [JsonEnumValue("LMS")]
        LolMasterSeries,
        [JsonEnumValue("PCS")]
        PacificChampionshipSeries
    }

    public enum SummonerIconRarityValue
    {
        Ultimate = 5,
        Mythic = 4,
        Legendary = 3,
        Epic = 2,
        Rare = 1,
        None = 0
    }

    [JsonEnum, JsonConverter(typeof(JsonEnumConverter))]
    public enum LeagueChallengeRank
    {
        [JsonEnumValue("IRON")]
        Iron,
        [JsonEnumValue("BRONZE")]
        Bronze,
        [JsonEnumValue("SILVER")]
        Silver,
        [JsonEnumValue("GOLD")]
        Gold,
        [JsonEnumValue("PLATINUM")]
        Platinum,
        [JsonEnumValue("DIAMOND")]
        Diamond,
        [JsonEnumValue("MASTER")]
        Master,
        [JsonEnumValue("GRANDMASTER")]
        Grandmaster,
        [JsonEnumValue("CHALLENGER")]
        Challenger
    }

    [JsonEnum, JsonConverter(typeof(JsonEnumConverter))]
    public enum LeagueChallengeSource
    {
        [JsonEnumValue("CHALLENGES")]
        Challenges,
        [JsonEnumValue("EOGD")]
        EOGD,
        [JsonEnumValue("CAP_INVENTORY")]
        CapInventory,
        [JsonEnumValue("CLASH")]
        Clash,
        [JsonEnumValue("ETERNALS")]
        Eternals,
        [JsonEnumValue("SUMMONER")]
        Summoner,
        [JsonEnumValue("RANKED")]
        Ranked
    }

    [JsonEnum, JsonConverter(typeof(JsonEnumConverter))]
    public enum ChallengeValueMapping
    {
        [JsonEnumValue("tierNames")]
        TierNames
    }

    [JsonEnum, JsonConverter(typeof(JsonEnumConverter))]
    public enum ChallengeCategory
    {
        [JsonEnumValue("TITLE")]
        Title
    }

    [JsonEnum, JsonConverter(typeof(JsonEnumConverter))]
    public enum ChampionRole
    {
        [JsonEnumValue("mage")]
        Mage,
        [JsonEnumValue("fighter")]
        Fighter,
        [JsonEnumValue("tank")]
        Tank,
        [JsonEnumValue("assassin")]
        Assassin,
        [JsonEnumValue("support")]
        Support,
        [JsonEnumValue("marksman")]
        Marksman
    }
}
