using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.League.CommunityDragon
{
    internal class JsonEnumValueAttribute : Attribute
    {
        public string DefaultValue;
        public string[] Values;

        public JsonEnumValueAttribute(string defaultValue, params string[] values)
        {
            DefaultValue = defaultValue;
            var vals = new List<string>();
            vals.Add(defaultValue);
            vals.AddRange(values);
            Values = vals.ToArray();
        }
    }
}
