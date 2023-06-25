using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace craftersmine.League.CommunityDragon
{
    public class SummonerIconSet
    {
        [JsonProperty("id")]
        public int Id { get; private set; }
        [JsonProperty("hidden")]
        public bool IsHidden { get; private set; }
        [JsonProperty("displayName")]
        public string DisplayName { get; private set; }
        [JsonProperty("description")]
        public string Description { get; private set; }
        [JsonProperty("icons")]
        public int[] IconIds { get; private set; }
    }
}
