namespace CoreLibrary

type Command = interface end

type RegisterUser(name : string, password : string) =
    interface Command
    member m.Name = name
    member m.Password = password
    override this.ToString() = name

type DeactivateUser(name : string) =
    interface Command
    member private this.Name = name
    override this.ToString() = name

type OpenAccount(number) = 
    interface Command
    member private m.Number = number
    override this.ToString() = number