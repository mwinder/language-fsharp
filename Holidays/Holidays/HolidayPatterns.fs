namespace Holidays.Patterns

open NodaTime

module Dates =
    let from (a:LocalDate) days =
        [0..days-1] |> Seq.map (a.PlusDays)

    let private rangeMutableWhile (a) (b:LocalDate) =
        seq {
            let mutable d = a
            while d <= b do
                yield d
                d <- d.PlusDays 1
        }

    let private rangeUnfold a (b:LocalDate) =
        Seq.unfold (fun d -> if d <= b then Some(d, d.PlusDays(1)) else None) a

    let private rangeSeqInfinite (a:LocalDate) b =
        Seq.initInfinite int |> Seq.map (a.PlusDays) |> Seq.takeWhile (fun d -> d <= b)

    let private rangeDiff a b =
        let (-) (x:LocalDate) (y:LocalDate) = LocalDate.Subtract (x, y)
        let days = (b-a).Days + 1
        from a days

    let rec private rangeRecursive (a:LocalDate) (b:LocalDate) =
        seq {
            if a <= b then
                yield a
                yield! rangeRecursive (a.PlusDays(1)) b
        }

    let range = rangeSeqInfinite


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

type HolidayDate = Date of LocalDate with
    static member (+) (d:LocalDate, Date wrapper) = d.PlusDays
    static member Zero = Date LocalDate.MinIsoValue

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
