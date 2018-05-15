using Xunit;

namespace Holidays.Tests
{
    public class DurationTests
    {
        [Fact]
        public void Addition()
        {
            var result = Days.NewDays(2) + Days.NewDays(4);

            Assert.Equal(Days.NewDays(6), result);
        }
    }
}