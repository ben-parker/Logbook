using System;
using Xunit;
using Logbook.Models;
using System.Collections.Generic;
using System.Linq;

namespace LogbookUnitTests
{
    public class RecurrenceShould
    {
        private Recurrence _recurrence;

        public RecurrenceShould()
        {
            _recurrence = new Recurrence();
        }

        [Fact]
        public void ParseSingleWeekday()
        {
            string recurString = "FREQ=MONTHLY;BYDAY=TU";

            _recurrence.RecurString = recurString;

            Assert.True(_recurrence.DaysOfWeek.SequenceEqual(new List<DayOfWeek> { DayOfWeek.Tuesday }));
        }

        [Fact]
        public void ParseMultipleWeekdays()
        {
            string recurString = "FREQ=MONTHLY;BYDAY=TU,TH";

            _recurrence.RecurString = recurString;

            Assert.True(_recurrence.DaysOfWeek.SequenceEqual(new List<DayOfWeek> { DayOfWeek.Tuesday, DayOfWeek.Thursday }));
        }

        [Fact]
        public void ParseBadWeekday()
        {
            string recurString = "FREQ=MONTHLY;BYDAY=FA,TH";



            Assert.Throws<ArgumentOutOfRangeException>(() => _recurrence.RecurString = recurString);
        }

        [Fact]
        public void ParseFrequency()
        {
            string recurString = "FREQ=YEARLY;BYDAY=TU,TH";
            _recurrence.RecurString = recurString;

            Assert.True(_recurrence.Frequency == ICalFrequency.Yearly);
        }

        [Fact]
        public void ParseIncorrectFrequency()
        {
            string recurString = "FREQ=WRONG;BYDAY=TU,TH";

            Assert.Throws<ArgumentException>(() => _recurrence.RecurString = recurString);
        }

        [Fact]
        public void ParseWrongInterval()
        {
            string recurString = "INTERVAL=stupid";
            Assert.Throws<FormatException>(() => _recurrence.RecurString = recurString);
        }

        [Fact]
        public void ParseComplexString()
        {
            string recurString = "FREQ=MONTHLY;BYDAY=FR,SA;INTERVAL=2";

            _recurrence.RecurString = recurString;

            Assert.True(_recurrence.DaysOfWeek.SequenceEqual(new List<DayOfWeek> { DayOfWeek.Friday, DayOfWeek.Saturday }));
            Assert.True(_recurrence.Frequency == ICalFrequency.Monthly);
            Assert.True(_recurrence.Interval == 2);
        }

        [Fact]
        public void WriteCorrectICalString()
        {
            _recurrence = new Recurrence
            {
                DaysOfWeek = new List<DayOfWeek> { DayOfWeek.Friday, DayOfWeek.Saturday },
                Frequency = ICalFrequency.Monthly,
                MonthDay = new List<int> { 5, 15, 25 },
                Interval = 2,
                Count = 10,
                Month = new List<Month> { Month.January, Month.June }
            };

            var recurString = _recurrence.RecurString;

            Assert.Equal("FREQ=MONTHLY;INTERVAL=2;COUNT=10;BYDAY=FR,SA;BYMONTH=1,6;BYMONTHDAY=5,15,25", recurString);
        }

        [Fact]
        public void ReturnEmptyIfNoRecurrence()
        {
            _recurrence = new Recurrence();

            Assert.Equal(String.Empty, _recurrence.RecurString);
        }
    }
}
