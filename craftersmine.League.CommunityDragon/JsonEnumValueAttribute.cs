using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.League.CommunityDragon
{
    internal class JsonEnumValueAttribute : Attribute
    {
        public string Value;

        public JsonEnumValueAttribute(string value)
        {
            Value = value;
        }
    }
}
