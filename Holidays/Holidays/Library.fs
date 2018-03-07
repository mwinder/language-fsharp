namespace Holidays

open NodaTime

type StartTime =
    | Start
    | Middle
    | Time of LocalTime

type EndTime =
    | Middle
    | End
    | Time of LocalTime

type HolidayStart = {
    Date: LocalDate
    Time: StartTime
}

type HolidayEnd = {
    Date: LocalDate
    Time: EndTime
}

type Holiday = {
    Start: LocalDate * StartTime
    End: LocalDate * EndTime
}

type Holiday2 = {
    Start: HolidayStart
    End: HolidayEnd
}