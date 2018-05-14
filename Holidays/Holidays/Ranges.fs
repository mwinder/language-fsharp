namespace Holidays.Ranges

open System
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

//type Holiday = {
//    Start: LocalDate * StartTime
//    End: LocalDate * EndTime
//}

type HolidayId = HolidayId of Guid

type HolidayId2 = Guid

type HolidayNotes = string

type HolidayRequest = {
    Id: HolidayId
    Start: HolidayStart
    End: HolidayEnd
    Notes: HolidayNotes option
}