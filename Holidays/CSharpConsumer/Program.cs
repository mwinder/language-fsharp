using Holidays;
using NodaTime;
using System;
using Newtonsoft.Json;
using NodaTime.Serialization.JsonNet;
using static Holidays.HolidayId;
using static Microsoft.FSharp.Core.FSharpOption<string>;

namespace CSharpConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var holidayId1 = NewHolidayId(new Guid("973e16ed-71de-4609-a631-d19918f3e2ea"));

            var holidayId2 = NewHolidayId(new Guid("973e16ed-71de-4609-a631-d19918f3e2ea"));

            Equality(holidayId1, holidayId2);

            var holiday = new HolidayRequest(
                holidayId1,
                new HolidayStart(new LocalDate(2018, 03, 01), StartTime.Start),
                new HolidayEnd(new LocalDate(2018, 03, 1), EndTime.End),
                None);

            Console.WriteLine(holiday);

            var holidayRequestTimed = new HolidayRequest(
                holidayId2,
                new HolidayStart(new LocalDate(2018, 03, 01), StartTime.NewTime(new LocalTime(9, 00))),
                new HolidayEnd(new LocalDate(2018, 03, 1), EndTime.NewTime(new LocalTime(17, 00))),
                None);

            Console.WriteLine(holidayRequestTimed);

            Serialisation(holiday);
            Serialisation(holidayRequestTimed);
        }

        private static void Equality(HolidayId holidayId1, HolidayId holidayId2)
        {
            Console.WriteLine(holidayId1 == holidayId2);
            Console.WriteLine(holidayId1.Equals(holidayId2));

            HolidayId holidayIdNull = null;
            Console.WriteLine(holidayId1 == holidayIdNull);
            Console.WriteLine(holidayIdNull == holidayId1);
            Console.WriteLine(holidayId1.Equals(holidayIdNull));
            //Console.WriteLine(holidayIdNull.Equals(holidayId1)); Fails
        }

        private static void Serialisation(HolidayRequest holiday)
        {
            var settings = new JsonSerializerSettings().ConfigureForNodaTime(DateTimeZoneProviders.Tzdb);
            Console.WriteLine(JsonConvert.SerializeObject(holiday, Formatting.Indented, settings));
        }
    }
}
