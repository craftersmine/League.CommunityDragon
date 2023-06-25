using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.League.CommunityDragon
{
    public class SummonerIconSetCollection : IReadOnlyCollection<SummonerIconSet>
    {
        private readonly List<SummonerIconSet> _summonerIconSets = new List<SummonerIconSet>();

        public SummonerIconSet this[int id]
        {
            get
            {
                SummonerIconSet? iconSet = _summonerIconSets.FirstOrDefault(i => i.Id == id);
                if (iconSet is not null) return iconSet;

                throw new KeyNotFoundException("Unable to find summoner icon with ID: " + id);
            }
        }

        public SummonerIconSet this[string title]
        {
            get
            {
                SummonerIconSet? icon = _summonerIconSets.FirstOrDefault(i => i.DisplayName.Trim() == title);
                if (icon is not null) return icon;

                throw new KeyNotFoundException("Unable to find summoner icon with Title: " + title);
            }
        }

        internal SummonerIconSetCollection(SummonerIconSet[]? iconSets)
        {
            if (iconSets is not null)
                _summonerIconSets.AddRange(iconSets);
        }

        public IEnumerator<SummonerIconSet> GetEnumerator()
        {
            return _summonerIconSets.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count => _summonerIconSets.Count;
    }
}
