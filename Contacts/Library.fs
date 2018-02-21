namespace Contacts

open System.Text.RegularExpressions

type CreationResult<'T> = Success of 'T | Error of string
    
module EmailAddress =
    
    type T = EmailAddress of string

    let create (s:string) =
        if System.Text.RegularExpressions.Regex.IsMatch(s,@"^\S+@\S+\.\S+$") 
            then Some (EmailAddress s)
            else None

    let create2 (s:string) = 
        if System.Text.RegularExpressions.Regex.IsMatch(s,@"^\S+@\S+\.\S+$") 
            then Success (EmailAddress s)
            else Error "Email address must contain an @ sign"

    let createWithContinuations success failure (s:string) = 
        if Regex.IsMatch(s,@"^\S+@\S+\.\S+$") 
            then success (EmailAddress s)
            else failure "Email address must contain an @ sign"

module Types =

    type PersonalName = {
        FirstName: string;
        MiddleInitial: string option;
        LastName: string;
    }    

    type EmailContactInfo = {
        EmailAddress: EmailAddress.T;
        IsEmailVerified: bool;
    }

    type StateCode = StateCode of string

    let CreateStateCode (s:string) = 
        let s' = s.ToUpper()
        let stateCodes = ["AZ";"CA";"NY"] //etc
        if stateCodes |> List.exists ((=) s')
            then Some (StateCode s')
            else None

    type ZipCode = ZipCode of string

    type PostalAddress = {
        Address1: string;
        Address2: string;
        City: string;
        State: StateCode;
        Zip: ZipCode;
    }

    type PostalContactInfo = {
        Address: PostalAddress;
        IsAddressValid: bool;
    }

    type Contact = {
        Name: PersonalName;
        EmailContactInfo: EmailContactInfo;
        PostalContactInfo: PostalContactInfo;
    }