﻿namespace Holidays

//type Duration =
//    | Days of double
//    | Hours of double
//with
//    static member (+) (a, b) =
//        match a b with
//            | (Days x) (Days y) -> Days(a + b)

type Days = Days of double
with
    static member (+) (a : Days, b : Days) =
        match a, b with | Days a, Days b -> Days(a + b) 