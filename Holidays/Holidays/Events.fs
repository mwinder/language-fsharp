namespace Holidays.Events

open Holidays

type HolidayEvent =
    | Requested of HolidayId
    | Approved of HolidayId
    | Declined of HolidayId
    | Cancelled of HolidayId