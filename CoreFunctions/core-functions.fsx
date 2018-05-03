
let map f opt =
    match opt with
    | None -> None
    | Some x -> Some (f x)

let retn x = Some x

let apply f opt = 
    match f, opt with
    | Some f, Some x -> Some (f x)
    | _ -> None

let bind f opt =
    match opt with
    | Some x -> f x
    | None -> None