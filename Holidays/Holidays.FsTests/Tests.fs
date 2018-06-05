namespace Holidays.FsTests

open System
open Holidays
open Holidays.Events
open Holidays.Patterns
open Holidays.UnitsOfMeasure
open NodaTime
open Xunit

module DurationTests =

    [<Fact>]
    let ``addition of days`` () =
        Assert.Equal(Days(4.0), Days(2.0) + Days(2.0))

    [<Fact>]
    let ``subtraction of days`` () =
        Assert.Equal(Days(2.0), Days(4.0) - Days(2.0))

    [<Fact>]
    let ``scalar multiplication of days`` () =
        Assert.Equal(Days(4.0), Days(2.0) * 2.0)

    [<Fact>]
    let ``scalar multiplication commutative`` () =
        Assert.Equal(Days(2.0) * 2.0, 2.0 * Days(2.0))

    [<Fact>]
    let ``summation`` () =
        let total = [Days 1.0; Days 2.0; Days 3.0] |> Seq.sum
        Assert.Equal(Days 6.0, total)

module HolidayPatternsTests =

    [<Fact>]
    let ``define a week`` () =
        let week = HolidayDay.FromRange (LocalDate(2018, 5, 14)) (LocalDate(2018, 5, 18))
        Assert.Equal(5, Seq.length week)

module EventsTests =

    [<Fact>]
    let ``holiday event usage`` () =
        let requested = Requested(HolidayId (Guid "e27d4fdd-12b8-49bc-bc0e-9216cadca2f7"))

        Assert.True(true)

module UnitsOfMeasureTests =

    [<Fact>]
    let ``usage of days and hours`` () =
        Assert.Equal(4<days>, Units.add 2<days> 2<days>)

    // [<Fact>]
    // let ``cannot mix units`` () =
    //     let r = 2<days> + 24<hours>
    //     Assert.Equal(3<days>, r)
