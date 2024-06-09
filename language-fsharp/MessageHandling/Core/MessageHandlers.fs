namespace CoreLibrary

open System

type MessageHandlers =

    static member Handle(command : RegisterUser) =
        Console.WriteLine("Registered: {0}", command)
        Console.WriteLine("Do something else")

    static member Handle(command : DeactivateUser) =
        Console.WriteLine("Deactivated: {0}", command)

    static member Handle(command : OpenAccount) =
        Console.WriteLine("OpenedAccount: {0}", command)