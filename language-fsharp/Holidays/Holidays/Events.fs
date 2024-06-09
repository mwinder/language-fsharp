namespace Holidays.Events

open Holidays

type DeclineData = {
    Reason : string
}

type HolidayEvent =
    | Requested of HolidayId
    | Approved of HolidayId
    | Declined of HolidayId * DeclineData
    | Cancelled of HolidayId