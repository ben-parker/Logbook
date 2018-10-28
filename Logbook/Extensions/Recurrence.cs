using Logbook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logbook.Extensions
{
    public static class Recurrence
    {
        public static DateTime? GetNext(Tracked t)
        {
            if (!t.IsRecurring) return null;


        }

        public static List<DateTime> Get(Tracked t, 
        {

        }

        public static List<DateTime> GetOccurrences(Tracked t, DateTime begin, DateTime end)
        {
            if (begin > end)
            {
                throw new ArgumentException("Begin date must be earlier than end date");
            }

            if (t is null) return null;

            var count = t.Recurrence.Count;
            var interval = t.Recurrence.Interval;
            var freq = t.Recurrence.Frequency;

            int numDays = end.DayOfYear - begin.DayOfYear;
            numDays = (numDays < 0) ? 365 - Math.Abs(numDays) : numDays;
            numDays = numDays + 1;

            if (t.Recurrence.DaysOfWeek != null)
            {
                DateTime.
            }
        }
    }
}
