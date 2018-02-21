namespace Contacts.Usage

open Contacts.Types

module Program =
    [<EntryPoint>]
    let main _ =
        let validEmail = CreateEmailAddress "a@example.com"
        printfn "valid email: %A" validEmail
        let invalidEmail = CreateEmailAddress "example.com"
        printfn "invalid email: %A" invalidEmail

        let validState = CreateStateCode "CA"
        printfn "valid state: %A" validState
        let invalidState = CreateStateCode "XX"
        printfn "invalid state: %A" invalidState
 
        0 // return an integer exit code