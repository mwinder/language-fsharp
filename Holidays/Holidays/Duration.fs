﻿namespace Holidays

type Duration =
    | Days of double
    | Hours of double
with
    static member (+) (a, b) =
        match a, b with
            | (Days a, Days b) -> Days(a + b)
            | (Hours a, Hours b) -> Hours(a + b)
            | (Days a, Hours b) -> Hours(24.0*a + b)
            | (Hours a, Days b) -> Hours(a + 24.0*b)

type Days = Days of double with
    static member (+) (Days a, Days b) = Days(a + b)
    static member (-) (Days a, Days b) = Days(a - b)
    static member (*) (Days a, s) = Days(a * s)
    static member (*) (s, Days a) = Days(a * s)
    static member Zero = Days 0.0
    static member create(d) =
        if (d < 0.0) then failwith "Days cannot be negative"
        else Days d

type Hours = Hours of double with
    static member (+) (Hours a, Hours b) = Hours(a + b)
    static member (-) (Hours a, Hours b) = Hours(a - b)
