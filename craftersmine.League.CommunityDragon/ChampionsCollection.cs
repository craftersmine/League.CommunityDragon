using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.League.CommunityDragon
{
    public class ChampionsCollection : IReadOnlyCollection<Champion>
    {
        private readonly List<Champion> _champions = new List<Champion>();

        public Champion this[int id]
        {
            get
            {
                Champion? champion = _champions.FirstOrDefault(i => i.Id == id);
                if (champion is not null) return champion;

                throw new KeyNotFoundException("Unable to find champion with ID: " + id);
            }
        }

        public Champion this[string alias]
        {
            get
            {
                Champion? champion = _champions.FirstOrDefault(i => i.Alias.Trim() == alias);
                if (champion is not null) return champion;

                throw new KeyNotFoundException("Unable to find champion with Alias: " + alias);
            }
        }

        internal ChampionsCollection(Champion[]? icons)
        {
            if (icons is not null)
                _champions.AddRange(icons);
        }

        public IEnumerator<Champion> GetEnumerator()
        {
            return _champions.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count => _champions.Count;
    }
}
