namespace CoreLibrary

type Account(name) =

    let calculateName bareName = name + "-suffix"

    let name = calculateName name

    member m.Name = name

