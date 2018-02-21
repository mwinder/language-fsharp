namespace Holidays

open NodaTime

type PartOfDay = 
    | FullDay
    | HalfDay

type HolidayTime =
    | Time of LocalTime
    | Part of PartOfDay
