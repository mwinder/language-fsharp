namespace Holidays.FsTests

open Holidays
open Holidays.Patterns
open NodaTime
open Xunit

module DurationTests =

    [<Fact>]
    let ``addition of days`` () =
        Assert.Equal(Days(4.0), Days(2.0) + Days(2.0))

    [<Fact>]
    let ``subtraction of days`` () =
        Assert.Equal(Days(2.0), Days(4.0) - Days(2.0))

module HolidayPatternsTests =

    [<Fact>]
    let ``define a week`` () =
        let week = HolidayDay.FromRange (LocalDate(2018, 5, 14)) (LocalDate(2018, 5, 18))
        Assert.Equal(5, Seq.length week)