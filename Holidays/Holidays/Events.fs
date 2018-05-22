namespace Holidays

//module Events =
    type HolidayEvent =
        | Requested of HolidayId
        | Approved of HolidayId
        | Declined of HolidayId
        | Cancelled of HolidayId