namespace Contacts.Usage

open Contacts
open Contacts.Types

module Program =

    [<EntryPoint>]
    let main _ =
        let validEmail = EmailAddress.create "a@example.com"
        printfn "valid email: %A" validEmail
        let invalidEmail = EmailAddress.create "example.com"
        printfn "invalid email: %A" invalidEmail

        let createdEmail = EmailAddress.create2 "example.com"
        printfn "created email: %A" createdEmail

        let validState = CreateStateCode "CA"
        printfn "valid state: %A" validState
        let invalidState = CreateStateCode "XX"
        printfn "invalid state: %A" invalidState
 
        0 // return an integer exit code