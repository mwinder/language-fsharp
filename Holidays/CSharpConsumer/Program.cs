using System;
using System.Collections.Generic;
using Holidays;
using Holidays.Ranges;
using Newtonsoft.Json;
using NodaTime;
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

            var holidayRequestTimed = new HolidayRequest(
                holidayId2,
                new HolidayStart(new LocalDate(2018, 03, 01), StartTime.NewTime(new LocalTime(9, 00))),
                new HolidayEnd(new LocalDate(2018, 03, 1), EndTime.NewTime(new LocalTime(17, 00))),
                None);

            ToString(holiday);
            ToString(holidayRequestTimed);

            Serialisation(holiday);
            Serialisation(holidayRequestTimed);


            var vacationId1 = new VacationId(new Guid("5d82b0a8-81cb-4bd2-8051-33b75a88f781"));
            var vacationId2 = new VacationId(new Guid("5d82b0a8-81cb-4bd2-8051-33b75a88f781"));
            Equality(vacationId1, vacationId2);
        }

        private static void Equality(HolidayId a, HolidayId b)
        {
            Console.WriteLine("HolidayId equality...");
            Console.WriteLine($"== -> {a == b}");
            Console.WriteLine($".Equals -> {a.Equals(b)}");

            HolidayId holidayIdNull = null;
            Console.WriteLine($"== null -> {a == holidayIdNull}");
            Console.WriteLine($"null == -> {holidayIdNull == a}");
            Console.WriteLine($".Equals(null) -> {a.Equals(holidayIdNull)}");
            //Console.WriteLine($"{holidayIdNull.Equals(a)}");

            Console.WriteLine();
        }

        private static void ToString(HolidayRequest holiday)
        {
            Console.WriteLine("HolidayRequest ToString...");
            Console.WriteLine(holiday);

            Console.WriteLine();
        }

        private static void Serialisation(HolidayRequest holiday)
        {
            Console.WriteLine("HolidayRequest serialisation...");
            var settings = new JsonSerializerSettings().ConfigureForNodaTime(DateTimeZoneProviders.Tzdb);
            Console.WriteLine(JsonConvert.SerializeObject(holiday, Formatting.Indented, settings));

            Console.WriteLine();
        }

        private static void Equality(VacationId a, VacationId b)
        {
            Console.WriteLine("VacationId equality...");
            Console.WriteLine(a.Equals(b));
            Console.WriteLine(a == b);

            Console.WriteLine();
        }
    }

    public class VacationId : IEquatable<VacationId>
    {
        private readonly Guid _value;

        public VacationId(Guid value) => _value = value;

        public override bool Equals(object obj) => Equals(obj as VacationId);

        public bool Equals(VacationId other) => (other != null) && _value == other._value;

        public override int GetHashCode()
        {
            return -1939223833 + EqualityComparer<Guid>.Default.GetHashCode(_value);
        }
    }
}
