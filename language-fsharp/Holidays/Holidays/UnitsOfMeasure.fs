namespace Holidays.UnitsOfMeasure

[<Measure>]
type days

[<Measure>]
type hours

module Units =
    let add (a : int<days>) (b : int<days>) =
        a + b