using System;
using System.Collections.Generic;
using System.Linq;
using Logbook.Services;

namespace Logbook.Models
{
    public class Recurrence
    {
        public int? Interval { get; set; }
        public ICalFrequency Frequency { get; set; }
        public int? Count { get; set; }
        public List<Month> Month { get; set; }
        public List<int> MonthDay { get; set; }
        public List<DayOfWeek> DaysOfWeek { get; set; }

        public string RecurString
        {
            get
            {
                string result = "";

                if (this.Frequency != null) result += $"FREQ={this.Frequency};";
                if (this.Interval != null) result += $"INTERVAL={this.Interval};";
                if (this.Count != null) result += $"COUNT={this.Count};";
                if (this.DaysOfWeek != null) result += $"BYDAY={ConvertToIcalDays(this.DaysOfWeek)};";
                if (this.Month != null) result += $"BYMONTH={string.Join(",", Month.Select(m => (int)m))};";
                if (this.MonthDay != null) result += $"BYMONTHDAY={string.Join(",", this.MonthDay)};";

                result = result.Equals(String.Empty) ? result : result.Remove(result.Length - 1);

                return result;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    return;
                }

                string[] sections = value.Split(";");

                this.Frequency = ICalConvert.Frequency(sections);
                this.Interval = ICalConvert.Interval(sections);
                this.Month = ICalConvert.ByMonth(sections);
                this.MonthDay = ICalConvert.ByMonthDay(sections);
                this.DaysOfWeek = ICalConvert.ByDay(sections);
            }
        }

        private string ConvertToIcalDays(List<DayOfWeek> daysOfWeek)
        {
            SortedDictionary<DayOfWeek, string> days = new SortedDictionary<DayOfWeek, string>
            {
                { DayOfWeek.Sunday, "SU" },
                { DayOfWeek.Monday, "MO" },
                { DayOfWeek.Tuesday, "TU" },
                { DayOfWeek.Wednesday, "WE" },
                { DayOfWeek.Thursday, "TH" },
                { DayOfWeek.Friday, "FR" },
                { DayOfWeek.Saturday, "SA" }
            };

            List<string> results = daysOfWeek.Select(day =>
            {
                if (days.TryGetValue(day, out string str))
                {
                    return str;
                }
                else
                {
                    throw new ArgumentOutOfRangeException($"Day \"{day}\" is not a valid day of the week");
                }
            })
            .ToList();

            return string.Join(",", results);
        }

        private List<DayOfWeek> ConvertToDayOfWeek(string icalDays)
        {
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

            List<DayOfWeek> result = icalDays
                .Split(",")
                .Select(d =>
                {
                    if (days.TryGetValue(d, out int day))
                    {
                        return (DayOfWeek)day;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException($"Day \"{d}\" is not a valid day of the week");
                    }
                })
                .ToList();

            return result;

        }
    }

    public sealed class ICalFrequency
    {
        private readonly string name;
        private readonly int value;

        public static readonly ICalFrequency Daily = new ICalFrequency(1, "DAILY");
        public static readonly ICalFrequency Weekly = new ICalFrequency(2, "WEEKLY");
        public static readonly ICalFrequency Monthly = new ICalFrequency(3, "MONTHLY");
        public static readonly ICalFrequency Yearly = new ICalFrequency(4, "YEARLY");

        private ICalFrequency(int value, string name)
        {
            this.name = name;
            this.value = value;
        }

        public override String ToString()
        {
            return name;
        }
    }

    public enum Month
    {
        January = 1,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }
}
