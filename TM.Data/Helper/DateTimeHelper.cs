using System;

namespace TM.Data.Helper
{
    public static class DateTimeHelper
    {
        public static DateTime DateTimeNow()
        {
            var dt = DateTime.Now;
            var dateTime = new DateTime(
                dt.Ticks - (dt.Ticks % TimeSpan.TicksPerSecond)
            );
            return dateTime;
        }
    }
}
