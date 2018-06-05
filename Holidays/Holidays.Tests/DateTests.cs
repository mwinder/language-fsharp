using System;
using System.Linq;
using NodaTime;
using Xunit;

namespace Holidays.Tests
{
    public static class DateTests
    {
        [Fact]
        public static void RangeDt()
        {
            var result = Dates.rangeDt(new DateTime(2018, 5, 14), new DateTime(2018, 5, 18));

            Assert.Equal(5, result.Count());
        }

        [Fact]
        public static void RangeDays()
        {
            var result = Dates.rangeDays(new LocalDate(2018, 5, 14), new LocalDate(2018, 5, 18));

            Assert.Equal(5, result.Count());
            Assert.Equal(new[]
            {
                new LocalDate(2018, 5, 14), 
                new LocalDate(2018, 5, 15), 
                new LocalDate(2018, 5, 16), 
                new LocalDate(2018, 5, 17), 
                new LocalDate(2018, 5, 18), 
            }, result);
        }

        [Fact]
        public static void YearOfWeeks()
        {
            var weeks = Dates.rangeWeeks(new LocalDate(2018, 1, 1), new LocalDate(2018, 12, 31));

            Assert.Equal(53, weeks.Count());
            Assert.Equal(new LocalDate(2018, 12, 31), weeks.Last());
        }
    }
}