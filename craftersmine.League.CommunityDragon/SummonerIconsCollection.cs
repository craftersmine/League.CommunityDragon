using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.League.CommunityDragon
{
    public class SummonerIconsCollection : IReadOnlyCollection<SummonerIcon>
    {
        private readonly List<SummonerIcon> _summonerIcons = new List<SummonerIcon>();

        public SummonerIcon this[int id]
        {
            get
            {
                SummonerIcon? icon = _summonerIcons.FirstOrDefault(i => i.Id == id);
                if (icon is not null) return icon;

                throw new KeyNotFoundException("Unable to find summoner icon with ID: " + id);
            }
        }

        public SummonerIcon this[string title]
        {
            get
            {
                SummonerIcon? icon = _summonerIcons.FirstOrDefault(i => i.Title == title);
                if (icon is not null) return icon;

                throw new KeyNotFoundException("Unable to find summoner icon with Title: " + title);
            }
        }

        internal SummonerIconsCollection(SummonerIcon[]? icons)
        {
            if (icons is not null)
                _summonerIcons.AddRange(icons);
        }

        public IEnumerator<SummonerIcon> GetEnumerator()
        {
            return _summonerIcons.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count => _summonerIcons.Count;
    }
}
