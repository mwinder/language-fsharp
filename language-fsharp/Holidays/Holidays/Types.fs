namespace Holidays

open System

type HolidayId = HolidayId of Guid

type HolidayId2 = Guid

type EntitlementDeducted = bool

type PublicHolidayPolicy =
    | Worked
    | NotWorked of EntitlementDeducted