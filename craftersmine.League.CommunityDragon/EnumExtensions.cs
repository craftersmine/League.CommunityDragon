using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.League.CommunityDragon
{
    public static class EnumExtensions
    {
        public static string GetJsonEnumValue(this Enum value)
        {
            if (value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonEnumValueAttribute), false)[0] is JsonEnumValueAttribute attribute)
                return attribute.Value;
            return value.ToString();
        }
    }
}
