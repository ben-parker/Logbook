using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logbook.Models;

namespace Logbook.Services
{
    public static class ICalConvert
    {
        public static ICalFrequency Frequency(string[] sections)
        {
            var text = sections.Where(s => s.Contains("FREQ=")).FirstOrDefault();
            if (text is null) return null;

            text = text.Substring(5);

            if (text.Equals(ICalFrequency.Daily.ToString())) return ICalFrequency.Daily;
            else if (text.Equals(ICalFrequency.Weekly.ToString())) return ICalFrequency.Weekly;
            else if (text.Equals(ICalFrequency.Monthly.ToString())) return ICalFrequency.Monthly;
            else if (text.Equals(ICalFrequency.Yearly.ToString())) return ICalFrequency.Yearly;
            else throw new ArgumentException($"Frequency {text} is not valid", text);
        }

        public static int? Interval(string[] sections)
        {
            var text = sections.Where(s => s.Contains("INTERVAL=")).FirstOrDefault();
            if (text is null) return null;

            text = text.Substring(9);

            if (int.TryParse(text, out int num))
            {
                return num;
            }
            else
            {
                throw new FormatException($"Interval \"{text}\" is not a number");
            }
        }

        public static int? Count(string[] sections)
        {
            var text = sections.Where(s => s.Contains("COUNT=")).FirstOrDefault();
            if (text is null) return null;

            text = text.Substring(6);

            if (int.TryParse(text, out int num))
            {
                return num;
            }
            else
            {
                throw new FormatException($"Count \"{text}\" is not a number");
            }
        }

        public static List<DayOfWeek> ByDay(string[] sections)
        {
            var text = sections.Where(s => s.Contains("BYDAY=")).FirstOrDefault();
            if (text is null) return null;

            SortedDictionary<string, int> days = new SortedDictionary<string, int>
            {
                { "FR", 5 },
                { "MO", 1 },
                { "SA", 6 },
                { "SU", 0 },
                { "TH", 4 },
                { "TU", 2 },
                { "WE", 3 }
            };

            text = text.Substring(6);
            List<DayOfWeek> result = text.Split(",").Select(d =>
            {
                if (days.TryGetValue(d, out int num))
                {
                    return (DayOfWeek)num;
                }
                else
                {
                    throw new ArgumentOutOfRangeException($"Day \"{d}\" is not a valid day of the week");
                }
            })
            .ToList();

            return result;
        }

        public static List<Month> ByMonth(string[] sections)
        {
            var text = sections.Where(s => s.Contains("BYMONTH=")).FirstOrDefault();
            if (text is null) return null;

            text = text.Substring(8);
            List<Month> results = text.Split(",").Select(i =>
            {
                if (Enum.IsDefined(typeof(Month), i))
                {
                    return (Month)Enum.Parse(typeof(Month), i);
                }
                else
                {
                    throw new ArgumentException($"Month {i} is not a valid month");
                }
            })
            .ToList();

            return results;
        }

        public static List<int> ByMonthDay(string[] sections)
        {
            var text = sections.Where(s => s.Contains("BYMONTHDAY=")).FirstOrDefault();
            if (text is null) return null;

            text = text.Substring(11);
            List<int> results = text.Split(",").Select(i =>
            {
                if (int.TryParse(text, out int num))
                {
                    if (num < 1 || num > 31)
                    {
                        throw new ArgumentOutOfRangeException($"Number \"{text}\" is not a valid month day");
                    }
                    else return num;
                }
                else
                {
                    throw new FormatException($"Month Day \"{text}\" is not a number");
                }
            })
            .ToList();

            return results;
        }
    }
}
