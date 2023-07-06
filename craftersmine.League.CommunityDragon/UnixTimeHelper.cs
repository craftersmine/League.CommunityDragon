namespace craftersmine.League.CommunityDragon
{
    internal static class UnixTimeHelper
    {
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1);

        public static DateTime FromUnixTimeMilliseconds(this long val)
        {
            return UnixEpoch.AddMilliseconds(val);
        }

        public static DateTime FromUnixTimeSeconds(this long val)
        {
            return UnixEpoch.AddSeconds(val);
        }

        public static long ToUnixTimeSeconds(this DateTime val)
        {
            if (val == DateTime.MinValue)
                return 0;

            var delta = val - UnixEpoch;

            if (delta.TotalSeconds < 0)
                throw new ArgumentOutOfRangeException(nameof(val), val, "Invalid datetime!");

            return (long)delta.TotalSeconds;
        }

        public static long ToUnixTimeMilliseconds(this DateTime val)
        {
            if (val == DateTime.MinValue)
                return 0;

            var delta = val - UnixEpoch;

            if (delta.TotalMilliseconds < 0)
                throw new ArgumentOutOfRangeException(nameof(val), val, "Invalid datetime!");

            return (long) delta.TotalMilliseconds;
        }
    }
}
