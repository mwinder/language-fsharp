using System.Linq;
using Xunit;
using Holidays.Patterns;
using NodaTime;
using static Holidays.Patterns.HolidayDate;
using static Holidays.Patterns.Hours;
using static Holidays.Patterns.PartOfDay;

namespace Holidays.Tests
{
    public class HolidayPatternsTests
    {
        [Fact]
        public void LongWeekend()
        {
            var friday = new HolidayDay(NewDate(new LocalDate(2018, 5, 11)), LastHalf);
            var monday = new HolidayDay(NewDate(new LocalDate(2018, 5, 14)), Whole);
            var tuesday = new HolidayDay(NewDate(new LocalDate(2018, 5, 15)), Whole);

            var longWeekend = new HolidayPatternRequest(new[] { friday, monday, tuesday });
        }

        [Fact]
        public void DoctorsAppointment()
        {
            var doctorsAppointment = new HolidayPatternRequest(new[]
            {
                new HolidayDay(NewDate(new LocalDate(2018, 5, 17)), NewFirstHours(NewHours(2))),
            });
        }

        [Fact]
        public void Week()
        {
            var week = HolidayDay.FromRange(new LocalDate(2018, 5, 14), new LocalDate(2018, 5, 18));
            Assert.Equal(5, week.Count());
        }

        [Fact]
        public void ThreeDays()
        {
            var threeDays = HolidayDay.DaysFrom(new LocalDate(2018, 5, 11), 3);
            Assert.Equal(3, threeDays.Count());
        }

        [Fact]
        public void WholeDay()
        {
            var wholeDay = HolidayDay.Whole(new LocalDate(2018, 5, 23));
            Assert.Equal(Whole, wholeDay.Part);
        }

        [Fact]
        public void Composite()
        {
            var composite = new[]
            {
                HolidayDay.LastHalf(new LocalDate(2018, 5, 7)),
            }.Union(HolidayDay.DaysFrom(new LocalDate(2018, 5, 8), 4));
            Assert.Equal(5, composite.Count());
        }
    }
}
