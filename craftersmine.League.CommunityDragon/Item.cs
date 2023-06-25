using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace craftersmine.League.CommunityDragon
{
    public class Item
    {
        [JsonProperty("id")]
        public int Id { get; private set; }
        [JsonProperty("price")]
        public int Price { get; private set; }
        [JsonProperty("priceTotal")]
        public int PriceTotal { get; private set; }
        [JsonProperty("maxStacks")]
        public int MaxStacks { get; private set; }
        [JsonProperty("requiredBuffCurrencyCost")]
        public int RequiredBuffCurrencyCost { get; private set; }
        [JsonProperty("from")]
        public int[] CraftableFromItemIds { get; private set; }
        [JsonProperty("to")]
        public int[] CraftedToItemIds { get; private set; }
        [JsonProperty("specialRecipe")]
        public int SpecialRecipeItemId { get; private set; }
        [JsonProperty("name")]
        public string Name { get; private set; }
        [JsonProperty("description")]
        public string Description { get; private set; }
        [JsonProperty("requiredChampion")]
        public string RequiredChampion { get; private set; }
        [JsonProperty("requiredAlly")]
        public string RequiredAlly { get; private set; }
        [JsonProperty("requiredBuffCurrencyName")]
        public string RequiredBuffCurrencyName { get; private set; }
        [JsonProperty("categories")]
        public ItemCategory[] Categories { get; private set; }
        [JsonProperty("active")]
        public bool Active { get; private set; }
        [JsonProperty("inStore")]
        public bool InStore { get; private set; }
        [JsonProperty("isEnchantment")]
        public bool IsEnchantment { get; private set; }

        [JsonProperty("iconPath")]
        internal string IconPath { get; private set; }
    }

    [JsonEnum]
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
        MagicResist
    }
}
