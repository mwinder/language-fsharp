namespace Tests

open Xunit

type ``Tests on a class``() =
    [<Fact>]
    member m.``Example unit test``() =
        Assert.Equal(2, 1 + 1)

module ``This is an example`` =
    let [<Fact>] ``Example unit test``() =
        Assert.Equal(2, 1+1)