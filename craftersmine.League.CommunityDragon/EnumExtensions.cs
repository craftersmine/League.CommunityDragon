using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public static T ParseJsonEnumValue<T>(this string val) where T : Enum
        {
            foreach (var field in typeof(T).GetFields())
            {
                if (field.GetCustomAttribute(typeof(JsonEnumValueAttribute)) is JsonEnumValueAttribute attribute)
                {
                    if (attribute.Value == val)
                        return (T)field.GetValue(null);
                    else if (field.Name == val)
                        return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException("Unable to find value \"" + val + "\" for " + typeof(T).FullName + " enum", nameof(val));
        }
    }
}
