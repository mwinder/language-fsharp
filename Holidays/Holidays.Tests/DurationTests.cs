using Xunit;

namespace Holidays.Tests
{
    public class DurationTests
    {
        [Fact]
        public void AdditionDays()
        {
            var result = Days.NewDays(2) + Days.NewDays(4);

            Assert.Equal(Days.NewDays(6), result);
        }

        [Fact]
        public void AdditionDuration()
        {
            Assert.Equal(Duration.NewHours(4), Duration.NewHours(2) + Duration.NewHours(2));
            Assert.Equal(Duration.NewDays(4), Duration.NewDays(2) + Duration.NewDays(2));
            Assert.Equal(Duration.NewHours(25), Duration.NewDays(1) + Duration.NewHours(1));
            Assert.Equal(Duration.NewHours(25), Duration.NewHours(1) + Duration.NewDays(1));
        }
    }
}