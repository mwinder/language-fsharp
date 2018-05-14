namespace Holidays.Patterns

open NodaTime
open Holidays

type TimePeriod = {
    Start: LocalTime
    End: LocalTime
}

type Hours = Hours of int

type PartOfDay =
    | Whole
    | FirstHalf
    | LastHalf
    | FirstHours of Hours
    | LastHours of Hours
    | TimePeriod

type HolidayDay = {
    Date: LocalDate
    Part: PartOfDay
} with
    static member Whole a = { Date = a; Part = Whole }

    static member FirstHalf a = { Date = a; Part = FirstHalf }

    static member LastHalf a = { Date = a; Part = LastHalf }

    static member FromRange a b = Dates.range a b |> Seq.map HolidayDay.Whole

    static member DaysFrom a days = Dates.from a days |> Seq.map HolidayDay.Whole

type HolidayPatternRequest = {
    Days: HolidayDay seq
}
