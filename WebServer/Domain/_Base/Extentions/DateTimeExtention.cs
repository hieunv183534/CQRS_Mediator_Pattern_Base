using System;

namespace NOM.Domain._Base.Extentions
{
    public static class DateTimeExtention
    {
        public static long ToUnixEpochDate(this DateTime date)
        {
            return new DateTimeOffset(date).ToUniversalTime().ToUnixTimeSeconds();
        }

        public static string ToISOString(this DateTime time, string format = "o")
        {
            return time.ToString(format);
        }
    }
}