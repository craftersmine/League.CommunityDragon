using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.League.CommunityDragon
{
    public class LeagueChallengesCollection : IReadOnlyCollection<LeagueChallenge>
    {
        private readonly Dictionary<int, LeagueChallenge> _leagueChallenges = new Dictionary<int, LeagueChallenge>();

        public LeagueChallenge this[int id]
        {
            get
            {
                if (_leagueChallenges.ContainsKey(id))
                    return _leagueChallenges[id];

                throw new KeyNotFoundException("Unable to find challenge with ID: " + id);
            }
        }

        internal LeagueChallengesCollection(Dictionary<string, LeagueChallenge> challenges)
        {
            Dictionary<int, LeagueChallenge> c = new Dictionary<int, LeagueChallenge>();
            foreach (System.Collections.Generic.KeyValuePair<string, LeagueChallenge> challenge in challenges)
            {
                _leagueChallenges.Add(int.Parse(challenge.Key), challenge.Value);
            }
        }

        internal LeagueChallengesCollection(Dictionary<int, LeagueChallenge> leagueChallenges)
        {
            _leagueChallenges = leagueChallenges;
        }

        public IEnumerator<LeagueChallenge> GetEnumerator()
        {
            return _leagueChallenges.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count => _leagueChallenges.Count;
    }
}
