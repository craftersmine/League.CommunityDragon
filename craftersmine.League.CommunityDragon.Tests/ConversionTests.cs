using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace craftersmine.League.CommunityDragon.Tests
{
    [TestClass]
    public class ConversionTests
    {
        public const string itemJson =
            "{\r\n    \"id\": 7026,\r\n    \"name\": \" The Unspoken Parasite\",\r\n    \"description\": \"<mainText><stats><ornnBonus> 550</ornnBonus> Health<br><ornnBonus> 40</ornnBonus> Armor<br><ornnBonus> 40</ornnBonus> Magic Resist<br><ornnBonus> 25</ornnBonus> Ability Haste</stats><br><li><passive>Voidborn Resilience:</passive> For each second in champion combat gain a stack granting <scaleArmor>Armor</scaleArmor> and <scaleMR>Magic Resist</scaleMR>, up to 8 stacks max. At max stacks become empowered, instantly draining enemies around you for magic damage, healing yourself, and increasing your bonus resist until end of combat.<br><br><rarityMythic>Mythic Passive:</rarityMythic> Grants all other <rarityLegendary>Legendary</rarityLegendary> items <attention>  Armor and  Magic Resist</attention>.</mainText><br>\",\r\n    \"active\": false,\r\n    \"inStore\": false,\r\n    \"from\": [6665],\r\n    \"to\": [],\r\n    \"categories\": [\r\n      \"Health\",\r\n      \"SpellBlock\",\r\n      \"Armor\",\r\n      \"CooldownReduction\",\r\n      \"MagicResist\",\r\n      \"AbilityHaste\"\r\n    ],\r\n    \"maxStacks\": 1,\r\n    \"requiredChampion\": \"\",\r\n    \"requiredAlly\": \"Ornn\",\r\n    \"requiredBuffCurrencyName\": \"\",\r\n    \"requiredBuffCurrencyCost\": 0,\r\n    \"specialRecipe\": 0,\r\n    \"isEnchantment\": false,\r\n    \"price\": 0,\r\n    \"priceTotal\": 3200,\r\n    \"iconPath\": \"/lol-game-data/assets/ASSETS/Items/Icons2D/6665_Tank_T4_JakShoTheProtean.png\"\r\n  }";

        [TestMethod]
        public void EnumConversionTest()
        {
            string[] values = new[] { "Damage", "Active", "Test" };
            ItemCategory[] categories = new ItemCategory[] { ItemCategory.Damage , ItemCategory.Active };

            for (int i = 0; i < values.Length; i++)
            {
                try
                {
                    Assert.IsTrue(values[i].ParseJsonEnumValue<ItemCategory>() == categories[i], values[i] + " found in enum!");
                }
                catch (Exception exception)
                {
                    Assert.IsTrue(values[i] == values[^1], "Value Test not found!");
                }
            }
        }

        [TestMethod]
        public void ItemJsonConvertionTest()
        {
            Item? item = JsonConvert.DeserializeObject<Item>(itemJson);

            Assert.IsNotNull(item);

            Assert.AreEqual(item.Id, 7026);
            Assert.AreEqual(item.Name, " The Unspoken Parasite");
            Assert.AreEqual(item.Description, "<mainText><stats><ornnBonus> 550</ornnBonus> Health<br><ornnBonus> 40</ornnBonus> Armor<br><ornnBonus> 40</ornnBonus> Magic Resist<br><ornnBonus> 25</ornnBonus> Ability Haste</stats><br><li><passive>Voidborn Resilience:</passive> For each second in champion combat gain a stack granting <scaleArmor>Armor</scaleArmor> and <scaleMR>Magic Resist</scaleMR>, up to 8 stacks max. At max stacks become empowered, instantly draining enemies around you for magic damage, healing yourself, and increasing your bonus resist until end of combat.<br><br><rarityMythic>Mythic Passive:</rarityMythic> Grants all other <rarityLegendary>Legendary</rarityLegendary> items <attention>  Armor and  Magic Resist</attention>.</mainText><br>");
            Assert.IsFalse(item.Active);
            Assert.IsFalse(item.InStore);
            Assert.IsTrue(item.CraftableFromItemIds.Contains(6665));
            Assert.IsFalse(item.CraftedToItemIds.Any());
            Assert.IsTrue(item.Categories.Any());
            Assert.IsTrue(item.Categories.Contains(ItemCategory.AbilityHaste));
            Assert.AreEqual(item.MaxStacks, 1);
            Assert.AreEqual(item.RequiredChampion, string.Empty);
            Assert.AreEqual(item.RequiredAlly, "Ornn");
            Assert.AreEqual(item.RequiredBuffCurrencyName, string.Empty);
            Assert.AreEqual(item.RequiredBuffCurrencyCost, 0);
            Assert.AreEqual(item.SpecialRecipeItemId, 0);
            Assert.IsFalse(item.IsEnchantment);
            Assert.AreEqual(item.Price, 0);
            Assert.AreEqual(item.PriceTotal, 3200);
        }
    }
}
