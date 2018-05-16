namespace Holidays.FsTests

open Holidays
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

module HolidayPatternsTests =

    [<Fact>]
    let ``define a week`` () =
        let week = HolidayDay.FromRange (LocalDate(2018, 5, 14)) (LocalDate(2018, 5, 18))
        Assert.Equal(5, Seq.length week)

module UnitsOfMeasureTests =

    [<Fact>]
    let ``usage of days and hours`` () =
        Assert.Equal(4<days>, Units.add 2<days> 2<days>)

    // [<Fact>]
    // let ``cannot mix units`` () =
    //     let r = 2<days> + 24<hours>
    //     Assert.Equal(3<days>, r)
